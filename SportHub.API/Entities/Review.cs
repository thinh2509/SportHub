namespace SportHub.API.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public int BookingId { get; set; }
        public Booking Booking { get; set; } = null!;
    }
}
