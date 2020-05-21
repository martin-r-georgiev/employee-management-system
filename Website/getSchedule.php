<?php

require ('dbConnection.php');

class WeekDay
{
    public $name;
    public $status;
    public $time;
}
$weekDays = array();
$fromDate = date("Y-m-d", strtotime('sunday last week'));
$userID = $_SESSION['userID'];


try {
  $sql = "SELECT * from `workshifts` WHERE `userID` = '$userID' AND `date` >= '$fromDate' AND `date` <= date_add('$fromDate', INTERVAL 7 DAY)";
  $result = $conn->query($sql);
  if ($result->num_rows > 0) {
    while($row = $result->fetch_assoc()) {
      $date = $row["date"];
      $dayOfWeek = date("l", strtotime($date));
      $newDay = new WeekDay();
      $newDay -> name = $dayOfWeek;
      switch ($row["workshift"]) {
          case 0:
              $newDay -> time = "Morning";
              break;
          case 1:
              $newDay -> time = "Afternoon";
              break;
          case 2:
              $newDay -> time = "Evening";
              break;
            }
      switch ($row["status"]) {
          case 0:
              $newDay -> status = "green";
              break;
          case 1:
              $newDay -> status = "yellow";
              break;
          case 2:
              $newDay -> status = "gray";
              break;
          case 3:
              $newDay -> status = "red";
              break;
      }
    array_push($weekDays, $newDay);
    }
      
     

  } else {
    echo "0 results";
  }
}

catch (Exception $e) {}

?>
