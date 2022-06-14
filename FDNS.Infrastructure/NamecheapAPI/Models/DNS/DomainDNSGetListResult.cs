using System.Xml.Serialization;

namespace FDNS.Infrastructure.NamecheapAPI.Models.DNS
{
    [XmlRoot]
    public class DomainDNSGetListResult
    {
        [XmlAttribute("IsUsingOurDNS")]
        public bool IsUsingOurDns { get; set; }
        [XmlElement("Nameserver")]
        public string[] Nameservers { get; set; }
    }
}