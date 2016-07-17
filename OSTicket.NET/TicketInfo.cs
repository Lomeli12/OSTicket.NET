using System;
using Newtonsoft.Json;

namespace OSTicket.NET {
    public class TicketInfo {
        private string _id, _number, _status_id, _subject, _overdue, _create_date, _url;

        public TicketInfo() {
            _id = "0";
            _number = "0";
            _status_id = "0";
            _subject = "";
            _overdue = "0";
            _create_date = "";
            _url = "#";
        }

        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        public string ID {
            get {
                return _id;
            }
        }

        [JsonProperty(PropertyName = "number", Required = Required.Always)]
        public string Number {
            get {
                return _number;
            }
        }

        [JsonProperty(PropertyName = "status_id", Required = Required.Always)]
        public string Status_ID {
            get {
                return _status_id;
            }
        }

        [JsonProperty(PropertyName = "subject", Required = Required.Always)]
        public string Subject {
            get {
                return _subject;
            }
        }

        [JsonProperty(PropertyName = "overdue", Required = Required.Always)]
        public string Overdue {
            get {
                return _overdue;
            }
        }

        [JsonProperty(PropertyName = "create_date", Required = Required.Always)]
        public string Creation_Date {
            get {
                return _create_date;
            }
        }

        public string URL {
            get {
                return _url;
            }
            set {
                _url = value;
            }
        }
    }
}

