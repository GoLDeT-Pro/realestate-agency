using Dapper;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.IO;
using System.Linq;

[ApiController]
[Route("api/[controller]")]
public class FavoritesController : ControllerBase
{
    private readonly DatabaseService _db;

    public FavoritesController(DatabaseService db) => _db = db;

    [HttpGet("{clientId}")]
    public IActionResult GetFavorites(int clientId)
    {
        using var conn = _db.GetConnection();
        var list = conn.Query<FavoriteDto>(@"
            SELECT p.id AS PropertyId, p.address AS Address, p.price,
                   (SELECT photo_path FROM property_photos WHERE property_id = p.id AND is_main = 1 LIMIT 1) AS MainPhotoPath
            FROM favorites f
            JOIN properties p ON f.property_id = p.id
            WHERE f.client_id = @clientId", new { clientId }).ToList();

        var baseUrl = $"{Request.Scheme}://{Request.Host}";
        foreach (var fav in list)
            fav.MainPhotoUrl = !string.IsNullOrEmpty(fav.MainPhotoPath) ? $"{baseUrl}/api/photos/{Path.GetFileName(fav.MainPhotoPath)}" : null;

        return Ok(list);
    }

    [HttpPost]
    public IActionResult AddFavorite([FromBody] FavoriteRequest request)
    {
        try
        {
            using var conn = _db.GetConnection();
            conn.Execute("INSERT INTO favorites (client_id, property_id) VALUES (@ClientId, @PropertyId)", request);
        }
        catch (MySqlException ex) when (ex.Number == 1062) 
        {
        }
        return Ok();
    }

    [HttpDelete("{clientId}/{propertyId}")]
    public IActionResult RemoveFavorite(int clientId, int propertyId)
    {
        using var conn = _db.GetConnection();
        conn.Execute("DELETE FROM favorites WHERE client_id = @ClientId AND property_id = @PropertyId", new { ClientId = clientId, PropertyId = propertyId });
        return Ok();
    }
}

public class FavoriteDto
{
    public int PropertyId { get; set; }
    public string Address { get; set; }
    public decimal Price { get; set; }
    public string MainPhotoUrl { get; set; }
    public string MainPhotoPath { get; set; }
}

public class FavoriteRequest
{
    public int ClientId { get; set; }
    public int PropertyId { get; set; }
}