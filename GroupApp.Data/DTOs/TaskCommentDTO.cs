namespace GroupApp.Data.DTOs;

public class TaskCommentDTO
{
    public string Content { get; set; } = string.Empty;
    public int TaskId { get; set; }
    public int UserId { get; set; }
}