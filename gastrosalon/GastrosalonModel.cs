
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace gastrosalon
{
   // [DelimitedRecord(",")]
    public class GastrosalonModel
    {
       
        public string Symbol { get; set; }
        public string EAN { get; set; }
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        public string Producent { get; set; }

        //public string Kategoria { get; set; }
        ////public string Kategoria1 { get; set; }
        ////public string Kategoria2 { get; set; }
        ////public string Kategoria3 { get; set; }


        public string Zdjecie { get; set; }
        ////public string ZdjęciDodatkowe { get; set; }
        ////public string ZdjęcieDodatkowe { get; set; }


        //public decimal CenaAnetto { get; set; }
        //public string CenaB { get; set; }
        //public string CenaC { get; set; }
        //public string CenaD { get; set; }
        //public string CenaZ { get; set; }
        //public string Stan { get; set; }
        //public string Widoczność { get; set; }
        //public string Koszyk { get; set; }
        //public string Wielosztuki { get; set; }
        //public string Załącznik { get; set; }
        //public string JednostkaMiary { get; set; }
        //public string Waga { get; set; }
        //public string f_wysokocs { get; set; }
        //public string f_długosc { get; set; }
        //public string f_głębokosc { get; set; }
        //public string f_szerokosc { get; set; }
        //public string f_material { get; set; }
        //public string f_filtr1 { get; set; }
        //public string f_filtr2 { get; set; }
        //public string f_filtr3 { get; set; }
        //public string vat { get; set; }
        //public string tagi { get; set; }
    }
}
