using System;

namespace OSTicket.NET {
    public class TicketInfo {
        private string _name, _email, _phone, _subject, _message;
        public TicketInfo(string name, string email, string phone, string subject, string message) {
            this._name = name;
            this._email = email;
            this._phone = phone;
            this._subject = subject;
            this._message = message;
        }

        public string name {
            get { 
                return _name;
            }
        }

        public string email {
            get {
                return this._email;
            }
        }

        public string phone {
            get {
                return this._phone;
            }
        }

        public string subject {
            get {
                return this._subject;
            }
        }

        public string message {
            get {
                return this._message;
            }
        }
    }
}

