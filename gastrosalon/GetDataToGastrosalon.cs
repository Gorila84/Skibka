
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
            StreamReader sr = new StreamReader("RM GASTRO XML products.xml");
            string xml = File.ReadAllText("RM GASTRO XML products.xml");

            using (TextReader reader = new StringReader(xml))
            {
                var products = (Products)xmlSerializer.Deserialize(reader);
               
            }

            

        }


        public void SerializeToCsv(string fileName)
        {
            CsvColumns columns = new CsvColumns();
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Products));
                var data = (Products)serializer.Deserialize(fs);
                
                List<CsvColumns> list = new List<CsvColumns>();

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

                    CsvColumns csvColumns = new CsvColumns()
                    {
                        Symbol = item.Itemcode.ToString(),
                        EAN = item.Itemcode.ToString(),
                        Nazwa = item.Name.ToString(),
                        Opis = item.Description.ToString(),
                        Producent = "RM Gastro",
                        Kategoria = item.Group.ToString(),
                        Kategoria1 = "",
                        Kategoria2 = "",
                        Kategoria3 = "",
                        Zdjecie = item.Image.ToString(),
                        ZdjęciDodatkowe = "",
                        ZdjęcieDodatkowe = "",
                        CenaAnetto = item.Price.ToString(),
                        CenaB = "",
                        CenaC = "",
                        CenaD = "",
                        CenaZ = "",
                        Stan = "",
                        Widoczność = "Y",
                        Koszyk = "",
                        Wielosztuki = "",
                        Załącznik = "",
                        JednostkaMiary = "",
                        Waga = waga,
                        f_wysokocs = "",
                        f_dlugosc = "",
                        f_glebokosc = "",
                        f_szerokosc = "",
                        f_material = "",
                        f_filtr1 = zastosowanie,
                        f_filtr2 = "",
                        f_filtr3 = "",
                        vat = "",
                        tagi = ""


                    };
                    list.Add(csvColumns);
                    
                   
                   
                }

                list = list.ToList();

                var allLines = (from product in list
                                select new object[]
                                {
                                    product.Symbol,
                                    product.EAN,
                                    product.Nazwa,
                                    product.Opis,
                                    product.Producent,
                                    product.Kategoria,
                                    product.Kategoria1,
                                    product.Kategoria2,
                                    product.Kategoria3,
                                    product.Zdjecie,
                                    product.ZdjęciDodatkowe,
                                    product.ZdjęcieDodatkowe,
                                    product.CenaAnetto,
                                    product.CenaB,
                                    product.CenaC,
                                    product.CenaD,
                                    product.CenaZ,
                                    product.Stan,
                                    product.Widoczność,
                                    product.Koszyk,
                                    product.Wielosztuki,
                                    product.Załącznik,
                                    product.JednostkaMiary,
                                    product.Waga,
                                    product.f_wysokocs,
                                    product.f_dlugosc,
                                    product.f_glebokosc,
                                    product.f_szerokosc,
                                    product.f_material,
                                    product.f_filtr1,
                                    product.f_filtr2,
                                    product.f_filtr3,
                                    product.vat,
                                    product.tagi
                                }).ToList();
                string finalPath = @"E:\RMGASTRO.csv";
                string header = "";
                ExportCsv<CsvColumns>(list, finalPath);

                //var csv = new StringBuilder();
                //if (!File.Exists(finalPath))
                //{
                //    var file = File.Create(finalPath);

                //    file.Close();
                //    foreach (var prop in typeof(CsvColumns).GetProperties())
                //    {
                //        header += prop.Name + "| ";
                //    }
                //    header = header.Substring(0, header.Length - 2);
                //    csv.AppendLine(header);
                //    TextWriter sw = new StreamWriter(finalPath, true);
                //    sw.Write(csv.ToString());
                //    sw.Close();
                //}
                
                //allLines.ForEach(line =>
                //{
                //    csv.AppendLine(string.Join("|", line));
                //});

                //File.WriteAllText(finalPath, csv.ToString());


            }
        }
    }
}
