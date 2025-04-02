namespace GroupApp.Data.Entities;

public class ProjectRoleEntity : EntityBase
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int ProjectId { get; set; }
    public int UserId { get; set; }
    public UserEntity User { get; set; } = null!;
    public ProjectEntity Project { get; set; } = null!;
}