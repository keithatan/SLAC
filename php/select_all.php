<?php

include 'php/connection.php';

$query = "select * from patient";

$result = mysql_query($query);

while($person = mysql_fetch_array($result)){
    echo 'ID: '.$person['ID'].'<Br>';
    echo 'First Name: '.$person['First Name'].'<Br>';
    echo 'Last Name: '.$person['Last Name'].'<Br>';
    echo 'Sex: '.$person['Sex'].'<Br>';
    echo 'Age: '.$person['Age'];
}

?>