using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GroupApp.Data.Entities;

namespace GroupApp.Data.Configurations;

public class ProjectRelEntityConfiguration : IEntityTypeConfiguration<ProjectRelEntity>
{
    public void Configure(EntityTypeBuilder<ProjectRelEntity> builder)
    {
        // Tablo Adı (Opsiyonel)
        builder.ToTable("ProjectUsers");

        // Composite Primary Key (UserId + ProjectId)
        builder.HasKey(pr => new { pr.ProjectId, pr.UserId });

        // Project - ProjectRelEntity ilişkisi (1-N)
        builder.HasOne(pr => pr.Project)
               .WithMany(p => p.Users)
               .HasForeignKey(pr => pr.ProjectId)
               .OnDelete(DeleteBehavior.Cascade); // Proje silinirse ilişkili kayıtları da sil

        // User - ProjectRelEntity ilişkisi (1-N)
        builder.HasOne(pr => pr.User)
               .WithMany(u => u.Projects)
               .HasForeignKey(pr => pr.UserId)
               .OnDelete(DeleteBehavior.Restrict); // Kullanıcı silinirse ilişkili kayıtları da sil
    }
}
