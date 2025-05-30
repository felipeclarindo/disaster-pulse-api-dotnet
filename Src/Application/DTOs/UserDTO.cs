namespace DisasterPulseApiDotnet.Src.Application.DTOs
{
    public class UserDTO
    {
        public required long Id { get; set; }
        public required string Username { get; set; }
        public required string Role { get; set; }

        public UserDTO(long id, string username, string role)
        {
            Id = id;
            Username = username;
            Role = role;
        }
    }
}