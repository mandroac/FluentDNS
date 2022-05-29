using System.Xml.Serialization;

namespace FDNS.Infrastructure.NamecheapAPI.Models.DNS
{
    [XmlRoot("DomainDNSSetHostsResult")]
    public class DomainDNSSetHostsResult
    {
        [XmlAttribute]
        public string Domain { get; set; }
        [XmlAttribute]
        public bool IsSuccess { get; set; }
    }
}