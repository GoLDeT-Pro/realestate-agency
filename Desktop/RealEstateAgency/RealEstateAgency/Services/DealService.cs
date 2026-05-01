using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;

public class DealService
{
    private readonly DatabaseService db;
    public DealService(DatabaseService databaseService) => db = databaseService;

    public List<Deal> GetAllDeals()
    {
        var conn = db.GetConnection();
        return conn.Query<Deal>(@"
            SELECT d.id, d.property_id AS PropertyId, d.client_id AS ClientId, d.realtor_id AS RealtorId,
                   d.deal_date AS DealDate, d.price, d.commission, d.status,
                   p.address AS PropertyAddress, c.full_name AS ClientName, r.full_name AS RealtorName
            FROM deals d
            JOIN properties p ON d.property_id = p.id
            JOIN clients c ON d.client_id = c.id
            JOIN realtors r ON d.realtor_id = r.id
            ORDER BY d.deal_date DESC").ToList();
    }

    public void CreateDeal(Deal deal)
    {
        var conn = db.GetConnection();
        conn.Execute(@"
            INSERT INTO deals (property_id, client_id, realtor_id, deal_date, price, commission, status)
            VALUES (@PropertyId, @ClientId, @RealtorId, @DealDate, @Price, @Commission, @Status)", deal);
    }

    public List<Deal> GetDealsByPeriod(DateTime from, DateTime to)
    {
        var conn = db.GetConnection();
        return conn.Query<Deal>(@"
            SELECT d.id, d.property_id AS PropertyId, d.client_id AS ClientId, d.realtor_id AS RealtorId,
                   d.deal_date AS DealDate, d.price, d.commission, d.status,
                   p.address AS PropertyAddress, c.full_name AS ClientName, r.full_name AS RealtorName
            FROM deals d
            JOIN properties p ON d.property_id = p.id
            JOIN clients c ON d.client_id = c.id
            JOIN realtors r ON d.realtor_id = r.id
            WHERE d.deal_date BETWEEN @From AND @To
            ORDER BY d.deal_date DESC", new { From = from, To = to }).ToList();
    }
}