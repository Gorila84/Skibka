using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace gastrosalon
{
    [Serializable]
    [XmlRoot("product")]
    public class RMGastroProduct
    {
        [XmlElement("itemcode")]
        public int Itemcode { get; set; }

        [XmlElement("code")]
        public string Code { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("description")]
        public string Description { get; set; }

        [XmlElement("price")]
        public string Price { get; set; }

        [XmlElement("image")]
        public string Image { get; set; }

        [XmlElement("group")]
        public string Group { get; set; }

        [XmlElement("instruction")]
        public string Instruction { get; set; }

        //[XmlAttribute("Wymiary_(mm)")]
        //public string Wymiary { get; set; }

        //[XmlAttribute("Moc_(kW)")]
        //public string Moc { get; set; }

        //[XmlAttribute("Waga_(kg)")]
        //public string Waga { get; set; }

        //[XmlAttribute("Zastosowanie")]
        //public string Zastosowanie { get; set; }

        //[XmlAttribute("Pojemność_(szt#)")]
        //public string Pojemność { get; set; }

        //[XmlAttribute("Ø_szklanki_(cm)")]
        //public string WysokośćSzklanki { get; set; }

        [XmlElement(ElementName = "property")]
        public List<Property> Property { get; set; }





    }

    [XmlRoot(ElementName = "property")]
    public class Property
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

}
