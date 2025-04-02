using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GroupApp.Data.Entities;

namespace GroupApp.Data.Configurations;

public class ProjectRoleEntityConfiguration : IEntityTypeConfiguration<ProjectRoleEntity>
{
    public void Configure(EntityTypeBuilder<ProjectRoleEntity> builder)
    {
        builder.ToTable("ProjectRoles");

        builder.HasKey(pr => pr.Id);

        builder.Property(pr => pr.Name)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(pr => pr.Description)
               .HasMaxLength(500);

        // ProjectRole - User ilişkisi (N-1)
        builder.HasOne(pr => pr.User)
               .WithMany(u => u.ProjectRoles)
               .HasForeignKey(pr => pr.UserId)
               .OnDelete(DeleteBehavior.Cascade);

        // ProjectRole - Project ilişkisi (N-1)
        builder.HasOne(pr => pr.Project)
               .WithMany(p => p.ProjectRoles)
               .HasForeignKey(pr => pr.ProjectId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
