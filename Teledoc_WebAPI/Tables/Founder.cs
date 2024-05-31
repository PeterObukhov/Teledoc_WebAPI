namespace Teledoc_WebAPI.Tables
{
    public class Founder
    {
        public int Id { get; set; }
        public string INN { get; set; }
        public string Name { get; set; }
        public DateTime? DateOfAddition { get; set; }
        public DateTime? DateOfUpdate { get; set; }
        public int ClientId { get; set; }
        public Client? Client { get; set; }
    }
}
