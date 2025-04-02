namespace GroupApp.Data.DTOs;

public class ProjectRoleDTO
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int ProjectId { get; set; }
    public int UserId { get; set; }
}