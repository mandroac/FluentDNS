using FDNS.Infrastructure.NamecheapAPI.Models.Base;
using System.Xml.Serialization;

namespace FDNS.Infrastructure.NamecheapAPI.Models.DNS
{
    [XmlRoot("DomainDNSGetHostsResult")]
    public class DomainDNSGetHostsResult
    {
        [XmlAttribute]
        public string Domain { get; set; }
        [XmlAttribute]
        public bool IsUsingOurDNS { get; set; }
        [XmlElement("host")]
        public Host[] Hosts { get; set; }
    }
}
