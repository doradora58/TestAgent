namespace WebApplication1.Models;

public class TaskDto 
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string AssignedTo { get; set; }
    public string Status { get; set; }

    public PlannedTerm PlannedTerm { get; set; }
    public ActualTerm ActualTerm { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime CompletedAt { get; set; }
}