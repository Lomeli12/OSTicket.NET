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
            var request = setupPostRequest(apiURL, apiKey);
            var response = (HttpWebResponse)request.GetResponse();
            return new StreamReader(response.GetResponseStream()).ReadToEnd();
        }
            
        public static string postOSTicketJson(string url, TicketInfo ticket, string apiKey, bool useHTTP) {
            string apiURL = url + (useHTTP ? "/api/http.php/tickets.json" : "/api/tickets.json");
            var request = setupPostRequest(apiURL, apiKey);
            request.ContentType = "application/json";
            using (var stream = new StreamWriter(request.GetRequestStream())) {
                stream.Write(JsonConvert.SerializeObject(ticket));
                stream.Flush();
                stream.Close();
            }
            var response = (HttpWebResponse)request.GetResponse();
            return new StreamReader(response.GetResponseStream()).ReadToEnd();
        }

        public static string postGetTicket(string url, string apiKey, int id) {
            string apiURL = url + "/api/listtickets.php?id=" + id;
            var request = setupPostRequest(apiURL, apiKey);
            var response = (HttpWebResponse)request.GetResponse();
            return new StreamReader(response.GetResponseStream()).ReadToEnd();
        }

        private static HttpWebRequest setupPostRequest(string url, string apiKey) {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.Headers.Add("X-API-KEY", apiKey);
            return request;
        }

        public static string getPublicIP() {
            var ip = new WebClient().DownloadString("http://icanhazip.com/");
            if (ip.EndsWith("\n"))
                ip = ip.Substring(0, ip.Length - "\n".Length);
            return ip;
        }
    }
}

