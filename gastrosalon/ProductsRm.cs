using System.Xml.Serialization;

namespace gastrosalon
{
    [Serializable]
    [XmlRoot("products")]
    public class Products
    {
        public Products() { }
        [XmlElement("product")]
        public RMGastroProduct[] ProductList { get; set; }

    }
}
