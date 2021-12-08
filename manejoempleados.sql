/*
SQLyog Community v13.1.7 (64 bit)
MySQL - 8.0.18 : Database - manejoempleados
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`manejoempleados` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;

USE `manejoempleados`;

/*Table structure for table `__efmigrationshistory` */

DROP TABLE IF EXISTS `__efmigrationshistory`;

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProductVersion` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `__efmigrationshistory` */

insert  into `__efmigrationshistory`(`MigrationId`,`ProductVersion`) values 
('20211204054256_InitialCreate','5.0.12');

/*Table structure for table `aspnetroleclaims` */

DROP TABLE IF EXISTS `aspnetroleclaims`;

CREATE TABLE `aspnetroleclaims` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `RoleId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ClaimType` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `ClaimValue` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetRoleClaims_RoleId` (`RoleId`),
  CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `aspnetroleclaims` */

/*Table structure for table `aspnetroles` */

DROP TABLE IF EXISTS `aspnetroles`;

CREATE TABLE `aspnetroles` (
  `Id` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Name` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `NormalizedName` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `ConcurrencyStamp` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `RoleNameIndex` (`NormalizedName`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `aspnetroles` */

insert  into `aspnetroles`(`Id`,`Name`,`NormalizedName`,`ConcurrencyStamp`) values 
('1','admin',NULL,NULL),
('2','empleado',NULL,NULL);

/*Table structure for table `aspnetuserclaims` */

DROP TABLE IF EXISTS `aspnetuserclaims`;

CREATE TABLE `aspnetuserclaims` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ClaimType` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `ClaimValue` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetUserClaims_UserId` (`UserId`),
  CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `aspnetuserclaims` */

/*Table structure for table `aspnetuserlogins` */

DROP TABLE IF EXISTS `aspnetuserlogins`;

CREATE TABLE `aspnetuserlogins` (
  `LoginProvider` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProviderKey` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProviderDisplayName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `UserId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`LoginProvider`,`ProviderKey`),
  KEY `IX_AspNetUserLogins_UserId` (`UserId`),
  CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `aspnetuserlogins` */

/*Table structure for table `aspnetuserroles` */

DROP TABLE IF EXISTS `aspnetuserroles`;

CREATE TABLE `aspnetuserroles` (
  `UserId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `RoleId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`UserId`,`RoleId`),
  KEY `IX_AspNetUserRoles_RoleId` (`RoleId`),
  CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `aspnetuserroles` */

insert  into `aspnetuserroles`(`UserId`,`RoleId`) values 
('25a36d10-1fbd-4d26-8d50-e83c0e5bad9e','1'),
('99c41951-b596-4618-a5ca-92bb9fc75403','2'),
('cdf3faef-2acb-401c-a4f0-c54ec6d13e9f','2');

/*Table structure for table `aspnetusers` */

DROP TABLE IF EXISTS `aspnetusers`;

CREATE TABLE `aspnetusers` (
  `Id` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `UserName` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `NormalizedUserName` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Email` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `NormalizedEmail` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `EmailConfirmed` tinyint(1) NOT NULL,
  `PasswordHash` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `SecurityStamp` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `ConcurrencyStamp` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `PhoneNumber` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `PhoneNumberConfirmed` tinyint(1) NOT NULL,
  `TwoFactorEnabled` tinyint(1) NOT NULL,
  `LockoutEnd` datetime(6) DEFAULT NULL,
  `LockoutEnabled` tinyint(1) NOT NULL,
  `AccessFailedCount` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `UserNameIndex` (`NormalizedUserName`),
  KEY `EmailIndex` (`NormalizedEmail`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `aspnetusers` */

insert  into `aspnetusers`(`Id`,`UserName`,`NormalizedUserName`,`Email`,`NormalizedEmail`,`EmailConfirmed`,`PasswordHash`,`SecurityStamp`,`ConcurrencyStamp`,`PhoneNumber`,`PhoneNumberConfirmed`,`TwoFactorEnabled`,`LockoutEnd`,`LockoutEnabled`,`AccessFailedCount`) values 
('25a36d10-1fbd-4d26-8d50-e83c0e5bad9e','admin@admin.com','ADMIN@ADMIN.COM','admin@admin.com','ADMIN@ADMIN.COM',1,'AQAAAAEAACcQAAAAECLd0yaZ889NZ6nsQk7Mn6ZCszUf08VQqcQsXZxwfv2BQ+zfol8RDQd8e5mMaBIq3g==','DVG3T4BPA66FHVNJZ5QWLVHTYAXQ276A','678e3e9e-5c5b-48c5-8546-27f73a7158c0',NULL,0,0,NULL,1,0),
('99c41951-b596-4618-a5ca-92bb9fc75403','prueba@gmail.com','PRUEBA@GMAIL.COM','prueba@gmail.com','PRUEBA@GMAIL.COM',1,'AQAAAAEAACcQAAAAELEHfbJDWF5bDDuZ062HOAmQrZLdSi5cQ+SD+2G3FJoldBiE9HPZlEdcqdHmtk5UIg==','JHKYINVND7PYFGNMNDZJ2L4FTUOKPN43','16f64e0d-4c11-4c53-90cb-5fb69801a860',NULL,0,0,NULL,1,0),
('cdf3faef-2acb-401c-a4f0-c54ec6d13e9f','postulante@gmail.com','POSTULANTE@GMAIL.COM','postulante@gmail.com','POSTULANTE@GMAIL.COM',0,'AQAAAAEAACcQAAAAEMXIYQw79jjfTJ7wVsYJLuK7rEC1oLnZlEl+xltxI+kaReE5nWFgANY2drlaSgCzgg==','633TTZY6QL6QAXWOFXL22LYFH5OSP5X2','b7aadd59-c13c-46c6-ac25-f33a7f38df47',NULL,0,0,NULL,1,0),
('d316bcbc-8263-4183-b72a-b8efddbfbc74','Jeff@gmail.com','JEFF@GMAIL.COM','Jeff@gmail.com','JEFF@GMAIL.COM',1,'AQAAAAEAACcQAAAAEBUsf5XRcWM3RYbWBSyrSOP6qTIDQeBhrpHCuksgKSV+Whk9wQISw/KPhMpspsuGsg==','UHS2TPX3SIIRKEFO7N7F2HM7BSRBMYX3','3dde3e9e-6717-4aad-a3f0-4a1f9887f1e4',NULL,0,0,NULL,1,0);

/*Table structure for table `aspnetusertokens` */

DROP TABLE IF EXISTS `aspnetusertokens`;

CREATE TABLE `aspnetusertokens` (
  `UserId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `LoginProvider` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Name` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Value` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`UserId`,`LoginProvider`,`Name`),
  CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `aspnetusertokens` */

/*Table structure for table `consumo_empleado` */

DROP TABLE IF EXISTS `consumo_empleado`;

CREATE TABLE `consumo_empleado` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Cooperativa` tinyint(1) DEFAULT NULL,
  `Cafeteria` int(11) DEFAULT NULL,
  `EmpleadoId` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `FK_Empleado_ConsumoEmpleado_ConsumoEmpleadoId` (`EmpleadoId`),
  CONSTRAINT `FK_Empleado_ConsumoEmpleado_ConsumoEmpleadoId` FOREIGN KEY (`EmpleadoId`) REFERENCES `empleado` (`Id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `consumo_empleado` */

insert  into `consumo_empleado`(`Id`,`Cooperativa`,`Cafeteria`,`EmpleadoId`) values 
(3,1,400,7),
(4,1,700,5);

/*Table structure for table `departamentocl` */

DROP TABLE IF EXISTS `departamentocl`;

CREATE TABLE `departamentocl` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `Siglas` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `departamentocl` */

insert  into `departamentocl`(`Id`,`Nombre`,`Siglas`) values 
(1,'Recursos Humanos','RRHH'),
(2,'Tecnologia informatica','IT');

/*Table structure for table `departamentopuestos` */

DROP TABLE IF EXISTS `departamentopuestos`;

CREATE TABLE `departamentopuestos` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `DepartamentoId` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `FK_DepartamentoPuestos_DepartamentoCL_DepartamentoId` (`DepartamentoId`),
  CONSTRAINT `FK_DepartamentoPuestos_DepartamentoCL_DepartamentoId` FOREIGN KEY (`DepartamentoId`) REFERENCES `departamentocl` (`Id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `departamentopuestos` */

insert  into `departamentopuestos`(`Id`,`Nombre`,`DepartamentoId`) values 
(1,'Gerente',1),
(2,'Supervisor',1),
(3,'CiberSegurity',2);

/*Table structure for table `empleado` */

DROP TABLE IF EXISTS `empleado`;

CREATE TABLE `empleado` (
  `Id` int(11) NOT NULL,
  `Nombre` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `Apellido` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `Telefono` varchar(25) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `Correo` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `FechaNacimiento` date NOT NULL,
  `DepartamentoPuestoId` int(11) NOT NULL,
  `FechaContratacion` date NOT NULL,
  `SueldoEmpleado` int(11) NOT NULL,
  `Codigo` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Codigo_UNIQUE` (`Codigo`),
  KEY `FK_Empleado_DepartamentoPuestos_DepartamentoPuestosId` (`DepartamentoPuestoId`),
  CONSTRAINT `FK_Empleado_DepartamentoPuestos_DepartamentoPuestosId` FOREIGN KEY (`DepartamentoPuestoId`) REFERENCES `departamentopuestos` (`Id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `empleado` */

insert  into `empleado`(`Id`,`Nombre`,`Apellido`,`Telefono`,`Correo`,`FechaNacimiento`,`DepartamentoPuestoId`,`FechaContratacion`,`SueldoEmpleado`,`Codigo`) values 
(0,'Jefferson','Payano','829-466-0420','Jeffkl@gmail.com','2001-09-05',3,'2021-11-26',25000,''),
(2,'Lisandro','Mora','8099806919','lisandro06@gmail.com','2021-12-04',2,'2021-12-04',100000000,'296-000'),
(3,'Rafa','Mora','8099806919','rafa@gmail.com','2021-12-04',1,'2021-12-04',10000000,'281-000'),
(4,'Dere','Hidalgo','8099806919','dere@gmail.com','2021-12-05',2,'2021-12-22',5000000,'283-000'),
(5,'Jenrry','m','8099806919','jenrry@gmail.com','2021-12-17',3,'2021-11-10',50000,'285-000'),
(6,'Manuel','Herrera','8295540072','Mherrera@gmail.com','2001-05-06',2,'2021-12-06',40000,'loquesea'),
(7,'Genuel','Castillo','849-650-1406','Gcastillo@gmail.com','2001-06-07',3,'2021-12-07',60000,'282-000'),
(8,'Pascual','Ramirez','809-554-6598','Pascual@gmail.com','1996-12-08',1,'2020-06-06',45000,'292-000'),
(9,'Juan','Payano','809-710-2809','Jpayano@gmail.com','1995-03-17',2,'2019-12-01',50000,'288-000');

/*Table structure for table `nomina` */

DROP TABLE IF EXISTS `nomina`;

CREATE TABLE `nomina` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `SueldoBruto` double NOT NULL,
  `SueldoNeto` double NOT NULL,
  `Comision` double DEFAULT NULL,
  `AFP` double NOT NULL,
  `Cafeteria` double DEFAULT NULL,
  `Cooperativa` double DEFAULT NULL,
  `ISR` double NOT NULL,
  `Seguro` double NOT NULL,
  `EmpleadoId` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `FK_Nomina_Empleado_EmpleadoId` (`EmpleadoId`),
  CONSTRAINT `FK_Nomina_Empleado_EmpleadoId` FOREIGN KEY (`EmpleadoId`) REFERENCES `empleado` (`Id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `nomina` */

insert  into `nomina`(`Id`,`SueldoBruto`,`SueldoNeto`,`Comision`,`AFP`,`Cafeteria`,`Cooperativa`,`ISR`,`Seguro`,`EmpleadoId`) values 
(1,0,4735150,5000000,14350,500,127,-172200,0,4),
(2,50000,49804.4725,50000,143.49999999999997,500,127,598278,0,5),
(3,50000,92191.000125,50000,1435,500,2500,1853.9998749999997,1520,5),
(4,60000,109567.35016666667,60000,1722,400,3000,3486.649833333333,1824,7),
(5,60000,109567.35016666667,60000,1722,400,3000,3486.649833333333,1824,7),
(6,50000,46991.000125,5000,1435,700,2500,1853.9998749999997,1520,5);

/*Table structure for table `usuario` */

DROP TABLE IF EXISTS `usuario`;

CREATE TABLE `usuario` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `User` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `Correo` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `Password` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `usuario` */

insert  into `usuario`(`Id`,`User`,`Correo`,`Password`) values 
(1,'Jmaster','Jjj@gmail.com','Jeeee123'),
(2,'JeffMaster','Jey@gmail.com','Jef123456');

/*Table structure for table `vacaciones` */

DROP TABLE IF EXISTS `vacaciones`;

CREATE TABLE `vacaciones` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `InicioVacaciones` date NOT NULL,
  `HastaVacaciones` date NOT NULL,
  `EmpleadoId` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `FK_Vacaciones_Empleado_EmpleadoId` (`EmpleadoId`),
  CONSTRAINT `FK_Vacaciones_Empleado_EmpleadoId` FOREIGN KEY (`EmpleadoId`) REFERENCES `empleado` (`Id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `vacaciones` */

insert  into `vacaciones`(`Id`,`InicioVacaciones`,`HastaVacaciones`,`EmpleadoId`) values 
(3,'2021-12-07','2022-01-07',8),
(4,'2022-01-07','2022-02-07',9);

/*Table structure for table `vacacionesestado` */

DROP TABLE IF EXISTS `vacacionesestado`;

CREATE TABLE `vacacionesestado` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `estado` tinyint(1) NOT NULL,
  `VacacionesId` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `FK_VacacionesEstado_Vacaciones_VacionesId` (`VacacionesId`),
  CONSTRAINT `FK_VacacionesEstado_Vacaciones_VacionesId` FOREIGN KEY (`VacacionesId`) REFERENCES `vacaciones` (`Id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `vacacionesestado` */

insert  into `vacacionesestado`(`Id`,`estado`,`VacacionesId`) values 
(2,0,4);

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
