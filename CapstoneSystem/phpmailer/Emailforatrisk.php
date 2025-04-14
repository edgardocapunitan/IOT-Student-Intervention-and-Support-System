<?php
require 'vendor/autoload.php'; // Include PHPMailer's autoload if using Composer

use PHPMailer\PHPMailer\PHPMailer;
use PHPMailer\PHPMailer\Exception;

// Database Connection
$host = 'localhost';
$db = 'finals';
$user = 'root';
$pass = '';

try {
    // Establish database connection
    $pdo = new PDO("mysql:host=$host;dbname=$db;charset=utf8", $user, $pass);
    $pdo->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);

    // Query to select 'At-Risk' students with grades and intervention details,
    // excluding students with 'Completed' in interventionstatus
    $stmt = $pdo->query("
        SELECT 
            student.NAME, 
            student.EMAIL_ADDRESS, 
            grades.*, 
            intervention.teacher, 
            intervention.subject AS intervention_subject, 
            intervention.Cause, 
            intervention.Solution
        FROM student
        LEFT JOIN status ON student.NAME = status.NAME
        LEFT JOIN grades ON student.NAME = grades.NAME
        LEFT JOIN intervention ON student.NAME = intervention.studentname
        WHERE status.atRiskStatus = 'At-Risk' 
          AND (intervention.interventionstatus IS NULL OR intervention.interventionstatus != 'Completed')
    ");

    $atRiskStudents = $stmt->fetchAll(PDO::FETCH_ASSOC);

    foreach ($atRiskStudents as $student) {
        // Find the failed subjects (grades below 75)
        $failedSubjects = [];
        $subjects = [
            'Programming', 'Social Science', 'HRO', 'Filipino 11+', 'MEDLIT', 
            'Literature 1', 'Literature 2', 'English 11+', 'Physical Education 3'
        ];

        foreach ($subjects as $subject) {
            if ($student[$subject] < 75) {
                // Add the failed subject to the list
                $failedSubjects[] = $subject . ' (' . $student[$subject] . ')';
            }
        }

        // If there are failed subjects, proceed to send the email
        if (!empty($failedSubjects)) {
            $mail = new PHPMailer(true);

            try {
                // SMTP server settings
                $mail->isSMTP();
                $mail->Host = 'smtp.gmail.com';
                $mail->SMTPAuth = true;
                $mail->Username = 'edgardocapunitan@trimexcolleges.edu.ph'; // Replace with your actual Gmail address
                $mail->Password = 'bong09183215659'; // Replace with your actual password or app-specific password
                $mail->SMTPSecure = PHPMailer::ENCRYPTION_STARTTLS;
                $mail->Port = 587;

                // Set the sender and recipient details
                $mail->setFrom('edgardocapunitan@trimexcolleges.edu.ph', 'Intervention System');
                $mail->addAddress($student['EMAIL_ADDRESS'], $student['NAME']);

                // Email content
                $mail->isHTML(true);
                $mail->Subject = 'At-Risk Notification - Failed Subjects and Intervention';

                // Construct the email body
                $mail->Body = 'Dear ' . htmlspecialchars($student['NAME']) . ',<br><br>';
                $mail->Body .= 'We have identified that you are "At-Risk" due to the following failed subjects:<br>';
                $mail->Body .= '<ul>';
                foreach ($failedSubjects as $failedSubject) {
                    $mail->Body .= '<li>' . $failedSubject . '</li>';
                }
                $mail->Body .= '</ul>';

                // Check if intervention data exists for this student
                if (!empty($student['teacher']) && !empty($student['Cause']) && !empty($student['Solution'])) {
                    $mail->Body .= '<br><strong>Intervention Details:</strong><br>';
                    $mail->Body .= 'Teacher: ' . htmlspecialchars($student['teacher']) . '<br>';
                    $mail->Body .= 'Subject: ' . htmlspecialchars($student['intervention_subject']) . '<br>';
                    $mail->Body .= 'Cause: ' . htmlspecialchars($student['Cause']) . '<br>';
                    $mail->Body .= 'Solution: ' . htmlspecialchars($student['Solution']) . '<br>';
                } else {
                    $mail->Body .= '<br><strong>No intervention details available for this student.</strong><br>';
                }

                $mail->Body .= '<br>Please contact your teacher to discuss potential solutions for improving your grades.<br><br>';
                $mail->Body .= 'Best regards,<br>Intervention System';

                // Send the email
                $mail->send();
                echo 'Message sent to ' . htmlspecialchars($student['NAME']) . '<br>';
            } catch (Exception $e) {
                echo "Message could not be sent to " . htmlspecialchars($student['NAME']) . ". Error: {$mail->ErrorInfo}<br>";
            }
        }
    }
} catch (PDOException $e) {
    echo "Connection failed: " . $e->getMessage();
}
