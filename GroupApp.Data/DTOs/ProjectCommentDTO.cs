namespace GroupApp.Data.DTOs;

public class ProjectCommentDTO
{
    public string Content { get; set; } = string.Empty;
    public int UserId { get; set; }
    public int ProjectId { get; set; }
}