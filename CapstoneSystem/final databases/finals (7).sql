-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Dec 03, 2024 at 08:47 AM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `finals`
--

-- --------------------------------------------------------

--
-- Table structure for table `admin`
--

CREATE TABLE `admin` (
  `id` int(11) NOT NULL,
  `username` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `admin`
--

INSERT INTO `admin` (`id`, `username`, `password`) VALUES
(1, 'admin', 'admin'),
(2, 'bong', 'bong');

-- --------------------------------------------------------

--
-- Table structure for table `attendance`
--

CREATE TABLE `attendance` (
  `ATTENDANCE` int(11) NOT NULL,
  `RFID` varchar(10) NOT NULL,
  `TIME_IN` time NOT NULL,
  `TIME_OUT` time NOT NULL,
  `DATE` date NOT NULL,
  `AM_STATUS` varchar(15) NOT NULL,
  `PM_STATUS` varchar(15) NOT NULL,
  `LATE_STATUS` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `attendance`
--

INSERT INTO `attendance` (`ATTENDANCE`, `RFID`, `TIME_IN`, `TIME_OUT`, `DATE`, `AM_STATUS`, `PM_STATUS`, `LATE_STATUS`) VALUES
(37, '0011602436', '09:35:18', '09:35:44', '2023-05-21', 'Time_In', 'Time_Out', 0),
(38, '0011596262', '11:09:47', '11:11:15', '2023-05-21', 'Time_In', 'Time_Out', 0),
(39, '0011584440', '11:15:33', '11:18:34', '2023-05-21', 'Time_In', 'Time_Out', 0),
(83, '0011602436', '02:56:32', '02:56:45', '2024-10-26', 'Time_In', 'Time_Out', 0),
(84, '2879432643', '02:56:38', '02:56:48', '2024-10-26', 'Time_In', 'Time_Out', 0),
(87, '2879432643', '06:18:34', '06:18:51', '2024-10-28', 'Time_In', 'Time_Out', 0),
(95, '0735792992', '02:18:23', '00:00:00', '2024-10-29', 'Time_In', '', 0),
(192, '2879432643', '05:00:31', '00:00:00', '2024-11-11', 'Time_In', '', 1),
(196, '0011602436', '04:57:10', '04:57:22', '2024-11-19', 'Time_In', 'Time_Out', 1),
(197, '0011557187', '05:04:36', '05:04:42', '2024-11-19', 'Time_In', 'Time_Out', 1),
(198, '0011602436', '09:19:03', '00:00:00', '2024-11-21', 'Time_In', '', 1),
(199, '0436222881', '10:39:30', '10:57:52', '2024-11-22', 'Time_In', 'Time_Out', 0),
(200, '2936153328', '10:58:06', '00:00:00', '2024-11-22', 'Time_In', '', 1),
(201, '4049019907', '10:58:24', '00:00:00', '2024-11-22', 'Time_In', '', 1),
(202, '0596563568', '10:58:33', '10:58:44', '2024-11-22', 'Time_In', 'Time_Out', 1),
(203, '0437610897', '10:58:55', '00:00:00', '2024-11-22', 'Time_In', '', 1),
(204, '0602695024', '10:59:03', '00:00:00', '2024-11-22', 'Time_In', '', 1),
(205, '0592614496', '10:59:09', '00:00:00', '2024-11-22', 'Time_In', '', 1),
(206, '2936486250', '10:59:17', '00:00:00', '2024-11-22', 'Time_In', '', 1),
(207, '1326367786', '10:59:24', '00:00:00', '2024-11-22', 'Time_In', '', 1),
(208, '1326105305', '10:59:31', '00:00:00', '2024-11-22', 'Time_In', '', 1),
(209, '2936099581', '10:59:37', '00:00:00', '2024-11-22', 'Time_In', '', 1),
(210, '0455156897', '10:59:43', '00:00:00', '2024-11-22', 'Time_In', '', 1),
(211, '1326361572', '10:59:51', '00:00:00', '2024-11-22', 'Time_In', '', 1),
(212, '1326143350', '10:59:59', '00:00:00', '2024-11-22', 'Time_In', '', 1),
(213, '0436316051', '11:00:07', '00:00:00', '2024-11-22', 'Time_In', '', 1),
(214, '0266526931', '11:00:17', '00:00:00', '2024-11-22', 'Time_In', '', 1),
(218, '2879432643', '10:52:24', '10:52:30', '2024-11-23', 'Time_In', 'Time_Out', 1),
(219, '0437610897', '07:13:48', '00:00:00', '2024-11-23', 'Time_In', '', 0),
(220, '1326367786', '07:13:51', '00:00:00', '2024-11-23', 'Time_In', '', 0),
(221, '4049019907', '07:14:15', '00:00:00', '2024-11-23', 'Time_In', '', 0),
(222, '0592614496', '07:14:37', '00:00:00', '2024-11-23', 'Time_In', '', 0),
(223, '0602695024', '07:15:00', '00:00:00', '2024-11-23', 'Time_In', '', 0),
(224, '0455156897', '07:15:04', '00:00:00', '2024-11-23', 'Time_In', '', 0),
(225, '1326289904', '07:15:08', '00:00:00', '2024-11-23', 'Time_In', '', 0),
(226, '0596563568', '07:15:13', '00:00:00', '2024-11-23', 'Time_In', '', 0),
(227, '1326143350', '07:15:20', '00:00:00', '2024-11-23', 'Time_In', '', 0),
(228, '1326361572', '07:15:25', '00:00:00', '2024-11-23', 'Time_In', '', 0),
(229, '2936153328', '07:15:27', '00:00:00', '2024-11-23', 'Time_In', '', 0),
(230, '2936099581', '07:15:30', '00:00:00', '2024-11-23', 'Time_In', '', 0),
(231, '0266526931', '07:16:34', '00:00:00', '2024-11-23', 'Time_In', '', 0),
(232, '2863319171', '07:16:56', '00:00:00', '2024-11-23', 'Time_In', '', 0),
(240, '2879432643', '09:37:01', '09:37:31', '2024-11-25', 'Time_In', 'Time_Out', 0),
(253, '2879432643', '11:42:15', '00:00:00', '2024-11-27', 'Time_In', '', 0);

-- --------------------------------------------------------

--
-- Table structure for table `grades`
--

CREATE TABLE `grades` (
  `id` int(11) NOT NULL,
  `NAME` varchar(255) NOT NULL,
  `Programming` int(11) NOT NULL,
  `Social Science` int(11) NOT NULL,
  `HRO` int(11) NOT NULL,
  `Filipino 11+` int(11) NOT NULL,
  `MEDLIT` int(11) NOT NULL,
  `Literature 1` int(11) NOT NULL,
  `Literature 2` int(11) NOT NULL,
  `English 11+` int(11) NOT NULL,
  `Physical Education 3` varchar(255) NOT NULL,
  `General Average` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `grades`
--

INSERT INTO `grades` (`id`, `NAME`, `Programming`, `Social Science`, `HRO`, `Filipino 11+`, `MEDLIT`, `Literature 1`, `Literature 2`, `English 11+`, `Physical Education 3`, `General Average`) VALUES
(22, 'Arnold Rodas', 74, 75, 75, 89, 76, 89, 87, 74, '74', 79),
(23, 'Edgardo Capunitan', 74, 74, 74, 74, 70, 73, 74, 74, '74', 73),
(24, 'Ross Gerald Kasalag', 76, 75, 75, 75, 75, 75, 75, 90, '75', 77);

-- --------------------------------------------------------

--
-- Table structure for table `intervention`
--

CREATE TABLE `intervention` (
  `id` int(11) NOT NULL,
  `studentname` varchar(1000) NOT NULL,
  `teacher` varchar(1000) NOT NULL,
  `subject` varchar(1000) NOT NULL,
  `Cause` varchar(1000) NOT NULL,
  `Solution` varchar(1000) NOT NULL,
  `dateissued` varchar(10) NOT NULL,
  `interventionstatus` varchar(255) NOT NULL,
  `dateofcompletion` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `intervention`
--

INSERT INTO `intervention` (`id`, `studentname`, `teacher`, `subject`, `Cause`, `Solution`, `dateissued`, `interventionstatus`, `dateofcompletion`) VALUES
(62, 'Arnold Rodas', 'Mr. Landeza', 'Programming', 'Failed Exam', 'Make-up Class', '2024-11-20', 'Completed', '2024-11-28'),
(63, 'Edgardo Capunitan', 'Ms. Bacoy', 'Literature 1', 'Failed to Submit', 'Make-up Class', '2024-11-20', 'Completed', '2024-11-28'),
(65, 'Edgardo Capunitan', 'Ms. Ursolino', 'HRO', 'Always Absent', 'Project Development', '2024-11-20', 'Completed', '2024-12-02'),
(66, 'Edgardo Capunitan', 'Ms. Cruz', 'English 11+', 'Failed to Submit', 'Remedial', '2024-11-20', 'Completed', '2024-12-03'),
(69, 'Edgardo Capunitan', 'Mr. Landeza', 'Programming', 'NO MIDTERM EXAM', 'Make-up Class', '', '', ''),
(70, 'Arnold Rodas', 'Ms. Cruz', 'English 11+', '3 consecutive absent', 'Guidance Consultation', '2024-12-03', 'Completed', '2024-12-03');

-- --------------------------------------------------------

--
-- Table structure for table `status`
--

CREATE TABLE `status` (
  `id` int(11) NOT NULL,
  `NAME` varchar(255) NOT NULL,
  `atRiskStatus` varchar(255) NOT NULL,
  `failedSubjects` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `status`
--

INSERT INTO `status` (`id`, `NAME`, `atRiskStatus`, `failedSubjects`) VALUES
(16, 'Amoranto, Fritzwilliam', 'Passed', 0),
(17, 'Arevalo, Cris Jireh', 'Passed', 0),
(18, 'Baluyot, Romar Gabriel', 'Passed', 0),
(19, 'Cabrera, Anton Philip', 'Passed', 0),
(20, 'Calalang, Gideon', 'Passed', 0),
(21, 'Calayag, Adrian L.', 'Passed', 0),
(22, 'Caneo, Wendell A.', 'Passed', 0),
(23, 'Carola, John Keeshanie L.', 'Passed', 0),
(24, 'Cervantes, Kim Rovic', 'Passed', 0),
(25, 'Cortez, Ronnell M.', 'Passed', 0),
(26, 'Debuton, Gian Carlo', 'Passed', 0),
(27, 'Decena, Riddeck Andre Dacumos', 'Passed', 0),
(28, 'Erocido, Kyle Joshua A.', 'Passed', 0),
(29, 'Escala, Uan Emerald G.', 'Passed', 0),
(30, 'Gonzales, Ren Gerald V.', 'Passed', 0),
(31, 'Forio, Jhon Paul', 'Passed', 0),
(32, 'Hular, Tristan Charles S.', 'Passed', 0),
(33, 'Seigfrid, Zaki A. Macuto', 'Passed', 0),
(34, 'Kerby L. Maglonso', 'Passed', 0),
(35, 'Maloma, Celestino', 'Passed', 0),
(36, 'Magno, Mark Jherico A.', 'Passed', 0),
(37, 'Melgar, Rancel Anthonyo', 'Passed', 0),
(38, 'Moron, Jhon Arrel', 'Passed', 0),
(39, 'Jose Lary D. Motus', 'Passed', 0),
(40, 'Marcelino N. Rapanan', 'Passed', 0),
(41, 'Reyes, Zcian Khierby A.', 'Passed', 0),
(42, 'Salazar, Joshua P.', 'Passed', 0),
(43, 'Bermio, Ashley Justine Heart', 'Passed', 0),
(44, 'Capunitan, Ma. Krizel Ann C', 'Passed', 0),
(45, 'Dial, Jully Anne Fhe T.', 'Passed', 0),
(46, 'Notarte, Janin Mae E.', 'Passed', 0),
(47, 'Navarro, Elyza Mae B.', 'Passed', 0),
(48, 'Renegado, Rowena D.', 'Passed', 0),
(50, 'Arnold Rodas', 'At-Risk', 1),
(51, 'Edgardo Capunitan', 'At-Risk', 2),
(52, 'Ross Gerald Kasalag', 'Passed', 0);

-- --------------------------------------------------------

--
-- Table structure for table `student`
--

CREATE TABLE `student` (
  `LOGS` int(255) NOT NULL,
  `RFID` varchar(10) NOT NULL,
  `NAME` varchar(255) NOT NULL,
  `YEAR_AND_COURSE` varchar(30) NOT NULL,
  `NUMBER` varchar(11) NOT NULL,
  `ADDRESS` varchar(255) NOT NULL,
  `EMAIL_ADDRESS` varchar(255) NOT NULL,
  `LATE_COUNT` int(11) NOT NULL,
  `ABSENT` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `student`
--

INSERT INTO `student` (`LOGS`, `RFID`, `NAME`, `YEAR_AND_COURSE`, `NUMBER`, `ADDRESS`, `EMAIL_ADDRESS`, `LATE_COUNT`, `ABSENT`) VALUES
(9029343, '0455156897', 'Amoranto, Fritzwilliam', '12-ICT', '09182613267', '128 A. Mabini St. Brgy DelaPaz Biñan Laguna', 'fritzwilliamamoranto@trimexcolleges.edu.ph', 0, 0),
(9029344, '0592614496', 'Arevalo, Cris Jireh', '12-ICT', '09777612115', 'Zone 6 Malaban Pantalan', 'crisjireharevalo@trimexcolleges.edu.ph', 0, 0),
(9029345, '0464277137', 'Baluyot, Romar Gabriel', '12-ICT', '09551456683', 'Blk 8 Lot25 Villa De Oro', 'RomarGabrielBaluyot@trimexcolleges.edu.ph', 0, 0),
(9029346, '4049366227', 'Cabrera, Anton Philip', '12-ICT', '09093545001', 'Purok 3 Mamplasan', 'AntonPhilipCabrera@trimexcolleges.edu.ph', 0, 0),
(9029347, '2880277587', 'Calalang, Gideon', '12-ICT', '09179674031', 'MetroVille, Brgy San Francisco', 'GideonAnthonyCalalang@trimexcolleges.edu.ph', 0, 0),
(9029348, '1326367786', 'Calayag, Adrian L.', '12-ICT', '09297965545', 'Brgy. Sto Nino', 'AdrianCalayag@trimexcolleges.edu.ph', 0, 0),
(9029350, '0266526931', 'Caneo, Wendell A.', '12-ICT', '09946122593', 'Brgy. Tagapo, Tionco Subd.', 'WendellCaneo@trimexcolleges.edu.ph', 0, 0),
(9029351, '1326374997', 'Carola, John Keeshanie L.', '12-ICT', '09213024117', 'St. Rose 2 Blk 3 Lot 12', 'CarolaKeeshanie@gmail.com', 0, 0),
(9029352, '0436316051', 'Cervantes, Kim Rovic', '12-ICT', '09755293295', 'Blk 7 Lot 3 Samasikap', 'KimRovicCervantes@trimexcolleges.edu.ph', 0, 0),
(9029353, '0982495707', 'Cortez, Ronnell M.', '12-ICT', '09863960914', '0291 Purok 5 Mamplasan ', 'ronnellcortez@trimexcolleges.edu.ph', 0, 0),
(9029354, '465155729\n', 'Debuton, Gian Carlo', '12-ICT', '09911179661', 'Purok 2 Sto. Nino', 'GianCarloOlonDebuton@trimexcolleges.edu.ph', 0, 0),
(9029355, '596945504\n', 'Decena, Riddeck Andre Dacumos', '12-ICT', '09061627633', 'Purok 6 Ganado', 'RiddeckAndreDecena@trimexcolleges.edu.ph', 0, 0),
(9029356, '588262528\n', 'Erocido, Kyle Joshua A.', '12-ICT', '09914905640', 'Purok 7 Ganado', 'Joshua11.erocido@gmail.com', 0, 0),
(9029357, '2936099581', 'Escala, Uan Emerald G.', '12-ICT', '09458720381', 'Purok 4 Mamplasan', '', 0, 0),
(9029359, '0602695024', 'Gonzales, Ren Gerald V.', '12-ICT', '09317912330', 'Almamanzo Subd. San Antonio', 'rengeraldgonzales@trimexcolleges.edu.ph', 0, 0),
(9029361, '1326289904', 'Hular, Tristan Charles S.', '12-ICT', '09194409631', 'Canlalay Binan Laguna', 'tristancharleshular@trimexcolleges.edu.ph', 0, 0),
(9029362, '602967664', 'Seigfrid, Zaki A. Macuto', '12-ICT', '09193881188', 'Brgy. Ibaba Sta. Rosa, Laguna', 'seigfridzakimakato@trimexcolleges.edu.ph', 0, 0),
(9029363, '2863319171', 'Kerby L. Maglonso', '12-ICT', '09636432594', 'San Antonio, Binan Laguna', 'kerbymaglonso@trimexcolleges.edu.ph', 0, 0),
(9029365, '588177248', 'Magno, Mark Jherico A.', '12-ICT', '09935835337', 'Wawa, Malaban, Biñan Laguna', 'markjhericomagno@trimexcolleges.edu.ph ', 0, 0),
(9029366, '2936486250', 'Melgar, Rancel Anthonyo', '12-ICT', '09949855078', 'Brgy. Timbao, Binan Laguna', 'rancelanthonyomelgar@trimexcolleges.edu.ph', 0, 0),
(9029367, '466206353', 'Moron, Jhon Arrel', '12-ICT', '09947538760', '', 'johnarrelmoron@gmail.com', 0, 0),
(9029368, '4049019907', 'Jose Lary D. Motus', '12-ICT', '09947571216', 'Brgy. Mamplasan Pag-asa Biñan Laguna', 'joselaryjr.motus@trimexcolleges.edu.ph', 0, 0),
(9029370, '2936153328', 'Reyes, Zcian Khierby A.', '12-ICT', '09708416700', '160 Tubigan Biñan City Laguna', 'zciankhierbyreyes@trimexcolleges.edu.ph', 0, 0),
(9029371, '458539921', 'Salazar, Joshua P.', '12-ICT', '09201145379', 'Brgy. Ganado Biñan City Laguna', 'joshuasalazar@trimexcolleges.edu.ph', 0, 0),
(9029372, '0596563568', 'Bermio, Ashley Justine Heart', '12-ICT', '09213015246', 'Brgy. Caingin, Sta. Rosa Laguna', 'ashleyjustineheartbermio@trimexcolleges.edu.ph', 0, 0),
(9029373, '30882466', 'Capunitan, Ma. Krizel Ann C', '12-ICT', '09701292598', 'Brgy. Sto. Tomas Biñan Laguna', 'ma.krizelanncapunitan@trimexcolleges.edu.ph', 0, 0),
(9029374, '1326361572', 'Dial, Jully Anne Fhe T.', '12-ICT', '09949360027', 'Brgy. Mamplasan Biñan Laguna', 'jullyannedial@trimexcolleges.edu.ph', 0, 0),
(9029375, '1326105305', 'Notarte, Janin Mae E.', '12-ICT', '09091523352', 'Brgy. Mamplasan Biñan Laguna', 'Janinmaenotarte@trimexcolleges.edu.ph', 0, 0),
(9029376, '0436222881', 'Navarro, Elyza Mae B.', '12-ICT', '09686805420', 'B6 L8 Neptune St. South Plains II Brgy. Sto. Tomas', 'elyzamaenavarro@trimexcolleges.edu.ph', 0, 0),
(9029377, '1326143350', 'Renegado, Rowena D.', '12-ICT', '09936098419', 'Biñan City, Laguna', 'rowenarenegado@trimexcolleges.edu.ph', 0, 0),
(9029378, '2879432643', 'Edgardo Capunitan', '4th-BSIT 1', '09563255695', 'Langkiwabb', 'edgardocapunitan@trimexcolleges.edu.ph', 0, 1),
(437610897, '0437610897', 'Marcelino N. Rapanan', '12-ICT', '09636897689', 'Sto. Nino Purok 2 Biñan Laguna', 'marcelinorapanan@trimexcolleges.edu.ph', 1, 0),
(0, '0735792992', 'Arnold Rodas', '4th-BSIT', '09391301675', 'Santa Rosa, Laguna', 'arnoldrodas@trimexcolleges.edu.ph', 0, 0),
(0, '1326348589', 'Ross Gerald Kasalag', '4th-BSIT', '0939131910', 'Pacita 1', 'rossgeraldkasilag@trimexcolleges.edu.ph', 0, 0);

-- --------------------------------------------------------

--
-- Table structure for table `subjectsteacher`
--

CREATE TABLE `subjectsteacher` (
  `id` int(11) NOT NULL,
  `teacher` varchar(255) NOT NULL,
  `subject` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `subjectsteacher`
--

INSERT INTO `subjectsteacher` (`id`, `teacher`, `subject`) VALUES
(1, 'Mr. Landeza', 'Programming'),
(2, 'Ms. Cruz', 'English 11+'),
(3, 'Mr. Dejan', 'Social Science'),
(4, 'Ms. Ursolino', 'Filipino 11+'),
(5, 'Ms. Ursolino', 'HRO'),
(6, 'Ms. Casipit', 'Physical Education 3'),
(7, 'Ms. Bacoy', 'MEDLIT'),
(8, 'Mr. Bautista', 'Literature 2'),
(9, 'Ms. Bacoy', 'Literature 1');

-- --------------------------------------------------------

--
-- Table structure for table `teacher`
--

CREATE TABLE `teacher` (
  `id` int(11) NOT NULL,
  `username` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL,
  `name` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `teacher`
--

INSERT INTO `teacher` (`id`, `username`, `password`, `name`) VALUES
(5, 'arnold', 'rodas', 'Arnold Rodas'),
(6, 'bong', 'bong', 'Edgardo Capunitan'),
(8, 'alfred', 'paldez', 'Alfred Paldez'),
(9, 'landeza', 'landeza', 'Mr. Landeza'),
(10, 'cruz', 'cruz', 'Ms. Cruz'),
(11, 'dejan', 'dejan', 'Mr. Dejan'),
(12, 'ursolino', 'ursolino', 'Ms. Ursolino'),
(13, 'casipit', 'casipit', 'Ms. Casipit'),
(14, 'bacoy', 'bacoy', 'Ms. Bacoy'),
(15, 'bautista', 'bautista', 'Mr. Bautista');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `admin`
--
ALTER TABLE `admin`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `attendance`
--
ALTER TABLE `attendance`
  ADD PRIMARY KEY (`ATTENDANCE`);

--
-- Indexes for table `grades`
--
ALTER TABLE `grades`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `NAME` (`NAME`);

--
-- Indexes for table `intervention`
--
ALTER TABLE `intervention`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `status`
--
ALTER TABLE `status`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `subjectsteacher`
--
ALTER TABLE `subjectsteacher`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `teacher`
--
ALTER TABLE `teacher`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `admin`
--
ALTER TABLE `admin`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `attendance`
--
ALTER TABLE `attendance`
  MODIFY `ATTENDANCE` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=254;

--
-- AUTO_INCREMENT for table `grades`
--
ALTER TABLE `grades`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=25;

--
-- AUTO_INCREMENT for table `intervention`
--
ALTER TABLE `intervention`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=71;

--
-- AUTO_INCREMENT for table `status`
--
ALTER TABLE `status`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=53;

--
-- AUTO_INCREMENT for table `subjectsteacher`
--
ALTER TABLE `subjectsteacher`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT for table `teacher`
--
ALTER TABLE `teacher`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
