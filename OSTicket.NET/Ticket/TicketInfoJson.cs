using System;
using System.Collections.Generic;

// Just a median between the json and a usable object
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

        public Staff assignee { get; set; }

        public List<MessageJson> messages { get; set; }
    }
}

