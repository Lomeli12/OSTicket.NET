using System;
using Newtonsoft.Json;

namespace OSTicket.NET {
    public class Ticket {
        private string _name, _email, _phone, _subject, _message;

        public Ticket(string name, string email, string phone, string subject, string message) {
            this._name = name;
            this._email = email;
            this._phone = phone;
            this._subject = subject;
            this._message = message;
        }

        [JsonProperty(PropertyName = "name", Required = Required.Always)]
        public string NAME {
            get { 
                return _name;
            }
        }

        [JsonProperty(PropertyName = "email", Required = Required.Always)]
        public string EMAIL {
            get {
                return this._email;
            }
        }

        [JsonProperty(PropertyName = "phone", NullValueHandling = NullValueHandling.Ignore)]
        public string PHONE {
            get {
                return this._phone;
            }
        }

        [JsonProperty(PropertyName = "subject", Required = Required.Always)]
        public string SUBJECT {
            get {
                return this._subject;
            }
        }

        [JsonProperty(PropertyName = "message", Required = Required.Always)]
        public string MESSAGE {
            get {
                return this._message;
            }
        }
    }
}

