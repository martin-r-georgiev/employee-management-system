<?php
$servername = "studmysql01.fhict.local";
$username = "dbi426060";
$password = "SuperSecurePassword";
$dbname = "dbi426060";
$user = $_POST["user"];
$pass = $_POST["pass"];
$hashed = hash("sha256", $pass);

try {
    $conn = new PDO("mysql:host=$servername;dbname=$dbname", $username,
        $password);
    $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
}
catch(PDOException $e)
{
    echo "Error: " . $e->getMessage();
}

$sql = "SELECT username FROM users WHERE username = :user AND password = :pass";
$statement = $conn -> prepare($sql);
$statement->execute([":user" => $user,":pass" => $hashed]);
$result = $statement->fetch();

if ($result)
{
    session_start();
    try {
      $sql = "SELECT * FROM employees AS e INNER JOIN users AS u ON e.userID = u.userID WHERE u.username = :user;";
      $statement = $conn->prepare($sql);
      $statement->bindParam(":user", $user);
      $statement->execute();
      $user_info = $statement->fetch(PDO::FETCH_ASSOC);
    }
    catch (PDOerrorInfo $e) {}
    $_SESSION['email']  = $user_info['email'];
    $_SESSION['firstName'] = $user_info['firstName'];
    $_SESSION['lastName'] = $user_info['lastName'];
    $_SESSION['nationality'] = $user_info['nationality'];
    $_SESSION['address'] = $user_info['address'];
    $_SESSION['phoneNumber'] = $user_info['phoneNumber'];
    $_SESSION['dateOfBirth'] = $user_info['dateOfBirth'];
    $_SESSION['userID'] = $user_info['userID'];
    $_SESSION["username"] = $user;
    $_SESSION['picture'] = $user_info['picture'];

}
$conn = null;
?>
