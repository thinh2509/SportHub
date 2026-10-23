namespace SportHub.API.Entities
{
    public class BookingSlot
    {
        public int Id { get; set; }
        public DateOnly SlotDate { get; set; }
        public TimeOnly SlotStart { get; set; }

        public int BookingId { get; set; }
        public Booking Booking { get; set; } = null!;

        public int CourtId { get; set; }
        public Court Court { get; set; } = null!;
    }
}
