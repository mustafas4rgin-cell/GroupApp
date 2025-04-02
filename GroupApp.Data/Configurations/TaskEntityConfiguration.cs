using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GroupApp.Data.Entities;

namespace GroupApp.Data.Configurations;

public class TaskEntityConfiguration : IEntityTypeConfiguration<TaskEntity>
{
    public void Configure(EntityTypeBuilder<TaskEntity> builder)
    {
        builder.ToTable("Tasks");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Name)
               .IsRequired()
               .HasMaxLength(200);

        builder.Property(t => t.Description)
               .HasMaxLength(1000);

        builder.Property(t => t.DueDate)
               .IsRequired();

        builder.Property(t => t.Status)
                .HasConversion<int>() // Enum'u int olarak saklayacak
                .IsRequired();


        // Task - Project ilişkisi (N-1)
        builder.HasOne(t => t.Project)
               .WithMany(p => p.Tasks)
               .HasForeignKey(t => t.ProjectId)
               .OnDelete(DeleteBehavior.Cascade);

        // Task - AssignedUser ilişkisi (N-1)
        builder.HasOne(t => t.AssignedUser)
               .WithMany(u => u.Tasks)
               .HasForeignKey(t => t.AssignedUserId)
               .OnDelete(DeleteBehavior.SetNull);

        // Task - Comments ilişkisi (1-N)
        builder.HasMany(t => t.Comments)
               .WithOne(tc => tc.Task)
               .HasForeignKey(tc => tc.TaskId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
