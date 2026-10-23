namespace SportHub.API.Entities
{
    public class Court
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;

        public int VenueId { get; set; }
        public Venue Venue { get; set; } = null!;

        public int SportTypeId { get; set; }
        public SportType SportType { get; set; } = null!;

        public ICollection<PriceRule> PriceRules { get; set; } = new List<PriceRule>();
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
        public ICollection<BookingSlot> BookingSlots { get; set; } = new List<BookingSlot>();
    }
}
