namespace SportHub.API.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        // Role
        public int RoleId { get; set; }
        public Role Role { get; set; } = null!;
        
        // Venue
        public ICollection<Venue> OwnedVenues { get; set; } = new List<Venue>();
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
        public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
    }
}
