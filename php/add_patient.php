<?php
	include "connection.php";
	$values = array( "last_name", "description",
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
	"BL_8000");
	$data = "'" . $_GET['first_name'] . "',";
	$columns = '`first_name`,';

	foreach ($values as $value) {
		if ($value == "BL_8000") {
			$data .= " '" . $_GET[$value] . "'";
			$columns .= ' `' . $value . '`';
		}
		else {
			$data .= " '" . $_GET[$value] ."',";
			$columns .= ' `' . $value . '`,';
		}
	}
	$sql = "INSERT INTO `slac`.`patients` (" . $columns . ") VALUES (" . $data . ")";
	if (mysqli_query($conn, $sql)) {
			//echo "it works";
		}
		else
		{
			//echo "Error: " . $sql . "<br>" . mysqli_error($conn);
		}
	mysqli_close($conn);
	header('Location: /SLAC/index.php');
	exit;
?>