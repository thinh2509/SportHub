using SportHub.API.Enums;

namespace SportHub.API.Entities
{
    public class Venue
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public string? Description { get; set; }
        public TimeOnly OpenTime { get; set; }
        public TimeOnly CloseTime { get; set; }
        public VenueStatus Status { get; set; } = VenueStatus.Pending;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public int OwnerId { get; set; }
        public User Owner { get; set; } = null!;

        public ICollection<Court> Courts { get; set; } = new List<Court>();
    }
}
