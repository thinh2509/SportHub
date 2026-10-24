using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportHub.API.Entities;

namespace SportHub.API.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.FullName).HasMaxLength(100).IsRequired();
            builder.Property(u => u.Email).HasMaxLength(100).IsRequired();
            builder.Property(u => u.PasswordHash).HasMaxLength(255).IsRequired();
            builder.Property(u => u.Phone).HasMaxLength(15).IsUnicode(false);

            builder.HasIndex(u => u.Email).IsUnique();

            // An User has one Role and a Roles has more Users
            builder.HasOne(u => u.Role)
                   .WithMany(r => r.Users)
                   .HasForeignKey(u => u.RoleId)
                   .OnDelete(DeleteBehavior.Restrict); // Not allow delete Role when user is exist
        }
    }
}
