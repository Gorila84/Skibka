
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
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
        //    public List<GastrosalonModel> GetDataFromXmlToGastrosalon()
        //    {
        //        XmlDocument xml = new XmlDocument();
        //        xml.Load("export.xml");
        //        XmlNodeList productList = xml.DocumentElement.SelectNodes("offer");
        //        IList<GastrosalonModel> products = new List<GastrosalonModel>();
        //        var culture = new CultureInfo("en-US");
        //        string price;
        //        string producent;
        //        string imageUrl;
        //        string ean;
        //        int row = 0;
        //        foreach (XmlNode product in productList)
        //        {
        //            //if (product["price"].ChildNodes[0].InnerText != "")
        //            //{
        //            //    price = product["price"].ChildNodes[0].InnerText;
        //            //}
        //            //else
        //            //{
        //            //    price = "0,00";
        //            //}

        //            if (product["producer"].ChildNodes[0].InnerText != "")
        //            {
        //                 producent = product["producer"].ChildNodes[0].InnerText;
        //            }
        //            else
        //            {
        //                producent = " ";
        //            }
        //            if (product["image"].IsEmpty)
        //            {
        //                imageUrl = " ";
        //            }
        //            else if (product["image"].ChildNodes[0].InnerText != "")
        //            {
        //                imageUrl = product["image"].ChildNodes[0].InnerText;
        //            }
        //            else
        //            {
        //                imageUrl = " ";
        //            }
        //            if (product["ean"] != null)
        //            {
        //                ean = product["ean"].ChildNodes[0].InnerText;
        //            }
        //            else
        //            {
        //                ean = " ";
        //            }
        //            GastrosalonModel productsFromXml = new GastrosalonModel()
        //            {
        //                Symbol = product["id"].ChildNodes[0].InnerText,
        //                EAN = ean,
        //                Nazwa = product["name"].ChildNodes[0].InnerText,
        //                Opis = product["description"].ChildNodes[0].InnerText,
        //                Producent = producent,
        //                Zdjecie = imageUrl
        //                //CenaAnetto = Convert.ToDecimal(product["price"])


        //            };
        //            products.Add(productsFromXml);
        //            //foreach (var item in products)
        //            //{
        //            //    Console.WriteLine(item.Symbol + ' ' + item.Nazwa + ' ' + item.Opis);
        //            //    Console.WriteLine(row++);
        //            //}

        //        }



        //        Console.WriteLine("koniec");
        //        return products.ToList();

        //    }

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
                    header += prop.Name + "| ";
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
                    line += prop.GetValue(obj, null) + "| ";
                }
                line = line.Substring(0, line.Length - 2);
                sb.AppendLine(line);
                TextWriter sw = new StreamWriter(finalPath, true);
                sw.Write(sb.ToString());
                sw.Close();
            }
        }
    


        public void DeserializeRMXmlFile()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Products));
            StreamReader sr = new StreamReader("Bartscher_XML_2023_09_12.xml");
            string xml = File.ReadAllText("Bartscher_XML_2023_09_12.xml");

            using (TextReader reader = new StringReader(xml))
            {
                var products = (ProductBartsher)xmlSerializer.Deserialize(reader);
               
            }

            

        }


        public void SerializeRMGastroToCsv(string fileName)
        {
           
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Products));
                var data = (Products)serializer.Deserialize(fs);
                
                List<GastroSalonCSV> list = new List<GastroSalonCSV>();

                string waga = "";
                string zastosowanie = "";

                foreach(var item in data.ProductList)
                {
                    foreach (var property in item.Property)
                    {
                        if (property.Name == "Waga (kg)" && property.Text is not null)
                        {
                            waga = property.Text.ToString(); 
                        }
                        else
                        {
                            waga = "";
                        }

                        if(property.Name == "Zastosowanie" && property.Text is not null)
                        {
                            zastosowanie = property.Text.ToString();
                        }
                        else
                        {
                            zastosowanie = "";
                        }

                    }

                    GastroSalonCSV csvColumns = new GastroSalonCSV()
                    {
                        Symbol = item.Itemcode.ToString(),
                        f_pojemność = "",
                        f_kolor = "",
                        kont_pojemość = "",
                        kont_kolor = "",
                        EAN = item.Itemcode.ToString(),
                        Nazwa = item.Name.ToString(),
                        Opis = item.Description.ToString(),
                        Producent = "RM Gastro",
                        Kategoria = item.Group.ToString(),
                        Kategoria1 = "",
                        Kategoria2 = "", 
                        Kategoria3 = "",
                        Zdjęcie = item.Image.ToString(),
                        ZdjęcieDodatkowe = "",
                        ZdjęcieDodatkowe1 = "",
                        CenaA = item.Price.ToString(),
                        CenaB = "",
                        CenaC = "",
                        CenaD = "",
                        CenaZ = "",
                        Stan = "",
                        Widoczny = "tak",
                        Koszyk = "",
                        Wielosztuki = "",
                        Załącznik = "",
                        JednostkaMiary = "",
                        Waga = waga,
                        f_wysokość = "",
                        f_długość = "",
                        f_szerokość = "",
                        f_materiał = "",
                        f_filtr1 = zastosowanie,
                        f_filtr2 = "",
                        f_filtr3 = "",
                        vat = "",
                        tagi = ""

                    };
                    list.Add(csvColumns);
                    
                   
                   
                }

                list = list.ToList();

                
                string finalPath = @"E:\RMGASTRO";
                string header = "";
                ExportCsv<GastroSalonCSV>(list, finalPath);



            }
        }
    
    
    
        public void Cos()
        {
            XmlDocument xml = new XmlDocument();
            xml.Load("Bartscher_XML_2023_09_12.xml");
            XmlNodeList productList = xml.DocumentElement.SelectNodes("product");
            IList<GastroSalonCSV> products = new List<GastroSalonCSV>();
            string empty;
            string name = "";
            
            string image1 = "";
            string image2 = "";
            string image3 = "";
            string category = "";
            string category1 = "";
            string category2 = "";
            string category3 = "";
            string code = "";
            string price = "";
            string netHigh = "";
            string depth = "";
            string width = "";
            foreach (XmlNode product in productList)
            {
                foreach (XmlNode item in product["name"]["value"])
                {

                    if (item.Attributes["lang"].Value == "pl")
                    {
                        name = item.InnerText;
                        
                    }
                    
                }
                if (product["category1"] != null)
                {

                    foreach (XmlNode item in product["category1"]["value"])
                    {

                        if (item.Attributes["lang"].Value == "pl")
                        {
                            category = item.InnerText;

                        }

                    }
                }

                if (product["category2"] != null)
                {
                    foreach (XmlNode item in product["category2"]["value"])
                    {

                        if (item.Attributes["lang"].Value == "pl")
                        {
                            category1 = item.InnerText;

                        }

                    }
                }

                if (product["category3"] != null)
                {
                    foreach (XmlNode item in product["category3"]["value"])
                    {

                        if (item.Attributes["lang"].Value == "pl")
                        {
                            category2 = item.InnerText;

                        }

                    }
                }
                if (product["category4"] != null)
                {
                    foreach (XmlNode item in product["category4"]["value"])
                    {

                        if (item.Attributes["lang"].Value == "pl")
                        {
                            category3 = item.InnerText;

                        }

                    }
                }

                if (product["Image1"] != null)
                {
                    image1 = product["Image1"].ChildNodes[0].InnerText;
                }

                if (product["Image2"] != null)
                {
                    image1 = product["Image2"].ChildNodes[0].InnerText;
                }
                if (product["Image3"] != null)
                {
                    image1 = product["Image3"].ChildNodes[0].InnerText;
                }
                if (product["code"] != null)
                {
                    code = product["code"].ChildNodes[0].InnerText;
                }
                if(product["listPrice"] != null)
                {
                    price = product["listPrice"].ChildNodes[0].InnerText;
                }

                if(product["netHeight"] != null)
                {
                    netHigh = product["netHeight"].ChildNodes[0].InnerText;
                }

                if(product["netDepth"] != null)
                {
                    depth = product["netDepth"].ChildNodes[0].InnerText;
                }

                if(product["netWidth"] != null)
                {
                    width = product["netWidth"].ChildNodes[0].InnerText;
                }

                GastroSalonCSV csvColumns = new GastroSalonCSV()
                {
                    Symbol = code,
                    f_pojemność = "",
                    f_kolor = "",
                    kont_pojemość = "",
                    kont_kolor = "",
                    EAN = "",
                    Nazwa = name.ToString(),
                    Opis = "",
                    Producent = "Bartscher",
                    Kategoria = category,
                    Kategoria1 = category + @"\" + category1,
                    Kategoria2 = category + @"\" + category1 + @"\" + category2,
                    Kategoria3 = category + @"\" + category1 + @"\" + category2 + @"\" + category2,
                    Zdjęcie = image1,
                    ZdjęcieDodatkowe = image2,
                    ZdjęcieDodatkowe1 = image3,
                    CenaA = price,
                    CenaB = "",
                    CenaC = "",
                    CenaD = "",
                    CenaZ = "",
                    Stan = "",
                    Widoczny = "tak",
                    Koszyk = "",
                    Wielosztuki = "",
                    Załącznik = "",
                    JednostkaMiary = "",
                    Waga = "",
                    f_wysokość = netHigh,
                    f_długość = depth,
                    f_szerokość =width,
                    f_materiał = "",
                    f_filtr1 = "",
                    f_filtr2 = "",
                    f_filtr3 = "",
                    vat = "",
                    tagi = ""

                };

                products.Add(csvColumns);



            }
            string finalPath = @"E:\Bartscher";
            string header = "";
            ExportCsv<GastroSalonCSV>(products.ToList(), finalPath);
            
        }
    }
}
