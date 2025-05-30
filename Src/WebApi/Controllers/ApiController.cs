using DisasterPulseApiDotnet.Src.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DisasterPulseApiDotnet.Src.WebApi.Controllers
{
    [ApiController]
    [Route("api")]
    public class ApiController : ControllerBase
    {
        [HttpGet]
        public Task<ApiDescriptionResponse> GetApiDescription()
        {
            ApiDescriptionResponse response = new ApiDescriptionResponse()
            {
                Status = "Api is running.",
                Version = "1.0.0",
                Description = "This is a sample API for managing countries, alerts and warns.",
                GithubAuthor = "https://github.com/felipeclarindo",
                GithubRepository = "https://github.com/felipeclarindo/disaster-pulse-api-dotnet",
                Name = "Disaster Pulse API",
            };

            return Task.FromResult(response);
        }
    }
}
