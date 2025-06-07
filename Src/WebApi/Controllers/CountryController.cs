using DisasterPulseApiDotnet.Src.Application.DTOs;
using DisasterPulseApiDotnet.Src.Infra.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DisasterPulseApiDotnet.Src.Domain.Entities
{
    [ApiController]
    [Route("api/countries")]
    public class CountryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CountryController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Country>>> GetAll()
        {
            return Ok(await _context.Countries.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Country>> GetById(long id)
        {
            var country = await _context.Countries.FindAsync(id);
            if (country == null) return NotFound();
            return Ok(country);
        }

        [HttpPost]
        public async Task<ActionResult<Country>> Create([FromBody] CountryDTO country)
        {
            Country countryToCreate = new Country
            {
                Id = country.Id,
                Name = country.Name,
                Alerts = new List<Alert>(),
            };
            _context.Countries.Add(countryToCreate);
            await _context.SaveChangesAsync();
            return CreatedAtAction(
                nameof(GetById),
                new { id = countryToCreate.Id },
                countryToCreate
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] Country country)
        {
            if (id != country.Id) return BadRequest();
            _context.Entry(country).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var country = await _context.Countries.FindAsync(id);
            if (country == null) return NotFound();
            _context.Countries.Remove(country);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}