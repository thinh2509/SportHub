namespace SportHub.API.Entities
{
    public class SportType
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<Court> Courts { get; set; } = new List<Court>();
    }
}
