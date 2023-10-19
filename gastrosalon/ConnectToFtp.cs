using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace gastrosalon
{
    public class ConnectToFtp
    {
        public string[] GetDirectoryListing()
        {
            FtpWebRequest directoryListRequest = (FtpWebRequest)WebRequest.Create("ftp://ftp.stalgast.com:22");
            directoryListRequest.Method = WebRequestMethods.Ftp.ListDirectory;
            directoryListRequest.Credentials = new NetworkCredential("dystrybutor", "wS;h9[Mv6#>}G,(");

            using (FtpWebResponse directoryListResponse = (FtpWebResponse)directoryListRequest.GetResponse())
            {
                using (StreamReader directoryListResponseReader = new StreamReader(directoryListResponse.GetResponseStream()))
                {
                    string responseString = directoryListResponseReader.ReadToEnd();
                    string[] results = responseString.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                    return results;
                }
            }
        }
        public void DownloadStalgastCatalogKS50FileFTP()
        {
            string inputfilepath = @"E:\stalgast_catalog_KS50.xml";
            string ftphost = "ftp.stalgast.com:22";
            string ftpfilepath = "/XML/KS50/stalgast_catalog.xml";

            string ftpfullpath = "ftp://" + ftphost + ftpfilepath;

            using (WebClient request = new WebClient())
            {
                request.Credentials = new NetworkCredential("dystrybutor", "wS;h9[Mv6#>}G,(");
                byte[] fileData = request.DownloadData(ftpfullpath);

                using (FileStream file = File.Create(inputfilepath))
                {
                    file.Write(fileData, 0, fileData.Length);
                    file.Close();
                }
                Console.WriteLine("Download Complete");
            }
        }

        public void DownloadStalgastCatalogKMPL202301FileFTP()
        {
            string inputfilepath = @"E:\stalgast_catalog_KMPL_2023_01.xml";
            string ftphost = "ftp.stalgast.com:22";
            string ftpfilepath = "/XML/KMPL_2023_01/stalgast_catalog.xml";

            string ftpfullpath = "ftp://" + ftphost + ftpfilepath;

            using (WebClient request = new WebClient())
            {
                request.Credentials = new NetworkCredential("dystrybutor", "wS;h9[Mv6#>}G,(");
                byte[] fileData = request.DownloadData(ftpfullpath);

                using (FileStream file = File.Create(inputfilepath))
                {
                    file.Write(fileData, 0, fileData.Length);
                    file.Close();
                }
                Console.WriteLine("Download Complete");
            }
        }
    }
}
