using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace gastrosalon
{
    [Serializable]
    [XmlRoot("products")]
    public class ProductBartsher
    {
        public ProductBartsher() { }
        [XmlElement("product")]
        public ProductsBartsher[] ProductList { get; set; }
    }
}
