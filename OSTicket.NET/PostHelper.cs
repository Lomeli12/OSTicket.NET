using System;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace OSTicket.NET {
    public class PostHelper {
        private PostHelper(){
        }

        public static string postKey(string url, string apiKey) {
            string apiURL = url + "/api/validate.php";
            var request = (HttpWebRequest)WebRequest.Create(apiURL);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Headers.Add("X-API-KEY", apiKey);
            var response = (HttpWebResponse)request.GetResponse();
            return new StreamReader(response.GetResponseStream()).ReadToEnd();
        }
            
        public static string postOSTicketJson(string url, TicketInfo ticket, string apiKey, bool useHTTP) {
            string apiURL = url + (useHTTP ? "/api/http.php/tickets.json" : "/api/tickets.json");
            var request = (HttpWebRequest)WebRequest.Create(apiURL);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Headers.Add("X-API-KEY", apiKey);
            using (var stream = new StreamWriter(request.GetRequestStream())) {
                stream.Write(JsonConvert.SerializeObject(ticket));
                stream.Flush();
                stream.Close();
            }
            var response = (HttpWebResponse)request.GetResponse();
            return new StreamReader(response.GetResponseStream()).ReadToEnd();
        }

        public static string getPublicIP() {
            var ip = new WebClient().DownloadString("http://icanhazip.com/");
            if (ip.EndsWith("\n"))
                ip = ip.Substring(0, ip.Length - 1);
            return ip;
        }
    }
}

