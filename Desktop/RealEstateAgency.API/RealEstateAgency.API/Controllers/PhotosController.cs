using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.IO;

[ApiController]
[Route("api/[controller]")]
public class PhotosController : ControllerBase
{
    private readonly string _photosPath;

    public PhotosController(IConfiguration configuration)
    {
        _photosPath = configuration["PhotosPath"] ?? Path.Combine(Directory.GetCurrentDirectory(), "Photos");
    }

    [HttpGet("{fileName}")]
    public IActionResult GetPhoto(string fileName)
    {
        var filePath = Path.Combine(_photosPath, fileName);
        if (!System.IO.File.Exists(filePath))
            return NotFound();

        var contentType = "image/jpeg";
        var ext = Path.GetExtension(filePath).ToLower();
        if (ext == ".png") contentType = "image/png";
        else if (ext == ".gif") contentType = "image/gif";

        return PhysicalFile(filePath, contentType);
    }
}