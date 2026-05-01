using System;

public class ViewingRequest
{
    public int Id { get; set; }
    public int ClientId { get; set; }
    public int PropertyId { get; set; }
    public DateTime RequestDate { get; set; }
    public string PreferredTime { get; set; }
    public string Status { get; set; }
    public string Comment { get; set; }

    public string ClientName { get; set; }
    public string PropertyAddress { get; set; }
}