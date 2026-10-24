using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SportHub.API.Entities;

namespace SportHub.API.Data.Configurations
{
    public class CourtConfiguration : IEntityTypeConfiguration<Court>
    {
        public void Configure(EntityTypeBuilder<Court> builder)
        {
            builder.Property(c => c.Name).HasMaxLength(50).IsRequired();

            builder.HasOne(c => c.Venue)
                   .WithMany(v => v.Courts)
                   .HasForeignKey(c => c.VenueId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.SportType)
                   .WithMany(s => s.Courts)
                   .HasForeignKey(c => c.SportTypeId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
