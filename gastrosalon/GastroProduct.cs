using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace gastrosalon
{
    [Serializable]
    [XmlRoot("offer")]
    public class Offer
    {
        [XmlElement("id")]
        public string Id { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("description")]
        public string Description { get; set; }

        [XmlElement("ean")]
        public string Ean { get; set; }

        [XmlElement("image")]
        public string Image { get; set; }

        [XmlElement("price")]
        public string Price { get; set; }
        [XmlAttribute("Opakowanie")]
        public string Opakowanie { get; set; }
        [XmlAttribute("Wymiary")]
        public string Wymiary { get; set; }

        [XmlAttribute("Pojemność")]
        public string Pojemność { get; set; }

        [XmlAttribute("categoryId")]
        public string CategoryId { get; set; }

        [XmlAttribute("productCode")]
        public string ProductCode { get; set; }

        [XmlAttribute("largeSize")]
        public string LargeSize { get; set; }

        [XmlAttribute("tillStockLasts")]
        public string TillStockLasts { get; set; }

        [XmlAttribute("productId")]
        public string ProductId { get; set; }

        [XmlAttribute("basePrice")]
        public string BasePrice { get; set; }
        [XmlElement("attribs")]
        public string Attribs { get; set; }
        [XmlElement("category")]
        public string Category { get; set; }
        [XmlElement("producer")]
        public string Producer { get; set; }
        [XmlElement("availability")]
        public string Availability { get; set; }
        [XmlElement("warranty")]
        public string Warranty { get; set; }
        [XmlElement("files")]
        public string files { get; set; }
        [XmlArray("images")]
        public Image[] Images { get;set; } 


    }

    [Serializable]
    [XmlRoot("image")]
    public class Image
    {
        [XmlElement("url")]
        public string Url { get; set; }
    }
}
