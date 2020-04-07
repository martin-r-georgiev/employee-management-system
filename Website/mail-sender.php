<?php
use PHPMailer\PHPMailer\PHPMailer;
use PHPMailer\PHPMailer\SMTP;
use PHPMailer\PHPMailer\Exception;

require 'PHPMailer/src/Exception.php';
require 'PHPMailer/src/PHPMailer.php';
require 'PHPMailer/src/SMTP.php';

$servername = "studmysql01.fhict.local";
$username = "dbi426060";
$password = "SuperSecurePassword";
$dbname = "dbi426060";

try {
    $conn = new PDO("mysql:host=$servername;dbname=$dbname", $username,
        $password);
    $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
}
catch(PDOException $e)
{
    echo "Error: " . $e->getMessage();
}

if(isset($_POST["email"])) {

  $emailSendTo = $_POST["email"];

  $code = uniqid(true);
  $sql = "INSERT INTO password_reset(code, email) VALUES('$code', '$emailSendTo')";
  $statement = $conn -> prepare($sql);
  $statement->execute();


  $mail = new PHPMailer(true);

  try {
      //Server settings
      $mail->isSMTP();                                            // Send using SMTP
      $mail->Host       = 'smtp.gmail.com';                    // Set the SMTP server to send through
      $mail->SMTPAuth   = true;                                   // Enable SMTP authentication
      $mail->Username   = 'ivanzl.website@gmail.com';                     // SMTP username
      $mail->Password   = 'ivanzl23';                               // SMTP password
      $mail->SMTPSecure = PHPMailer::ENCRYPTION_STARTTLS;         // Enable TLS encryption; `PHPMailer::ENCRYPTION_SMTPS` encouraged
      $mail->Port       = 587;                                    // TCP port to connect to, use 465 for `PHPMailer::ENCRYPTION_SMTPS` above

      //Recipients
      $mail->setFrom('ivanzl.website@gmail.com', 'Steller Jay Website');
      $mail->addAddress("$emailSendTo");     // Add a recipient   //-----------------------------
      $mail->addReplyTo('no-reply@gmail.com', 'No reply');

      // Content
      $url = "http://" . $_SERVER["HTTP_HOST"] . dirname($_SERVER["PHP_SELF"]) . "/recover-form.php?code=$code";
      $mail->isHTML(true);                                  // Set email format to HTML
      $mail->Subject = 'Password reset link for musaka';
      $mail->Body    = "<h1> You have requested a password reset <br></br>
                         Click <a href='$url'>this link</a> to do so!";
      $mail->AltBody = 'This is the body in plain text for non-HTML mail clients';

      $mail->send();
      echo '<script language="javascript">';
      echo 'alert("Reset passsword link has been set to your email")';
      echo '</script>';
      header( "refresh:0.5;url=index.php" );       //TO DO: Cleaner way of doing this
  } catch (Exception $e) {
      echo "Message could not be sent. Mailer Error: {$mail->ErrorInfo}";
  }
  exit();
}

$conn = null;
?>
