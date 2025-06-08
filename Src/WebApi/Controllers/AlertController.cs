using DisasterPulseApiDotnet.Src.Application.DTOs;
using DisasterPulseApiDotnet.Src.Domain.Entities;
using DisasterPulseApiDotnet.Src.Infra.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DisasterPulseApiDotnet.Src.WebApi.Controllers
{
    [ApiController]
    [Route("api/alerts")]
    public class AlertController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AlertController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Alert>>> GetAll()
        {
            return Ok(await _context.Alerts.AsNoTracking().ToListAsync());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Alert), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Alert>> GetById(long id)
        {
            var alert = await _context.Alerts.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);
            if (alert == null) return NotFound();
            return Ok(alert);
        }

        [HttpGet("criticality")]
        public ActionResult<List<AlertCriticalityCountDTO>> GetCriticalityCounts()
        {
            var counts = Enum.GetValues(typeof(Criticality))
                .Cast<Criticality>()
                .Select(criticality => new AlertCriticalityCountDTO
                {
                    Criticality = (int)criticality,
                    Count = _context.Alerts.Count(a => a.Criticality == criticality),
                })
                .ToList();

            return Ok(counts);
        }

        [HttpPost]
        public async Task<ActionResult<Alert>> Create([FromBody] AlertDTO alertDTO)
        {
            if (alertDTO == null)
                return BadRequest("Alert data is required.");

            var country = await _context.Countries.FindAsync(alertDTO.CountryId);
            if (country == null)
                return BadRequest("Invalid country ID.");

            var alert = new Alert
            {
                Description = alertDTO.Description,
                Topic = alertDTO.Topic,
                CountryId = alertDTO.CountryId,
                Criticality = alertDTO.Criticality,
            };

            _context.Alerts.Add(alert);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = alert.Id }, alert);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] AlertDTO alertDTO)
        {
            var alert = await _context.Alerts.FindAsync(id);
            if (alert == null) return NotFound();

            var country = await _context.Countries.FindAsync(alertDTO.CountryId);
            if (country == null)
                return BadRequest("Invalid country ID.");

            alert.Topic = alertDTO.Topic;
            alert.Description = alertDTO.Description;
            alert.CountryId = alertDTO.CountryId;
            alert.Criticality = alertDTO.Criticality;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var alert = await _context.Alerts.FindAsync(id);
            if (alert == null) return NotFound();

            _context.Alerts.Remove(alert);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}