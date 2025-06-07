using DisasterPulseApiDotnet.Src.Application.DTOs;
using DisasterPulseApiDotnet.Src.Domain.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace DisasterPulseApiDotnet.Src.Front.Pages
{
    public class DashboardModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;

        public List<Alert> Alerts { get; set; } = new();
        public List<Country> Countries { get; set; } = new();

        public List<string> AlertCountryNames { get; set; } = new();
        public List<int> AlertCountsByCountry { get; set; } = new();

        public Dictionary<string, int> CriticalityCounts { get; set; } = new();
        public DashboardModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task OnGetAsync()
        {
            var client = _clientFactory.CreateClient("ApiClient");

            // Buscar alertas
            var alertsResponse = await client.GetFromJsonAsync<List<Alert>>("alerts");
            Alerts = alertsResponse ?? new List<Alert>();

            // Buscar países
            var countriesResponse = await client.GetFromJsonAsync<List<Country>>("countries");
            Countries = countriesResponse ?? new List<Country>();

            // Agrupar alertas por país (CountryId)
            var grouped = Alerts
                .GroupBy(a => a.CountryId)
                .Select(g => new { CountryId = g.Key, Count = g.Count() })
                .ToList();

            // Mapear CountryId para nome
            AlertCountryNames = grouped.Select(g =>
            {
                var country = Countries.FirstOrDefault(c => c.Id == g.CountryId);
                return country != null ? country.Name : $"País {g.CountryId}";
            })
            .ToList();

            AlertCountsByCountry = grouped.Select(g => g.Count).ToList();

            var criticalsResponse = await client.GetFromJsonAsync<List<AlertCriticalityCountDTO>>(
                "alerts/criticality"
            );
            if (criticalsResponse != null)
            {
                // Mapeia os valores numéricos para string
                CriticalityCounts = criticalsResponse.ToDictionary(
                    c => c.Criticality switch
                    {
                        0 => "Low",
                        1 => "Medium",
                        2 => "High",
                        3 => "Critical",
                        _ => "Unknown",
                    },
                    c => c.Count
                );
            }
            else
            {
                CriticalityCounts = new Dictionary<string, int>();
            }

            foreach (var key in new[] { "Low", "Medium", "High", "Critical" })
            {
                if (!CriticalityCounts.ContainsKey(key))
                    CriticalityCounts[key] = 0;
            }

        }
    }
}
