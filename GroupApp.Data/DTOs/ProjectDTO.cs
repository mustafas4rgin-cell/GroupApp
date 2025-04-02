namespace GroupApp.Data.DTOs;

public class ProjectDTO
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int OwnerId { get; set; }
    public DateTime? DeadLine { get; set; }
}