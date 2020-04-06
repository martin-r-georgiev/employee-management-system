<?php session_start() ?>

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
  <script type="text/javascript" src="validation.js"></script>
</head>
<body>
 <div class="modal-dialog text-center">
   <div class="col-sm-12 main-section">
     <div class="modal-content">
      <div class="col-12 comp-img">
        <img src="images/logo.png" alt="">
      </div>
      <form class="col-12" action="mail-sender.php" method="post" onsubmit="return validateEmail()">
        <p class="p-recover">Enter email for password reset!</p>
        <div class="form-group">
          <input type="email" class="form-control" name="email" placeholder="Enter e-mail" required>
          <span name="messages" style="color: red;"></span>
        </div>
        <button type="submit" class="btn btn-login"><i class="fas fa-envelope"></i>Send recovery</button>
      </form>
     </div>
   </div>
</div>
</body>
</html>
