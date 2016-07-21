using System;

namespace OSTicket.NET {
    public class OSTicketSession {
        private string _url, _apikey;
        private bool _https, _valid_key;

        public OSTicketSession(string url, string apikey) {
            this._apikey = apikey;
            if (url.EndsWith("/", StringComparison.Ordinal)) url = url.Substring(0, url.Length - 1);
            this._url = url;
            this._https = this._url.StartsWith("https://", StringComparison.OrdinalIgnoreCase);
            this._valid_key = this.validateKey();
        }

        /// <summary>
        /// Validates the api key.
        /// </summary>
        /// <returns><c>true</c>, if key was validated, <c>false</c> otherwise.</returns>
        private bool validateKey() {
            var response = PostHelper.postKey(URL, API_KEY);
            return String.IsNullOrWhiteSpace(response);
        }

        /// <summary>
        /// Submits the ticket to server.
        /// </summary>
        /// <returns>If successful, will return the ID of the newly created ticket.</returns>
        /// <param name="ticket">Ticket.</param>
        /// <param name="useHTTP">If set to <c>true</c> use /api/http.php/tickets.json instead of /api/tickets.json. Should be used if server does NOT have a SSL Certificate.</param>
        public string submitTicket(Ticket ticket, bool useHTTP) {
            if (!KEY_VALID) return null;
            if (ticket == null) return null;
            return PostHelper.postOSTicketJson(URL, ticket, API_KEY, useHTTP);
        }

        public string submitTicket(Ticket ticket) {
            return submitTicket(ticket, !HTTPS);
        }

        public TicketInfo getTicketInfo(int id) {
            return PostHelper.postGetTicketInfo(URL, API_KEY, id);
        }

        public bool HTTPS {
            get {
                return _https;
            }
        }

        public string URL {
            get { 
                return _url; 
            }
        }

        public string API_KEY {
            get { 
                return _apikey; 
            }
        }

        public bool KEY_VALID {
            get {
                return _valid_key;
            }
        }
    }
}

