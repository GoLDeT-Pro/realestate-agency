using System;
using System.Data;
using MySql.Data.MySqlClient;

public class DatabaseService : IDisposable
{
    private readonly string _connectionString;

    public DatabaseService(string server, string database, string uid, string password)
    {
        _connectionString = $"Server={server};Database={database};Uid={uid};Pwd={password};Charset=utf8mb4;";
    }

    public IDbConnection GetConnection()
    {
        var connection = new MySqlConnection(_connectionString);
        connection.Open();
        return connection;
    }

    public void Dispose()
    {
    }
}