using SportHub.API.Enums;

namespace SportHub.API.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string VnpTxnRef { get; set; } = string.Empty;
        public string? VnpTransactionNo { get; set; }
        public PaymentStatus Status { get; set; } = PaymentStatus.Pending;
        public DateTime? PaidAt { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public int BookingId { get; set; }
        public Booking Booking { get; set; } = null!;
    }
}
