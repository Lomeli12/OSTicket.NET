<?php
class TicketHelper{
    // Simple function to help get Tickets
    // Made it as it's own class as it'll probably be useful in
    // the future.
    static function getTicketByNumber($number, $email=null) {
        if (is_null($number) || !ctype_digit($number))
            return null;
        $ticket = new Ticket(0);
        $id = $ticket->getIdByNumber($number, $email);
        $ticket->load($id);
        return $ticket;
    }

    static function getTicketInfo($number, $email=null) {
        $ticket = self::getTicketByNumber($number, $email);
        if (is_null($ticket))
            return null;
        return new TicketInfo($ticket->getId(), $ticket->getNumber(), $ticket->getStatusId(), $ticket->getSubject(), $ticket->isOverdue(), $ticket->getCreateDate(), $ticket->isAnswered());
    }

}

class TicketInfo {
    var $id;
    var $number;
    var $status_id;
    var $subject;
    var $overdue;
    var $create_date;
    var $is_answered;

    function TicketInfo($id, $number, $status_id, $subject, $overdue, $create_date, $is_answered) {
        $this->id = $id;
        $this->number = $number;
        $this->status_id = $status_id;
        $this->subject = $subject;
        $this->overdue = $overdue;
        $this->create_date = $create_date;
        $this->is_answered = $is_answered;
    }
}
?>