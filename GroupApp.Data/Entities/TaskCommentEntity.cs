namespace GroupApp.Data.Entities;

public class TaskCommentEntity : EntityBase
{
    public string Content { get; set; } = string.Empty;
    public int TaskId { get; set; }
    public int UserId { get; set; }
    public bool IsConfirmed { get; set; } = false;
    public UserEntity User { get; set; } = null!;
    public TaskEntity Task { get; set; } = null!;
}