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
    $_SESSION["username"] = $user;
    header("Location:home.php");
}
 else
{
    echo '<script language="javascript">';
    echo 'alert("Wrong credentials! Please try again.")';
    echo '</script>';
    header( "refresh:0.5;url=index.php" );
}
$conn = null;
?>
