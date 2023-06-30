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
    public class GastroProduct
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("name")] 
        public string Name { get; set; }

        [XmlAttribute("description")]
        public string Description { get; set; }

        [XmlAttribute("ean")]
        public int Ean { get; set; }

        [XmlAttribute("image")]
        public string Image { get; set; }

        [XmlAttribute("price")]
        public decimal Price { get; set; }
       
    }
}
