using System.Xml.Serialization;

namespace FDNS.Infrastructure.NamecheapAPI.Models.Base
{
    public class Host
    {
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public string Type { get; set; }
        [XmlAttribute]
        public string Address { get; set; }
        [XmlAttribute]
        public int MXPref { get; set; }
        [XmlAttribute]
        public int TTL { get; set; }
    }
}
