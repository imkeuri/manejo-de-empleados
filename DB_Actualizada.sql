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

/*Table structure for table `consumo_empleado` */

DROP TABLE IF EXISTS `consumo_empleado`;

CREATE TABLE `consumo_empleado` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Cooperativa` tinyint(1) DEFAULT NULL,
  `Comision` double DEFAULT NULL,
  `Cafeteria` double DEFAULT NULL,
  `EmpleadoId` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `FK_Empleado_ConsumoEmpleado_ConsumoEmpleadoId` (`EmpleadoId`),
  CONSTRAINT `FK_Empleado_ConsumoEmpleado_ConsumoEmpleadoId` FOREIGN KEY (`EmpleadoId`) REFERENCES `empleado` (`Id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `consumo_empleado` */

insert  into `consumo_empleado`(`Id`,`Cooperativa`,`Comision`,`Cafeteria`,`EmpleadoId`) values 
(5,1,400,600,4),
(6,1,700,800,5);

/*Table structure for table `departamentocl` */

DROP TABLE IF EXISTS `departamentocl`;

CREATE TABLE `departamentocl` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(255) COLLATE utf8mb4_general_ci NOT NULL,
  `Siglas` varchar(255) COLLATE utf8mb4_general_ci NOT NULL,
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
  `Nombre` varchar(255) COLLATE utf8mb4_general_ci NOT NULL,
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
  `Nombre` varchar(255) COLLATE utf8mb4_general_ci NOT NULL,
  `Apellido` varchar(255) COLLATE utf8mb4_general_ci NOT NULL,
  `Telefono` varchar(25) COLLATE utf8mb4_general_ci NOT NULL,
  `Correo` varchar(100) COLLATE utf8mb4_general_ci NOT NULL,
  `FechaNacimiento` date NOT NULL,
  `DepartamentoclId` int(11) NOT NULL,
  `FechaContratacion` date NOT NULL,
  `SueldoEmpleado` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `FK_Empleado_Departamento` (`DepartamentoclId`),
  CONSTRAINT `FK_Empleado_Departamento` FOREIGN KEY (`DepartamentoclId`) REFERENCES `departamentocl` (`Id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `empleado` */

insert  into `empleado`(`Id`,`Nombre`,`Apellido`,`Telefono`,`Correo`,`FechaNacimiento`,`DepartamentoclId`,`FechaContratacion`,`SueldoEmpleado`) values 
(0,'Jeff','Bezon','846-552-6985','Bbezon@gmail.ocm','2001-12-29',2,'2021-11-29',50000),
(4,'Manolo','Duluc','809-562-6085','Duluc@gmail.ocm','2001-05-09',1,'2021-11-29',40000),
(5,'Jonphy','Guerrero','829-517-1758','JGuerrero@gmail.ocm','2001-08-10',1,'2021-11-30',45000);

/*Table structure for table `usuario` */

DROP TABLE IF EXISTS `usuario`;

CREATE TABLE `usuario` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `User` varchar(255) COLLATE utf8mb4_general_ci NOT NULL,
  `Correo` varchar(255) COLLATE utf8mb4_general_ci NOT NULL,
  `Password` varchar(255) COLLATE utf8mb4_general_ci NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `usuario` */

insert  into `usuario`(`Id`,`User`,`Correo`,`Password`) values 
(1,'Jmaster','Jjj@gmail.com','Jeeee123');

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
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `vacaciones` */

/*Table structure for table `vacacionesestado` */

DROP TABLE IF EXISTS `vacacionesestado`;

CREATE TABLE `vacacionesestado` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `estado` int(11) NOT NULL,
  `VacacionesId` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `FK_VacacionesEstado_Vacaciones_VacionesId` (`VacacionesId`),
  CONSTRAINT `FK_VacacionesEstado_Vacaciones_VacionesId` FOREIGN KEY (`VacacionesId`) REFERENCES `vacaciones` (`Id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `vacacionesestado` */

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
