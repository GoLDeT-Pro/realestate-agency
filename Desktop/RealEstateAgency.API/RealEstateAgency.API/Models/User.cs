using System;

public class User
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
    public string Login { get; set; }
    public string PasswordHash { get; set; }
    public DateTime? RegistrationDate { get; set; }
    public string PassportData { get; set; }
    public string Address { get; set; }
}