using System;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace OSTicket.NET {
	public class PostHelper {
		private PostHelper(){
		}

		public static string postOSTicketJson(string url, TicketInfo ticket, string apiKey, bool useHTTP) {
			string value;
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
			Console.WriteLine(apiURL);
			var response = (HttpWebResponse)request.GetResponse();
			value = new StreamReader(response.GetResponseStream()).ReadToEnd();
			return value;
		}

		public static string getPublicIP() {
			var ip = new WebClient().DownloadString("http://icanhazip.com/");
			if (ip.EndsWith("\n"))
				ip = ip.Substring(0, ip.Length - 1);
			return ip;
		}
	}
}

