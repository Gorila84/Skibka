using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gastrosalon
{
    public class GetDataFromRestoQuality
    {
        //public List<GastroSalonCSV> GetDataForRestoQuality()
        //{
        //    using (var reader = new ChoCSVReader("test.csv").WithFirstLineHeader())
        //    {
        //        foreach (dynamic item in reader)
        //        {
        //            Console.WriteLine(item.Id);
        //            Console.WriteLine(item.Name);
        //        }
        //    }
        //}


        

        public void DeserializeCsvFile()
        {
            GetDataToGastrosalon getDataToGastrosalon = new GetDataToGastrosalon();
                var config = new CsvConfiguration(CultureInfo.CurrentCulture)
                {
                    PrepareHeaderForMatch = args => args.Header.Replace(" ", "")
                };


                using var reader = new StreamReader("Oferta Resto Quality - 10.2023.csv");
                using var csv = new CsvReader(reader, config);

                // Read CSV file
                //var employees = csv.GetRecords<RestoQualityModel>();
                List<GastroSalonCSV> list = new List<GastroSalonCSV>();

                
                var products = csv.GetRecords<dynamic>();
                string category1 = "";
                string category2 = "";
                string category3 = "";
                string visibility = "";
                string image1 = "";
                string image2 = "";
                string image3 = "";
                string description = "";
                string name = "";
                

                foreach (var e in products)
                {
                    string[] tekscik = e.category.Split(">");

                    description = e.description.Replace("|", " ");
                    name = e.name.Replace("|", " ");
                    if(e.images1  != null)
                    {
                        image1 = e.images1;
                    }
                    if (e.images2 != null)
                    {
                        image1 = e.images2;
                    }
                    if (e.images3 != null)
                    {
                        image1 = e.images3;
                    }
                if (tekscik.Length > 1)
                    {
                        category1 = tekscik[0];
                        
                    }
                    
                    if(tekscik.Length > 2)
                    {
                        category2 = $"{tekscik[0]}\\{tekscik[1]}" ;
                    }
                    if (tekscik.Length > 2)
                    {
                        category3 = $"{tekscik[0]}\\{tekscik[1]}\\{tekscik[2]}";
                    }
                    if (int.Parse(e.active) != 1)
                    {
                        visibility = "nie";
                    }
                    else
                    {
                        visibility = "tak";
                    }


                    GastroSalonCSV csvColumns = new GastroSalonCSV()
                    {
                        Symbol = e.product_code,
                        f_pojemność = "",
                        f_kolor = "",
                        kont_pojemość = "",
                        kont_kolor = "",
                        EAN = "",
                        Nazwa = name,
                        Opis = description,
                        Producent = e.producer,
                        Kategoria = category1,
                        Kategoria1 = category2,
                        Kategoria2 = category3,
                        Kategoria3 = "",
                        Zdjęcie = e.images1,
                        ZdjęcieDodatkowe = e.images2,
                        ZdjęcieDodatkowe1 = e.images3,
                        CenaA = e.price,
                        CenaB = "",
                        CenaC = "",
                        CenaD = "",
                        CenaZ = "",
                        Stan = "",
                        Widoczny = visibility,
                        Koszyk = "",
                        Wielosztuki = "",
                        Załącznik = "",
                        JednostkaMiary = "",
                        Waga = "",
                        f_wysokość = "",
                        f_długość = "",
                        f_szerokość = "",
                        f_materiał = "",
                        f_filtr1 = "",
                        f_filtr2 = "",
                        f_filtr3 = "",
                        vat = "",
                        tagi = ""

                    };
                    list.Add(csvColumns);

                }

            getDataToGastrosalon.ExportCsv(list, "E:\\RestoQuality");


            }
        }
    }

