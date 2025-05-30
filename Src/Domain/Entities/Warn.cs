namespace DisasterPulseApiDotnet.Src.Domain.Entities
{
    public class Warn
    {
        public required long Id { get; set; }
        public required string Criticality { get; set; }
        public required string? Description { get; set; }
    }
}