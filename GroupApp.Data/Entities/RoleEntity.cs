namespace GroupApp.Data.Entities;

public class RoleEntity : EntityBase
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public ICollection<UserEntity> Users { get; set; } = new List<UserEntity>();
}