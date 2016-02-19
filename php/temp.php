<?php 
    include '../php/connection.php';
    $sql = "SELECT id, first_name, last_name FROM Patients"; 
    echo "helloworld\n";
    if($conn->query($sql))
    {
    	foreach ($conn->query($sql) as $row) {
    		print $row['id']. \t;
    		print $row['first_name']. \t;
    		print $row['last_name'] . \t;
    	}
    }
    else
    {
    	echo "error\n";
    	print_r($conn->errorInfo());
    }
?>