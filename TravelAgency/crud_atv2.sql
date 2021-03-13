-- phpMyAdmin SQL Dump
-- version 5.0.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Feb 20, 2021 at 03:15 AM
-- Server version: 10.4.17-MariaDB
-- PHP Version: 8.0.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `crud_atv2`
--

-- --------------------------------------------------------

--
-- Table structure for table `pacoteturistico`
--

CREATE TABLE `pacoteturistico` (
  `Id` int(11) NOT NULL,
  `Nome` varchar(80) NOT NULL,
  `Origem` varchar(80) NOT NULL,
  `Destino` varchar(100) NOT NULL,
  `Saida` date NOT NULL,
  `Retorno` date NOT NULL,
  `Atrativos` varchar(100) NOT NULL,
  `Usuario` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `pacoteturistico`
--

INSERT INTO `pacoteturistico` (`Id`, `Nome`, `Origem`, `Destino`, `Saida`, `Retorno`, `Atrativos`, `Usuario`) VALUES
(1, 'New York Winter', 'Rio de Janeiro - RJ', 'New York - United States', '2021-01-05', '2021-02-05', 'Empire state building, Central Park', 1),
(3, 'The king of the Jungle', 'Rio de Janeiro - RJ', 'South Africa - Africa', '2021-08-01', '2021-08-16', 'Kruger National Park, Mesa Mountain', 1);

-- --------------------------------------------------------

--
-- Table structure for table `usuario`
--

CREATE TABLE `usuario` (
  `Id` int(11) NOT NULL,
  `Nome` varchar(30) DEFAULT NULL,
  `DataNascimento` date DEFAULT NULL,
  `Login` varchar(80) NOT NULL,
  `Senha` varchar(80) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `usuario`
--

INSERT INTO `usuario` (`Id`, `Nome`, `DataNascimento`, `Login`, `Senha`) VALUES
(1, 'Rodrigo', '0001-01-01', 'ab', 'ab');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `pacoteturistico`
--
ALTER TABLE `pacoteturistico`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `pacoteturistico_ibfk_1` (`Usuario`);

--
-- Indexes for table `usuario`
--
ALTER TABLE `usuario`
  ADD PRIMARY KEY (`Id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `pacoteturistico`
--
ALTER TABLE `pacoteturistico`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT for table `usuario`
--
ALTER TABLE `usuario`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `pacoteturistico`
--
ALTER TABLE `pacoteturistico`
  ADD CONSTRAINT `pacoteturistico_ibfk_1` FOREIGN KEY (`Usuario`) REFERENCES `usuario` (`Id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
