using SportHub.API.Enums;

namespace SportHub.API.Entities
{
    public class PriceRule
    {
        public int Id { get; set; }
        public DayType DayType { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public decimal PricePerHour { get; set; }

        public int CourtId { get; set; }
        public Court Court { get; set; } = null!;
    }
}
