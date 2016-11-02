<?php

	include 'connection.php';

	/*SCRIPT USED TO LOGIN AND RETURNS A ERROR MESSAGE OR NOTHING ON SUCCESSFUL LOGIN*/
	session_start();



	$email = $_POST["email"];
	$password = $_POST["pass"];

	$sql = "SELECT PasswordHash from Users where email=" . "'". $email."'";

	if ($res = $conn->query($sql))
	{

		$row = $res->fetch_row();

		$hash =  $row[0];

		if (/*password_verify($password, $hash)*/ true)
		{
			$_SESSION['user'] = $email;
			// header("Location: /simulator.php");
			// exit();
		}
		else
		{
			echo "Invalid Password";
		}

		//check count to be 1 before sending verified password
		if ($res->num_rows != 1)
		{
			echo "Invalid Email";
		}
		//idk how it would be not equal to 1
		else if ($res->num_rows > 1)
		{
			echo "Why are there more than one of the same email";
		}
	}
	else
	{
		echo "SQL error please contact someone";
	}
?>
