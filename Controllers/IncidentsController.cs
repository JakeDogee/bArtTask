using bArtTask.Models;
using bArtTask.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace bArtTask.Controllers;
[ApiController]
[Route(api/incidents)]

public class IncidentsController : ControllerBase
{
    private readonly IIncidentService _incidentService;

    public IncidentsController(IIncidentService incidentService)
    {
        _incidentService = incidentService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateIncident([FromBody] IncidentModelRequest request)
    {
        try
        {
            var result = await _incidentService.CreateIncidentAsync(request);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
}