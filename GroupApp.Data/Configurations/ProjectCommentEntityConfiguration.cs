using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GroupApp.Data.Entities;

namespace GroupApp.Data.Configurations;

public class ProjectCommentEntityConfiguration : IEntityTypeConfiguration<ProjectCommentEntity>
{
    public void Configure(EntityTypeBuilder<ProjectCommentEntity> builder)
    {
        builder.ToTable("ProjectComments");

        builder.HasKey(pc => pc.Id);

        builder.Property(pc => pc.Content)
               .IsRequired()
               .HasMaxLength(1000);

        builder.Property(pc => pc.IsConfirmed)
               .HasDefaultValue(false);

        // ProjectComment - User ilişkisi (N-1)
        builder.HasOne(pc => pc.User)
               .WithMany(u => u.ProjectComments) // Eğer User'ın ProjectComments koleksiyonu varsa güncelle
               .HasForeignKey(pc => pc.UserId)
               .OnDelete(DeleteBehavior.Cascade);

        // ProjectComment - Project ilişkisi (N-1)
        builder.HasOne(pc => pc.Project)
               .WithMany(p => p.Comments) // Eğer Project'in ProjectComments koleksiyonu varsa güncelle
               .HasForeignKey(pc => pc.ProjectId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
