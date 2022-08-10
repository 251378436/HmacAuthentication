namespace Server.Models.Client
{
    public class MapperRequest
    {
        public int SpecialId { get; set; }
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Manufacturer { get; set; }
        public DateTime MadeDate { get; set; }
    }
}
