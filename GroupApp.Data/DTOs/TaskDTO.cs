namespace GroupApp.Data.DTOs;

public class TaskDTO
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime DueDate { get; set; }
    public int AssignedUserId { get; set; }
}