using GroupApp.Data.Entities;

namespace GroupApp.Data.Entities;

public class ProjectRelEntity : EntityBase
{
    public int ProjectId { get; set; }
    public int UserId { get; set; }
    public UserEntity User { get; set; } = null!;
    public ProjectEntity Project { get; set; } = null!;
}