<?php
//echo 'hello';

function mysqli_result($result, $row, $field = 0) {
    // Adjust the result pointer to that specific row
    $result->data_seek($row);
    // Fetch result array
    $data = $result->fetch_array();
 
    return $data[$field];
}

if (isset($_POST['name']) === true && empty($_POST['name']) === false) {
	require '../db/connect.php';
	$query = mysqli_query($link,"
		SELECT 	`people`.`age`
		FROM 	`people`
		WHERE 	`people`.`name` ='" . mysqli_real_escape_string($link,trim($_POST['name'])) . "'
		");

		//The one above just has age whereas the one below has id,name as well as age.
$patientQuery = mysqli_query($link,"
		SELECT 	id,name,age
		FROM 	`people`
		WHERE 	`people`.`name` ='" . mysqli_real_escape_string($link,trim($_POST['name'])) . "'
		");		
		//$infoString = "Patient ID: ".mysqli_result($query,0,'id')."<br>Patient Name: ".mysqli_result($query,0,'name')."<br>Patient Age".mysqli_result($query,0,'age'); //This infostring doesn't seem to be able to retrieve 'name' and 'id' - just the age. 
		if(mysqli_num_rows($query) !== 0){
		$row = mysqli_fetch_row($patientQuery);
		$infoString = "Patient ID: ".$row[0]."<br>Patient Name: ".$row[1]."<br>Patient Age: ".$row[2];	
		}
		
		echo (mysqli_num_rows($query) !== 0) ? $infoString : 'No such patient'; 	//This displays whatever is in infoString

		// echo (mysqli_num_rows($query) !== 0) ? mysqli_result($query,0,'age') : 'No such patient';   //This displays only the age
}