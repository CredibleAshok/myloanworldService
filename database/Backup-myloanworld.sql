CREATE DATABASE  IF NOT EXISTS `myloanworld` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `myloanworld`;
-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: 148.72.232.182    Database: myloanworld
-- ------------------------------------------------------
-- Server version	5.5.51-38.1-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `applicationDetail`
--

DROP TABLE IF EXISTS `applicationDetail`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `applicationDetail` (
  `applicationId` int(11) NOT NULL AUTO_INCREMENT,
  `applicationStatusId` int(11) NOT NULL,
  `customerId` int(11) NOT NULL,
  `enquiryId` int(11) DEFAULT NULL,
  `applicationTypeId` int(11) NOT NULL,
  `validTo` datetime DEFAULT NULL,
  `validFrom` datetime DEFAULT NULL,
  `creationDate` datetime NOT NULL,
  PRIMARY KEY (`applicationId`),
  KEY `fk_applicationDetail_applicationStatus` (`applicationStatusId`),
  KEY `fk_applicationDetail_applicationType` (`applicationTypeId`),
  KEY `fk_applicationDetail_customer` (`customerId`),
  CONSTRAINT `fk_applicationDetail_applicationStatus` FOREIGN KEY (`applicationStatusId`) REFERENCES `applicationStatus` (`applicationStatusId`),
  CONSTRAINT `fk_applicationDetail_applicationType` FOREIGN KEY (`applicationTypeId`) REFERENCES `applicationType` (`applicationTypeId`),
  CONSTRAINT `fk_applicationDetail_customer` FOREIGN KEY (`customerId`) REFERENCES `customer` (`customerId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `applicationDetail`
--

LOCK TABLES `applicationDetail` WRITE;
/*!40000 ALTER TABLE `applicationDetail` DISABLE KEYS */;
/*!40000 ALTER TABLE `applicationDetail` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `applicationHistory`
--

DROP TABLE IF EXISTS `applicationHistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `applicationHistory` (
  `applicationHistoryId` int(11) NOT NULL AUTO_INCREMENT,
  `applicationId` int(11) NOT NULL,
  `applicationStatusId` int(11) DEFAULT NULL,
  `comments` varchar(200) DEFAULT NULL,
  `creationDate` datetime DEFAULT NULL,
  `createdBy` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`applicationHistoryId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `applicationHistory`
--

LOCK TABLES `applicationHistory` WRITE;
/*!40000 ALTER TABLE `applicationHistory` DISABLE KEYS */;
/*!40000 ALTER TABLE `applicationHistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `applicationStatus`
--

DROP TABLE IF EXISTS `applicationStatus`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `applicationStatus` (
  `applicationStatusId` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  `validFrom` datetime DEFAULT NULL,
  `validTo` datetime DEFAULT NULL,
  `updatedBy` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`applicationStatusId`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `applicationStatus`
--

LOCK TABLES `applicationStatus` WRITE;
/*!40000 ALTER TABLE `applicationStatus` DISABLE KEYS */;
INSERT INTO `applicationStatus` VALUES (1,'With galaxy',NULL,NULL,NULL),(2,'With Galaxy',NULL,NULL,NULL),(3,'With Bank',NULL,NULL,NULL),(4,'Verification',NULL,NULL,NULL),(5,'Approved',NULL,NULL,NULL);
/*!40000 ALTER TABLE `applicationStatus` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `applicationType`
--

DROP TABLE IF EXISTS `applicationType`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `applicationType` (
  `applicationTypeId` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  `descText` varchar(10000) DEFAULT NULL,
  `href` varchar(100) DEFAULT NULL,
  `icon` varchar(100) DEFAULT NULL,
  `sref` varchar(100) DEFAULT NULL,
  `localhref` varchar(100) DEFAULT NULL,
  `validFrom` datetime DEFAULT NULL,
  `validTo` datetime DEFAULT NULL,
  `updatedDate` datetime DEFAULT NULL,
  `updatedBy` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`applicationTypeId`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `applicationType`
--

LOCK TABLES `applicationType` WRITE;
/*!40000 ALTER TABLE `applicationType` DISABLE KEYS */;
INSERT INTO `applicationType` VALUES (1,'Credit Card','At My Loan World we understand that “life happens” and that our bank accounts are often unprepared for unexpected financial needs. From medical emergencies to happy events like weddings, My Loan World’s consumer business focuses on providing unsecured','myloanworld.com/home','credit-card','homeloan','app/pages/home.html','2018-01-08 00:00:00',NULL,NULL,NULL),(2,'Car Loan','Auto Loan: At My Loan World we understand that “life happens” and that our bank accounts are often unprepared for unexpected financial needs. From medical emergencies to happy events like weddings, My Loan World’s consumer business focuses on providing unsecured','myloanworld.com/auto','car','autoloan','app/pages/auto.html','2018-01-08 00:00:00',NULL,NULL,NULL),(3,'Personal Loan','Loan Against Property: At My Loan World we understand that “life happens” and that our bank accounts are often unprepared for unexpected financial needs. From medical emergencies to happy events like weddings, My Loan World’s consumer business focuses on providing unsecured','myloanworld.com/education','cc-visa','personalloan','app/pages/education.html','2018-01-08 00:00:00',NULL,NULL,'SaxenaVaibhav'),(4,'Home Loan','Loan Against Property: At My Loan World we understand that “life happens” and that our bank accounts are often unprepared for unexpected financial needs. From medical emergencies to happy events like weddings, My Loan World’s consumer business focuses on providing unsecured','myloanworld.com/education','home','educationloan','app/pages/education.html','2018-01-08 00:00:00',NULL,NULL,NULL),(5,'Loan Against Property','Loan Against Property: At My Loan World we understand that “life happens” and that our bank accounts are often unprepared for unexpected financial needs. From medical emergencies to happy events like weddings, My Loan World’s consumer business focuses on providing unsecured','myloanworld.com','building','loanAgainstProperty','app/pages/education.html','2018-01-08 00:00:00',NULL,NULL,'SaxenaVaibhav');
/*!40000 ALTER TABLE `applicationType` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `contactDetails`
--

DROP TABLE IF EXISTS `contactDetails`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `contactDetails` (
  `contactDetailsId` int(11) NOT NULL AUTO_INCREMENT,
  `emailList` varchar(300) NOT NULL,
  `addressList` varchar(500) NOT NULL,
  `validFrom` datetime DEFAULT NULL,
  `updatedDate` datetime DEFAULT NULL,
  `updatedBy` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`contactDetailsId`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `contactDetails`
--

LOCK TABLES `contactDetails` WRITE;
/*!40000 ALTER TABLE `contactDetails` DISABLE KEYS */;
INSERT INTO `contactDetails` VALUES (1,'info@myloanworld.com','B-538 3rd Floor Nehru ground NIT Faridabad',NULL,NULL,NULL);
/*!40000 ALTER TABLE `contactDetails` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `customer`
--

DROP TABLE IF EXISTS `customer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `customer` (
  `customerId` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  `emailId` varchar(100) NOT NULL,
  `FirstName` varchar(50) DEFAULT NULL,
  `MiddleName` varchar(50) DEFAULT NULL,
  `LastName` varchar(50) DEFAULT NULL,
  `MaritalStatusId` int(11) DEFAULT NULL,
  `MotherName` varchar(50) DEFAULT NULL,
  `FatherName` varchar(50) DEFAULT NULL,
  `OtherPersonal` varchar(50) DEFAULT NULL,
  `HusbandName` varchar(50) DEFAULT NULL,
  `LocalHomeContact` varchar(50) DEFAULT NULL,
  `LocalOfficeContact` varchar(50) DEFAULT NULL,
  `LocalOfficeAddress` varchar(50) DEFAULT NULL,
  `LocalHomeAddress` varchar(50) DEFAULT NULL,
  `enquiryId` varchar(100) DEFAULT NULL COMMENT 'This tells if customer turned from Enquiry',
  `homeAddress` varchar(200) DEFAULT NULL,
  `officeAddress` varchar(200) DEFAULT NULL,
  `homeContact` varchar(25) DEFAULT NULL,
  `officeContact` varchar(25) DEFAULT NULL,
  `otherContact` varchar(25) DEFAULT NULL,
  `SexId` int(11) DEFAULT NULL,
  `loanAmt` double DEFAULT NULL,
  `accessKeyCode` varchar(100) DEFAULT NULL COMMENT 'This column does not need to be here',
  `validFrom` datetime DEFAULT NULL,
  `validTo` datetime DEFAULT NULL,
  `updatedDate` datetime DEFAULT NULL,
  `updatedBy` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`customerId`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customer`
--

LOCK TABLES `customer` WRITE;
/*!40000 ALTER TABLE `customer` DISABLE KEYS */;
INSERT INTO `customer` VALUES (1,'SaxenaVaibhav','vaibhav2121984@gmail.com',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'1','TestHomeAdd','TestofficeAdd','98765432345','98765432345','98765432345',0,123432,'1232131',NULL,NULL,NULL,NULL);
/*!40000 ALTER TABLE `customer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `customerRoleType`
--

DROP TABLE IF EXISTS `customerRoleType`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `customerRoleType` (
  `customerRoleTypeId` int(11) NOT NULL AUTO_INCREMENT,
  `roleTypeId` int(11) NOT NULL,
  `customerId` int(11) NOT NULL,
  `validTo` datetime DEFAULT NULL,
  `validFrom` datetime DEFAULT NULL,
  `updatedDate` datetime DEFAULT NULL,
  `updatedBy` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`customerRoleTypeId`),
  KEY `fk_customerRoleType_roleTypeId` (`roleTypeId`),
  KEY `fk_customerRoleType_customerId` (`customerId`),
  CONSTRAINT `fk_customerRoleType_roleTypeId` FOREIGN KEY (`roleTypeId`) REFERENCES `roleType` (`roleTypeId`),
  CONSTRAINT `fk_customerRoleType_customerId` FOREIGN KEY (`customerId`) REFERENCES `customer` (`customerId`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customerRoleType`
--

LOCK TABLES `customerRoleType` WRITE;
/*!40000 ALTER TABLE `customerRoleType` DISABLE KEYS */;
INSERT INTO `customerRoleType` VALUES (1,1,1,NULL,NULL,NULL,NULL);
/*!40000 ALTER TABLE `customerRoleType` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `enquiry`
--

DROP TABLE IF EXISTS `enquiry`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `enquiry` (
  `enquiryId` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  `contactNumber` varchar(45) DEFAULT NULL,
  `loanAmt` double DEFAULT NULL,
  `tennure` int(11) DEFAULT NULL,
  `comments` varchar(445) DEFAULT NULL,
  `creationDate` datetime NOT NULL,
  `refferId` int(11) DEFAULT NULL,
  PRIMARY KEY (`enquiryId`),
  KEY `fk_refferId` (`refferId`),
  CONSTRAINT `fk_refferId` FOREIGN KEY (`refferId`) REFERENCES `customer` (`customerId`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `enquiry`
--

LOCK TABLES `enquiry` WRITE;
/*!40000 ALTER TABLE `enquiry` DISABLE KEYS */;
INSERT INTO `enquiry` VALUES (1,'Test',NULL,NULL,NULL,NULL,'2018-01-08 00:00:00',1);
/*!40000 ALTER TABLE `enquiry` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `maritalStatus`
--

DROP TABLE IF EXISTS `maritalStatus`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `maritalStatus` (
  `MaritalStatusId` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) NOT NULL,
  `validTo` datetime DEFAULT NULL,
  `validFrom` datetime DEFAULT NULL,
  `updatedDate` datetime DEFAULT NULL,
  `updatedBy` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`MaritalStatusId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `maritalStatus`
--

LOCK TABLES `maritalStatus` WRITE;
/*!40000 ALTER TABLE `maritalStatus` DISABLE KEYS */;
/*!40000 ALTER TABLE `maritalStatus` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `menus`
--

DROP TABLE IF EXISTS `menus`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `menus` (
  `menuId` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  `sortOrder` int(11) DEFAULT NULL,
  `parentMenu` int(11) DEFAULT NULL,
  `isManagement` tinyint(1) NOT NULL,
  `roleId` int(11) DEFAULT NULL,
  `href` varchar(100) DEFAULT NULL,
  `icon` varchar(100) DEFAULT NULL,
  `sref` varchar(100) DEFAULT NULL,
  `localhref` varchar(100) DEFAULT NULL,
  `validFrom` datetime DEFAULT NULL,
  `validTo` datetime DEFAULT NULL,
  `updatedDate` datetime DEFAULT NULL,
  `updatedBy` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`menuId`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `menus`
--

LOCK TABLES `menus` WRITE;
/*!40000 ALTER TABLE `menus` DISABLE KEYS */;
INSERT INTO `menus` VALUES (1,'View Applications',1,NULL,1,NULL,NULL,'home','allApplications',NULL,NULL,NULL,NULL,NULL),(2,'View Enquiries',2,NULL,1,NULL,NULL,'home','enquiries',NULL,NULL,NULL,NULL,NULL),(3,'Maintain Application Status',3,NULL,1,1,NULL,'home','maintainApplicationStatus',NULL,NULL,NULL,NULL,NULL),(4,'Maintain Products',4,NULL,1,1,NULL,'home','maintainProducts',NULL,NULL,NULL,NULL,NULL),(5,'Manage Contact Details',5,NULL,1,1,NULL,'home','contactDetails',NULL,NULL,NULL,NULL,NULL),(6,'logOff',6,NULL,1,NULL,NULL,'home','logOff',NULL,NULL,NULL,NULL,NULL);
/*!40000 ALTER TABLE `menus` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `myLoanWorldUser`
--

DROP TABLE IF EXISTS `myLoanWorldUser`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `myLoanWorldUser` (
  `myLoanWorldUserId` int(11) NOT NULL AUTO_INCREMENT,
  `userName` varchar(100) NOT NULL,
  `accessKeyCode` varchar(100) DEFAULT NULL,
  `enquiryId` int(11) NOT NULL,
  `creationDate` datetime NOT NULL,
  PRIMARY KEY (`myLoanWorldUserId`),
  KEY `fk_enquiry_myLoanWorldUser` (`enquiryId`),
  CONSTRAINT `fk_enquiry_myLoanWorldUser` FOREIGN KEY (`enquiryId`) REFERENCES `enquiry` (`enquiryId`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `myLoanWorldUser`
--

LOCK TABLES `myLoanWorldUser` WRITE;
/*!40000 ALTER TABLE `myLoanWorldUser` DISABLE KEYS */;
INSERT INTO `myLoanWorldUser` VALUES (1,'SaxenaVaibhav','Test',1,'2018-01-08 00:00:00');
/*!40000 ALTER TABLE `myLoanWorldUser` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `roleType`
--

DROP TABLE IF EXISTS `roleType`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `roleType` (
  `roleTypeId` int(11) NOT NULL AUTO_INCREMENT,
  `featureName` varchar(100) NOT NULL,
  `validTo` datetime DEFAULT NULL,
  `validFrom` datetime DEFAULT NULL,
  `updatedDate` datetime DEFAULT NULL,
  `updatedBy` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`roleTypeId`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `roleType`
--

LOCK TABLES `roleType` WRITE;
/*!40000 ALTER TABLE `roleType` DISABLE KEYS */;
INSERT INTO `roleType` VALUES (1,'Admin',NULL,NULL,NULL,NULL),(2,'Customer',NULL,NULL,NULL,NULL);
/*!40000 ALTER TABLE `roleType` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'myloanworld'
--

--
-- Dumping routines for database 'myloanworld'
--
/*!50003 DROP PROCEDURE IF EXISTS `authenticate_User` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE PROCEDURE `authenticate_User`(
IN _UserName varchar(50),
IN _AccessKeyCode varchar(50)
)
BEGIN
SELECT mlwu.userName as 'User Name'
    ,mlwu.enquiryId as 'Enquiry Id'
    ,c.customerId as 'customer Id'
    ,c.name as 'Customer Name' 
    ,crt.roleTypeId
    ,rt.featureName 'Feature Name'
    FROM `myloanworld`.`myLoanWorldUser` as mlwu
    join `myloanworld`.`customer` as c on c.enquiryId = mlwu.enquiryId
    right outer join `myloanworld`.`customerRoleType` as crt on crt.customerId = c.customerId
    join `myloanworld`.`roleType` as rt on rt.roleTypeId = crt.roleTypeId
    where mlwu.userName = _UserName and mlwu.accessKeyCode = _AccessKeyCode;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `change_Application_Status` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE PROCEDURE `change_Application_Status`(
IN _ApplicationId int
,IN _ApplicationStatusId int
,IN _Comments varchar(200)
,IN _CreatedBy varchar(100)
)
BEGIN

update `myloanworld`.`applicationDetail` set `applicationStatusId` = _ApplicationStatusId
where applicationId = _ApplicationId;

INSERT INTO `myloanworld`.`applicationHistory` (`applicationId` ,`applicationStatusId`
,`comments`
,`creationDate`
,`createdBy`) VALUES (
_ApplicationId
,_ApplicationStatusId
,_Comments
,CURDATE()
,_CreatedBy);

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `create_Password` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE  PROCEDURE `create_Password`(
IN _UserName varchar(50),
IN _AccessKeyCode varchar(50)
)
BEGIN
update `myloanworld`.`myLoanWorldUser` as mlwu
    set mlwu.accessKeyCode = _AccessKeyCode
    where mlwu.userName = _UserName;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `forgot_Password` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE  PROCEDURE `forgot_Password`(
IN _UserName varchar(50)
,OUT _UserPasssword varchar(50)
,OUT _UserEmailId varchar(50)
,OUT _UserContactNumber varchar(50)
)
BEGIN
SELECT mlwu.accessKeyCode, c.emailId, e.contactNumber INTO _UserPasssword, _UserEmailId ,_UserContactNumber
FROM  `myloanworld`.`myLoanWorldUser` as mlwu 
join `myloanworld`.`enquiry` as e on e.enquiryId = mlwu.enquiryId
join `myloanworld`.`customer` as c on c.enquiryId= mlwu.enquiryId
where mlwu.userName = _UserName; 
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `get_ApplicationById` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE  PROCEDURE `get_ApplicationById`(
IN _ApplicationId int
)
BEGIN
if(_ApplicationId IS NULL)
then
	SELECT apd.applicationId as 'Application Id', apd.applicationStatusId, 
    aps.name as 'Application Status' ,apd.applicationTypeId
    ,apt.name as 'Application Type' ,e.name as 'Customer Name' 
	FROM `myloanworld`.`applicationDetail` as apd
    join `myloanworld`.`applicationStatus` as aps on aps.applicationStatusId = apd.applicationStatusId
    join `myloanworld`.`applicationType` as apt on apt.applicationTypeId = apd.applicationTypeId
	left outer join `myloanworld`.`enquiry` as e on e.enquiryId = apd.enquiryId;
else 
	SELECT apd.applicationId as 'Application Id'
    ,apd.applicationStatusId
    ,aps.name as 'Application Status'
    ,apd.applicationTypeId
    ,apt.name as 'Application Type'
    ,e.name as 'Customer Name' 
    FROM `myloanworld`.`applicationDetail` as apd
	left outer join `myloanworld`.`enquiry` as e on e.enquiryId = apd.enquiryId
    join `myloanworld`.`applicationStatus` as aps on aps.applicationStatusId = apd.applicationStatusId
    join `myloanworld`.`applicationType` as apt on apt.applicationTypeId = apd.applicationTypeId
    where apd.applicationId = _ApplicationId;
end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `get_Customer` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE  PROCEDURE `get_Customer`(
IN _EnquiryId INT
)
BEGIN
select 
`customerId` as 'Customer Id'
,`enquiryId` as 'Enquiry Id'
,`FirstName` as 'First Name'
,`MiddleName` as 'Middle Name'
,`LastName` as 'Last Name'
,`emailId` as 'EmailId'
,`SexId` as 'Sex Id'
,`MaritalStatusId` as 'Marital Status Id'
from myloanworld.customer
WHERE `enquiryId` = _EnquiryId;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `get_menusByRole` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE  PROCEDURE `get_menusByRole`(
IN _RoleId int
)
BEGIN
	SELECT m.`name` as 'Menu Name', m.isManagement as 'Is Management', 
    m.icon as 'Icon' ,m.sref
	FROM `myloanworld`.`menus` as m
	where m.roleId = _RoleId or m.roleId is null
	order by m.sortOrder;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `save_Application` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE  PROCEDURE `save_Application`(
IN _Name varchar(100)
,IN _HomeAddress varchar(100)
,IN _OfficeAddress varchar(100)
,IN _HomeContact  varchar(100)
,IN _OfficeContact varchar(100)
,IN _EnquiryId INT
,IN _ValidFrom datetime
,IN _ApplicationStatusId int
,IN _ApplicationTypeId INT
,IN _Comments varchar(200)
,IN _CreatedBy varchar(100)
,IN _EmailId varchar(100)
,OUT _UserId varchar(100)
,OUT _ContactUsEmail varchar(100)
)
BEGIN
INSERT INTO `myloanworld`.`customer` (`name`
,`homeAddress`
,`officeAddress`
,`homeContact`
,`officeContact`
,`EnquiryId`
,`emailId`) VALUES (
_Name
,_HomeAddress
,_OfficeAddress
,_HomeContact
,_OfficeContact
,_EnquiryId
,_EmailId);

SELECT customerId, enquiryId INTO @TempCustomerId, @TempEnquiryId FROM `myloanworld`.`customer`
where name = _Name ;

/* Assign role to this customer, make an entry into role type for this customer */
INSERT INTO `myloanworld`.`customerRoleType` (`roleTypeId`, `customerId`) VALUES ('2', @TempCustomerId);

/* create a user for this customer, make an entry into role type for this customer
by default no password, user has to create his password by create password utility
by default user name is one sent from enquiry table. This needs to be changed
 */
INSERT INTO `myloanworld`.`myLoanWorldUser` (`enquiryId`, `creationDate`, 
`userName`) VALUES (@TempEnquiryId, '2018-01-08 00:00:00' ,concat(_Name,@TempEnquiryId));

SET _UserId = concat(_Name,@TempEnquiryId);

select `EmailList` into _ContactUsEmail from `myloanworld`.`contactDetails`;

INSERT INTO `myloanworld`.`applicationDetail` (`applicationStatusId`
,`customerId`
,`enquiryId`
,`applicationTypeId`
,`creationDate`) VALUES (
_ApplicationStatusId
,@TempCustomerId
,@TempEnquiryId
,_ApplicationTypeId
,CURDATE());

SELECT applicationId INTO @TempApplicationId FROM `myloanworld`.`applicationDetail`
where customerId = @TempCustomerId ;

INSERT INTO `myloanworld`.`applicationHistory` (`applicationId`
, `applicationStatusId`
,`comments`
,`creationDate`
,`createdBy` ) VALUES (
@TempApplicationId
,_ApplicationStatusId
,_Comments
,CURDATE()
,_CreatedBy);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `save_applicationStatus` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE  PROCEDURE `save_applicationStatus`(
IN _Name varchar(50)
,IN _UpdatedBy varchar(50)
)
BEGIN
INSERT INTO `myloanworld`.`applicationStatus`(`name`,`updatedBy`) 
VALUES(_Name, _UpdatedBy);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `save_applicationType` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE  PROCEDURE `save_applicationType`(
IN _Name varchar(50)
,IN _DescText varchar(10000)
,IN _Href varchar(100)
,IN _Icon varchar(100)
,IN _Sref varchar(100)
,IN _Localhref  varchar(100)
,IN _UpdatedBy varchar(50)
)
BEGIN
INSERT INTO `myloanworld`.`applicationType`(`name`,`descText`,`href`,`icon`,`sref`,`localhref`,`updatedBy`) 
VALUES(_Name, _DescText, _Href, _Icon, _Sref, _Localhref, _UpdatedBy);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `save_Enquiry` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE  PROCEDURE `save_Enquiry`(
IN _Name varchar(100)
,IN _ContactNumber varchar(100)
,IN _LoanAmt double
,IN _Comments varchar(200)
,IN _Tennure INT
,OUT _EnquiryId INT
)
BEGIN
INSERT INTO `myloanworld`.`enquiry` (`name`
,`contactNumber`
,`loanAmt`
,`comments`
,`tennure`
,`creationDate`) VALUES (
_Name
,_ContactNumber
,_LoanAmt
,_Comments
,_Tennure
,CURDATE());

SELECT enquiryId INTO _EnquiryId FROM `myloanworld`.`enquiry`
where name = _Name  AND contactNumber = _ContactNumber;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `update_applicationStatus` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE  PROCEDURE `update_applicationStatus`(
IN _Name varchar(50)
,IN _UpdatedBy varchar(50)
,IN _ApplicationStatusId int
)
BEGIN
UPDATE `myloanworld`.`applicationStatus` aps set 
aps.`name` = _Name
,aps.`updatedBy` = _UpdatedBy
where aps.`applicationStatusId` = _ApplicationStatusId;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `update_applicationType` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE  PROCEDURE `update_applicationType`(
IN _Name varchar(50)
,IN _DescText varchar(10000)
,IN _Href varchar(100)
,IN _Icon varchar(100)
,IN _Sref varchar(100)
,IN _Localhref  varchar(100)
,IN _UpdatedBy varchar(50)
,IN _ApplicationTypeId int
)
BEGIN
UPDATE `myloanworld`.`applicationType` apt set 
apt.`name` = _Name
,apt.`descText` = _DescText
,apt.`href` = _Href
,apt.`icon` = _Icon
,apt.`sref` = Sref
,apt.`localhref` = _Localhref
,apt.`updatedBy` = _UpdatedBy
where apt.`applicationTypeId` = _ApplicationTypeId;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `update_contactDetails` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE  PROCEDURE `update_contactDetails`(
IN _EmailList varchar(100)
,IN _AddressList varchar(100)
)
BEGIN
update `myloanworld`.`contactDetails` set  `EmailList` = _EmailList, 
`AddressList` = _AddressList;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `update_Customer` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE  PROCEDURE `update_Customer`(
IN _FirstName varchar(100)
,IN _MiddleName varchar(100)
,IN _LastName varchar(100)
,IN _HomeAddress varchar(100)
,IN _OfficeAddress varchar(100)
,IN _HomeContact  varchar(100)
,IN _OfficeContact varchar(100)
,IN _EnquiryId INT
,IN _ValidFrom datetime
,IN _ApplicationStatusId int
,IN _ApplicationTypeId INT
,IN _Comments varchar(200)
,IN _CreatedBy varchar(100)
,IN _SexId INT
,IN _MaritalStatusId INT
)
BEGIN
update `myloanworld`.`customer` 
set `FirstName` = _FirstName
,`MiddleName` = _MiddleName
,`LastName` = _LastName
,`homeAddress` = _HomeAddress
,`officeAddress` = _OfficeAddress
,`homeContact` =_HomeContact
,`officeContact` = _HomeContact
,`SexId` =_SexId
,`MaritalStatusId` =_MaritalStatusId;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-02-27 19:10:47
