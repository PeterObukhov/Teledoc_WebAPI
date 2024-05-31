namespace Teledoc_WebAPI.Tables
{
    public class Client
    {
        public int Id { get; set; }
        public string INN { get; set; }
        public string ClientName { get; set; }
        public ClientType Type { get; set; }
        public DateTime? DateOfAddition { get; set; }
        public DateTime? DateOfUpdate { get; set; }
        public List<Founder> Founders { get; set; } = new();
    }
}
