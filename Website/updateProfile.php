<?php
$servername = "studmysql01.fhict.local";
$username = "dbi426060";
$password = "SuperSecurePassword";
$dbname = "dbi426060";
$email = $_POST["email"];
$phoneNum = $_POST["phoneNum"];
$address = $_POST["address"];

try {
    $conn = new PDO("mysql:host=$servername;dbname=$dbname", $username,
        $password);
    $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
}
catch(PDOException $e)
{
    echo "Error: " . $e->getMessage();
}
session_start();

$sql = "UPDATE employees AS e INNER JOIN users AS u ON e.userId = u.userId SET e.email = :email, e.phoneNumber = :phoneNum, e.address = :address WHERE u.username=:username;";

$statement = $conn->prepare($sql);
$statement->bindParam(":email", $email);
$statement->bindParam(":phoneNum", $phoneNum);
$statement->bindParam(":address", $address);
$statement->bindParam(":username", $_SESSION['username']);
$statement->execute();

try {
  $sql = "SELECT * FROM employees AS e INNER JOIN users AS u ON e.userID = u.userID WHERE u.username = :username;";
  $statement = $conn->prepare($sql);
  $statement->bindParam(":username", $_SESSION['username']);
  $statement->execute();
  $user_info = $statement->fetch(PDO::FETCH_ASSOC);
}
catch (PDOerrorInfo $e) {}
$_SESSION['email']  = $user_info['email'];
$_SESSION['address'] = $user_info['address'];
$_SESSION['phoneNumber'] = $user_info['phoneNumber'];

echo("Information updated...");
exit(header( "refresh:3; url=profile.php" ));

$conn = null;
?>
