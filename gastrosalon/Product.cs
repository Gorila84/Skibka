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
    public class Product
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

        [XmlElement("property")]
        public Properties[] properties { get; set; }    

    }
}
