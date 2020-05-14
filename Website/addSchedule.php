<?php
require ('dbConnection.php')
$colorMap = [
    '0' => 'green',
    '1' => 'yellow',
    '2' => 'gray',
    '3' => 'red',
];
$firstDay = date("Y-m-d", strtotime('sunday last week'));
$lastDay = date("Y-m-d", strtotime('sunday this week'));
$userID = $_SESSION['userID'];

try {
  $sql = "SELECT * from `workshifts` WHERE `userID` = '.$userID.' AND `date` >= '.$firstDay.' AND `date` <= date_add('.$firstDay.', INTERVAL 7 DAY)"  //Not working

  $statement = $conn->prepare($sql);
  $statement->execute();
  $info = $statement->fetch(PDO::FETCH_ASSOC);
}
catch (PDOerrorInfo $e) {}

//not working
switch ($info['workshift']) {
    case 0:
        echo "Morning"; //For test

        if (isset($info['status']) && isset($colorMap[$info['status']])) {  //Change color based on status
            $bgColor = $colorMap[$info['status']];
        } else {
            $bgColor = DEFAULT_COLOR;
        }
        break;
    case 1:
        echo "Afternoon";

        if (isset($info['status']) && isset($colorMap[$info['status']])) {
            $bgColor = $colorMap[$info['status']];
        } else {
            $bgColor = DEFAULT_COLOR;
        }
        break;
    case 2:
        echo "Evening";

        if (isset($info['status']) && isset($colorMap[$info['status']])) {
            $bgColor = $colorMap[$info['status']];
        } else {
            $bgColor = DEFAULT_COLOR;
        }
        break;
}



?>
