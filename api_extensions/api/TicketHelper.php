<?php
class TicketHelper{
    // Simple function to help get Tickets
    // Made it as it's own class as it'll probably be useful in
    // the future.

    // Gets ticket ID via a ticket number. Necessary and stupid
    // because OSTicket gives tickets an ID AND a number that has
    // no relation to the ID.
    static function getTicketByNumber($number, $email=null) {
        if (is_null($number) || !ctype_digit($number))
            return null;
        $ticket = new Ticket(0);
        $id = $ticket->getIdByNumber($number, $email);
        $ticket->load($id);
        return $ticket;
    }

    // Get's a ticket by its number and only get the parts
    // we need as a TicketInfo object
    static function getTicketInfo($number, $email=null) {
        $ticket = self::getTicketByNumber($number, $email);
        if (is_null($ticket))
            return null;

        return new TicketInfo($ticket->getId(), $ticket->getNumber(), $ticket->getStatusId(), $ticket->getSubject(),
            $ticket->isOverdue(), $ticket->getCreateDate(), $ticket->isAnswered(), $ticket->getAssignee(), array_merge($ticket->getMessages(), $ticket->getResponses()));
    }

}

// Just fields with the information needed, nothing special
class TicketInfo {
    var $id;
    var $number;
    var $status_id;
    var $subject;
    var $overdue;
    var $create_date;
    var $is_answered;
    var $assignee;
    var $messages;

    function TicketInfo($id, $number, $status_id, $subject, $overdue, $create_date, $is_answered, $assignee, $messages) {
        $this->id = $id;
        $this->number = $number;
        $this->status_id = $status_id;
        $this->subject = $subject;
        $this->overdue = $overdue;
        $this->create_date = $create_date;
        $this->is_answered = $is_answered;
        $this->assignee = $assignee;
        $this->messages = $messages;
    }
}
?>