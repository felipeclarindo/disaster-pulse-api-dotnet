using DisasterPulseApiDotnet.Src.Domain.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DisasterPulseApiDotnet.Src.Front.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;

        public List<Alert> Alerts { get; set; } = new();

        public IndexModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task OnGetAsync()
        {
            var client = _clientFactory.CreateClient("ApiClient");
            var response = await client.GetFromJsonAsync<List<Alert>>("alerts");
            Alerts = response ?? new List<Alert>();
        }
    }
}
