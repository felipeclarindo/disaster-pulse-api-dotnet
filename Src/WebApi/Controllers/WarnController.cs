using DisasterPulseApiDotnet.Src.Infra.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DisasterPulseApiDotnet.Src.Domain.Entities
{
    [ApiController]
    [Route("api/warns")]
    public class WarnController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public WarnController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Warn>>> GetAll()
        {
            return Ok(await _context.Warns.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Warn>> GetById(long id)
        {
            var warn = await _context.Warns.FindAsync(id);
            if (warn == null) return NotFound();
            return Ok(warn);
        }

        [HttpPost]
        public async Task<ActionResult<Warn>> Create(Warn warn)
        {
            _context.Warns.Add(warn);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = warn.Id }, warn);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, Warn warn)
        {
            if (id != warn.Id) return BadRequest();
            _context.Entry(warn).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var warn = await _context.Warns.FindAsync(id);
            if (warn == null) return NotFound();
            _context.Warns.Remove(warn);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}