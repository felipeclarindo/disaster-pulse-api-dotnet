namespace DisasterPulseApiDotnet.Src.Domain.Entities
{
    public class User
    {
        public long Id { get; set; }
        public required string Username { get; set; }
        public required string PasswordHash { get; set; }
        public UserRole Role { get; set; } = UserRole.USER;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }
}
