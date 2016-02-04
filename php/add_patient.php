<?php
	include "connection.php";
	//see connection.php about variable "values"
	$data = "'" . $_GET['first_name'] . "',";
	$columns = '`first_name`,';

	foreach ($values as $value) {
		if ($value == "BML_8000") {
			$data .= " '" . $_GET[$value] . "'";
			$columns .= ' `' . $value . '`';
		}
		elseif ($value == "first_name") {
			//do nothing
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