<?php
session_start();
if (!isset($_SESSION["username"]))
{
    header("Location: index.php");
    die();
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
  <!--Navbar-->
  <nav class="navbar navbar-expand-md navbar-light bg-light sticky-top">
    <div class="container-fluid">
      <a class="navbar-brand" href="#"><img id="brand-img" src="images/stretched.png"></a>
      <button type="button" class="navbar-toggler" data-toggle="collapse" data-target="#navbarResponsive">
        <span class="navbar-toggler-icon"></span>
      </button>
      <div class="collapse navbar-collapse" id="navbarResponsive">
        <ul class="navbar-nav ml-auto">
          <li class="nav-item">
            <a href="home.php" class="nav-link">Home</a>
          </li>
          <li class="nav-item active">
            <a href="profile.php" class="nav-link">Profile</a>
          </li>
          <li class="nav-item">
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
<div class="container">
  <h1>Edit Profile</h1>
	<hr>
	<div class="row row-content">
      <!-- left column -->
      <div class="col-md-3">
        <div class="text-center">
          <img src="//placehold.it/100" class="avatar img-circle" alt="avatar">
          <br>
          <h6>Upload a different photo...</h6>
          <br>
          <input type="file">
        </div>
      </div>

      <!-- edit form column -->
      <div class="col-md-9 personal-info">
        <div class="alert alert-info alert-dismiss">
          <a class="panel-close close" data-dismiss="alert">×</a>
          <i class="fa fa-coffee"></i>
          This is an <strong>.alert</strong>. Use this to show important messages to the user.
        </div>
        <h3>Personal info</h3>
        <form class="form-horizontal" role="form" method="post" action="updateProfile.php">
          <div class="row row-info">
            <div class="col-md-5 column-one">
              <div class="form-group">
                <label class="col-lg-6 control-label">First name:</label>
                <div class="col-lg-12">
                  <input class="form-control" type="text" value="<?php echo ($_SESSION["firstName"])?>" readonly>
                </div>
              </div>
              <div class="form-group">
                <label class="col-lg-6 control-label">Last name:</label>
                <div class="col-lg-12">
                  <input class="form-control" type="text" value="<?php echo ($_SESSION["lastName"])?>" readonly>
                </div>
              </div>
              <div class="form-group">
                <label class="col-lg-6 control-label">Email:</label>
                <div class="col-lg-12">
                  <input class="form-control" type="text" name="email" value="<?php echo ($_SESSION["email"])?>">
                </div>
              </div>
              <div class="form-group">
                <label class="col-lg-6 control-label">Address:</label>
                <div class="col-lg-12">
                  <input class="form-control" type="text" name="address" value="<?php echo ($_SESSION["address"])?>">
                </div>
              </div>
            </div>
            <div class="col-md-4 column-two">
              <div class="form-group">
                <label class="col-lg-8 control-label">Date of birth:</label>
                <div class="col-lg-7">
                  <input class="form-control" type="text" value="<?php echo ($_SESSION["dateOfBirth"])?>" readonly>
                </div>
              </div>
              <div class="form-group">
                <label class="col-lg-6 control-label">Nationality:</label>
                <div class="col-lg-8">
                  <input class="form-control" type="text" value="<?php echo ($_SESSION["nationality"])?>" readonly>
                </div>
              </div>
              <div class="form-group">
                <label class="col-lg-8 control-label">Phone Number:</label>
                <div class="col-lg-8">
                  <input class="form-control" type="text" name="phoneNum" value="<?php echo ($_SESSION["phoneNumber"])?>">
                </div>
              </div>
              <div class="form-group">
                <label class="col-md-12 control-label">Need a new password?</label>
                <div class="col-lg-10">
                  <button type="button" class="btn btn-info" onclick="window.location.href='forgotten.php';">Change Password</button>
                </div>
              </div>
            </div>
          </div>
          <div class="form-group">
            <label class="col-md-6 control-label"></label>
            <div class="col-md-12">
              <input type="submit" class="btn btn-primary" value="Save Changes">
              <span></span>
              <input type="reset" class="btn btn-default btn-cancel" value="Cancel">
            </div>
          </div>
        </form>
      </div>
  </div>
</div>
</body>
</html>
