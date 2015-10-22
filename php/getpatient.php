<?php

$values = array( "first_name", "last_name", "description",
    "R_125",
    "R_250",
    "R_500",
    "R_750",
    "R_1000",
    "R_1500",
    "R_2000",
    "R_3000",
    "R_4000",
    "R_6000",
    "R_8000",
    "L_125",
    "L_250",
    "L_500",
    "L_750",
    "L_1000",
    "L_1500",
    "L_2000",
    "L_3000",
    "L_4000",
    "L_6000",
    "L_8000",
    "BR_125",
    "BR_250",
    "BR_500",
    "BR_750",
    "BR_1000",
    "BR_1500",
    "BR_2000",
    "BR_3000",
    "BR_4000",
    "BR_6000",
    "BR_8000",
    "BL_125",
    "BL_250",
    "BL_500",
    "BL_750",
    "BL_1000",
    "BL_1500",
    "BL_2000",
    "BL_3000",
    "BL_4000",
    "BL_6000",
    "BL_8000");

include 'connection.php';
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

//Format how the output looks
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

elseif ($count == 3) {
    $sql = "UPDATE `slac`.`patients` SET " .$q[1]. "='" .$q[2]. "'" . "WHERE id = '" .$id. "'";
    $result = mysqli_query($conn, $sql);
    if (mysqli_query($conn, $sql)) {
        echo "it works";
    }
    else {
        echo "Error updating record: " . mysqli_error($conn);
    }
}
echo $count;
mysqli_close($conn); 
?>