using SportHub.API.Enums;

namespace SportHub.API.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public string BookingCode { get; set; } = string.Empty;
        public DateOnly BookingDate { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal DepositAmount { get; set; }
        public BookingStatus Status { get; set; } = BookingStatus.PendingPayment;
        public DateTime ExpiredAt { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public int CustomerId { get; set; }
        public User Customer { get; set; } = null!;

        public int CourtId { get; set; }
        public Court Court { get; set; } = null!;

        public ICollection<BookingSlot> Slots { get; set; } = new List<BookingSlot>();
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();

        public Review? Review { get; set; }
    }
}
