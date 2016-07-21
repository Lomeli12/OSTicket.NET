using System;

namespace OSTicket.NET {
    public class Message {
        private int _id, _user_id;
        private string _poster, _source, _format, _name;
        private Body _body;
        private DateTime _created;

        public Message(MessageJson json) {
            this._id = int.Parse(json.id);
            this._user_id = int.Parse(json.user_id);
            this._poster = json.poster;
            this._body = json.body;
            this._source = json.source;
            this._format = json.format;
            this._created = Convert.ToDateTime(json.created);
            this._name = json.name;
        }

        public int ID {
            get {
                return _id;
            }
        }

        public int UserID {
            get {
                return _user_id;
            }
        }

        public string Poster {
            get {
                return _poster;
            }
        }

        public Body MessageBody {
            get {
                return _body;
            }
        }

        public string Source {
            get {
                return _source;
            }
        }

        public string Format {
            get {
                return _format;
            }
        }

        public DateTime CreationDate {
            get {
                return _created;
            }
        }

        public string Name {
            get {
                return _name;
            }
        }
    }
}

