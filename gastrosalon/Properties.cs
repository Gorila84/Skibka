using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace gastrosalon
{
    [XmlRoot(ElementName = "products")]
    public class Properties
    {
        
       
            [XmlArray("product")]
            [XmlArrayItem("property", Type = typeof(Property))]
            
            public Food[] Foods { get; set; }
        

        

    }
    [XmlInclude(typeof(Property))]
   
    public class Food
    {
        [XmlText]
        public string Text { get; set; }
    }

    public class Property : Food { }
  
}
