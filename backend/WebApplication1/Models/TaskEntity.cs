namespace WebApplication1.Models;

public class TaskEntity
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string AssignedTo { get; set; }
    public TaskProgress Status { get; set; }

    public PlannedTerm PlannedTerm { get; set; }
    public ActualTerm ActualTerm { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime CompletedAt { get; set; }
}

public class ActualTerm : Term
{
}

public class PlannedTerm : Term
{
}

public abstract class Term
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}

public enum TaskProgress
{
    New,
    Active,
    Review,
    Solved,
    Completed,
    Pending
}