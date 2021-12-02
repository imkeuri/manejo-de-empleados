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
  `DepartamentoPuestoId` int(11) NOT NULL,
  `FechaContratacion` date NOT NULL,
  `SueldoEmpleado` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `FK_Empleado_DepartamentoPuestos_DepartamentoPuestosId` (`DepartamentoPuestoId`),
  CONSTRAINT `FK_Empleado_DepartamentoPuestos_DepartamentoPuestosId` FOREIGN KEY (`DepartamentoPuestoId`) REFERENCES `departamentopuestos` (`Id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `empleado` */

insert  into `empleado`(`Id`,`Nombre`,`Apellido`,`Telefono`,`Correo`,`FechaNacimiento`,`DepartamentoPuestoId`,`FechaContratacion`,`SueldoEmpleado`) values 
(0,'Jefferson','Payano','829-466-0420','Jeffkl@gmail.com','2001-09-05',3,'2021-11-26',25000);

/*Table structure for table `nomina` */

DROP TABLE IF EXISTS `nomina`;

CREATE TABLE `nomina` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `SueldoBruto` double NOT NULL,
  `SueldoNeto` double NOT NULL,
  `Comision` double NOT NULL,
  `AFP` double NOT NULL,
  `Cafeteria` double NOT NULL,
  `Cooperativa` double NOT NULL,
  `ISR` double NOT NULL,
  `Seguro` double NOT NULL,
  `EmpleadoId` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `FK_Nomina_Empleado_EmpleadoId` (`EmpleadoId`),
  CONSTRAINT `FK_Nomina_Empleado_EmpleadoId` FOREIGN KEY (`EmpleadoId`) REFERENCES `empleado` (`Id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `nomina` */

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
