using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SportHub.API.Entities;

namespace SportHub.API.Data.Configurations
{
    public class BookingSlotConfiguration : IEntityTypeConfiguration<BookingSlot>
    {
        public void Configure(EntityTypeBuilder<BookingSlot> builder)
        {
            // Chống đặt trùng: 1 sân, 1 ngày, 1 khung giờ chỉ có đúng 1 dòng
            builder.HasIndex(s => new { s.CourtId, s.SlotDate, s.SlotStart })
                   .IsUnique();

            builder.HasOne(s => s.Booking)
                   .WithMany(b => b.Slots)
                   .HasForeignKey(s => s.BookingId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(s => s.Court)
                   .WithMany(c => c.BookingSlots)
                   .HasForeignKey(s => s.CourtId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
