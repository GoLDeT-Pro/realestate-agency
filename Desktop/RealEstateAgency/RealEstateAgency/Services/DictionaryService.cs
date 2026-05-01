using System.Collections.Generic;
using System.Linq;
using Dapper;

public class DictionaryService
{
    private readonly DatabaseService db;
    public DictionaryService(DatabaseService databaseService) => db = databaseService;

    public List<District> GetAllDistricts()
    {
        var conn = db.GetConnection();
        return conn.Query<District>("SELECT id, name FROM districts ORDER BY name").ToList();
    }

    public void AddDistrict(string name)
    {
        var conn = db.GetConnection();
        conn.Execute("INSERT INTO districts (name) VALUES (@Name)", new { Name = name });
    }

    public void UpdateDistrict(District district)
    {
        var conn = db.GetConnection();
        conn.Execute("UPDATE districts SET name = @Name WHERE id = @Id", district);
    }

    public void DeleteDistrict(int id)
    {
        var conn = db.GetConnection();
        conn.Execute("DELETE FROM districts WHERE id = @Id", new { Id = id });
    }

    public List<PropertyType> GetAllPropertyTypes()
    {
        var conn = db.GetConnection();
        return conn.Query<PropertyType>("SELECT id, name FROM property_types ORDER BY name").ToList();
    }

    public void AddPropertyType(string name)
    {
        var conn = db.GetConnection();
        conn.Execute("INSERT INTO property_types (name) VALUES (@Name)", new { Name = name });
    }

    public void UpdatePropertyType(PropertyType pt)
    {
        var conn = db.GetConnection();
        conn.Execute("UPDATE property_types SET name = @Name WHERE id = @Id", pt);
    }

    public void DeletePropertyType(int id)
    {
        var conn = db.GetConnection();
        conn.Execute("DELETE FROM property_types WHERE id = @Id", new { Id = id });
    }
}