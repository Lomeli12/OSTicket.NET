using System;

namespace OSTicket.NET {
    public class MessageJson {
        public string id { get; set; }
        public string user_id { get; set; }
        public string poster { get; set; }
        public string source { get; set; }
        public Body body { get; set; }
        public string format { get; set; }
        public string created { get; set; }
        public string name { get; set; }
    }
}

