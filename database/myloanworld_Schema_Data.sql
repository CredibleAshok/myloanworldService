use `myloanworld`;

CREATE TABLE `myloanworld`.`applicationType` ( `applicationTypeId` INT NOT NULL AUTO_INCREMENT , 
`name` VARCHAR(100) NOT NULL ,
`descText` VARCHAR(10000) NULL ,
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

INSERT INTO `myloanworld`.`menus` (`name`, `isManagement`, `icon`, `sref`) VALUES ('View Applications', '1', 'home', 'allApplications');
INSERT INTO `myloanworld`.`menus` (`name`, `isManagement`, `icon`, `sref`) VALUES ('View Enquiries', '1', 'home', 'enquiries');
INSERT INTO `myloanworld`.`menus` (`name`, `isManagement`, `icon`, `sref`) VALUES ('Maintain Application Status', '1', 'home', 'maintainApplicationStatus');
INSERT INTO `myloanworld`.`menus` (`name`, `isManagement`, `icon`, `sref`) VALUES ('Maintain Products', '1', 'home', 'maintainProducts');
INSERT INTO `myloanworld`.`menus` (`name`, `isManagement`, `icon`, `sref`) VALUES ('logOff', '1', 'home', 'logOff');
INSERT INTO `myloanworld`.`menus` (`name`, `isManagement`, `icon`, `sref`) VALUES ('Manage Contact Details', '1', 'home', 'contactDetails');

INSERT INTO `myloanworld`.`applicationType` (`name`, `descText`, `href`,`icon`, `sref`,`localhref`, `validFrom`, `validTo`) VALUES ('Credit Card', 'At My Loan World we understand that “life happens” and that our bank accounts are often unprepared for unexpected financial needs. From medical emergencies to happy events like weddings, My Loan World’s consumer business focuses on providing unsecured' ,'myloanworld.com/home','home','homeloan','app/pages/home.html','2018-01-08 00:00:00', NULL);

INSERT INTO `myloanworld`.`applicationType` (`name`, 
`descText`, 
`href`, 
`icon`, 
`sref`, 
`localhref`, 
`validFrom`, 
`validTo`) VALUES ('Car Loan', 
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
`validTo`) VALUES ('Personal Loan', 
'Loan Against Property: At My Loan World we understand that “life happens” and that our bank accounts are often unprepared for unexpected financial needs. From medical emergencies to happy events like weddings, My Loan World’s consumer business focuses on providing unsecured' ,
'myloanworld.com/education',
'book',
'educationloan',
'app/pages/education.html',
'2018-01-08 00:00:00', 
NULL);

INSERT INTO `myloanworld`.`applicationType` (`name`, 
`descText`, 
`href`, 
`icon`, 
`sref`, 
`localhref`, 
`validFrom`, 
`validTo`) VALUES ('Home Loan', 
'Loan Against Property: At My Loan World we understand that “life happens” and that our bank accounts are often unprepared for unexpected financial needs. From medical emergencies to happy events like weddings, My Loan World’s consumer business focuses on providing unsecured' ,
'myloanworld.com/education',
'book',
'educationloan',
'app/pages/education.html',
'2018-01-08 00:00:00', 
NULL);

INSERT INTO `myloanworld`.`applicationType` (`name`, 
`descText`, 
`href`, 
`icon`, 
`sref`, 
`localhref`, 
`validFrom`, 
`validTo`) VALUES ('Loan Against Property', 
'Loan Against Property: At My Loan World we understand that “life happens” and that our bank accounts are often unprepared for unexpected financial needs. From medical emergencies to happy events like weddings, My Loan World’s consumer business focuses on providing unsecured' ,
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
`updatedBy` VARCHAR(50) NULL,
PRIMARY KEY (`applicationStatusId`)) ENGINE = InnoDB;

CREATE TABLE `myloanworld`.`customer` (
  `customerId` INT NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  `emailId` varchar(100) NOT NULL,
  `FirstName` varchar(50) NULL,
`MiddleName` varchar(50) NULL,	
	`LastName` varchar(50) NULL,
	`MaritalStatusId` INT NULL,
	`MotherName` varchar(50) NULL,
	`FatherName` varchar(50) NULL,
	`OtherPersonal` varchar(50) NULL,
	`HusbandName` varchar(50) NULL,
	`LocalHomeContact` varchar(50) NULL,
	`LocalOfficeContact` varchar(50) NULL,
	`LocalOfficeAddress` varchar(50) NULL,
	`LocalHomeAddress` varchar(50) NULL,
  `enquiryId` varchar(100) NULL COMMENT 'This tells if customer turned from Enquiry',
  `homeAddress` varchar(200) DEFAULT NULL,
  `officeAddress` varchar(200) DEFAULT NULL,
  `homeContact` varchar(25) DEFAULT NULL,
  `officeContact` varchar(25) DEFAULT NULL,
  `otherContact` varchar(25) DEFAULT NULL,
  `sex` tinyint(1) DEFAULT NULL,
  `loanAmt` DOUBLE NULL,
  `accessKeyCode` varchar(100) NULL COMMENT 'This column does not need to be here',
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
CONSTRAINT fk_applicationDetail_applicationStatus FOREIGN KEY (`applicationStatusId`)
  REFERENCES applicationStatus(`applicationStatusId`),
CONSTRAINT fk_applicationDetail_applicationType FOREIGN KEY (`applicationTypeId`)
  REFERENCES applicationType(`applicationTypeId`),
CONSTRAINT fk_applicationDetail_customer FOREIGN KEY (`customerId`)
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
`tennure` INT NULL,
`comments` varchar(445) DEFAULT NULL, 
`creationDate` datetime NOT NULL, 
`refferId` INT NULL,
PRIMARY KEY (`enquiryId`),
CONSTRAINT fk_refferId FOREIGN KEY (`refferId`)
  REFERENCES customer(`customerId`) ) ENGINE=InnoDB;

CREATE TABLE `myloanworld`.`myLoanWorldUser` ( 
`myLoanWorldUserId` INT NOT NULL AUTO_INCREMENT, 
`userName` varchar(100) NOT NULL, 
`accessKeyCode` varchar(100) NULL, 
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

CREATE TABLE `myloanworld`.`maritalStatus` ( 
`maritalStatusId` INT NOT NULL AUTO_INCREMENT , 
`Name` VARCHAR(100) NOT NULL , 
`validTo` DATETIME NULL, 
`validFrom` DATETIME NULL ,
`updatedDate` datetime NULL,
`updatedBy` varchar(100) NULL,
PRIMARY KEY (`maritalStatusId`)) ENGINE = InnoDB;

CREATE TABLE `myloanworld`.`contactDetails` ( 
`contactDetailsId` INT NOT NULL AUTO_INCREMENT , 
`emailList` VARCHAR(300) NOT NULL , 
`addressList` VARCHAR(500) NOT NULL, 
`validFrom` DATETIME NULL ,
`updatedDate` datetime NULL,
`updatedBy` varchar(100) NULL,
PRIMARY KEY (`contactDetailsId`)) ENGINE = InnoDB;

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

INSERT INTO `myloanworld`.`contactDetails` (`emailList`, `addressList`) VALUES ('info@myloanworld.com; vaibhav2121984@gmail.com', 'B-538 3rd Floor Nehru ground NIT Faridabad');

INSERT INTO `myloanworld`.`customer` (`name`,`emailId`, `homeAddress`, `officeAddress`, `homeContact`, `officeContact`, `otherContact`, `sex`, `loanAmt`, `accessKeyCode`, `validFrom`, `validTo`, `enquiryId`) VALUES ('SaxenaVaibhav','letusknow@myloanworld.com', 'TestHomeAdd', 'TestofficeAdd', '98765432345', '98765432345', '98765432345', '0', '123432', '1232131', NULL, NULL, 1);
/*
can be removed once testing is done
INSERT INTO `myloanworld`.`customer` (`name`, `homeAddress`, `officeAddress`, `homeContact`, `officeContact`, `otherContact`, `sex`, `loanAmt`, `accessKeyCode`, `validFrom`, `validTo`) VALUES ('TestCustomer2', 'TestHomeAdd', 'TestofficeAdd', '98765432345', '98765432345', '98765432345', '0', '123432', '1232131', NULL, NULL);

INSERT INTO `myloanworld`.`applicationHistory` (`applicationId`, `applicationStatusId`, `comments`, `creationDate`, `createdBy`) VALUES ('1', '1', 'New', '2018-01-08 00:00:00', 'Ashok');
INSERT INTO `myloanworld`.`applicationHistory` (`applicationId`, `applicationStatusId`, `comments`, `creationDate`, `createdBy`) VALUES ('1', '2', 'With Galaxy', '2018-01-08 00:00:00', 'Ashok 1');
*/
INSERT INTO `myloanworld`.`applicationStatus` (`name`) VALUES ('New');
INSERT INTO `myloanworld`.`applicationStatus` (`name`) VALUES ('With Galaxy');
INSERT INTO `myloanworld`.`applicationStatus` (`name`) VALUES ('With Bank');
INSERT INTO `myloanworld`.`applicationStatus` (`name`) VALUES ('Verification');
INSERT INTO `myloanworld`.`applicationStatus` (`name`) VALUES ('Approved');

/*
can be removed once testing is done
INSERT INTO `myloanworld`.`applicationDetail` (`applicationStatusId`, `applicationTypeId`,`enquiryId`,`customerId`, `validTo`, `validFrom`, `creationDate`) VALUES ('1', '1', NULL, 1, NULL, NULL, '2018-01-08 00:00:00');
*/
INSERT INTO `myloanworld`.`roleType` (`featureName`, `validTo`, `validFrom`) VALUES ('Admin', NULL, NULL), ('Customer', NULL, NULL);
/*
can be removed once testing is done
INSERT INTO `myloanworld`.`enquiry` (`name`, `contactNumber`, `loanAmt`, `comments`, `creationDate`, `refferId`) VALUES ('Test', NULL, NULL, NULL, '2018-01-08 00:00:00', NULL);
*/
INSERT INTO `myloanworld`.`enquiry` (`name`, `contactNumber`, `loanAmt`, `comments`, `creationDate`, `refferId`) VALUES ('Test', NULL, NULL, NULL, '2018-01-08 00:00:00', 1);


INSERT INTO `myloanworld`.`myLoanWorldUser` (`accessKeyCode`, `enquiryId`, `creationDate`, 
`userName`) VALUES ('Test', 1, '2018-01-08 00:00:00' ,'SaxenaVaibhav');

INSERT INTO `myloanworld`.`customerRoleType` (`roleTypeId`, `customerId`, `validTo`, `validFrom`, `updatedDate`, `updatedBy`) VALUES ('1', '1', NULL, NULL, NULL, NULL);
/*
can be removed once testing is done
INSERT INTO `myloanworld`.`customerRoleType` (`roleTypeId`, `customerId`, `validTo`, `validFrom`, `updatedDate`, `updatedBy`) VALUES ('2', '1', NULL, NULL, NULL, NULL);
INSERT INTO `myloanworld`.`customerRoleType` (`roleTypeId`, `customerId`, `validTo`, `validFrom`, `updatedDate`, `updatedBy`) VALUES ('1', '2', NULL, NULL, NULL, NULL);
*/

USE `myloanworld`;
DROP procedure IF EXISTS `save_Application`;

DELIMITER $$
CREATE PROCEDURE `save_Application`(
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
END$$

DELIMITER ;

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

DELIMITER $$
CREATE  PROCEDURE `change_Application_Status`(
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

END$$

DELIMITER ;

/* CALL `myloanworld`.`change_Application_Status`(
1, 2, 'from Proc', 'ash from proc');
*/

USE `myloanworld`;
DROP procedure IF EXISTS `save_Enquiry`;

DELIMITER $$
USE `myloanworld`$$
CREATE PROCEDURE `save_Enquiry`(
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
END$$

DELIMITER;


DELIMITER $$
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
END$$

DELIMITER ;



/* CALL `myloanworld`.`get_ApplicationByIdWhere`(
'apd.applicationId = 1');
*/


USE `myloanworld`;
DROP procedure IF EXISTS `update_Customer`;

DELIMITER $$
USE `myloanworld`$$
CREATE PROCEDURE `update_Customer`(
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
)
BEGIN
update `myloanworld`.`customer` 
set `FirstName` = _FirstName
,`MiddleName` = _MiddleName
,`LastName` = _LastName
,`homeAddress` = _HomeAddress
,`officeAddress` = _OfficeAddress
,`homeContact` =_HomeContact
,`officeContact` = _HomeContact;
END$$

DELIMITER ;


USE `myloanworld`;
DROP procedure IF EXISTS `get_Customer`;

DELIMITER $$
USE `myloanworld`$$
CREATE PROCEDURE `get_Customer`(
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
from myloanworld.customer
WHERE `enquiryId` = _EnquiryId;
END$$

DELIMITER ;


USE `myloanworld`;
DROP procedure IF EXISTS `authenticate_User`;

DELIMITER $$
USE `myloanworld`$$
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
END$$

DELIMITER ;

call `myloanworld`.`authenticate_User`('TestCustomer','Test');

USE `myloanworld`;
DROP procedure IF EXISTS `create_Password`;

DELIMITER $$
USE `myloanworld`$$
CREATE PROCEDURE `create_Password`(
IN _UserName varchar(50),
IN _AccessKeyCode varchar(50)
)
BEGIN
update `myloanworld`.`myLoanWorldUser` as mlwu
    set mlwu.accessKeyCode = _AccessKeyCode
    where mlwu.userName = _UserName;
END$$

DELIMITER ;


USE `myloanworld`;
DROP procedure IF EXISTS `forgot_Password`;

DELIMITER $$
USE `myloanworld`$$
CREATE PROCEDURE `forgot_Password`(
IN _UserName varchar(50)
,OUT _UserPasssword varchar(50)
)
BEGIN
SELECT mlwu.accessKeyCode INTO _UserPasssword FROM  `myloanworld`.`myLoanWorldUser` as mlwu 
where mlwu.userName = _UserName; 
END$$

DELIMITER ;


USE `myloanworld`;
DROP procedure IF EXISTS `save_applicationType`;

DELIMITER $$
USE `myloanworld`$$
CREATE PROCEDURE `save_applicationType`(
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
END$$

DELIMITER ;


DELIMITER $$
USE `myloanworld`$$
CREATE PROCEDURE `update_applicationType`(
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
END$$

DELIMITER ;

DELIMITER $$
USE `myloanworld`$$
CREATE PROCEDURE `save_applicationStatus`(
IN _Name varchar(50)
,IN _UpdatedBy varchar(50)
)
BEGIN
INSERT INTO `myloanworld`.`applicationStatus`(`name`,`updatedBy`) 
VALUES(_Name, _UpdatedBy);
END$$

DELIMITER ;

DELIMITER $$
USE `myloanworld`$$
CREATE PROCEDURE `update_applicationStatus`(
IN _Name varchar(50)
,IN _UpdatedBy varchar(50)
,IN _ApplicationStatusId int
)
BEGIN
UPDATE `myloanworld`.`applicationStatus` aps set 
aps.`name` = _Name
,aps.`updatedBy` = _UpdatedBy
where aps.`applicationStatusId` = _ApplicationStatusId;
END$$

DELIMITER ;

USE `myloanworld`;
DROP procedure IF EXISTS `update_contactDetails`;

DELIMITER $$
USE `myloanworld`$$
CREATE PROCEDURE `update_contactDetails`(
IN _EmailList varchar(100)
,IN _AddressList varchar(100)
)
BEGIN
update `myloanworld`.`contactDetails` set  `EmailList` = _EmailList, 
`AddressList` = _AddressList;
END$$

DELIMITER ;


