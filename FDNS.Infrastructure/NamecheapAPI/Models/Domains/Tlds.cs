using FDNS.Infrastructure.NamecheapAPI.Models.Base;
using System.Xml.Serialization;

namespace FDNS.Infrastructure.NamecheapAPI.Models.Domains
{
    [XmlRoot("Tlds")]
    public class Tlds
    {
        [XmlElement("Tld")]
        public Tld[] TldList { get; set; }
    }
}