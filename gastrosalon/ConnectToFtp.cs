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
    }
}
