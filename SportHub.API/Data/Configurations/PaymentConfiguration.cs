using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SportHub.API.Entities;

namespace SportHub.API.Data.Configurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.Property(p => p.Amount).HasPrecision(18, 0);
            builder.Property(p => p.VnpTxnRef).HasMaxLength(50).IsUnicode(false).IsRequired();
            builder.Property(p => p.VnpTransactionNo).HasMaxLength(50).IsUnicode(false);
            builder.Property(p => p.Status).HasConversion<string>().HasMaxLength(20);

            builder.HasIndex(p => p.VnpTxnRef).IsUnique();

            builder.HasOne(p => p.Booking)
                   .WithMany(b => b.Payments)
                   .HasForeignKey(p => p.BookingId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
