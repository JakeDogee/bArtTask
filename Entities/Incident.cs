namespace bArtTask.Entities;

public class Incident
{
    public int Id { get; set; }
    public string IncidentName { get; set; } 
    public string Description { get; set; }
    
    public int AccountId { get; set; }
    public Account Account { get; set; }
}