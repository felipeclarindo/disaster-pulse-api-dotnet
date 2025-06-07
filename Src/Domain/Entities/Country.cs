namespace DisasterPulseApiDotnet.Src.Domain.Entities
{
    public class Country
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public List<Alert> Alerts { get; set; } = new List<Alert>();
    }
}
