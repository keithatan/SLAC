<?php
	include '../php/connection.php';
	/*SCRIPT USED TO LOGIN AND RETURNS A ERROR MESSAGE OR NOTHING ON SUCCESSFUL LOGIN*/

	$q = $_GET['q'];
	$q = explode(" ", $q);
	$count = 0;

	if ($q[0] == "login") {
		$email = $q[1];
		$password = $q[2];

		$sql = "SELECT PasswordHash from Users where email=" . "'". $email."'";

		if ($res = $conn->query($sql)) 
		{
			/*use a for loop here because fetchColumns() was being diffult*/
			foreach ($res as $row) {
				$count = $count + 1;
				$hash =  $row['PasswordHash'];
				if (password_verify($password, $hash)) 
				{
					
				}
				else
				{
					echo "Invalid Passowrd";
				}
			}
			//check count to be 1 before sending verified password
			if ($count == 0) 
			{
				echo "Invalid Email";
			}
			//idk how it would be not equal to 1
			else if ($count != 1) 
			{
				echo "Why are there more than one of the same email";
			}
		}
		else
		{
			echo "SQL error please contact someone";
		}
	}
?>