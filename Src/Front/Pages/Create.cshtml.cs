using DisasterPulseApiDotnet.Src.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DisasterPulseApiDotnet.Src.Front.Pages
{
    public class CreateModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;

        [BindProperty]
        public Alert Alert { get; set; } = new();

        public List<SelectListItem> CountryOptions { get; set; } = new();

        public CreateModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public void OnGet()
        {
            CountryOptions = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Brasil" },
                new SelectListItem { Value = "2", Text = "Estados Unidos" },
                new SelectListItem { Value = "3", Text = "Japão" },
            };
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var client = _clientFactory.CreateClient("WebApi");
            var response = await client.PostAsJsonAsync("alerts", Alert);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("Index");
            }

            ModelState.AddModelError(string.Empty, "Erro ao enviar o alerta.");
            return Page();
        }
    }
}
