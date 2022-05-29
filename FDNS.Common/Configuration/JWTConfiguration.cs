namespace FDNS.Common.Configuration
{
    public class JWTConfiguration
    {
        public string Key { get; set; }
        public int ExpirationMinutes { get; set; }
        public string Issuer { get; set; }
    }
}