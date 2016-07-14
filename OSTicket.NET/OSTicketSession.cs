using System;

namespace OSTicket.NET {
	public class OSTicketSession {
		private string _url, _apikey;
		public OSTicketSession (string url, string apikey) {
			this._apikey = apikey;
			this._url = url;
		}

		public string submitTicket(TicketInfo ticket, bool useHTTP) {
			if (ticket == null) return;
			return PostHelper.postOSTicketJson(URL, ticket, API_KEY, useHTTP);
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

	}
}

