namespace DisasterPulseApiDotnet.Src.Domain.Entities
{
    public class ApiDescriptionResponse()
    {
        public string? Status { get; set; }
        public string? Version { get; set; }
        public string? Description { get; set; }
        public string? GithubAuthor { get; set; }
        public string? GithubRepository { get; set; }
        public string? Name { get; set; }
    }
}
