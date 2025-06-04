using DisasterPulseApiDotnet.Src.Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DisasterPulseApiDotnet.Src.Front.Pages
{
    public class CreateModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;

        [BindProperty]
        public AlertDTO Alert { get; set; } =
            new AlertDTO
            {
                Description = string.Empty,
                Topic = string.Empty,
                CountryId = 0,
                Criticality = Criticality.Low,
            };

        public List<SelectListItem> CountryOptions { get; set; } = new();

        [TempData]
        public string? SuccessMessage { get; set; }

        public CreateModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task OnGetAsync()
        {
            await LoadCountryOptionsAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await LoadCountryOptionsAsync();

            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var client = _clientFactory.CreateClient("ApiClient");
                var response = await client.PostAsJsonAsync("alerts", Alert);

                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    SuccessMessage = "Alerta criado com sucesso!";
                    ModelState.Clear();
                    Alert = new AlertDTO
                    {
                        Description = string.Empty,
                        Topic = string.Empty,
                        CountryId = 0,
                        Criticality = Criticality.Low,
                    };
                }

                var errorContent = await response.Content.ReadAsStringAsync();

                Console.WriteLine($"Erro na API: {errorContent}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro inesperado: {ex.Message}");
            }

            return Page();
        }

        private async Task LoadCountryOptionsAsync()
        {
            CountryOptions.Clear();

            try
            {
                var client = _clientFactory.CreateClient("ApiClient");
                var countries = await client.GetFromJsonAsync<List<CountryDTO>>("countries");

                if (countries != null)
                {
                    CountryOptions = countries
                        .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error ao carregar paises: {ex.Message}");
            }
        }
    }
}
