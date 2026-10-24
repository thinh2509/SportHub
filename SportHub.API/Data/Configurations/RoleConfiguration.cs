using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportHub.API.Entities;

namespace SportHub.API.Data.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.Property(r => r.Name).HasMaxLength(50).IsRequired();
            builder.HasIndex(r => r.Name).IsUnique();

            builder.HasData(
                new Role { Id = 1, Name = "Customer" },
                new Role { Id = 2, Name = "Owner" },
                new Role { Id = 3, Name = "Admin" }
            );
        }
    }
}
