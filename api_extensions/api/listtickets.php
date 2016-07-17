<?php
@chdir(dirname(__FILE__).'/'); //Change dir.
require('api.inc.php');
require('TicketHelper.php');
/*
 * Returns ticket in JSON format. Requester should handle parsing it themselves
 * Ticket Status goes from 1 = Open, 2 = Resolved (and closed), and 3 = Closed
 */
$controller = new ApiController();
$controller->requireApiKey();
if (isset($_GET["id"])) {
    $id = $_GET["id"];
    if (!ctype_digit($id)) {
        echo "Invalid id";
        exit;
    }
    $ticket = TicketHelper::getTicketInfo($id);
    if ($ticket)
        echo json_encode($ticket);
    else
        echo "Something went wrong, help!";
} else
    echo "Missing ticket id";
?>