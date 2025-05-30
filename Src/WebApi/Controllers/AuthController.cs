using DisasterPulseApiDotnet.Src.Infra.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DisasterPulseApiDotnet.Src.Domain.Entities
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AuthController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public async Task<ActionResult<bool>> Login([FromBody] Credentials credentials)
        {
            if (credentials == null
                || string.IsNullOrWhiteSpace(credentials.Username)
                || string.IsNullOrWhiteSpace(credentials.Password))
            {
                return BadRequest("Invalid credentials.");
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == credentials.Username);

            if (user == null || !BCrypt.Net.BCrypt.Verify(credentials.Password, user.PasswordHash))
            {
                return Unauthorized("Invalid username or password.");
            }

            return Ok(true);
        }
    }

    public class Credentials
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
