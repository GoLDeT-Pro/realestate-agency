using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ProfileController : ControllerBase
{
    private readonly UserService _userService;

    public ProfileController(UserService userService) => _userService = userService;

    [HttpGet("{id}")]
    public IActionResult GetProfile(int id)
    {
        var clients = _userService.GetAllClients();
        var client = clients.Find(c => c.Id == id);
        if (client == null) return NotFound();
        return Ok(new { client.FullName, client.Phone, client.Email });
    }

    [HttpPut("{id}")]
    public IActionResult UpdateProfile(int id, [FromBody] UpdateProfileRequest request)
    {
        var user = new User { Id = id, FullName = request.FullName, Phone = request.Phone, Email = request.Email };
        _userService.UpdateClient(user);
        return Ok();
    }
}

public class UpdateProfileRequest
{
    public string FullName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
}