using System.Xml.Serialization;

namespace FDNS.Infrastructure.NamecheapAPI.Models.DNS
{
    [XmlRoot]
    public class DomainDNSSetDefaultResult
    {
        [XmlAttribute]
        public string Domain { get; set; }
        [XmlAttribute]
        public bool Updated { get; set; }
    }
}