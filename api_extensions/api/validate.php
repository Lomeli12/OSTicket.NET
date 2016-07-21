<?php
@chdir(dirname(__FILE__).'/'); //Change dir.
require('api.inc.php');

// Just used to validate a key. If key is valid,
// there should be no output. Will output a pretty
// self-explanatory error if something is wrong.
$controller = new ApiController();
$controller->requireApiKey();
?>
