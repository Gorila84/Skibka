// See https://aka.ms/new-console-template for more information
using gastrosalon;
using System.Globalization;
using System.Xml;
using System.Xml.Serialization;

Console.WriteLine("Hello, World!");

ConnectToFtp connectToFtp = new ConnectToFtp();
//connectToFtp.GetDirectoryListing();
//connectToFtp.DownloadStalgastCatalogKMPL202301FileFTP();
//GetDataFromRestoQuality getDataFromRestoQuality = new GetDataFromRestoQuality();
//getDataFromRestoQuality.DeserializeCsvFile();
GetDataToGastrosalon _getData = new GetDataToGastrosalon();
_getData.SerializeHendiToCSV("C:\\Users\\macie\\Downloads\\export_93865_15e247314a5c20ab44abd26dfa7fb7f5_0_0 (1).xml");
    //_getData.Cos();
//_getData.SerializeRMGastroToCsv("RM GASTRO XML products.xml");
//_getData.GetDataFromXmlToGastrosalon();
//_getData.ExportCsv<GastrosalonModel>(_getData.GetDataFromXmlToGastrosalon(), "gastro");