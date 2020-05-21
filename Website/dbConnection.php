<?php
$servername = "studmysql01.fhict.local";
$username = "dbi426060";
$password = "SuperSecurePassword";
$dbname = "dbi426060";

$conn = mysqli_connect($servername, $username, $password, $dbname);

if (!$conn) {
    die("Connection failed: ".mysqli_connect_error());
}
?>
