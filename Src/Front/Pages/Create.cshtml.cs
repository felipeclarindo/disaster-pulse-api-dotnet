using DisasterPulseApiDotnet.Src.Application.DTOs;
using DisasterPulseApiDotnet.Src.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.Http.Json;

namespace DisasterPulseApiDotnet.Src.Front.Pages
{
    public class CreateModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;

        [BindProperty]
        public Alert Alert { get; set; } = new Alert
        {
            Id = 0,
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
                return Page();

            try
            {
                var client = _clientFactory.CreateClient("ApiClient");

                var alertDTO = new AlertDTO
                {
                    Topic = Alert.Topic,
                    Description = Alert.Description,
                    CountryId = Alert.CountryId,
                    Criticality = Alert.Criticality,
                };

                var response = await client.PostAsJsonAsync("alerts", alertDTO);

                if (response.IsSuccessStatusCode)
                {
                    SuccessMessage = "Alerta criado com sucesso!";
                    return RedirectToPage("/Create"); // redireciona para forçar novo GET
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    ModelState.AddModelError(string.Empty, $"Erro ao criar alerta: {errorContent}");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Erro inesperado: {ex.Message}");
            }

            return Page();
        }

        private async Task LoadCountryOptionsAsync()
        {
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
                Console.WriteLine($"Erro ao carregar países: {ex.Message}");
            }
        }
    }
}
