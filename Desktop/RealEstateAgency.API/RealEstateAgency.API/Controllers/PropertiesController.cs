using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Linq;

[ApiController]
[Route("api/[controller]")]
public class PropertiesController : ControllerBase
{
    private readonly PropertyService _propertyService;

    public PropertiesController(PropertyService propertyService) => _propertyService = propertyService;

    [HttpGet]
    public IActionResult GetProperties([FromQuery] SearchCriteria criteria)
    {
        var properties = _propertyService.SearchProperties(criteria ?? new SearchCriteria());
        var baseUrl = $"{Request.Scheme}://{Request.Host}";
        var result = properties.Select(p => new PropertyDto
        {
            Id = p.Id,
            Address = p.Address,
            Area = p.Area,
            Rooms = p.Rooms,
            Price = p.Price,
            Status = p.Status,
            District = p.DistrictName,
            PropertyType = p.PropertyTypeName,
            MainPhotoUrl = !string.IsNullOrEmpty(p.MainPhotoPath) ? $"{baseUrl}/api/photos/{Path.GetFileName(p.MainPhotoPath)}" : null
        });
        return Ok(result);
    }

    [HttpGet("{id}")]
    public IActionResult GetProperty(int id)
    {
        var p = _propertyService.GetPropertyById(id);
        if (p == null) return NotFound();
        var baseUrl = $"{Request.Scheme}://{Request.Host}";
        var photos = _propertyService.GetPhotos(id)
            .Select(ph => $"{baseUrl}/api/photos/{Path.GetFileName(ph.PhotoPath)}").ToList();
        return Ok(new PropertyDetailDto
        {
            Id = p.Id,
            Address = p.Address,
            Area = p.Area,
            Rooms = p.Rooms,
            Floor = p.Floor,
            TotalFloors = p.TotalFloors,
            Price = p.Price,
            Description = p.Description,
            Status = p.Status,
            District = p.DistrictName,
            PropertyType = p.PropertyTypeName,
            OwnerName = p.OwnerName,
            OwnerPhone = p.OwnerPhone,
            PhotoUrls = photos,
            IsFavorite = false,
            MainPhotoUrl = !string.IsNullOrEmpty(p.MainPhotoPath) ? $"{baseUrl}/api/photos/{Path.GetFileName(p.MainPhotoPath)}" : null
        });
    }
}

public class PropertyDto
{
    public int Id { get; set; }
    public string Address { get; set; }
    public decimal Area { get; set; }
    public int Rooms { get; set; }
    public decimal Price { get; set; }
    public string Status { get; set; }
    public string District { get; set; }
    public string PropertyType { get; set; }
    public string MainPhotoUrl { get; set; }
}

public class PropertyDetailDto
{
    public int Id { get; set; }
    public string Address { get; set; }
    public decimal Area { get; set; }
    public int Rooms { get; set; }
    public int? Floor { get; set; }
    public int? TotalFloors { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public string District { get; set; }
    public string PropertyType { get; set; }
    public string OwnerName { get; set; }
    public string OwnerPhone { get; set; }
    public List<string> PhotoUrls { get; set; }
    public bool IsFavorite { get; set; }
    public string MainPhotoUrl { get; set; }
}