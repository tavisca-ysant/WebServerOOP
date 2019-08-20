<?php
    require 'db.php';
    session_start();

    if ($_SESSION['logged_in'] != 1)
    {
        $_SESSION['message'] = "<div class='info-alert'>You must log in before viewing your profile page!</div>";
        header("location: error.php");    
    }
    else if ($_SESSION['email'] == 'admin@admin.com')
    {
        header("location: admin.php");
    }
    else
    {
        $email = $mysqli->escape_string($_SESSION['email']);
        $result = $mysqli->query("SELECT * FROM users WHERE email='$email'");
        $user = $result->fetch_assoc();

        $first_name = $user['first_name'];
        $last_name = $user['last_name'];
        $email = $user['email'];
        $active = $user['active'];
    }
?>

<!DOCTYPE html>
<html >
<head>
    <meta charset="UTF-8">
    <title>Welcome <?= $first_name.' '.$last_name ?></title>
    <?php include 'css/css.html'; ?>
</head>
<body>
    <div class="form">
        <h1>Welcome</h1>  
        <?php  
            if ($active == "0")
            {
                $_SESSION['message'] = '<div class="info-alert">Account is unverified, please confirm your email by 
                clicking on the link sent to your email!</div>
                <a href="resend.php"><button class="button button-block" name="resend"/>Resend Link</button></a>';
                header("location: unverified.php");
            }
        ?>
        <h2><?php echo $first_name.' '.$last_name; ?></h2>
        <p><?= $email ?></p>
        <a href="logout.php"><button class="button button-block" name="logout"/>Log Out</button></a>
        <a href="update.php"><button class="button button-block" name="update"/>Update Profile</button></a>
        <a href="changepassword.php"><button class="button button-block" name="changepassword"/>Change Password</button></a>
    </div>
    <script src='http://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script>
    <script src="js/index.js"></script>
</body>
</html>