using System.Xml.Serialization;

namespace gastrosalon
{
    [Serializable]
    [XmlRoot("offers")]
    public class Offers
    {
        public Offers() { }

        [XmlElement("offer")]
        public Offer[] List { get; set; }
    }
}