using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;

public class PropertyService
{
    private readonly DatabaseService db;

    public PropertyService(DatabaseService databaseService) => db = databaseService;

    public List<Property> GetAllProperties()
    {
        var conn = db.GetConnection();
        return conn.Query<Property>(@"
            SELECT p.id, p.address, p.area, p.rooms, p.floor, p.total_floors, p.price,
                   p.description, p.status, p.created_at AS CreatedAt,
                   p.owner_id AS OwnerId, p.district_id AS DistrictId, p.property_type_id AS PropertyTypeId,
                   d.name AS DistrictName, pt.name AS PropertyTypeName,
                   o.full_name AS OwnerName, o.phone AS OwnerPhone,
                   (SELECT photo_path FROM property_photos WHERE property_id = p.id AND is_main = 1 LIMIT 1) AS MainPhotoPath
            FROM properties p
            JOIN districts d ON p.district_id = d.id
            JOIN property_types pt ON p.property_type_id = pt.id
            JOIN owners o ON p.owner_id = o.id
            ORDER BY p.created_at DESC").ToList();
    }

    public List<Property> SearchProperties(SearchCriteria criteria)
    {
        var conn = db.GetConnection();
        return conn.Query<Property>("CALL search_properties(@MinPrice, @MaxPrice, @MinArea, @MaxArea, @Rooms, @DistrictId, @PropertyTypeId)", criteria).ToList();
    }

    public Property GetPropertyById(int id)
    {
        var conn = db.GetConnection();
        return conn.QuerySingleOrDefault<Property>(@"
            SELECT p.id, p.address, p.area, p.rooms, p.floor, p.total_floors, p.price,
                   p.description, p.status, p.created_at AS CreatedAt,
                   p.owner_id AS OwnerId, p.district_id AS DistrictId, p.property_type_id AS PropertyTypeId,
                   d.name AS DistrictName, pt.name AS PropertyTypeName,
                   o.full_name AS OwnerName, o.phone AS OwnerPhone
            FROM properties p
            JOIN districts d ON p.district_id = d.id
            JOIN property_types pt ON p.property_type_id = pt.id
            JOIN owners o ON p.owner_id = o.id
            WHERE p.id = @Id", new { Id = id });
    }

    public int AddProperty(Property property)
    {
        var conn = db.GetConnection();
        return conn.ExecuteScalar<int>(@"
            INSERT INTO properties (owner_id, district_id, property_type_id, address, area, rooms, floor, total_floors, price, description, status)
            VALUES (@OwnerId, @DistrictId, @PropertyTypeId, @Address, @Area, @Rooms, @Floor, @TotalFloors, @Price, @Description, @Status);
            SELECT LAST_INSERT_ID()", property);
    }

    public void UpdateProperty(Property property)
    {
        var conn = db.GetConnection();
        conn.Execute(@"
            UPDATE properties SET owner_id=@OwnerId, district_id=@DistrictId, property_type_id=@PropertyTypeId,
            address=@Address, area=@Area, rooms=@Rooms, floor=@Floor, total_floors=@TotalFloors,
            price=@Price, description=@Description, status=@Status
            WHERE id=@Id", property);
    }

    public void DeleteProperty(int id)
    {
        var conn = db.GetConnection();
        conn.Execute("DELETE FROM properties WHERE id=@Id", new { Id = id });
    }

    public List<PropertyPhoto> GetPhotos(int propertyId)
    {
        var conn = db.GetConnection();
        return conn.Query<PropertyPhoto>("SELECT id, property_id AS PropertyId, photo_path AS PhotoPath, is_main AS IsMain FROM property_photos WHERE property_id = @Id", new { Id = propertyId }).ToList();
    }

    public void AddPhoto(PropertyPhoto photo)
    {
        var conn = db.GetConnection();
        conn.Execute("INSERT INTO property_photos (property_id, photo_path, is_main) VALUES (@PropertyId, @PhotoPath, @IsMain)", photo);
    }

    public void DeletePhoto(int photoId)
    {
        var conn = db.GetConnection();
        conn.Execute("DELETE FROM property_photos WHERE id = @Id", new { Id = photoId });
    }

    public void SetMainPhoto(int photoId, int propertyId)
    {
        var conn = db.GetConnection();
        conn.Execute("UPDATE property_photos SET is_main = 0 WHERE property_id = @PropertyId", new { PropertyId = propertyId });
        conn.Execute("UPDATE property_photos SET is_main = 1 WHERE id = @Id", new { Id = photoId });
    }
}