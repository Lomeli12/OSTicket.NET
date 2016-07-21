using System;
using Newtonsoft.Json;

namespace OSTicket.NET {
    public class TicketInfoJson {
        public string id { get; set; }

        public string number { get; set; }

        public string status_id { get; set; }

        public string subject { get; set; }

        public string overdue { get; set; }

        public string is_answered { get; set; }

        public string create_date { get; set; }

        public string url { get; set; }
    }
}

