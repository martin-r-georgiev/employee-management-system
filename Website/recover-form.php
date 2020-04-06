<?php session_start();
$servername = "studmysql01.fhict.local";
$username = "dbi426060";
$password = "SuperSecurePassword";
$dbname = "dbi426060";

try {
    $conn = new PDO("mysql:host=$servername;dbname=$dbname", $username,
        $password);
// set the PDO error mode to exception
    $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
}
catch(PDOException $e)
{
    echo "Error: " . $e->getMessage();
}

if(!isset($_GET["code"]))
{
  exit ("This link is not working.");
}

$code = $_GET["code"];

$sql = "SELECT email FROM password_reset WHERE code=:code";

$statement = $conn -> prepare($sql);
$statement->bindParam(":code", $code);
$statement->execute();
$result = $statement->fetch();

if (isset($_POST["pass"]) && isset($_POST["confirm-pass"]))
{
  if (($_POST["pass"]) == ($_POST["confirm-pass"]))
  {
    $pwRecovery = $_POST["pass"];
    $hashed = hash("sha256", $pwRecovery);
    $email = $result["email"];

    $sql = "UPDATE users AS u INNER JOIN employees AS e ON u.userId = e.userId SET u.password=:password WHERE e.email=:email;";

    $statement = $conn->prepare($sql);
    $statement->bindParam(":password", $hashed);
    $statement->bindParam(":email", $email);
    $statement->execute();

    if ($result)
    {
       $sql = "DELETE FROM password_reset WHERE code=:code";
       $statement = $conn -> prepare($sql);
       $statement->execute([":code" => $code]);
     }
    echo("Password updated, redirecting you to front page...");
    exit(header( "refresh:3;url=index.php" ));
  }
  echo "<script type='text/javascript'>alert('Passwords do not match!');</script>";
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
  <script type="text/javascript" src="validation.js"></script>
</head>
<body>
 <div class="modal-dialog text-center">
   <div class="col-sm-10 main-section">
     <div class="modal-content">
      <div class="col-12 comp-img">
        <img src="images/logo.png" alt="">
      </div>
      <form class="col-12" method="post" onsubmit="return validateLogin()">
        <p class="p-recover">Please enter your new desired password!</p>
        <div class="form-group form-recover">
          <input type="password" class="form-control" name="pass" placeholder="Enter password">
        </div>
        <div class="form-group">
          <input type="password" class="form-control" name="confirm-pass" placeholder="Confirm password">
          <span name="messages" style="color: red;"></span>
        </div>
        <button type="submit" class="btn btn-login"><i class="fas fa-check-circle"></i>Change password</button>
      </form>
     </div> <!-- End of modal content -->
   </div>
</div>
</body>
</html>
