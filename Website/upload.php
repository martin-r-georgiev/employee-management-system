<?php
session_start();
//error_reporting(0);
if(!@$_SERVER['HTTP_REFERER']) die('No direct Access');
$img=$_FILES['img'];
$servername = "studmysql01.fhict.local";
$username = "dbi426060";
$password = "SuperSecurePassword";
$dbname = "dbi426060";
    if($img['name']==''){
        echo "<h2>An Image Please.</h2>";
    }else{
        $filename = $img['tmp_name'];
        $client_id="7073e08a67bdc04";
        $handle = fopen($filename, "r");
        $data = fread($handle, filesize($filename));
        $pvars   = array('image' => base64_encode($data));
        $timeout = 30;
        $curl = curl_init();
        curl_setopt($curl, CURLOPT_SSL_VERIFYPEER, false);
        curl_setopt($curl, CURLOPT_URL, 'https://api.imgur.com/3/image.json');
        curl_setopt($curl, CURLOPT_TIMEOUT, $timeout);
        curl_setopt($curl, CURLOPT_HTTPHEADER, array('Authorization: Client-ID ' . $client_id));
        curl_setopt($curl, CURLOPT_POST, 1);
        curl_setopt($curl, CURLOPT_RETURNTRANSFER, 1);
        curl_setopt($curl, CURLOPT_POSTFIELDS, $pvars);
        $out = curl_exec($curl);
        curl_close ($curl);
        $pms = json_decode($out,true);
        $url=$pms['data']['link'];
        if($url!=""){
          try {
              $conn = new PDO("mysql:host=$servername;dbname=$dbname", $username,
                  $password);
              $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
          }
          catch(PDOException $e)
          {
              echo "Error: " . $e->getMessage();
          }
         $sql = "UPDATE employees AS e INNER JOIN users AS u ON e.userId = u.userId SET e.picture = :picture WHERE u.username= :username";
         $statement = $conn->prepare($sql);
         $statement->bindParam(":picture", $url);
         $statement->bindParam(":username", $_SESSION['username']);
         $statement->execute();

         $_SESSION['picture']  = $url;
         header("Refresh:0; url=profile.php");
        }else{
            echo "<h2>There's a Problem</h2>";
            echo $pms['data']['error'];
        }
    }
?>
