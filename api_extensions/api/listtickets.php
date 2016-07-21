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

// Gets id from url (example : listtickets.php?id=IDHERE
if (isset($_GET["id"])) {
    $id = $_GET["id"];
    // Check if it's an integer. Exit out if it isn't
    if (!ctype_digit($id)) {
        echo "Invalid id";
        exit;
    }
    // Attempt to get ticket info and output it as JSON.
    $ticket = TicketHelper::getTicketInfo($id);
    if ($ticket)
        echo json_encode($ticket);
    else
        echo "Could not find ticket with id ".$id;
} else
    echo "Missing ticket id";
?>