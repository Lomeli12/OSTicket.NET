﻿using System;

namespace OSTicket.NET {
    public class Message {
        int _id, _user_id;
        string _poster, _source, _format, _name;
        Body _body;
        DateTime _created;

        /// <summary>
        /// Convert a MessageJson object to a more usable format with more usable members.
        /// </summary>
        /// <param name="json">Json.</param>
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

