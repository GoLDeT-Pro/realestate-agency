using Microsoft.AspNetCore.Mvc;
using System;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly UserService _userService;

    public AuthController(UserService userService) => _userService = userService;

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        var clients = _userService.GetAllClients();
        var client = clients.Find(c => c.Phone == request.Phone);
        if (client == null)
            return Unauthorized(new { message = "Клиент не найден" });

        return Ok(new LoginResponse
        {
            ClientId = client.Id,
            FullName = client.FullName,
            Token = Guid.NewGuid().ToString()
        });
    }

    [HttpPost("register")]
    public IActionResult Register([FromBody] RegisterRequest request)
    {
        var client = new User
        {
            FullName = request.FullName,
            Phone = request.Phone,
            Email = request.Email,
            RegistrationDate = DateTime.Now
        };
        int id = _userService.AddClient(client);
        return Ok(new LoginResponse
        {
            ClientId = id,
            FullName = request.FullName,
            Token = Guid.NewGuid().ToString()
        });
    }
}

public class LoginRequest
{
    public string Phone { get; set; }
}

public class RegisterRequest
{
    public string FullName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
}

public class LoginResponse
{
    public int ClientId { get; set; }
    public string FullName { get; set; }
    public string Token { get; set; }
}