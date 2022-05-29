namespace FDNS.Common.Configuration
{
    public class NamecheapApiConfiguration
    {
        public NamecheapGlobalParameters Sandbox { get; set; }
        public NamecheapGlobalParameters Production { get; set; }

    }
    public class NamecheapGlobalParameters
    {
        public string ApiServiceUrl { get; set; }
        public string ApiKey { get; set; }
        public string ApiUser { get; set; }
        public string Username { get; set; }
        public string ClientIp { get; set; }
    }
}
