using Npgsql;
using System.Data;

namespace _19_Dapper.Helpers;

class PostgresHelper
{
    private const string _connStr = "Server=127.0.0.1;Port=5432;Database=DapperCRUD;User Id=postgres;Password=postgres123;";
    public static int Exec(string query)
    {
        using NpgsqlConnection conn = new NpgsqlConnection(_connStr);
        using NpgsqlCommand cmd = new NpgsqlCommand(query, conn);

        conn.Open();
        int affRow = cmd.ExecuteNonQuery();
        conn.Close();

        return affRow;
    }
    public static DataTable Read(string query)
    {
        using NpgsqlConnection conn = new NpgsqlConnection(_connStr);
        using NpgsqlDataAdapter sda = new NpgsqlDataAdapter(query, conn);
        DataTable dt = new DataTable();

        conn.Open();
        sda.Fill(dt);
        conn.Close();

        return dt;
    }
}
