using System;

public class Deal
{
    public int Id { get; set; }
    public int PropertyId { get; set; }
    public int ClientId { get; set; }
    public int RealtorId { get; set; }
    public DateTime DealDate { get; set; }
    public decimal Price { get; set; }
    public decimal Commission { get; set; }
    public string Status { get; set; }

    public string PropertyAddress { get; set; }
    public string ClientName { get; set; }
    public string RealtorName { get; set; }
}