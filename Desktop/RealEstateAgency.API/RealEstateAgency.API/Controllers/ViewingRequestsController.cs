using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

[ApiController]
[Route("api/[controller]")]
public class ViewingRequestsController : ControllerBase
{
    private readonly ViewingRequestService _viewingRequestService;

    public ViewingRequestsController(ViewingRequestService viewingRequestService)
    {
        _viewingRequestService = viewingRequestService;
    }

    [HttpPost]
    public IActionResult Create([FromBody] ViewingRequestDto request)
    {
        var viewingRequest = new ViewingRequest
        {
            ClientId = request.ClientId,
            PropertyId = request.PropertyId,
            RequestDate = DateTime.Parse(request.PreferredDate),
            PreferredTime = request.PreferredTime,
            Comment = request.Comment,
            Status = "Новый"
        };
        _viewingRequestService.AddRequest(viewingRequest);
        return Ok(new { message = "Заявка создана" });
    }

    [HttpGet("client/{clientId}")]
    public IActionResult GetClientRequests(int clientId)
    {
        var requests = _viewingRequestService.GetAllRequests()
            .Where(r => r.ClientId == clientId).ToList();
        return Ok(requests);
    }
}

public class ViewingRequestDto
{
    public int ClientId { get; set; }
    public int PropertyId { get; set; }
    public string PreferredDate { get; set; }
    public string PreferredTime { get; set; }
    public string Comment { get; set; }
}