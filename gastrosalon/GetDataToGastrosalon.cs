using FileHelpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace gastrosalon
{
    public class GetDataToGastrosalon
    {
        public List<GastrosalonModel> GetDataFromXmlToGastrosalon()
        {
            XmlDocument xml = new XmlDocument();
            xml.Load("export.xml");
            XmlNodeList productList = xml.DocumentElement.SelectNodes("offer");
            IList<GastrosalonModel> products = new List<GastrosalonModel>();
            var culture = new CultureInfo("en-US");
            string price;
            string producent;
            string imageUrl;
            string ean;
            int row = 0;
            foreach (XmlNode product in productList)
            {
                Console.WriteLine(product["category"].ChildNodes[0].InnerText.Split(':')[0].Trim());
                string kat2 = product["category"].ChildNodes[0].InnerText;
                string kat1 = product["category"].ChildNodes[0].InnerText;
                string kategoria1 = kat1.Substring(kat1.IndexOf("::") + 3).Split(':')[0].Trim();
                string kategoria2 = kat2.Substring(kat2.LastIndexOf("::") + 3);
                Console.WriteLine(kat1.Substring(kat1.IndexOf("::") + 3).Split(':')[0].Trim());
                Console.WriteLine(kat2.Substring(kat2.LastIndexOf("::") + 3));
                if (product["price"].ChildNodes[0].InnerText != "")
                {
                    price = product["price"].ChildNodes[0].InnerText;
                }
                else
                {
                    price = "0,00";
                }

                if (product["producer"].ChildNodes[0].InnerText != "")
                {
                    producent = product["producer"].ChildNodes[0].InnerText;
                }
                else
                {
                    producent = " ";
                }
                if (product["image"].IsEmpty)
                {
                    imageUrl = " ";
                }
                else if (product["image"].ChildNodes[0].InnerText != "")
                {
                    imageUrl = product["image"].ChildNodes[0].InnerText;
                }
                else
                {
                    imageUrl = " ";
                }
                if (product["ean"] != null)
                {
                    ean = product["ean"].ChildNodes[0].InnerText;
                }
                else
                {
                    ean = " ";
                }
                GastrosalonModel productsFromXml = new GastrosalonModel()
                {
                    Symbol = product["id"].ChildNodes[0].InnerText,
                    EAN = ean,
                    Nazwa = product["name"].ChildNodes[0].InnerText,
                    Opis = product["description"].ChildNodes[0].InnerText,
                    Producent = producent,
                    Kategoria = product["category"].ChildNodes[0].InnerText.Split(':')[0].Trim(),
                    Kategoria1 = kategoria1,
                    Kategoria2 = kategoria2,
                    Kategoria3 = "",
                    Zdjecie = imageUrl,
                    ZdjecieDodatkowe = "",
                    ZdjecieDodatkowe1 = "",
                    CenaAnetto = price,
                    CenaB = "",
                    CenaC = "",
                    CenaD = "",
                    CenaZ = "",
                    Stan = "Nowe",
                    Widoczność = "tak",
                    Koszyk = "",
                    Wielosztuki = "",
                    Załacznik = "",
                    JednostkaMiary = "",
                    Waga = "",
                    f_wysokocs = "",
                    f_dlugosc = "",
                    f_glebokosc = "",
                    f_szerokosc = "",
                    f_material = "",
                    f_filtr1 = "",
                    f_filtr2 = "",
                    f_filtr3 = "",
                    vat = "",
                    tagi = ""

                };
                products.Add(productsFromXml);
                //foreach (var item in products)
                //{
                //    Console.WriteLine(item.Symbol + ' ' + item.Nazwa + ' ' + item.CenaAnetto);
                //    Console.WriteLine(row++);
                //}

            }



            Console.WriteLine("koniec");
            return products.ToList();

        }

        public void ExportCsv<T>(List<T> genericList, string fileName)
        {
            var sb = new StringBuilder();
            var basePath = AppDomain.CurrentDomain.BaseDirectory;
            var finalPath = Path.Combine(basePath, fileName + ".csv");
            var header = "";
            var info = typeof(T).GetProperties();
            if (!File.Exists(finalPath))
            {
                var file = File.Create(finalPath);
                file.Close();
                foreach (var prop in typeof(T).GetProperties())
                {
                    header += prop.Name + "; ";
                }
                header = header.Substring(0, header.Length - 2);
                sb.AppendLine(header);
                TextWriter sw = new StreamWriter(finalPath, true);
                sw.Write(sb.ToString());
                sw.Close();
            }
            foreach (var obj in genericList)
            {
                sb = new StringBuilder();
                var line = "";
                foreach (var prop in info)
                {
                    line += prop.GetValue(obj, null) + "; ";
                }
                line = line.Substring(0, line.Length - 2);
                sb.AppendLine(line);
                TextWriter sw = new StreamWriter(finalPath, true);
                sw.Write(sb.ToString());
                sw.Close();
            }
        }
    }

    //public void DeserializeXmlFile()
    //{
    //    XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<GastroProduct>));
    //    StreamReader sr = new StreamReader("export.xml");
    //    List<GastroProduct> products = (List<GastroProduct>)xmlSerializer.Deserialize(sr);
    //    foreach (GastroProduct product in products)
    //    {
    //        Console.WriteLine("Nazwa: " + product.Name);
    //    }

    //    //XmlRootAttribute xRoot = new XmlRootAttribute();
    //    //xRoot.ElementName = "offers";
    //    //xRoot.IsNullable = true;
    //    //using (StreamReader reader = new StreamReader("export.xml"))
    //    //{
    //    //    List<GastroProduct> result = (List<GastroProduct>)(new XmlSerializer(typeof(List<GastroProduct>), xRoot)).Deserialize(reader);
    //    //    int numOfPersons = result.Count;
    //    //}

    //}
}


    
