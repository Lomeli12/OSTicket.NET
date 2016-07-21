using System;
using System.Collections.Generic;

namespace OSTicket.NET {
    public class BodyJson {
        public string body { get; set; }
        public string type { get; set; }
        public List<object> stripped_images { get; set; }
        public List<object> embedded_images { get; set; }
    }
}

