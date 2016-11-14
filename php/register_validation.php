<?php
	include "connection.php";
	/*check if email or puid exists and report appropriate error message*/

	$q = $_GET['q'];
	$q = explode(" ", $q);
	$count = 0;

	if ($q[0] == 'CheckEmail')
	{
		$email = $q[1];
		$sql = "SELECT * from Users where email=" . "'". $email."'";
		if ($res = $conn->query($sql))
		{
			if($res->num_rows > 0)
			{
				echo "Email already in use";
				exit();
			}

		}
		else
		{
			echo "SQL error please contact someone";
		}
	}
	else if ($q[0] == 'CheckPUID') {
		$PUID = $q[1];
		$sql = "SELECT * from Users where PUID=" . "'". $PUID."'";
		if ($res = $conn->query($sql))
		{
			if($res->num_rows > 0)
			{
				echo "PUID already in use";
				exit();
			}
		}
		else
		{
			echo "SQL error please contact someone";
		}
	}
?>
