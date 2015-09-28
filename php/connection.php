<?php
$dbhost='localhost';
$dbuser='root';
$dbpass='';
$db = 'slac';

$conn = mysqli_connect($dbhost,$dbuser,$dbpass, $db);
if (!$conn) {
	echo "Error connecting to Database";
	exit;
}
//mysql_select_db($db);
?>