
namespace GroupApp.Data.Entities;

public class UserEntity : EntityBase
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public byte[] PasswordHash { get; set; } = null!;
    public byte[] PasswordSalt { get; set; } = null!;
    public int RoleId { get; set; }
    public RoleEntity Role { get; set; } = null!;
    public ICollection<ProjectEntity> OwnedProjects { get; set; } = null!;
    public ICollection<ProjectRoleEntity> ProjectRoles { get; set; } = null!;
    public ICollection<ProjectRelEntity> Projects { get; set; } = new List<ProjectRelEntity>();
    public ICollection<TaskEntity> Tasks { get; set; } = new List<TaskEntity>();
    public ICollection<TaskCommentEntity> TaskComments { get; set; } = new List<TaskCommentEntity>();
    public ICollection<ProjectCommentEntity> ProjectComments { get; set; } = new List<ProjectCommentEntity>();
}
