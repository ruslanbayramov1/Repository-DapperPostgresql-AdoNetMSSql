using Microsoft.Data.SqlClient;
using System.Data;

namespace _19_Dapper.Helpers;

static class SqlHelper
{
    private const string _connStr = "Server=.\\SQLEXPRESS;Database=DapperCRUD;Trusted_Connection=True;TrustServerCertificate=True";
    public static int Exec(string query)
    {
        using SqlConnection conn = new SqlConnection(_connStr);
        using SqlCommand cmd = new SqlCommand(query, conn);

        conn.Open();
        int affRow = cmd.ExecuteNonQuery();
        conn.Close();

        return affRow;
    }
    public static DataTable Read(string query)
    {
        using SqlConnection conn = new SqlConnection(_connStr);
        using SqlDataAdapter sda = new SqlDataAdapter(query, conn);
        DataTable dt = new DataTable();

        conn.Open();
        sda.Fill(dt);
        conn.Close();

        return dt;
    }
}
