using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SportHub.API.Entities;

namespace SportHub.API.Data.Configurations
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.Property(b => b.BookingCode).HasMaxLength(20).IsUnicode(false).IsRequired();
            builder.Property(b => b.TotalPrice).HasPrecision(18, 0);
            builder.Property(b => b.DepositAmount).HasPrecision(18, 0);
            builder.Property(b => b.Status).HasConversion<string>().HasMaxLength(20);

            builder.HasIndex(b => b.BookingCode).IsUnique();
            builder.HasIndex(b => new { b.CourtId, b.BookingDate });

            builder.HasOne(b => b.Customer)
                   .WithMany(u => u.Bookings)
                   .HasForeignKey(b => b.CustomerId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(b => b.Court)
                   .WithMany(c => c.Bookings)
                   .HasForeignKey(b => b.CourtId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
