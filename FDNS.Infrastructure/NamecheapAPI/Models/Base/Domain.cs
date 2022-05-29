using System.Xml.Serialization;

namespace FDNS.Infrastructure.NamecheapAPI.Models.Base
{
    public class Domain
    {
        [XmlAttribute]
        internal int ID { get; set; }
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public string User { get; set; }
        [XmlAttribute]
        public string Created { get; set; }
        [XmlAttribute]
        public string Expires { get; set; }
        [XmlAttribute]
        public bool IsExpired { get; set; }
        [XmlAttribute]
        public bool IsLocked { get; set; }
        [XmlAttribute]
        public bool AutoRenew { get; set; }
        [XmlAttribute]
        public string WhoisGuard { get; set; }
        [XmlAttribute]
        public bool IsOurDNS { get; set; }
    }
}
