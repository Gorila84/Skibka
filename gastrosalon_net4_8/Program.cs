using gastrosalon_net4_8.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gastrosalon_net4_8
{
    internal class Program
    {
        static void Main(string[] args)
        {



            //string xml = File.ReadAllText("stalgast_catalog.xml");
            ////Deserialize the XML back into an object
            //stalgast_catalog catalog = XmlConverter<stalgast_catalog>.ToObject(xml);


            string xml = File.ReadAllText("RM GASTRO XML products.xml");
            //Deserialize the XML back into an object
            products catalog = XmlConverter<products>.ToObject(xml);

<<<<<<< Updated upstream
       }
=======
        }
>>>>>>> Stashed changes
    }
}
