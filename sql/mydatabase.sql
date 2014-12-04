-- phpMyAdmin SQL Dump
-- version 4.0.4
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: May 01, 2014 at 07:45 PM
-- Server version: 5.6.12-log
-- PHP Version: 5.4.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `mydatabase`
--
CREATE DATABASE IF NOT EXISTS `mydatabase` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `mydatabase`;

-- --------------------------------------------------------

--
-- Table structure for table `glenn quagmire`
--

CREATE TABLE IF NOT EXISTS `glenn quagmire` (
  `Type` varchar(10) NOT NULL,
  `125` int(11) DEFAULT NULL,
  `250` int(11) DEFAULT NULL,
  `500` int(11) DEFAULT NULL,
  `1000` int(11) DEFAULT NULL,
  `2000` int(11) DEFAULT NULL,
  `4000` int(11) DEFAULT NULL,
  `8000` int(11) DEFAULT NULL,
  PRIMARY KEY (`Type`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `glenn quagmire`
--

INSERT INTO `glenn quagmire` (`Type`, `125`, `250`, `500`, `1000`, `2000`, `4000`, `8000`) VALUES
('AC', NULL, 20, 20, 20, 15, 15, 20),
('BC', NULL, 10, 10, 10, 10, 10, NULL),
('Masked AC', NULL, 20, 20, 20, 20, 20, 20),
('Masked BC', NULL, 10, 10, 10, 10, 10, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `joseph swanson`
--

CREATE TABLE IF NOT EXISTS `joseph swanson` (
  `Type` varchar(10) NOT NULL,
  `125` int(11) DEFAULT NULL,
  `250` int(11) DEFAULT NULL,
  `500` int(11) DEFAULT NULL,
  `1000` int(11) DEFAULT NULL,
  `2000` int(11) DEFAULT NULL,
  `4000` int(11) DEFAULT NULL,
  `8000` int(11) DEFAULT NULL,
  PRIMARY KEY (`Type`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `joseph swanson`
--

INSERT INTO `joseph swanson` (`Type`, `125`, `250`, `500`, `1000`, `2000`, `4000`, `8000`) VALUES
('AC', NULL, 5, 10, 10, 10, 15, 15),
('BC', NULL, 0, 0, 0, 5, 0, NULL),
('Masked AC', NULL, 10, 15, 10, 10, 10, 10),
('Masked BC', NULL, -5, 0, -5, -5, -5, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `lois griffin`
--

CREATE TABLE IF NOT EXISTS `lois griffin` (
  `Type` varchar(10) NOT NULL,
  `125` int(11) DEFAULT NULL,
  `250` int(11) DEFAULT NULL,
  `500` int(11) DEFAULT NULL,
  `1000` int(11) DEFAULT NULL,
  `2000` int(11) DEFAULT NULL,
  `4000` int(11) DEFAULT NULL,
  `8000` int(11) DEFAULT NULL,
  PRIMARY KEY (`Type`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `lois griffin`
--

INSERT INTO `lois griffin` (`Type`, `125`, `250`, `500`, `1000`, `2000`, `4000`, `8000`) VALUES
('AC', NULL, 30, 40, 40, 30, 35, 40),
('BC', NULL, 10, 10, 10, 5, 5, NULL),
('Masked AC', NULL, 30, 40, 50, 40, 40, 40),
('Masked BC', NULL, 0, 0, -5, 0, 10, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `patient`
--

CREATE TABLE IF NOT EXISTS `patient` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `First Name` varchar(20) NOT NULL,
  `Last Name` varchar(20) NOT NULL,
  `Sex` varchar(6) NOT NULL,
  `Age` int(11) NOT NULL,
  `Race` varchar(10) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=5 ;

--
-- Dumping data for table `patient`
--

INSERT INTO `patient` (`ID`, `First Name`, `Last Name`, `Sex`, `Age`, `Race`) VALUES
(1, 'Peter', 'Griffin', 'Male', 42, 'White'),
(2, 'Lois', 'Griffin', 'Female', 27, 'White'),
(3, 'Glenn', 'Quagmire', 'Male', 35, 'White'),
(4, 'Joseph', 'Swanson', 'Male', 13, 'White');

-- --------------------------------------------------------

--
-- Table structure for table `peter griffin`
--

CREATE TABLE IF NOT EXISTS `peter griffin` (
  `Type` varchar(10) NOT NULL,
  `125` int(11) DEFAULT NULL,
  `250` int(11) DEFAULT NULL,
  `500` int(11) DEFAULT NULL,
  `1000` int(11) DEFAULT NULL,
  `2000` int(11) DEFAULT NULL,
  `4000` int(11) DEFAULT NULL,
  `8000` int(11) DEFAULT NULL,
  PRIMARY KEY (`Type`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `peter griffin`
--

INSERT INTO `peter griffin` (`Type`, `125`, `250`, `500`, `1000`, `2000`, `4000`, `8000`) VALUES
('AC', NULL, 20, 20, 20, 15, 15, 20),
('BC', NULL, 10, 10, 10, 10, 15, NULL),
('Masked AC', NULL, 25, 20, 25, 20, 25, 25),
('Masked BC', NULL, 10, 10, 10, 10, 10, NULL);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
