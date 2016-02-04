<?php
include 'connection.php';

//COUNT DETERMINES WHETHER TO UPDATE OR IF YOU SELECTED A PATIENT

//see connection.php for variable "values"
$q = $_GET['q'];
$q = explode(" ", $q);
$count = count($q);
$i = 0;

$id = intval($q[0]);

$sql = "SELECT * FROM `slac`.`patients` WHERE id = '" .$id. "'";
$result = mysqli_query($conn, $sql);
if (mysqli_query($conn, $sql)) {}
else {
    exit();
}

//Format how the output looks when patient selected
if ($count == 1) {
    while ($row = mysqli_fetch_array($result))
    {
        echo '<h1 class="display-patient">' . $row['first_name'] . " " . $row['last_name'] . "</h1>";
        echo '<h1 class="display-patient">' . $row['description'] . "</h1>";
    }
}
elseif ($q[1] == "all") {
    while ($row = mysqli_fetch_array($result)) {
        foreach ($values as $value) {
            echo $row[$value] . ',';
        }
    }
}

//edit a patient
elseif ($count == 3) {
    $sql = "UPDATE `slac`.`patients` SET " .$q[1]. "='" .$q[2]. "'" . "WHERE id = '" .$id. "'";
    $result = mysqli_query($conn, $sql);
    echo "hello";
    if (mysqli_query($conn, $sql)) {
        echo "it works";
    }
    else {
        echo "Error updating record: " . mysqli_error($conn);
    }
}
mysqli_close($conn); 
?>