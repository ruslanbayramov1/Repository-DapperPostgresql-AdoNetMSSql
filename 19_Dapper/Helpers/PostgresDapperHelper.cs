using Dapper;
using Npgsql;

namespace _19_Dapper.Helpers;

static class PostgresDapperHelper
{
    private const string _connStr = "Server=127.0.0.1;Port=5432;Database=DapperCRUD;User Id=postgres;Password=postgres123;";
    public static void Exec(string query)
    {
        using NpgsqlConnection conn = new NpgsqlConnection(_connStr);
        conn.Query(query);
    }
    public static List<T> Read<T>(string query)
    {
        using NpgsqlConnection conn = new NpgsqlConnection(_connStr);
        List<T> datas = conn.Query<T>(query).ToList();
        return datas;
    }
    public static T ReadSingle<T>(string query)
    {
        using NpgsqlConnection conn = new NpgsqlConnection(_connStr);
        T data = conn.QuerySingle<T>(query);
        return data;
    }
}
