using System;

namespace OSTicket.NET {
    public class OSTicketSession {
        private string _url, _apikey;
        private bool _https, _valid_key;

        /// <summary>
        /// Creates a new session with OSTicket and validates key. If key is invalid,
        /// all functions will auto return null values.
        /// </summary>
        /// <param name="url">URL.</param>
        /// <param name="apikey">Apikey.</param>
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
            try {
                var response = PostHelper.postKeyValidate(URL, API_KEY);
                return String.IsNullOrWhiteSpace(response);
            } catch (Exception) {
                return false;
            }
        }

        /// <summary>
        /// Submits the ticket to server.
        /// </summary>
        /// <returns>If successful, will return the ID of the newly created ticket.</returns>
        /// <param name="ticket">Ticket.</param>
        /// <param name="useHTTP">If set to <c>true</c> use /api/http.php/tickets.json instead of /api/tickets.json. Should be used if server does NOT have a SSL Certificate.</param>
        public string submitTicket(Ticket ticket, bool useHTTP) {
            if (!KEY_VALID || ticket == null) return null;
            try {
                return PostHelper.postSubmitTicket(URL, ticket, API_KEY, useHTTP);
            } catch (Exception) {
                return null;
            }
        }

        public string submitTicket(Ticket ticket) {
            return submitTicket(ticket, !HTTPS);
        }

        /// <summary>
        /// Get basic info about a ticket (such as status, subject, creation date, etc)
        /// </summary>
        /// <returns>Basic ticket info</returns>
        /// <param name="id">Ticket id</param>
        public TicketInfo getTicketInfo(int id) {
            if (!KEY_VALID) return null;
            try {
                return PostHelper.postGetTicketInfo(URL, API_KEY, id);
            } catch (Exception) {
                return null;
            }
        }

        /// <summary>
        /// Use HTTPS when making submit ticket requests
        /// </summary>
        public bool HTTPS {
            get {
                return _https;
            } set {
                _https = value;
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

        /// <summary>
        /// Is the API key is valid
        /// </summary>
        public bool KEY_VALID {
            get {
                return _valid_key;
            }
        }
    }
}

