using GroupApp.Data.Enums;

namespace GroupApp.Data.Entities;

public class TaskEntity : EntityBase
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime DueDate { get; set; }
    public int AssignedUserId { get; set; }
    public TaskStatusEnum Status { get; set; } = TaskStatusEnum.Pending;
    public int ProjectId { get; set; }
    public ProjectEntity Project { get; set; } = null!;
    public UserEntity AssignedUser { get; set; } = null!;
    public ICollection<TaskCommentEntity> Comments { get; set; } = new List<TaskCommentEntity>();
}