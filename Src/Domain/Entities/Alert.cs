namespace DisasterPulseApiDotnet.Src.Domain.Entities
{
    public class Alert
    {
        public required long Id { get; set; }
        public required string? Description { get; set; }
        public required long Topic { get; set; }
    }
}
