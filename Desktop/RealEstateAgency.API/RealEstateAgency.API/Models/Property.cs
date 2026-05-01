using System;

public class Property
{
    public int Id { get; set; }
    public int OwnerId { get; set; }
    public int DistrictId { get; set; }
    public int PropertyTypeId { get; set; }
    public string Address { get; set; }
    public decimal Area { get; set; }
    public int Rooms { get; set; }
    public int? Floor { get; set; }
    public int? TotalFloors { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public DateTime CreatedAt { get; set; }

    public string DistrictName { get; set; }
    public string PropertyTypeName { get; set; }
    public string OwnerName { get; set; }
    public string OwnerPhone { get; set; }
    public string MainPhotoPath { get; set; }
}