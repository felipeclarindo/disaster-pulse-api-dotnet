namespace DisasterPulseApiDotnet.Src.Domain.Entities
{
    public class ApiDescriptionResponse()
    {
        public required string Status { get; set; }
        public required string Version { get; set; }
        public required string Description { get; set; }
        public required string GithubAuthor { get; set; }
        public required string GithubRepository { get; set; }
        public required string Name { get; set; }
    }
}
