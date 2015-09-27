<?php
    $dbhost='localhost';
    $dbuser='root';
    $dbpass='';
    $db = 'slac';
    $conn = mysqli_connect ($dbhost, $dbuser, $dbpass, $db); 
    
    if (!$conn) {
      echo "Error can not connect to the server";
      exit;
    }
?>