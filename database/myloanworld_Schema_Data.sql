
CREATE TABLE `myloanworld`.`applicationType` ( `applicationTypeId` INT NOT NULL AUTO_INCREMENT , 
`name` VARCHAR(100) NOT NULL ,
`descText` VARCHAR(1000) NULL ,
`href` VARCHAR(100) NULL ,
`icon` VARCHAR(100) NULL ,
`sref` VARCHAR(100) NULL ,
`localhref` VARCHAR(100) NULL ,
`validFrom` DATETIME NULL , 
`validTo` DATETIME NULL , 
`updatedDate` datetime NULL,
`updatedBy` varchar(100) NULL,
PRIMARY KEY (`applicationTypeId`)) ENGINE = InnoDB;

CREATE TABLE `myloanworld`.`menus` ( `menuId` INT NOT NULL AUTO_INCREMENT , 
`name` VARCHAR(100) NOT NULL ,
`sortOrder` int NULL ,
`parentMenu` int NULL ,
`isManagement` bool not NULL ,
`href` VARCHAR(100) NULL ,
`icon` VARCHAR(100) NULL ,
`sref` VARCHAR(100) NULL ,
`localhref` VARCHAR(100) NULL ,
`validFrom` DATETIME NULL , 
`validTo` DATETIME NULL , 
`updatedDate` datetime NULL,
`updatedBy` varchar(100) NULL,
PRIMARY KEY (`menuId`)) ENGINE = InnoDB;

INSERT INTO `myloanworld`.`menus` (`name`, `isManagement`, `icon`, `sref`) VALUES ('My Profile', '1', 'home', 'profile');
INSERT INTO `myloanworld`.`menus` (`name`, `isManagement`, `icon`, `sref`) VALUES ('View Applications', '1', 'home', 'allApplications');
INSERT INTO `myloanworld`.`menus` (`name`, `isManagement`, `icon`, `sref`) VALUES ('logOff', '1', 'home', 'logOff');
INSERT INTO `myloanworld`.`menus` (`name`, `isManagement`, `icon`, `sref`) VALUES ('View Enquiries', '1', 'home', 'enquiries');

INSERT INTO `myloanworld`.`applicationType` (`name`, `descText`, `href`,`icon`, `sref`,`localhref`, `validFrom`, `validTo`) VALUES ('Credit Card', 'At My Loan World we understand that “life happens” and that our bank accounts are often unprepared for unexpected financial needs. From medical emergencies to happy events like weddings, My Loan World’s consumer business focuses on providing unsecured' ,'myloanworld.com/home','home','homeloan','app/pages/home.html','2018-01-08 00:00:00', NULL);

INSERT INTO `myloanworld`.`applicationType` (`name`, 
`descText`, 
`href`, 
`icon`, 
`sref`, 
`localhref`, 
`validFrom`, 
`validTo`) VALUES ('Auto Loan', 
'Auto Loan: At My Loan World we understand that “life happens” and that our bank accounts are often unprepared for unexpected financial needs. From medical emergencies to happy events like weddings, My Loan World’s consumer business focuses on providing unsecured' ,
'myloanworld.com/auto',
'car',
'autoloan',
'app/pages/auto.html',
'2018-01-08 00:00:00', 
NULL);

INSERT INTO `myloanworld`.`applicationType` (`name`, 
`descText`, 
`href`, 
`icon`, 
`sref`, 
`localhref`, 
`validFrom`, 
`validTo`) VALUES ('Education Loan', 
'Education Loan: At My Loan World we understand that “life happens” and that our bank accounts are often unprepared for unexpected financial needs. From medical emergencies to happy events like weddings, My Loan World’s consumer business focuses on providing unsecured' ,
'myloanworld.com/education',
'book',
'educationloan',
'app/pages/education.html',
'2018-01-08 00:00:00', 
NULL);

CREATE TABLE `myloanworld`.`applicationStatus` ( 
`applicationStatusId` INT NOT NULL AUTO_INCREMENT , 
`name` VARCHAR(100) NOT NULL , 
`validFrom` DATETIME NULL, 
`validTo` DATETIME NULL, 
PRIMARY KEY (`applicationStatusId`)) ENGINE = InnoDB;

CREATE TABLE `myloanworld`.`customer` (
  `customerId` INT NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  `enquiryId` varchar(100) NULL COMMENT 'This tells if customer turned from Enquiry',
  `homeAddress` varchar(200) DEFAULT NULL,
  `officeAddress` varchar(200) DEFAULT NULL,
  `homeContact` varchar(25) DEFAULT NULL,
  `officeContact` varchar(25) DEFAULT NULL,
  `otherContact` varchar(25) DEFAULT NULL,
  `sex` tinyint(1) DEFAULT NULL,
  `loanAmt` DOUBLE NULL,
  `accessKeyCode` varchar(100) NULL,
  `validFrom` datetime DEFAULT NULL,
  `validTo` datetime DEFAULT NULL,
  `updatedDate` datetime NULL,
  `updatedBy` varchar(100) NULL,
  PRIMARY KEY (`customerId`)
) ENGINE=InnoDB;


CREATE TABLE `myloanworld`.`applicationDetail` ( 
`applicationId` INT NOT NULL AUTO_INCREMENT , 
`applicationStatusId` INT NOT NULL, 
`customerId` INT NOT NULL, 
`enquiryId` INT NULL, 
`applicationTypeId` INT NOT NULL, 
`validTo` DATETIME NULL, 
`validFrom` DATETIME NULL , 
`creationDate` DATETIME NOT NULL, 
PRIMARY KEY (`applicationId`),
CONSTRAINT fk_applicationStatus_applicationDetail FOREIGN KEY (`applicationStatusId`)
  REFERENCES applicationStatus(`applicationStatusId`),
CONSTRAINT fk_applicationType_applicationType FOREIGN KEY (`applicationTypeId`)
  REFERENCES applicationType(`applicationTypeId`),
CONSTRAINT fk_customer_customer FOREIGN KEY (`customerId`)
  REFERENCES customer(`customerId`)
) ENGINE = InnoDB;



CREATE TABLE `myloanworld`.`applicationHistory` (
  `applicationHistoryId` INT NOT NULL AUTO_INCREMENT,
  `applicationId` int NOT NULL,
  `applicationStatusId` int NULL,
  `comments` varchar(200) DEFAULT NULL,
  `creationDate` datetime DEFAULT NULL,
  `createdBy` varchar(100) NULL,
  PRIMARY KEY (`applicationHistoryId`)
) ENGINE=InnoDB;


CREATE TABLE `myloanworld`.`enquiry` ( 
`enquiryId` INT NOT NULL AUTO_INCREMENT, 
`name` varchar(100) NOT NULL, 
`contactNumber` varchar(45) DEFAULT NULL, 
`loanAmt` double DEFAULT NULL, 
`comments` varchar(445) DEFAULT NULL, 
`creationDate` datetime NOT NULL, 
`refferId` INT NULL,
PRIMARY KEY (`enquiryId`),
CONSTRAINT fk_refferId FOREIGN KEY (`refferId`)
  REFERENCES customer(`customerId`) ) ENGINE=InnoDB;

CREATE TABLE `myloanworld`.`myLoanWorldUser` ( 
`myLoanWorldUserId` INT NOT NULL AUTO_INCREMENT, 
`userName` varchar(100) NOT NULL, 
`accessKeyCode` varchar(100) NOT NULL, 
`enquiryId` INT NOT NULL, 
`creationDate` datetime NOT NULL, 
PRIMARY KEY (`myLoanWorldUserId`),
CONSTRAINT fk_enquiry_myLoanWorldUser FOREIGN KEY (`enquiryId`)
  REFERENCES enquiry(`enquiryId`) ) ENGINE=InnoDB;

CREATE TABLE `myloanworld`.`roleType` ( 
`roleTypeId` INT NOT NULL AUTO_INCREMENT , 
`featureName` VARCHAR(100) NOT NULL , 
`validTo` DATETIME NULL, 
`validFrom` DATETIME NULL ,
`updatedDate` datetime NULL,
`updatedBy` varchar(100) NULL,
PRIMARY KEY (`roleTypeId`)) ENGINE = InnoDB;

CREATE TABLE `myloanworld`.`customerRoleType` ( 
`customerRoleTypeId` INT NOT NULL AUTO_INCREMENT , 
`roleTypeId` INT NOT NULL, 
`customerId` INT NOT NULL, 
`validTo` DATETIME NULL, 
`validFrom` DATETIME NULL ,
`updatedDate` datetime NULL,
`updatedBy` varchar(100) NULL,
PRIMARY KEY (`customerRoleTypeId`),
CONSTRAINT fk_customerRoleType_roleTypeId FOREIGN KEY (`roleTypeId`)
  REFERENCES roleType(`roleTypeId`),
CONSTRAINT fk_customerRoleType_customerId FOREIGN KEY (`customerId`)
  REFERENCES customer(`customerId`)) ENGINE = InnoDB;



INSERT INTO `myloanworld`.`applicationType` (`name`, `validFrom`, `validTo`) VALUES ('Credit Card', '2018-01-08 00:00:00', NULL);
INSERT INTO `myloanworld`.`applicationType` (`name`, `validFrom`, `validTo`) VALUES ('Home Loan', '2018-01-08 00:00:00', NULL);
INSERT INTO `myloanworld`.`applicationType` (`name`, `validFrom`, `validTo`) VALUES ('Personal Loan', '2018-01-08 00:00:00', NULL);
INSERT INTO `myloanworld`.`applicationType` (`name`, `validFrom`, `validTo`) VALUES ('Education Loan', '2018-01-08 00:00:00', NULL);
INSERT INTO `myloanworld`.`applicationType` (`name`, `validFrom`, `validTo`) VALUES ('Vehicle Card', '2018-01-08 00:00:00', NULL);

INSERT INTO `myloanworld`.`customer` (`name`, `homeAddress`, `officeAddress`, `homeContact`, `officeContact`, `otherContact`, `sex`, `loanAmt`, `accessKeyCode`, `validFrom`, `validTo`) VALUES ('TestCustomer', 'TestHomeAdd', 'TestofficeAdd', '98765432345', '98765432345', '98765432345', '0', '123432', '1232131', NULL, NULL);
INSERT INTO `myloanworld`.`customer` (`name`, `homeAddress`, `officeAddress`, `homeContact`, `officeContact`, `otherContact`, `sex`, `loanAmt`, `accessKeyCode`, `validFrom`, `validTo`) VALUES ('TestCustomer2', 'TestHomeAdd', 'TestofficeAdd', '98765432345', '98765432345', '98765432345', '0', '123432', '1232131', NULL, NULL);

INSERT INTO `myloanworld`.`applicationHistory` (`applicationId`, `applicationStatusId`, `comments`, `creationDate`, `createdBy`) VALUES ('1', '1', 'New', '2018-01-08 00:00:00', 'Ashok');
INSERT INTO `myloanworld`.`applicationHistory` (`applicationId`, `applicationStatusId`, `comments`, `creationDate`, `createdBy`) VALUES ('1', '2', 'Stage 1', '2018-01-08 00:00:00', 'Ashok 1');
INSERT INTO `myloanworld`.`applicationHistory` (`applicationId`, `applicationStatusId`, `comments`, `creationDate`, `createdBy`) VALUES ('1', '3', 'Stage 2', '2018-01-08 00:00:00', 'Ashok 2');
INSERT INTO `myloanworld`.`applicationHistory` (`applicationId`, `applicationStatusId`, `comments`, `creationDate`, `createdBy`) VALUES ('1', '4', 'Stage 3', '2018-01-08 00:00:00', 'Ashok 3');
INSERT INTO `myloanworld`.`applicationHistory` (`applicationId`, `applicationStatusId`, `comments`, `creationDate`, `createdBy`) VALUES ('1', '5', 'Stage 4', '2018-01-08 00:00:00', 'Ashok 3');


INSERT INTO `myloanworld`.`applicationType` (`name`, `validFrom`, `validTo`) VALUES ('Credit Card', NULL, NULL);
INSERT INTO `myloanworld`.`applicationStatus` (`name`) VALUES ('New');
INSERT INTO `myloanworld`.`applicationStatus` (`name`) VALUES ('Stage3');
INSERT INTO `myloanworld`.`applicationStatus` (`name`) VALUES ('Stage 4');
INSERT INTO `myloanworld`.`applicationStatus` (`name`) VALUES ('Stage 5');

INSERT INTO `myloanworld`.`applicationDetail` (`applicationStatusId`, `applicationTypeId`,`enquiryId`,`customerId`, `validTo`, `validFrom`, `creationDate`) VALUES ('1', '1', NULL, 1, NULL, NULL, '2018-01-08 00:00:00');

INSERT INTO `myloanworld`.`roleType` (`featureName`, `validTo`, `validFrom`) VALUES ('View customer Profile', NULL, NULL), ('Modify customer Profile', NULL, NULL);

INSERT INTO `myloanworld`.`enquiry` (`name`, `contactNumber`, `loanAmt`, `comments`, `creationDate`, `refferId`) VALUES ('Test', NULL, NULL, NULL, '2018-01-08 00:00:00', NULL);
INSERT INTO `myloanworld`.`enquiry` (`name`, `contactNumber`, `loanAmt`, `comments`, `creationDate`, `refferId`) VALUES ('Test', NULL, NULL, NULL, '2018-01-08 00:00:00', 1);


INSERT INTO `myloanworld`.`myLoanWorldUser` (`accessKeyCode`, `enquiryId`, `creationDate`, 
`userName`) VALUES ('Test', 1, '2018-01-08 00:00:00' ,'TestCustomer');

INSERT INTO `myloanworld`.`customerRoleType` (`roleTypeId`, `customerId`, `validTo`, `validFrom`, `updatedDate`, `updatedBy`) VALUES ('1', '1', NULL, NULL, NULL, NULL);
INSERT INTO `myloanworld`.`customerRoleType` (`roleTypeId`, `customerId`, `validTo`, `validFrom`, `updatedDate`, `updatedBy`) VALUES ('1', '2', NULL, NULL, NULL, NULL);
INSERT INTO `myloanworld`.`customerRoleType` (`roleTypeId`, `customerId`, `validTo`, `validFrom`, `updatedDate`, `updatedBy`) VALUES ('2', '1', NULL, NULL, NULL, NULL);

USE `myloanworld`;
DROP procedure IF EXISTS `save_Application`;

CREATE DEFINER=`root`@`localhost` PROCEDURE `save_Application`(
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
)
BEGIN
INSERT INTO `myloanworld`.`customer` (`name`
,`homeAddress`
,`officeAddress`
,`homeContact`
,`officeContact`
,`EnquiryId`) VALUES (
_Name
,_HomeAddress
,_OfficeAddress
,_HomeContact
,_OfficeContact
,_EnquiryId);

SELECT customerId, enquiryId INTO @TempCustomerId, @TempEnquiryId FROM `myloanworld`.`customer`
where name = _Name ;

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
END

/* CALL `myloanworld`.`save_Application`(
'Europe3'
, 'Home a 3'
, 'office a 3 '
, 'HomeContact 3'
, 'OfficeContact 3'
, '1'
, '2018-01-08 00:00:00'
, 1
, 1, 'comments from param', 'user fro param');
*/

USE `myloanworld`;
DROP procedure IF EXISTS `change_Application_Status`;

CREATE DEFINER=`root`@`localhost` PROCEDURE `change_Application_Status`(
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

END

/* CALL `myloanworld`.`change_Application_Status`(
1, 2, 'from Proc', 'ash from proc');
*/