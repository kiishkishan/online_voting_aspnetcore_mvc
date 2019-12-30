-- phpMyAdmin SQL Dump
-- version 4.9.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Dec 30, 2019 at 12:28 PM
-- Server version: 10.4.11-MariaDB
-- PHP Version: 7.4.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `onlinevoting`
--

-- --------------------------------------------------------

--
-- Table structure for table `ballot_paper`
--

CREATE TABLE `ballot_paper` (
  `ElectionId` varchar(50) NOT NULL,
  `CandidateId` varchar(50) NOT NULL,
  `ElectionDate` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `ballot_paper`
--

INSERT INTO `ballot_paper` (`ElectionId`, `CandidateId`, `ElectionDate`) VALUES
('ELEC/001', 'PRESPOLL2020/001', '01/01/2020'),
('ELEC/001', 'PRESPOLL2020/002', '01/01/2020');

-- --------------------------------------------------------

--
-- Table structure for table `candidate`
--

CREATE TABLE `candidate` (
  `CandidateId` varchar(50) NOT NULL,
  `Candidate Name` varchar(100) NOT NULL,
  `Party` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `candidate`
--

INSERT INTO `candidate` (`CandidateId`, `Candidate Name`, `Party`) VALUES
('PRESPOLL2020/001', '', 'Party A'),
('PRESPOLL2020/002', '', 'Party B');

-- --------------------------------------------------------

--
-- Table structure for table `election`
--

CREATE TABLE `election` (
  `ElectionId` varchar(50) NOT NULL,
  `ElectionName` varchar(100) NOT NULL,
  `ElectionType` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `election`
--

INSERT INTO `election` (`ElectionId`, `ElectionName`, `ElectionType`) VALUES
('ELEC/001', 'Presidentional Election 2020', 'Presidential Election');

-- --------------------------------------------------------

--
-- Table structure for table `voter`
--

CREATE TABLE `voter` (
  `VoterId` varchar(50) NOT NULL,
  `Name` varchar(150) NOT NULL,
  `Address` varchar(200) NOT NULL,
  `EMail` varchar(100) NOT NULL,
  `Voted` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `voter`
--

INSERT INTO `voter` (`VoterId`, `Name`, `Address`, `EMail`, `Voted`) VALUES
('SL/JAF/001', 'Kishanth', 'Athiady, Jaffna', 'kishanth001@gmail.com', 0),
('SL/JAF/002', 'Thuvarakan', 'Chundikuli, Jaffna', 'kishanth001@gmail.com', 0);

-- --------------------------------------------------------

--
-- Table structure for table `vote_cast`
--

CREATE TABLE `vote_cast` (
  `VoterId` varchar(50) NOT NULL,
  `ElectionId` varchar(50) NOT NULL,
  `CandidateId` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `vote_cast`
--

INSERT INTO `vote_cast` (`VoterId`, `ElectionId`, `CandidateId`) VALUES
('SL/JAF/001', 'ELEC/001', 'PRESPOLL2020/001'),
('SL/JAF/002', 'ELEC/001', 'PRESPOLL2020/002');

-- --------------------------------------------------------

--
-- Table structure for table `vote_count`
--

CREATE TABLE `vote_count` (
  `ElectionId` varchar(50) NOT NULL,
  `CandidateId` varchar(50) NOT NULL,
  `Votes` bigint(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `ballot_paper`
--
ALTER TABLE `ballot_paper`
  ADD KEY `candidate_id` (`CandidateId`),
  ADD KEY `election_Id` (`ElectionId`) USING BTREE;

--
-- Indexes for table `candidate`
--
ALTER TABLE `candidate`
  ADD KEY `CandidateId` (`CandidateId`);

--
-- Indexes for table `election`
--
ALTER TABLE `election`
  ADD PRIMARY KEY (`ElectionId`);

--
-- Indexes for table `voter`
--
ALTER TABLE `voter`
  ADD PRIMARY KEY (`VoterId`);

--
-- Indexes for table `vote_cast`
--
ALTER TABLE `vote_cast`
  ADD KEY `VoterId` (`VoterId`),
  ADD KEY `ElectionId` (`ElectionId`),
  ADD KEY `CandidateId` (`CandidateId`);

--
-- Indexes for table `vote_count`
--
ALTER TABLE `vote_count`
  ADD KEY `ElectionId` (`ElectionId`),
  ADD KEY `CandidateId` (`CandidateId`);

--
-- Constraints for dumped tables
--

--
-- Constraints for table `ballot_paper`
--
ALTER TABLE `ballot_paper`
  ADD CONSTRAINT `candidate_id` FOREIGN KEY (`CandidateId`) REFERENCES `candidate` (`CandidateId`),
  ADD CONSTRAINT `election_id` FOREIGN KEY (`ElectionId`) REFERENCES `election` (`ElectionId`);

--
-- Constraints for table `vote_cast`
--
ALTER TABLE `vote_cast`
  ADD CONSTRAINT `voting_candidate_id` FOREIGN KEY (`CandidateId`) REFERENCES `candidate` (`CandidateId`),
  ADD CONSTRAINT `voting_election_id` FOREIGN KEY (`ElectionId`) REFERENCES `election` (`ElectionId`),
  ADD CONSTRAINT `voting_voter_id` FOREIGN KEY (`VoterId`) REFERENCES `voter` (`VoterId`);

--
-- Constraints for table `vote_count`
--
ALTER TABLE `vote_count`
  ADD CONSTRAINT `votecount_candidate_id` FOREIGN KEY (`CandidateId`) REFERENCES `candidate` (`CandidateId`),
  ADD CONSTRAINT `votecount_election_id` FOREIGN KEY (`ElectionId`) REFERENCES `election` (`ElectionId`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
