using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace OSTicket.NET {
    public class PostHelper {
        PostHelper() {
        }

        /// <summary>
        /// Validates API key using API extension
        /// </summary>
        /// <returns>The key validate.</returns>
        /// <param name="url">URL.</param>
        /// <param name="apiKey">API key.</param>
        public static string postKeyValidate(string url, string apiKey) {
            string apiURL = url + "/api/validate.php";
            var request = setupPostRequest(apiURL, apiKey);
            var response = (HttpWebResponse)request.GetResponse();
            return new StreamReader(response.GetResponseStream()).ReadToEnd();
        }

        /// <summary>
        /// Converts a ticket to JSON, then submits said JSON to OSTicket to make a ticket
        /// </summary>
        /// <returns>The submit ticket.</returns>
        /// <param name="url">URL.</param>
        /// <param name="ticket">Ticket.</param>
        /// <param name="apiKey">API key.</param>
        /// <param name="useHTTP">If set to <c>true</c> use HTTP instead of HTTPS.</param>
        public static string postSubmitTicket(string url, Ticket ticket, string apiKey, bool useHTTP) {
            var content = JsonConvert.SerializeObject(ticket);
            if (!string.IsNullOrWhiteSpace(content)) {
                string apiURL = url + (useHTTP ? "/api/http.php/tickets.json" : "/api/tickets.json");
                var request = setupPostRequest(apiURL, apiKey);
                request.ContentType = "application/json";
                using (var stream = new StreamWriter(request.GetRequestStream())) {
                    stream.Write(content);
                    stream.Flush();
                    stream.Close();
                }
                var response = (HttpWebResponse)request.GetResponse();
                return new StreamReader(response.GetResponseStream()).ReadToEnd();
            }
            return null;
        }

        /// <summary>
        /// Gets basic info on a ticket using the API extension
        /// </summary>
        /// <returns>The get ticket info.</returns>
        /// <param name="url">URL.</param>
        /// <param name="apiKey">API key.</param>
        /// <param name="id">Identifier.</param>
        public static TicketInfo postGetTicketInfo(string url, string apiKey, int id) {
            string apiURL = url + "/api/listtickets.php?id=" + id;
            var request = setupPostRequest(apiURL, apiKey);
            var response = (HttpWebResponse)request.GetResponse();
            var json_response = new StreamReader(response.GetResponseStream()).ReadToEnd();
            var ticket_info = JsonConvert.DeserializeObject<TicketInfoJson>(json_response);
            if (ticket_info != null) ticket_info.url = string.Format("{0}/tickets.php?id={1}", url, ticket_info.id);
            return new TicketInfo(ticket_info);
        }

        /// <summary>
        /// Sets up a basic post request for OSTicket
        /// </summary>
        /// <returns>The post request.</returns>
        /// <param name="url">URL.</param>
        /// <param name="apiKey">API key.</param>
        private static HttpWebRequest setupPostRequest(string url, string apiKey) {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.Headers.Add("X-API-KEY", apiKey);
            return request;
        }
    }
}

