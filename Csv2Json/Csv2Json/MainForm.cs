using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Text;

namespace Csv2Json
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonShowCsv_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    LoadCsvToDataGridView(openFileDialog.FileName);
                }
            }

        }

        private void buttonConvertToJson_Click(object sender, EventArgs e)
        {
            if (dataGridCsv.DataSource != null)
            {
                // Serialize directly
                textJson.Text = JsonConvert.SerializeObject(dataGridCsv.DataSource, Formatting.Indented).Replace("\\\"", "\"");
            }
            else
            {
                var rows = dataGridCsv.Rows.Cast<DataGridViewRow>()
                    .Where(r => !r.IsNewRow)
                    .Select(r => r.Cells.Cast<DataGridViewCell>()
                        .ToDictionary(
                            c => c.OwningColumn.Name,
                            c => c.Value?.ToString() ?? ""
                        ));

                textJson.Text = JsonConvert.SerializeObject(rows, Formatting.Indented).Replace("\\\"", "\"");
            }
        }

        private void buttonShowJson_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\";
                openFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                // Show dialog and verify if the user clicked OK
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Read all the text from the file and assign it to the TextBox
                        string fileContent = File.ReadAllText(openFileDialog.FileName);
                        textJson.Text = fileContent;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error reading file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

        private void buttonConvertToCsv_Click(object sender, EventArgs e)
        {
            DataTable dataTable = ConvertJsonToDataTable(textJson.Text);

            dataGridCsv.DataSource = dataTable;

            if (dataTable == null || dataTable.Rows.Count == 0)
            {
                MessageBox.Show("No data found to convert.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

        }

        private void buttonSaveCsv_Click(object sender, EventArgs e)
        {
            DataTable dataTable = ConvertJsonToDataTable(textJson.Text);
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    StringBuilder csvContent = new StringBuilder();

                    // 4. Extract headers (Columns)
                    string[] columnNames = dataTable.Columns
                        .Cast<DataColumn>()
                        .Select(column => EscapeValueCsv(column.ColumnName))
                        .ToArray();
                    csvContent.AppendLine(string.Join(",", columnNames));

                    // 5. Extract rows
                    foreach (DataRow row in dataTable.Rows)
                    {
                        string[] fields = row.ItemArray
                            .Select(field => EscapeValueCsv(field.ToString()))
                            .ToArray();
                        csvContent.AppendLine(string.Join(",", fields));
                    }

                    // 6. Write to file
                    File.WriteAllText(saveFileDialog.FileName, csvContent.ToString(), Encoding.UTF8);
                    MessageBox.Show("CSV file saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void buttonSaveJson_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    saveFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // 2. Convert the object to a formatted JSON string
                        var options = new System.Text.Json.JsonSerializerOptions { WriteIndented = true };

                        File.WriteAllText(saveFileDialog.FileName, textJson.Text);
                        MessageBox.Show("File saved successfully!");
                    }
                }
            }
        }
        private void LoadCsvToDataGridView(string filePath)
        {
            DataTable dt = new DataTable();

            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string headerLine = sr.ReadLine();
                    if (headerLine == null) return;

                    string[] headers = headerLine.Split(',');
                    foreach (string header in headers)
                    {
                        dt.Columns.Add(header.Trim());
                    }

                    while (!sr.EndOfStream)
                    {
                        string dataLine = sr.ReadLine();
                        if (string.IsNullOrWhiteSpace(dataLine)) continue;

                        string[] rows = dataLine.Split(',');

                        dt.Rows.Add(rows);
                    }
                }

                dataGridCsv.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading CSV file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable ConvertJsonToDataTable(string json)
        {
            JArray jsonArray = JArray.Parse(json);

            DataTable dataTable = new DataTable();

            if (jsonArray.Count == 0)
                return dataTable;

            // Kolonları oluştur
            IList<JToken> list = (JObject)jsonArray[0];
            for (int i = 0; i < list.Count; i++)
            {
                JProperty property = (JProperty)list[i];
                dataTable.Columns.Add(property.Name, typeof(string));
            }

            // Satırları oluştur
            foreach (JObject obj in jsonArray)
            {
                DataRow row = dataTable.NewRow();

                foreach (JProperty property in obj.Properties())
                {
                    row[property.Name] = property.Value.Type == JTokenType.Null
                        ? ""
                        : property.Value.ToString();
                }

                dataTable.Rows.Add(row);
            }

            return dataTable;
        }

        private string EscapeValueCsv(string value)
        {
            if (string.IsNullOrEmpty(value))
                return "";

            if (value.Contains(",") ||
                value.Contains("\"") ||
                value.Contains("\r") ||
                value.Contains("\n"))
            {
                return $"\"{value.Replace("\"", "\"\"")}\"";
            }

            return value;
        }

    }
}

