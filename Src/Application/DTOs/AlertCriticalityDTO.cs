namespace DisasterPulseApiDotnet.Src.Application.DTOs
{
    public class AlertCriticalityCountDTO
    {
        public required int Criticality { get; set; }
        public int Count { get; set; }
    }
}