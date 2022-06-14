namespace FDNS.WebAPI.Models.Domains
{
    public class HostRecord
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Address { get; set; }
        public int MXPref { get; set; }
        public int TTL { get; set; }
    }
}