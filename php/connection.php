<?php

// Try to pull in the config variables from the config file
$config = include $_SERVER['DOCUMENT_ROOT'].'/config.php';
// If that doesn't work, set it here (above wasn't working on server)
if (!isset($config)) {
	$config = array(
	    'dbhost' => 'mysql.ecn.purdue.edu',
	    'dbuser' => '',
	    'dbpassword' => '',
	    'dbname' => 'slac'
	);
}
//INCLUDE IN ALL PHP SCRIPTS

//echo 'Current PHP version: ' . phpversion();

//echo 'Php info' . phpinfo();

$conn = new mysqli($config['dbhost'], $config['dbuser'], $config['dbpassword'], $config['dbname']);
if ($conn->connect_errno) {
    echo "Failed to connect to MySQL: (" . $conn->connect_errno . ") " . $conn->connect_error;
		die();
}
$home = 'Location: /index.php';
$header = 'Location: /simulator.php';


// array of values used
$values = array( "first_name", "last_name", "description",
	"R_125",
	"R_250",
	"R_500",
	"R_750",
	"R_1000",
	"R_1500",
	"R_2000",
	"R_3000",
	"R_4000",
	"R_6000",
	"R_8000",
	"L_125",
	"L_250",
	"L_500",
	"L_750",
	"L_1000",
	"L_1500",
	"L_2000",
	"L_3000",
	"L_4000",
	"L_6000",
	"L_8000",
	"BR_125",
	"BR_250",
	"BR_500",
	"BR_750",
	"BR_1000",
	"BR_1500",
	"BR_2000",
	"BR_3000",
	"BR_4000",
	"BR_6000",
	"BR_8000",
	"BL_125",
	"BL_250",
	"BL_500",
	"BL_750",
	"BL_1000",
	"BL_1500",
	"BL_2000",
	"BL_3000",
	"BL_4000",
	"BL_6000",
	"BL_8000",
    "BMR_125",
    "BMR_250",
    "BMR_500",
    "BMR_750",
    "BMR_1000",
    "BMR_1500",
    "BMR_2000",
    "BMR_3000",
    "BMR_4000",
    "BMR_6000",
    "BMR_8000",
    "BML_125",
    "BML_250",
    "BML_500",
    "BML_750",
    "BML_1000",
    "BML_1500",
    "BML_2000",
    "BML_3000",
    "BML_4000",
    "BML_6000",
    "BML_8000");
?>
