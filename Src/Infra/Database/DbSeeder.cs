using DisasterPulseApiDotnet.Src.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DisasterPulseApiDotnet.Src.Infra.Database
{
    public static class DbSeeder
    {
        public static async Task SeedCountriesAsync(DbContext context)
        {
            var count = await context.Set<Country>().CountAsync();

            if (count == 0)
            {
                var countries = new List<Country>
                {
                    new Country { Name = "Brasil" },
                    new Country { Name = "Estados Unidos" },
                    new Country { Name = "Canadá" },
                    new Country { Name = "Alemanha" },
                    new Country { Name = "Japão" },
                };

                await context.Set<Country>().AddRangeAsync(countries);
                await context.SaveChangesAsync();
            }
        }
    }
}
