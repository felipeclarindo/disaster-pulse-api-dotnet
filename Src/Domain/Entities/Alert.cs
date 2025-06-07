using System.Text.Json.Serialization;

namespace DisasterPulseApiDotnet.Src.Domain.Entities
{
    public class Alert
    {
        public long Id { get; set; }
        public string? Topic { get; set; }
        public string? Description { get; set; }

        public long CountryId { get; set; }
        public Criticality Criticality { get; set; }
        [JsonIgnore]
        public Country? Country { get; set; }
    }
}
