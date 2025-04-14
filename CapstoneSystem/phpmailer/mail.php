<?php
use PHPMailer\PHPMailer\PHPMailer;
use PHPMailer\PHPMailer\Exception;

require 'vendor/autoload.php';  // Make sure to include PHPMailer

if (isset($_POST['send'])) {
    // Retrieve the form data
    $name = $_POST['name'];
    $email = $_POST['email'];
    $subject = $_POST['subject'];
    $message = $_POST['message'];

    // Create an instance of PHPMailer
    $mail = new PHPMailer(true);

    try {
        // Server settings
        $mail->isSMTP();                                           // Set mailer to use SMTP
        $mail->Host = 'smtp.gmail.com';                             // Set the SMTP server to Gmail
        $mail->SMTPAuth = true;                                     // Enable SMTP authentication
        $mail->Username = 'edgardocapunitan@trimexcolleges.edu.ph';                   // SMTP username (use your email address)
        $mail->Password = 'bong09183215659';                    // SMTP password (use app password if 2FA is enabled)
        $mail->SMTPSecure = PHPMailer::ENCRYPTION_STARTTLS;         // Enable TLS encryption
        $mail->Port = 587;                                          // TCP port for TLS (587)

        // Recipients
        $mail->setFrom('edgardocapunitan@trimexcolleges.edu.ph', 'Your Name');        // Sender's email
        $mail->addAddress('edgardocapunitan@trimexcolleges.edu.ph', 'Recipient');    // Recipient's email (change to the real email)

        // Content
        $mail->isHTML(true);                                        // Set email format to HTML
        $mail->Subject = $subject;
        $mail->Body    = '<p><strong>Name:</strong> ' . $name . '</p>
                          <p><strong>Email:</strong> ' . $email . '</p>
                          <p><strong>Message:</strong><br>' . nl2br($message) . '</p>';

        // Send email
        $mail->send();
        echo 'Message has been sent successfully.';
    } catch (Exception $e) {
        echo "Message could not be sent. Mailer Error: {$mail->ErrorInfo}";
    }
}
?>
