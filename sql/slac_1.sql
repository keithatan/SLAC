-- phpMyAdmin SQL Dump
-- version 4.4.14
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Sep 28, 2015 at 06:58 AM
-- Server version: 5.6.26
-- PHP Version: 5.6.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `slac`
--

-- --------------------------------------------------------

--
-- Table structure for table `patients`
--

CREATE TABLE IF NOT EXISTS `patients` (
  `id` int(11) NOT NULL,
  `first_name` varchar(255) DEFAULT NULL,
  `last_name` varchar(255) DEFAULT NULL,
  `description` varchar(255) DEFAULT NULL,
  `R_125` int(11) DEFAULT NULL,
  `R_250` int(11) DEFAULT NULL,
  `R_500` int(11) DEFAULT NULL,
  `R_750` int(11) DEFAULT NULL,
  `R_1000` int(11) DEFAULT NULL,
  `R_1500` int(11) DEFAULT NULL,
  `R_2000` int(11) DEFAULT NULL,
  `R_3000` int(11) DEFAULT NULL,
  `R_4000` int(11) DEFAULT NULL,
  `R_6000` int(11) DEFAULT NULL,
  `R_8000` int(11) DEFAULT NULL,
  `L_125` int(11) DEFAULT NULL,
  `L_250` int(11) DEFAULT NULL,
  `L_500` int(11) DEFAULT NULL,
  `L_750` int(11) DEFAULT NULL,
  `L_1000` int(11) DEFAULT NULL,
  `L_1500` int(11) DEFAULT NULL,
  `L_2000` int(11) DEFAULT NULL,
  `L_3000` int(11) DEFAULT NULL,
  `L_4000` int(11) DEFAULT NULL,
  `L_6000` int(11) DEFAULT NULL,
  `L_8000` int(11) DEFAULT NULL,
  `BR_125` int(11) DEFAULT NULL,
  `BR_250` int(11) DEFAULT NULL,
  `BR_500` int(11) DEFAULT NULL,
  `BR_750` int(11) DEFAULT NULL,
  `BR_1000` int(11) DEFAULT NULL,
  `BR_1500` int(11) DEFAULT NULL,
  `BR_2000` int(11) DEFAULT NULL,
  `BR_3000` int(11) DEFAULT NULL,
  `BR_4000` int(11) DEFAULT NULL,
  `BR_6000` int(11) DEFAULT NULL,
  `BR_8000` int(11) DEFAULT NULL,
  `BL_125` int(11) DEFAULT NULL,
  `BL_250` int(11) DEFAULT NULL,
  `BL_500` int(11) DEFAULT NULL,
  `BL_750` int(11) DEFAULT NULL,
  `BL_1000` int(11) DEFAULT NULL,
  `BL_1500` int(11) DEFAULT NULL,
  `BL_2000` int(11) DEFAULT NULL,
  `BL_3000` int(11) DEFAULT NULL,
  `BL_4000` int(11) DEFAULT NULL,
  `BL_6000` int(11) DEFAULT NULL,
  `BL_8000` int(11) DEFAULT NULL
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `patients`
--

INSERT INTO `patients` (`id`, `first_name`, `last_name`, `description`, `R_125`, `R_250`, `R_500`, `R_750`, `R_1000`, `R_1500`, `R_2000`, `R_3000`, `R_4000`, `R_6000`, `R_8000`, `L_125`, `L_250`, `L_500`, `L_750`, `L_1000`, `L_1500`, `L_2000`, `L_3000`, `L_4000`, `L_6000`, `L_8000`, `BR_125`, `BR_250`, `BR_500`, `BR_750`, `BR_1000`, `BR_1500`, `BR_2000`, `BR_3000`, `BR_4000`, `BR_6000`, `BR_8000`, `BL_125`, `BL_250`, `BL_500`, `BL_750`, `BL_1000`, `BL_1500`, `BL_2000`, `BL_3000`, `BL_4000`, `BL_6000`, `BL_8000`) VALUES
(1, 'Aneesh', 'Samudrala', 'nothing', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 11, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
(2, 'Aneesh', 'Samudrala', 'nothing', 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 11, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
(3, 'a', '', '', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0),
(4, 'a', '', '', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0),
(5, 'a', '', '', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0),
(6, 'Test subject', '', '', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `patients`
--
ALTER TABLE `patients`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `patients`
--
ALTER TABLE `patients`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=7;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
