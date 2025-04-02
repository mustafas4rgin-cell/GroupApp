using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GroupApp.Data.Entities;

namespace GroupApp.Data.Configurations;

public class TaskCommentEntityConfiguration : IEntityTypeConfiguration<TaskCommentEntity>
{
    public void Configure(EntityTypeBuilder<TaskCommentEntity> builder)
    {
        builder.ToTable("TaskComments");

        builder.HasKey(tc => tc.Id);

        builder.Property(tc => tc.Content)
               .IsRequired()
               .HasMaxLength(1000);

        builder.Property(tc => tc.IsConfirmed)
               .HasDefaultValue(false);

        // TaskComment - User ilişkisi (N-1)
        builder.HasOne(tc => tc.User)
               .WithMany(u => u.TaskComments)
               .HasForeignKey(tc => tc.UserId)
               .OnDelete(DeleteBehavior.Cascade);

        // TaskComment - Task ilişkisi (N-1)
        builder.HasOne(tc => tc.Task)
               .WithMany(t => t.Comments)
               .HasForeignKey(tc => tc.TaskId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
