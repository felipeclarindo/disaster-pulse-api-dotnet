namespace DisasterPulseApiDotnet.Src.Domain.Entities
{
    public class User
    {
        public required long Id { get; set; }
        public required string Username { get; set; }
        public required string PasswordHash { get; set; }
        public required string Role { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}