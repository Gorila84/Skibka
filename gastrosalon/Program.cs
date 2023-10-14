// See https://aka.ms/new-console-template for more information
using gastrosalon;
using System.Globalization;
using System.Xml;
using System.Xml.Serialization;

Console.WriteLine("Hello, World!");

GetDataToGastrosalon _getData = new GetDataToGastrosalon();
_getData.SerializeToCsv("RM GASTRO XML products.xml");
//_getData.GetDataFromXmlToGastrosalon();
//_getData.ExportCsv<GastrosalonModel>(_getData.GetDataFromXmlToGastrosalon(), "gastro");