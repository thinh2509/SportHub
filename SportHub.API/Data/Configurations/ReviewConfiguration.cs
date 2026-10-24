using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SportHub.API.Entities;

namespace SportHub.API.Data.Configurations
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.Property(r => r.Comment).HasMaxLength(500);

            builder.ToTable(t => t.HasCheckConstraint("CK_Reviews_Rating", "[Rating] BETWEEN 1 AND 5"));

            builder.HasOne(r => r.Booking)
                   .WithOne(b => b.Review)
                   .HasForeignKey<Review>(r => r.BookingId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
