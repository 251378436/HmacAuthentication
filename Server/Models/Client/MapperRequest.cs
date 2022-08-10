namespace Server.Models.Client
{
    public class MapperRequest
    {
        public string? IdpUserReference { get; set; }
        public string? Title { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Email { get; set; }
        public string? Mobile { get; set; }
    }
}