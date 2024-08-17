using bArtTask.Models;

namespace bArtTask.Services.Interfaces;

public interface IIncidentService
{
    Task<string> CreateIncidentAsync(IncidentModelRequest request);
}