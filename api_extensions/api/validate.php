<?php
@chdir(dirname(__FILE__).'/'); //Change dir.
require('api.inc.php');

$controller = new ApiController();
$controller->requireApiKey();
?>
