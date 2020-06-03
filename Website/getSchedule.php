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
$date = $_GET["year"]."-01-01";
$start_date = date('Y-m-d', strtotime($date. ' +'.$_GET['week'].' week -10 day'));



try {
  if($_GET['year'] != "") {
      $sql = "SELECT * from `workshifts` WHERE `userID` = '$userID' AND `date` >= '$start_date' AND `date` <= date_add('$start_date', INTERVAL 7 DAY)";
  } else {
      $sql = "SELECT * from `workshifts` WHERE `userID` = '$userID' AND `date` >= '$fromDate' AND `date` <= date_add('$fromDate', INTERVAL 7 DAY)";
  }
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
              $newDay -> status = "grey";
              break;
          case 3:
              $newDay -> status = "red";
              break;
      }
    array_push($weekDays, $newDay);
    }



  }
}

catch (Exception $e) {}

?>
