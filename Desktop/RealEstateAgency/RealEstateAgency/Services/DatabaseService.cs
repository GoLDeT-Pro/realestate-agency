using System;
using System.Data;
using MySql.Data.MySqlClient;

public class DatabaseService : IDisposable
{
    private readonly string _connectionString;
    private MySqlConnection _connection;

    public DatabaseService(string server, string database, string uid, string password)
    {
        _connectionString = $"Server={server};Database={database};Uid={uid};Pwd={password};Charset=utf8mb4;";
    }

    public IDbConnection GetConnection()
    {
        if (_connection == null)
            _connection = new MySqlConnection(_connectionString);
        if (_connection.State != ConnectionState.Open)
            _connection.Open();
        return _connection;
    }

    public void Dispose()
    {
        _connection?.Close();
        _connection?.Dispose();
    }
}