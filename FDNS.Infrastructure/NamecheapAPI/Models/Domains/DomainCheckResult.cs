using System.Xml.Serialization;

namespace FDNS.Infrastructure.NamecheapAPI.Models.Domains
{
    [XmlRoot("DomainCheckResult")]
    public class DomainCheckResult
    {
        [XmlAttribute]
        public string Domain { get; set; }
        [XmlAttribute]
        public bool Available { get; set; }
        [XmlAttribute]
        public bool IsPremiumName { get; set; }
        [XmlAttribute]
        public double PremiumRegistrationPrice { get; set; }
        [XmlAttribute]
        public double PremiumRenewalPrice { get; set; }
        [XmlAttribute]
        public double PremiumRestorePrice { get; set; }
        [XmlAttribute]
        public double PremiumTransferPrice { get; set; }
        [XmlAttribute]
        public double IcannFee { get; set; }
    }
}