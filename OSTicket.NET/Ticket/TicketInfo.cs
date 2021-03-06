﻿using System;
using System.Collections.Generic;

namespace OSTicket.NET {
    public class TicketInfo {
        static readonly TicketStatus[] VALID_VALUES = { TicketStatus.OPEN, TicketStatus.RESOLVED, TicketStatus.CLOSED };

        int _id, _number;
        TicketStatus _status;
        string _subject, _staff_assigned;
        bool _overdue, _answered;
        DateTime _creation_date;
        Uri _url;
        Message _original_message;
        List<Message> _messages;

        /// <summary>
        /// Converts TicketInfoJson to a more usable object with more usable members.
        /// </summary>
        /// <param name="json">Json.</param>
        public TicketInfo(TicketInfoJson json) {
            this._id = int.Parse(json.id);
            this._number = int.Parse(json.number);
            this._status = getStatusByNum(int.Parse(json.status_id) - 1);
            this._subject = json.subject;
            this._staff_assigned = (json.assignee != null ? json.assignee.name : "Unassigned");
            this._overdue = Convert.ToBoolean(int.Parse(json.overdue));
            this._answered = Convert.ToBoolean(int.Parse(json.is_answered));
            this._creation_date = Convert.ToDateTime(json.create_date);
            this._url = new Uri(json.url);
            this._messages = new List<Message>();
            if (json.messages != null && json.messages.Count > 0) {
                if (json.messages.Count > 0) foreach (MessageJson msgJson in json.messages) this._messages.Add(new Message(msgJson));
                this._messages.Sort((x, y) => DateTime.Compare(x.CreationDate, y.CreationDate));
                this._original_message = this._messages[0];
                this._messages.RemoveAt(0);
            }
            if (this.Status == TicketStatus.OPEN && this.Overdue) this._status = TicketStatus.OVERDUE;
        }

        public int ID {
            get {
                return _id;
            }
        }

        public int Number {
            get {
                return _number;
            }
        }

        public TicketStatus Status {
            get {
                return _status;
            }
        }

        public string Subject {
            get {
                return _subject;
            }
        }

        public string AssignedStaff {
            get {
                return _staff_assigned;
            }
        }

        public bool Overdue {
            get {
                return _overdue;
            }
        }

        public bool Answered {
            get {
                return _answered;
            }
        }

        public DateTime CreationDate {
            get {
                return _creation_date;
            }
        }

        public Uri URL {
            get {
                return _url;
            }
        }

        public Message OriginalMessage {
            get {
                return _original_message;
            }
        }

        public List<Message> Messages {
            get {
                return _messages;
            }
        }

        /// <summary>
        /// Convert the status number recieved from OSTicket into a TicketStatus enum object
        /// </summary>
        /// <returns>The status by number.</returns>
        /// <param name="i">The index.</param>
        static TicketStatus getStatusByNum(int i) {
            if (i < 0 || i >= validValues().Length) return TicketStatus.UNKNOWN;
            return validValues()[i];
        }

        public static TicketStatus[] validValues() {
            return (TicketStatus[])VALID_VALUES.Clone();
        }
    }
}

