using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportHub.API.Entities;

namespace SportHub.API.Data.Configurations
{
    public class VenueConfiguration : IEntityTypeConfiguration<Venue>
    {
        public void Configure(EntityTypeBuilder<Venue> builder)
        {
            builder.Property(v => v.Name).HasMaxLength(150).IsRequired();
            builder.Property(v => v.Address).HasMaxLength(255).IsRequired();
            builder.Property(v => v.District).HasMaxLength(100).IsRequired();
            builder.Property(v => v.Status).HasConversion<string>().HasMaxLength(20);

            builder.HasIndex(v => v.District);

            // A Venue has one owner and an user can has more venues
            builder.HasOne(v => v.Owner)
                   .WithMany(u => u.OwnedVenues)
                   .HasForeignKey(v => v.OwnerId)
                   .OnDelete(DeleteBehavior.Restrict); // can not delete the user when Venue is exist
        }
    }
}
