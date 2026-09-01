using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;

class Program
{
    public static void Main()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["SqlConn"].ConnectionString;

        string query = "EXEC test";

        using (SqlConnection conn = new(connectionString))
        using (SqlCommand cmd = new(query, conn))
        {
            cmd.CommandTimeout = 0;

            conn.Open();

            Stopwatch sw = Stopwatch.StartNew();
            cmd.ExecuteNonQuery();
            sw.Stop();

            Console.WriteLine($"Sorgu çalışma süresi: {sw.Elapsed.TotalSeconds} sn");
            Console.WriteLine($"(ms): {sw.ElapsedMilliseconds}");
        }

        Console.ReadLine();
    }
}