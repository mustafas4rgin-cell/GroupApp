using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GroupApp.Data.Entities;

namespace GroupApp.Data.Configurations;

public class ProjectEntityConfiguration : IEntityTypeConfiguration<ProjectEntity>
{
    public void Configure(EntityTypeBuilder<ProjectEntity> builder)
    {
        builder.ToTable("Projects");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name)
               .IsRequired()
               .HasMaxLength(200);

        builder.Property(p => p.Description)
               .HasMaxLength(1000);

        builder.Property(p => p.DeadLine)
               .IsRequired(false);

        builder.Property(p => p.Status)
                .HasConversion<int>() // Enum'u int olarak saklayacak
                .IsRequired();



        builder.HasOne(p => p.Owner)
                .WithMany(u => u.OwnedProjects) // Burada OwnedProject yerine OwnedProjects olacak
                .HasForeignKey(p => p.OwnerId)
                .OnDelete(DeleteBehavior.Cascade);



        // Project - ProjectRel ilişkisi (N-N)
        builder.HasMany(p => p.Users)
               .WithOne(pr => pr.Project)
               .HasForeignKey(pr => pr.ProjectId)
               .OnDelete(DeleteBehavior.Cascade);

        // Project - ProjectRole ilişkisi (1-N)
        builder.HasMany(p => p.ProjectRoles)
               .WithOne(pr => pr.Project)
               .HasForeignKey(pr => pr.ProjectId)
               .OnDelete(DeleteBehavior.Cascade);

        // Project - Task ilişkisi (1-N)
        builder.HasMany(p => p.Tasks)
               .WithOne(t => t.Project)
               .HasForeignKey(t => t.ProjectId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
