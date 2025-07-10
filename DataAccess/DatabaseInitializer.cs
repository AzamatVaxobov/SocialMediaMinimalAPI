using System.Data;
using Npgsql;

namespace DataAccess.DbContext;

public class DatabaseInitializer
{
    private readonly string _connectionString;

    public DatabaseInitializer(string connectionString)
    {
        _connectionString = connectionString;
    }

    // Create a PostgreSQL connection using Npgsql
    public IDbConnection CreateConnection()
    {
        return new NpgsqlConnection(_connectionString);
    }
}