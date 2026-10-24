using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportHub.API.Entities;

namespace SportHub.API.Data.Configurations
{
    public class SportTypeConfiguration : IEntityTypeConfiguration<SportType>
    {
        public void Configure(EntityTypeBuilder<SportType> builder)
        {
            builder.Property(s => s.Name).HasMaxLength(50).IsRequired();
            builder.HasIndex(s => s.Name).IsUnique();

            builder.HasData(
                new SportType { Id = 1, Name = "Bóng đá mini" },
                new SportType { Id = 2, Name = "Cầu lông" },
                new SportType { Id = 3, Name = "Pickleball" }
            );
        }
    }
}
