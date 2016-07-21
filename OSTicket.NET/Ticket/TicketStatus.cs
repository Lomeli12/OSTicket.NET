using System;

namespace OSTicket.NET {
    public enum TicketStatus {
        OPEN,
        RESOLVED,
        CLOSED,
        UNKNOWN // Only used when a nonsensical number is recieved.
    }
}

