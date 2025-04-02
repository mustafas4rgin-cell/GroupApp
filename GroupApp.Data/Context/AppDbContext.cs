
using GroupApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GroupApp.Data.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
    {
    }
    public DbSet<ProjectCommentEntity> ProjectComments { get; set; }
    public DbSet<ProjectRoleEntity> ProjectRoles { get; set; }
    public DbSet<RoleEntity> Roles { get; set; }
    public DbSet<TaskCommentEntity> TaskComments { get; set; }
    public DbSet<TaskEntity> Tasks { get; set; }
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<ProjectEntity> Projects { get; set; }
    public DbSet<ProjectRelEntity> UserProjects { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
