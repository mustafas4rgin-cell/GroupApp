namespace GroupApp.Data.Entities;

public class ProjectCommentEntity : EntityBase
{
    public string Content { get; set; } = string.Empty;
    public int UserId { get; set; }
    public int ProjectId { get; set; }
    public bool IsConfirmed { get; set; } = false;
    public UserEntity User { get; set; } = null!;
    public ProjectEntity Project { get; set; } = null!;
}