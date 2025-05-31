namespace DisasterPulseApiDotnet.Src.Application.DTOs
{
    public class AlertDTO
    {
        public required string? Description { get; set; }
        public required string Topic { get; set; }
        public required long CountryId { get; set; }
        public required Criticality Criticality { get; set; }
    }
}
