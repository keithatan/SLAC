<?php
include 'connection.php';
/*THIS SCRIPT IS USED FOR THE SELECT PATIENT AND EDIT PATIENT TABS*/

//COUNT DETERMINES WHETHER TO UPDATE OR IF YOU SELECTED A PATIENT
//basically acts like case statement but sloppy coding

//see connection.php for variable "values"
$q = $_GET['q'];
$q = explode(" ", $q);
$count = count($q);
$i = 0;

$id = intval($q[0]);

$sql = "SELECT * FROM Patients WHERE id = '" .$id. "'";
//$result = mysqli_query($conn, $sql);
$result = $conn->query($sql);
if ($result) {}
else {
    exit();
}

//Format how the output looks when patient selected
if ($count == 1) {
    foreach($result as $row)
    {
        echo json_encode($row);
        //echo '<h1 class="display-patient">' . $row['first_name'] . " " . $row['last_name'] . "</h1>";
        //echo '<h1 class="display-patient">' . $row['description'] . "</h1>";
    }
}
elseif ($q[1] == "all") {
    foreach ($result as $row) {
        $combinedValue = '';
        foreach ($values as $value) {
             $combinedValue .= $row[$value] . ',';
        }
        $finalValue = array('stringResult'=>$combinedValue, 'objectResult'=>$row);
        echo json_encode($finalValue);
    }
}

//edit a patient
elseif ($count == 3) {
    $sql = "UPDATE Patients SET " .$q[1]. "='" .$q[2]. "'" . "WHERE id = '" .$id. "'";
    //$result = mysqli_query($conn, $sql);
    $result = $conn->query($sql);
    echo "hello";
    if ($result) {
        echo "it works";
    }
    else {
        echo "Error updating record: ";
        print_r($conn->error);
    }
}
// mysqli_close($conn);
?>
