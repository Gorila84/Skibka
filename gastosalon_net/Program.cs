using gastosalon_net.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace gastosalon_net
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
              
                stalgast_catalog catalog = new stalgast_catalog();


                string xml =  File.ReadAllText("stalgast_catalog.xml");


                //Deserialize the XML back into an object
                stalgast_catalog myContactAgain = XmlConverter<stalgast_catalog>.ToObject(xml);
            }
            catch(Exception ex) {
            }
         
        }
    }
}
