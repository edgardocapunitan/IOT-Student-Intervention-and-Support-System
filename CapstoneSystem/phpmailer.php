<?php
use PHPMailer\PHPMailer\PHPMailer;
use PHPMailer\PHPMailer\Exception;

// Adjust this path if you're using Composer
require 'vendor/autoload.php'; // This assumes Composer's autoload is in the root of your project

function sendEmail($studentEmail, $studentName) {
    $mail = new PHPMailer(true);
    try {
        // Server settings
        $mail->isSMTP();                                        // Set mailer to use SMTP
        $mail->Host       = 'smtp.example.com';                // Specify main and backup SMTP servers
        $mail->SMTPAuth   = true;                             // Enable SMTP authentication
        $mail->Username   = 'your_email@example.com';         // SMTP username
        $mail->Password   = 'your_email_password';            // SMTP password
        $mail->SMTPSecure = PHPMailer::ENCRYPTION_STARTTLS;   // Enable TLS encryption, `ssl` also accepted
        $mail->Port       = 587;                              // TCP port to connect to

        // Recipients
        $mail->setFrom('your_email@example.com', 'Your Name'); // Adjust sender name and email
        $mail->addAddress($studentEmail, $studentName); // Add a recipient

        // Content
        $mail->isHTML(true);                                  // Set email format to HTML
        $mail->Subject = 'Important: Academic Alert';
        $mail->Body    = '<p>Dear ' . $studentName . ',</p>
                          <p>You are currently identified as an <strong>At-Risk</strong> student based on your recent academic performance.</p>
                          <p>Please take the necessary steps to improve your grades and consider reaching out for help.</p>
                          <p>Best regards,<br>Your School Name</p>'; // Change to your school name

        $mail->send();
        echo 'Message has been sent to ' . $studentName;
    } catch (Exception $e) {
        echo "Message could not be sent. Mailer Error: {$mail->ErrorInfo}";
    }
}

// Function to check At-Risk students and send emails
function notifyAtRiskStudents($conn) {
    // Adjust this query based on how you define 'At-Risk'
    $sql = "SELECT NAME, EMAIL_ADDRESS FROM finals.student WHERE STATUS = 'At-Risk'";
    $result = $conn->query($sql);

    if ($result->num_rows > 0) {
        while ($row = $result->fetch_assoc()) {
            sendEmail($row['EMAIL_ADDRESS'], $row['NAME']);
        }
    } else {
        echo "No At-Risk students found.";
    }
}

// Database connection (adjust credentials)
$conn = new mysqli('localhost', 'username', 'password', 'finals'); // Update with your DB credentials

// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

// Notify at-risk students
notifyAtRiskStudents($conn);

// Close connection
$conn->close();
?>
