using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GroupApp.Data.Entities;

namespace GroupApp.Data.Configurations;

public class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Name)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(u => u.Email)
               .IsRequired()
               .HasMaxLength(150);

        builder.HasIndex(u => u.Email)
               .IsUnique();

        builder.Property(u => u.PasswordHash)
               .IsRequired();

        builder.Property(u => u.PasswordSalt)
               .IsRequired();

        // User - Role (N-1) ilişkisi
        builder.HasOne(u => u.Role)
               .WithMany(r => r.Users)
               .HasForeignKey(u => u.RoleId)
               .OnDelete(DeleteBehavior.Restrict);

        // User - OwnedProjects (1-N) ilişkisi
        builder.HasMany(u => u.OwnedProjects) // Değiştirilen kısım burası!
               .WithOne(p => p.Owner)
               .HasForeignKey(p => p.OwnerId)
               .OnDelete(DeleteBehavior.Cascade);

        // User - ProjectRoles (1-N) ilişkisi
        builder.HasMany(u => u.ProjectRoles)
               .WithOne(pr => pr.User)
               .HasForeignKey(pr => pr.UserId)
               .OnDelete(DeleteBehavior.Cascade);

        // User - Projects ilişkisi (Many-to-Many, ara tablo: ProjectRelEntity)
        builder.HasMany(u => u.Projects)
               .WithOne(pr => pr.User)
               .HasForeignKey(pr => pr.UserId)
               .OnDelete(DeleteBehavior.Restrict);

        // User - Tasks (1-N) ilişkisi
        builder.HasMany(u => u.Tasks)
               .WithOne(t => t.AssignedUser)
               .HasForeignKey(t => t.AssignedUserId)
               .OnDelete(DeleteBehavior.SetNull);

        // User - TaskComments (1-N) ilişkisi
        builder.HasMany(u => u.TaskComments)
               .WithOne(tc => tc.User)
               .HasForeignKey(tc => tc.UserId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
