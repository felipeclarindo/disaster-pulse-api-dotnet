using DisasterPulseApiDotnet.Src.Application.DTOs;
using DisasterPulseApiDotnet.Src.Infra.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DisasterPulseApiDotnet.Src.Domain.Entities
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            return Ok(await _context.Users.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetById(long id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<User>> Create([FromBody] UserDTO userDTO)
        {
            if (string.IsNullOrEmpty(userDTO.Username))
                return BadRequest("Username is required.");

            if (string.IsNullOrEmpty(userDTO.Password))
                return BadRequest("Password is required.");

            if (await _context.Users.AnyAsync(u => u.Username == userDTO.Username))
                return BadRequest("Username already exists.");

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(userDTO.Password);

            User user = new User { Username = userDTO.Username, PasswordHash = passwordHash };


            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] UserUpdateDTO updateDTO)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return NotFound();

            if (!string.IsNullOrEmpty(updateDTO.Username))
                user.Username = updateDTO.Username;

            if (!string.IsNullOrEmpty(updateDTO.Password))
                user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(updateDTO.Password);

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return NotFound();

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
