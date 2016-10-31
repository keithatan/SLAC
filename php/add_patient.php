<?php
	//Just adds a patient to the database
	include "../php/connection.php";
	//see connection.php about variable "values"
	$data = "'" . $_GET['first_name'] . "',";
	$columns = 'first_name,';

	foreach ($values as $value) {
		if ($value == "BML_8000") {
			$data .= " '" . $_GET[$value] . "'";
			$columns .= ' ' . $value;
		}
		elseif ($value == "first_name") {
			//do nothing
		}
		else {
			$data .= " '" . $_GET[$value] ."',";
			$columns .= ' ' . $value . ',';
		}
	}
	$sql = "INSERT INTO Patients (" . $columns . ") VALUES (" . $data . ")";
		if ($conn->query($sql)) {
			header($header);
		}
		else
		{
			print_r($conn->error);
		}
	//mssql_close($conn);
	//header('Location: http://epics.ecn.purdue.edu/wise/slac-dev/');
	exit;
?>
