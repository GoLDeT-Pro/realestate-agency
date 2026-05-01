using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;

public class ViewingRequestService
{
    private readonly DatabaseService db;
    public ViewingRequestService(DatabaseService databaseService) => db = databaseService;

    public List<ViewingRequest> GetAllRequests()
    {
        var conn = db.GetConnection();
        return conn.Query<ViewingRequest>(@"
            SELECT vr.id, vr.client_id AS ClientId, vr.property_id AS PropertyId,
                   vr.request_date AS RequestDate, vr.preferred_time AS PreferredTime,
                   vr.status AS Status, vr.comment AS Comment,
                   c.full_name AS ClientName, p.address AS PropertyAddress
            FROM viewing_requests vr
            JOIN clients c ON vr.client_id = c.id
            JOIN properties p ON vr.property_id = p.id
            ORDER BY vr.request_date DESC").ToList();
    }

    public void UpdateStatus(int requestId, string newStatus)
    {
        var conn = db.GetConnection();
        conn.Execute("UPDATE viewing_requests SET status = @Status WHERE id = @Id", new { Id = requestId, Status = newStatus });
    }
}