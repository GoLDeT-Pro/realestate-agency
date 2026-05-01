using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Dapper;

public class UserService
{
    private readonly DatabaseService db;

    public UserService(DatabaseService databaseService) => db = databaseService;

    private string HashPassword(string password)
    {
        var sha256 = SHA256.Create();
        var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        return string.Concat(bytes.Select(b => b.ToString("x2")));
    }

    public User AuthenticateRealtor(string login, string password)
    {
        var conn = db.GetConnection();
        return conn.QuerySingleOrDefault<User>(
            "SELECT id, full_name AS FullName, phone, email, role, login, password_hash AS PasswordHash FROM realtors WHERE login = @Login AND password_hash = @Hash",
            new { Login = login, Hash = HashPassword(password) });
    }

    public List<User> GetAllClients()
    {
        var conn = db.GetConnection();
        return conn.Query<User>("SELECT id, full_name AS FullName, phone, email, registration_date AS RegistrationDate FROM clients ORDER BY full_name").ToList();
    }

    public List<User> GetAllOwners()
    {
        var conn = db.GetConnection();
        return conn.Query<User>("SELECT id, full_name AS FullName, phone, email, passport_data AS PassportData, address FROM owners ORDER BY full_name").ToList();
    }

    public List<User> GetAllRealtors()
    {
        var conn = db.GetConnection();
        return conn.Query<User>("SELECT id, full_name AS FullName, phone, email, login, role FROM realtors ORDER BY full_name").ToList();
    }

    public int AddClient(User client)
    {
        var conn = db.GetConnection();
        return conn.ExecuteScalar<int>(
            "INSERT INTO clients (full_name, phone, email, registration_date) VALUES (@FullName, @Phone, @Email, @RegistrationDate); SELECT LAST_INSERT_ID()", client);
    }

    public void UpdateClient(User client)
    {
        var conn = db.GetConnection();
        conn.Execute("UPDATE clients SET full_name=@FullName, phone=@Phone, email=@Email WHERE id=@Id", client);
    }

    public void DeleteClient(int id)
    {
        var conn = db.GetConnection();
        conn.Execute("DELETE FROM clients WHERE id=@Id", new { Id = id });
    }

    public int AddOwner(User owner)
    {
        var conn = db.GetConnection();
        return conn.ExecuteScalar<int>(
            "INSERT INTO owners (full_name, phone, email, passport_data, address) VALUES (@FullName, @Phone, @Email, @PassportData, @Address); SELECT LAST_INSERT_ID()", owner);
    }

    public void UpdateOwner(User owner)
    {
        var conn = db.GetConnection();
        conn.Execute("UPDATE owners SET full_name=@FullName, phone=@Phone, email=@Email, passport_data=@PassportData, address=@Address WHERE id=@Id", owner);
    }

    public void DeleteOwner(int id)
    {
        var conn = db.GetConnection();
        conn.Execute("DELETE FROM owners WHERE id=@Id", new { Id = id });
    }

    public void AddRealtor(User realtor, string password)
    {
        realtor.PasswordHash = HashPassword(password);
        var conn = db.GetConnection();
        conn.Execute("INSERT INTO realtors (full_name, phone, email, login, password_hash, role) VALUES (@FullName, @Phone, @Email, @Login, @PasswordHash, @Role)", realtor);
    }

    public void UpdateRealtor(User realtor)
    {
        var conn = db.GetConnection();
        conn.Execute("UPDATE realtors SET full_name=@FullName, phone=@Phone, email=@Email, login=@Login, role=@Role WHERE id=@Id", realtor);
    }

    public void DeleteRealtor(int id)
    {
        var conn = db.GetConnection();
        conn.Execute("DELETE FROM realtors WHERE id=@Id", new { Id = id });
    }
}