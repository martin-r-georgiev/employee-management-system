<?php
session_start();
error_reporting(0);
if (!isset($_SESSION["username"]))
{
    header("Location: index.php");
    die();
}
require("getSchedule.php");
$colored_days = array();
$new_colored_days = array();
//for ($i = 0; $i < $weekDays.length; $i++) {
//  echo $weekDays[$i];
//}
//print_r($weekDays);exit;
foreach ($weekDays as $WeekDay) {
   $combination = $WeekDay->name.'-'.$WeekDay->time;
     $colored_days[$combination] = array('status' => 'status-'.$WeekDay->status);
}
?>

<!DOCTYPE html>
<html>
<head>
  <title>Steller Jay - Website</title>
  <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" integrity="sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh" crossorigin="anonymous">
  <script src="https://code.jquery.com/jquery-3.4.1.slim.min.js" integrity="sha384-J6qa4849blE2+poT4WnyKhv5vZF5SrPo0iEjwBvKU7imGFAV0wwj1yYfoRSJoZ+n" crossorigin="anonymous"></script>
  <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
  <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js" integrity="sha384-wfSDF2E50Y2D1uUdj0O3uMBJnjuUD4Ih7YwaYd1iqfktj0Uod8GCExl3Og8ifwB6" crossorigin="anonymous"></script>
  <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.13.0/css/all.css" integrity="sha384-Bfad6CLCknfcloXFOyFnlgtENryhrpZCe29RTifKEixXQZ38WheV+i/6YWSzkz3V" crossorigin="anonymous">
  <script src="https://kit.fontawesome.com/2f1dc81eac.js" crossorigin="anonymous"></script>
  <link rel="stylesheet" type="text/css" href="style.css">
  <link href='https://fonts.googleapis.com/css?family=Montserrat' rel='stylesheet'>
</head>
<body>
  <nav class="navbar navbar-expand-md navbar-light bg-light sticky-top">
    <div class="container-fluid">
      <a class="navbar-brand" href="#"><img id="brand-img" src="images/stretched.png"></a>
      <button type="button" class="navbar-toggler" data-toggle="collapse" data-target="#navbarResponsive">
        <span class="navbar-toggler-icon"></span>
      </button>
      <div class="collapse navbar-collapse" id="navbarResponsive">
        <ul class="navbar-nav ml-auto">
          <li class="nav-item">
            <a href="profile.php" class="nav-link">Profile</a>
          </li>
          <li class="nav-item active
          ">
            <a href="schedule.php" class="nav-link">Schedule</a>
          </li>
          <li class="nav-item">
            <a href="logout.php" class="nav-link">Logout</a>
          </li>
        </ul>
      </div>
    </div>
  </nav>
  <!--Profile box-->
<div class="container sc-container">
  <h1>Work-shift schedule</h1>
  <?php
  $dt = new DateTime;
  if (isset($_GET['year']) && isset($_GET['week'])) {
      $dt->setISODate($_GET['year'], $_GET['week']);
  } else {
      $dt->setISODate($dt->format('o'), $dt->format('W'));
  }
  $year = $dt->format('o');
  $week = $dt->format('W');
  ?>
  <a href="<?php echo $_SERVER['PHP_SELF'].'?week='.($week-1).'&year='.$year; ?>">Prev Week</a> <a>|</a>
  <a href="<?php echo $_SERVER['PHP_SELF'].'?week='.($week+1).'&year='.$year; ?>">Next  Week</a>
	<hr>
	<div class="row row-content">
  <table class="table table-bordered table-hover">
    <thead>
      <tr>
      <td></td>
      <?php
      do {

          echo "<td>" . $dt->format('l') . "<br>" . $dt->format('d M Y') . "</td>\n";
          $dt->modify('+1 day');
      } while ($week == $dt->format('W'));
      ?>
      </tr>
    </thead>
  <tbody>
     <tr>
      <th scope="row">Morning</th>
      <td id="Monday-Morning" class="<?php if(array_key_exists('Monday-Morning', $colored_days)) echo $colored_days["Monday-Morning"]["status"];  ?>"></td>
      <td id="Tuesday-Morning" class="<?php if(array_key_exists('Tuesday-Morning', $colored_days)) echo $colored_days["Tuesday-Morning"]["status"];  ?>" ></td>
      <td id="Wednesday-Morning" class="<?php if(array_key_exists('Wednesday-Morning', $colored_days)) echo $colored_days["Wednesday-Morning"]["status"];  ?>" ></td>
      <td id="Thursday-Morning" class="<?php if(array_key_exists('Thursday-Morning', $colored_days)) echo $colored_days["Thursday-Morning"]["status"]; ?>" ></td>
      <td id="Friday-Morning" class="<?php if(array_key_exists('Friday-Morning', $colored_days)) echo $colored_days["Friday-Morning"]["status"];  ?>" ></td>
      <td id="Saturday-Morning" class="<?php if(array_key_exists('Saturday-Morning', $colored_days)) echo $colored_days["Saturday-Morning"]["status"];  ?>" ></td>
      <td id="Sunday-Morning" class="<?php if(array_key_exists('Sunday-Morning', $colored_days)) echo $colored_days["Sunday-Morning"]["status"];  ?>" ></td>
    </tr>
    <tr>
      <th scope="row">Afternoon</th>
      <td id="Monday-Afternoon"class="<?php if(array_key_exists('Monday-Afternoon', $colored_days)) echo $colored_days["Monday-Afternoon"]["status"];  ?>" ></td>
      <td id="Tuesday-Afternoon" class="<?php if(array_key_exists('Tuesday-Afternoon', $colored_days)) echo $colored_days["Tuesday-Afternoon"]["status"];  ?>" ></td>
      <td id="Wednesday-Afternoon" class="<?php if(array_key_exists('Wednesday-Afternoon', $colored_days)) echo $colored_days["Wednesday-Afternoon"]["status"];  ?>" ></td>
      <td id="Thursday-Afternoon" class="<?php if(array_key_exists('Thursday-Afternoon', $colored_days)) echo $colored_days["Thursday-Afternoon"]["status"];  ?>" ></td>
      <td id="Friday-Afternoon" class="<?php if(array_key_exists('Friday-Afternoon', $colored_days)) echo $colored_days["Friday-Afternoon"]["status"];  ?>" ></td>
      <td id="Saturday-Afternoon" class="<?php if(array_key_exists('Saturday-Afternoon', $colored_days)) echo $colored_days["Saturday-Afternoon"]["status"];  ?>" ></td>
      <td id="Sunday-Afternoon" class="<?php if(array_key_exists('Sunday-Afternoon', $colored_days)) echo $colored_days["Sunday-Afternoon"]["status"];  ?>" ></td>
    </tr>
    <tr>
      <th scope="row">Evening</th>
      <td id="Monday-Evening" class="<?php if(array_key_exists('Monday-Evening', $colored_days)) echo $colored_days["Monday-Evening"]["status"];  ?>" ></td>
      <td id="Tuesday-Evening" class="<?php if(array_key_exists('Tuesday-Evening', $colored_days)) echo $colored_days["Tuesday-Evening"]["status"];  ?>" ></td>
      <td id="Wednesday-Evening" class="<?php if(array_key_exists('Wednesday-Evening', $colored_days)) echo $colored_days["Wednesday-Evening"]["status"];  ?>" ></td>
      <td id="Thursday-Evening" class="<?php if(array_key_exists('Thursday-Evening', $colored_days)) echo $colored_days["Thursday-Evening"]["status"];  ?>" ></td>
      <td id="Friday-Evening" class="<?php if(array_key_exists('Friday-Evening', $colored_days)) echo $colored_days["Friday-Evening"]["status"];  ?>" ></td>
      <td id="Saturday-Evening" class="<?php if(array_key_exists('Saturday-Evening', $colored_days)) echo $colored_days["Saturday-Evening"]["status"];  ?>" ></td>
      <td id="Sunday-Evening" class="<?php if(array_key_exists('Sunday-Evening', $colored_days)) echo $colored_days["Sunday-Evening"]["status"];  ?>" ></td>
    </tr>
  </tbody>
</table>
  </div>
  <br>
</div>
</body>
</html>
