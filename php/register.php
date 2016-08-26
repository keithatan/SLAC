<?php
	include "../php/connection.php";
	/*AFTER all text field validations add user to database*/

	$q = $_GET['q'];
	$q = explode(" ", $q);

	$admin = $q[0];
	$firstname = $q[1];
	$lastname = $q[2];
	$PUID = $q[3];
	$email = $q[4];
	$password = $q[5];

	$hash_pass = password_hash($password, PASSWORD_DEFAULT);

	//1 means admin 0 means student
	if ($admin == 'admin') 
	{
		$user = 1;
	}
	else
	{
		$user = 0;
	}

	//due to some stupid reason I have to check if email is used or not twice and display error message
	$sql = "SELECT * from Users where email=" . "'". $email."'";
	if ($res = $conn->query($sql)) 
	{
		if($res->fetchColumn() > 0)
		{
			echo "ERROR: Check Form";
			exit();
		}

	}
	else
	{
		echo "SQL error please contact someone";
	}

	//due to some stupid reason I have to check if PUID is used or not twice and display error message
	$sql = "SELECT * from Users where PUID=" . "'". $PUID."'";
	if ($res = $conn->query($sql)) 
	{
		if($res->fetchColumn() > 0)
		{
			echo "ERROR: Check Form";
			exit();
		}
	}
	else
	{
		echo "SQL error please contact someone";
	}

	//add the information to database finally
	$sql = "INSERT INTO Users (account_type, first_name, last_name, PUID, email, PasswordHash) VALUES " . "('" . $user . "', '" . $firstname . "', '" . $lastname . "', '" . $PUID . "', '" . $email . "', '" . $hash_pass . "')";
	if ($conn->query($sql)) 
	{
		echo "SUBMITTED! Please confirm email (currently not implemented)";
		exit();
	}
	else
	{
		print_r($conn->errorInfo());
	}
?>