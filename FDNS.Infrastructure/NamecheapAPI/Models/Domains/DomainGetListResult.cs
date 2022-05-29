using FDNS.Infrastructure.NamecheapAPI.Models.Base;
using System.Xml.Serialization;

namespace FDNS.Infrastructure.NamecheapAPI.Models.Domains
{
    [XmlRoot("DomainGetListResult")]
    public class DomainGetListResult
    {
        [XmlElement("Domain")]
        public Domain[] Domains { get; set; }
    }
}
