namespace Csv2Json
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            buttonSaveCsv = new Button();
            dataGridCsv = new DataGridView();
            buttonConvertToJson = new Button();
            buttonShowCsv = new Button();
            groupBox2 = new GroupBox();
            textJson = new TextBox();
            buttonSaveJson = new Button();
            buttonConvertToCsv = new Button();
            buttonShowJson = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridCsv).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(buttonSaveCsv);
            groupBox1.Controls.Add(dataGridCsv);
            groupBox1.Controls.Add(buttonConvertToJson);
            groupBox1.Controls.Add(buttonShowCsv);
            groupBox1.Location = new Point(12, 26);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(474, 536);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // buttonSaveCsv
            // 
            buttonSaveCsv.Location = new Point(265, 399);
            buttonSaveCsv.Name = "buttonSaveCsv";
            buttonSaveCsv.Size = new Size(172, 54);
            buttonSaveCsv.TabIndex = 3;
            buttonSaveCsv.Text = "Kaydet";
            buttonSaveCsv.UseVisualStyleBackColor = true;
            buttonSaveCsv.Click += buttonSaveCsv_Click;
            // 
            // dataGridCsv
            // 
            dataGridCsv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridCsv.Location = new Point(35, 140);
            dataGridCsv.Name = "dataGridCsv";
            dataGridCsv.Size = new Size(402, 235);
            dataGridCsv.TabIndex = 2;
            // 
            // buttonConvertToJson
            // 
            buttonConvertToJson.Location = new Point(35, 399);
            buttonConvertToJson.Name = "buttonConvertToJson";
            buttonConvertToJson.Size = new Size(172, 54);
            buttonConvertToJson.TabIndex = 1;
            buttonConvertToJson.Text = "Dönüştür";
            buttonConvertToJson.UseVisualStyleBackColor = true;
            buttonConvertToJson.Click += buttonConvertToJson_Click;
            // 
            // buttonShowCsv
            // 
            buttonShowCsv.Location = new Point(132, 41);
            buttonShowCsv.Name = "buttonShowCsv";
            buttonShowCsv.Size = new Size(172, 54);
            buttonShowCsv.TabIndex = 0;
            buttonShowCsv.Text = "CSV Dosyasını Seç";
            buttonShowCsv.UseVisualStyleBackColor = true;
            buttonShowCsv.Click += buttonShowCsv_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(textJson);
            groupBox2.Controls.Add(buttonSaveJson);
            groupBox2.Controls.Add(buttonConvertToCsv);
            groupBox2.Controls.Add(buttonShowJson);
            groupBox2.Location = new Point(504, 26);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(474, 536);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "groupBox2";
            // 
            // textJson
            // 
            textJson.Location = new Point(35, 140);
            textJson.Multiline = true;
            textJson.Name = "textJson";
            textJson.ScrollBars = ScrollBars.Both;
            textJson.Size = new Size(402, 235);
            textJson.TabIndex = 4;
            // 
            // buttonSaveJson
            // 
            buttonSaveJson.Location = new Point(265, 399);
            buttonSaveJson.Name = "buttonSaveJson";
            buttonSaveJson.Size = new Size(172, 54);
            buttonSaveJson.TabIndex = 3;
            buttonSaveJson.Text = "Kaydet";
            buttonSaveJson.UseVisualStyleBackColor = true;
            buttonSaveJson.Click += this.buttonSaveJson_Click;
            // 
            // buttonConvertToCsv
            // 
            buttonConvertToCsv.Location = new Point(35, 399);
            buttonConvertToCsv.Name = "buttonConvertToCsv";
            buttonConvertToCsv.Size = new Size(172, 54);
            buttonConvertToCsv.TabIndex = 1;
            buttonConvertToCsv.Text = "Dönüştür";
            buttonConvertToCsv.UseVisualStyleBackColor = true;
            buttonConvertToCsv.Click += buttonConvertToCsv_Click;
            // 
            // buttonShowJson
            // 
            buttonShowJson.Location = new Point(149, 41);
            buttonShowJson.Name = "buttonShowJson";
            buttonShowJson.Size = new Size(172, 54);
            buttonShowJson.TabIndex = 0;
            buttonShowJson.Text = "Json Dosyasını Seç";
            buttonShowJson.UseVisualStyleBackColor = true;
            buttonShowJson.Click += buttonShowJson_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(998, 588);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "MainForm";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridCsv).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        
        #endregion

        private GroupBox groupBox1;
        private Button buttonConvertToJson;
        private Button buttonShowCsv;
        private Button buttonSaveCsv;
        private DataGridView dataGridCsv;
        private GroupBox groupBox2;
        private Button buttonSaveJson;
        private Button buttonConvertToCsv;
        private Button buttonShowJson;
        private TextBox textJson;
    }
}
