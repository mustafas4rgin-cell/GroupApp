
using GroupApp.Data.Enums;

namespace GroupApp.Data.Entities;

public class ProjectEntity : EntityBase
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int OwnerId { get; set; }
    public DateTime? DeadLine { get; set; }
    public TaskStatusEnum Status { get; set; } = TaskStatusEnum.Pending;
    public UserEntity Owner { get; set; } = null!;
    public ICollection<ProjectRelEntity> Users { get; set; } = new List<ProjectRelEntity>();
    public ICollection<TaskEntity> Tasks { get; set; } = new List<TaskEntity>();
    public ICollection<ProjectRoleEntity> ProjectRoles { get; set; } = null!;
    public ICollection<ProjectCommentEntity> Comments { get; set; } = new List<ProjectCommentEntity>();
}