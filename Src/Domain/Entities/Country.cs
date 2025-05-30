namespace DisasterPulseApiDotnet.Src.Domain.Entities
{
    public class Country
    {
        public required long Id { get; set; }
        public required string Name { get; set; }
        public required string? Region { get; set; }
    }
}