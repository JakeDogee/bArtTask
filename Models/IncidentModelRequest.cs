namespace bArtTask.Models;

public class IncidentModelRequest
{
    public string AccountName { get; set; }
    public string ContactFirstName { get; set; }
    public string ContactLastName { get; set; }
    public string ContactEmail { get; set; }
    public string IncidentDescription { get; set; }
}