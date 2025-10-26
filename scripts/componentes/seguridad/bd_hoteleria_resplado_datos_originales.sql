-- MySQL dump 10.13  Distrib 8.0.41, for Win64 (x86_64)
--
create database Bd_Hoteleria;
use Bd_Hoteleria;
-- Host: switchback.proxy.rlwy.net    Database: Bd_Hoteleria
-- ------------------------------------------------------
-- Server version	9.4.0

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `Tbl_Aplicacion`
--

DROP TABLE IF EXISTS `Tbl_Aplicacion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Tbl_Aplicacion` (
  `Pk_Id_Aplicacion` int NOT NULL,
  `Fk_Id_Reporte_Aplicacion` int DEFAULT NULL,
  `Cmp_Nombre_Aplicacion` varchar(50) DEFAULT NULL,
  `Cmp_Descripcion_Aplicacion` varchar(50) DEFAULT NULL,
  `Cmp_Estado_Aplicacion` bit(1) NOT NULL,
  PRIMARY KEY (`Pk_Id_Aplicacion`),
  KEY `Fk_Aplicacion_Reporte` (`Fk_Id_Reporte_Aplicacion`),
  CONSTRAINT `Fk_Aplicacion_Reporte` FOREIGN KEY (`Fk_Id_Reporte_Aplicacion`) REFERENCES `Tbl_Reportes` (`Pk_Id_Reporte`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Tbl_Aplicacion`
--

LOCK TABLES `Tbl_Aplicacion` WRITE;
/*!40000 ALTER TABLE `Tbl_Aplicacion` DISABLE KEYS */;
INSERT INTO `Tbl_Aplicacion` VALUES (1,1,'Gestion de empleado','Se gestionan los empleados del hotel',_binary ''),(2,1,'pepe','pepe pepa',_binary ''),(3,NULL,'Gestion De Empleados','prueba permisos',_binary ''),(5,NULL,'Administracion','Formularios de administracion',_binary ''),(9,NULL,'prueba','aaaaa',_binary ''),(10,1,'Cesar Estrada Elias','cesar el mero mero',_binary ''),(12,NULL,'','',_binary ''),(15,NULL,'Vacio','asd',_binary ''),(16,NULL,'asd','asd',_binary ''),(22,NULL,'Administracion','a',_binary '\0'),(99,1,'Rockstar API','Rockstar API',_binary ''),(100,NULL,'Pruebaap','Prueba para MdA',_binary ''),(301,NULL,'Empleados','Control de empleados de la hoteleria',_binary ''),(302,NULL,'Usuarios','Control de usuarios de empleados',_binary ''),(303,NULL,'Perfiles','Perfiles que se asignan a usuarios',_binary ''),(304,NULL,'Modulos','Mantenimiento de modulos',_binary ''),(305,NULL,'Aplicacion','Mantenimiento de aplicaciones',_binary ''),(306,NULL,'Asig Aplicacion Usuario','Asigna permisos a usuarios',_binary ''),(307,NULL,'Asig aplicacion Perfil','Asigna permisos a perfiles',_binary ''),(308,NULL,'Asig Perfiles','Asigna los perfiles a usuarios',_binary ''),(309,NULL,'Bitacora','Da acceso a bitacora',_binary ''),(310,NULL,'Prueba25','prueba de estandar',_binary ''),(342,NULL,'Biología','Ver animales y estudiarlos',_binary ''),(424,NULL,'Caries','Ver los dientes y la boca en general',_binary ''),(483,NULL,'Intento2','Ver si se borra',_binary ''),(865,NULL,'Quimica','Ver quimicos y bacterias',_binary ''),(2222,NULL,'hola','mundo',_binary '\0'),(5000,NULL,'prueba de permisos','aaa',_binary ''),(9000,NULL,'AppPrueba','Prueba',_binary ''),(50000,NULL,'prueba permisos','yo nunca vi tv',_binary '\0');
/*!40000 ALTER TABLE `Tbl_Aplicacion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Tbl_Asignacion_Modulo_Aplicacion`
--

DROP TABLE IF EXISTS `Tbl_Asignacion_Modulo_Aplicacion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Tbl_Asignacion_Modulo_Aplicacion` (
  `Fk_Id_Modulo` int NOT NULL,
  `Fk_Id_Aplicacion` int NOT NULL,
  PRIMARY KEY (`Fk_Id_Modulo`,`Fk_Id_Aplicacion`),
  KEY `Fk_AsigAplicacion` (`Fk_Id_Aplicacion`),
  CONSTRAINT `Fk_AsigAplicacion` FOREIGN KEY (`Fk_Id_Aplicacion`) REFERENCES `Tbl_Aplicacion` (`Pk_Id_Aplicacion`),
  CONSTRAINT `Fk_AsigModulo` FOREIGN KEY (`Fk_Id_Modulo`) REFERENCES `Tbl_Modulo` (`Pk_Id_Modulo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Tbl_Asignacion_Modulo_Aplicacion`
--

LOCK TABLES `Tbl_Asignacion_Modulo_Aplicacion` WRITE;
/*!40000 ALTER TABLE `Tbl_Asignacion_Modulo_Aplicacion` DISABLE KEYS */;
INSERT INTO `Tbl_Asignacion_Modulo_Aplicacion` VALUES (2,1),(1,2),(3,3),(2,5),(9,9),(1,10),(5,12),(5,15),(10,16),(4,22),(99,99),(96,100),(4,301),(4,302),(4,303),(4,304),(4,305),(4,306),(4,307),(4,308),(4,309),(1,310),(1,342),(543,424),(435,483),(10,865),(4,2222),(1,9000),(9,50000);
/*!40000 ALTER TABLE `Tbl_Asignacion_Modulo_Aplicacion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Tbl_Asignar_Perfil_Cliente`
--

DROP TABLE IF EXISTS `Tbl_Asignar_Perfil_Cliente`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Tbl_Asignar_Perfil_Cliente` (
  `Fk_Id_Perfil` int NOT NULL,
  `Fk_Id_Cliente` int NOT NULL,
  PRIMARY KEY (`Fk_Id_Perfil`,`Fk_Id_Cliente`),
  KEY `Fk_AsigCliente` (`Fk_Id_Cliente`),
  CONSTRAINT `Fk_AsigCliente` FOREIGN KEY (`Fk_Id_Cliente`) REFERENCES `Tbl_Cliente` (`Pk_Id_Cliente`),
  CONSTRAINT `Fk_AsigPerfil` FOREIGN KEY (`Fk_Id_Perfil`) REFERENCES `Tbl_Perfil` (`Pk_Id_Perfil`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Tbl_Asignar_Perfil_Cliente`
--

LOCK TABLES `Tbl_Asignar_Perfil_Cliente` WRITE;
/*!40000 ALTER TABLE `Tbl_Asignar_Perfil_Cliente` DISABLE KEYS */;
/*!40000 ALTER TABLE `Tbl_Asignar_Perfil_Cliente` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Tbl_Bitacora`
--

DROP TABLE IF EXISTS `Tbl_Bitacora`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Tbl_Bitacora` (
  `Pk_Id_Bitacora` int NOT NULL AUTO_INCREMENT,
  `Fk_Id_Usuario` int DEFAULT NULL,
  `Fk_Id_Aplicacion` int DEFAULT NULL,
  `Cmp_Fecha` datetime DEFAULT NULL,
  `Cmp_Accion` varchar(255) DEFAULT NULL,
  `Cmp_Ip` varchar(50) DEFAULT NULL,
  `Cmp_Nombre_Pc` varchar(50) DEFAULT NULL,
  `Cmp_Login_Estado` bit(1) DEFAULT NULL,
  PRIMARY KEY (`Pk_Id_Bitacora`),
  KEY `Fk_Bitacora_Usuario` (`Fk_Id_Usuario`),
  KEY `Fk_Bitacora_Aplicacion` (`Fk_Id_Aplicacion`),
  CONSTRAINT `Fk_Bitacora_Aplicacion` FOREIGN KEY (`Fk_Id_Aplicacion`) REFERENCES `Tbl_Aplicacion` (`Pk_Id_Aplicacion`) ON DELETE SET NULL ON UPDATE CASCADE,
  CONSTRAINT `Fk_Bitacora_Usuario` FOREIGN KEY (`Fk_Id_Usuario`) REFERENCES `Tbl_Usuario` (`Pk_Id_Usuario`)
) ENGINE=InnoDB AUTO_INCREMENT=3772 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Tbl_Bitacora`
--

LOCK TABLES `Tbl_Bitacora` WRITE;
/*!40000 ALTER TABLE `Tbl_Bitacora` DISABLE KEYS */;
/*!40000 ALTER TABLE `Tbl_Bitacora` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Tbl_Bloqueo_Usuario`
--

DROP TABLE IF EXISTS `Tbl_Bloqueo_Usuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Tbl_Bloqueo_Usuario` (
  `Pk_Id_Bloqueo` int NOT NULL AUTO_INCREMENT,
  `Fk_Id_Usuario` int DEFAULT NULL,
  `Fk_Id_Bitacora` int DEFAULT NULL,
  `Cmp_Fecha_Inicio_Bloqueo_Usuario` datetime DEFAULT NULL,
  `Cmp_Fecha_Fin_Bloqueo_Usuario` datetime DEFAULT NULL,
  `Cmp_Motivo__Bloqueo_Usuario` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`Pk_Id_Bloqueo`),
  KEY `Fk_Bloqueo_Usuario` (`Fk_Id_Usuario`),
  KEY `Fk_Bloqueo_Bitacora` (`Fk_Id_Bitacora`),
  CONSTRAINT `Fk_Bloqueo_Bitacora` FOREIGN KEY (`Fk_Id_Bitacora`) REFERENCES `Tbl_Bitacora` (`Pk_Id_Bitacora`),
  CONSTRAINT `Fk_Bloqueo_Usuario` FOREIGN KEY (`Fk_Id_Usuario`) REFERENCES `Tbl_Usuario` (`Pk_Id_Usuario`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Tbl_Bloqueo_Usuario`
--

LOCK TABLES `Tbl_Bloqueo_Usuario` WRITE;
/*!40000 ALTER TABLE `Tbl_Bloqueo_Usuario` DISABLE KEYS */;
/*!40000 ALTER TABLE `Tbl_Bloqueo_Usuario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Tbl_Cliente`
--

DROP TABLE IF EXISTS `Tbl_Cliente`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Tbl_Cliente` (
  `Pk_Id_Cliente` int NOT NULL,
  `Cmp_Nombres_Cliente` varchar(50) DEFAULT NULL,
  `Cmp_Apellidos_Cliente` varchar(50) DEFAULT NULL,
  `Cmp_Dni_Cliente` bigint DEFAULT NULL,
  `Cmp_Fecha_Registro_Cliente` datetime DEFAULT NULL,
  `Cmp_Estado_Cliente` bit(1) DEFAULT NULL,
  `Cmp_Nacionalidad_Cliente` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`Pk_Id_Cliente`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Tbl_Cliente`
--

LOCK TABLES `Tbl_Cliente` WRITE;
/*!40000 ALTER TABLE `Tbl_Cliente` DISABLE KEYS */;
INSERT INTO `Tbl_Cliente` VALUES (1,'Cliente','Prueba',9876543210101,'2025-09-21 23:00:51',_binary '','Guatemalteco');
/*!40000 ALTER TABLE `Tbl_Cliente` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Tbl_Correo_Cliente`
--

DROP TABLE IF EXISTS `Tbl_Correo_Cliente`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Tbl_Correo_Cliente` (
  `Pk_Id_Correo` int NOT NULL,
  `Fk_Id_Cliente` int DEFAULT NULL,
  `Cmp_Correo_Cliente` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`Pk_Id_Correo`),
  KEY `Fk_Correo_Cliente` (`Fk_Id_Cliente`),
  CONSTRAINT `Fk_Correo_Cliente` FOREIGN KEY (`Fk_Id_Cliente`) REFERENCES `Tbl_Cliente` (`Pk_Id_Cliente`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Tbl_Correo_Cliente`
--

LOCK TABLES `Tbl_Correo_Cliente` WRITE;
/*!40000 ALTER TABLE `Tbl_Correo_Cliente` DISABLE KEYS */;
/*!40000 ALTER TABLE `Tbl_Correo_Cliente` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Tbl_Empleado`
--

DROP TABLE IF EXISTS `Tbl_Empleado`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Tbl_Empleado` (
  `Pk_Id_Empleado` int NOT NULL AUTO_INCREMENT,
  `Cmp_Nombres_Empleado` varchar(50) DEFAULT NULL,
  `Cmp_Apellidos_Empleado` varchar(50) DEFAULT NULL,
  `Cmp_Dpi_Empleado` bigint DEFAULT NULL,
  `Cmp_Nit_Empleado` bigint DEFAULT NULL,
  `Cmp_Correo_Empleado` varchar(50) DEFAULT NULL,
  `Cmp_Telefono_Empleado` varchar(15) DEFAULT NULL,
  `Cmp_Genero_Empleado` bit(1) DEFAULT NULL,
  `Cmp_Fecha_Nacimiento_Empleado` date DEFAULT NULL,
  `Cmp_Fecha_Contratacion__Empleado` date DEFAULT NULL,
  PRIMARY KEY (`Pk_Id_Empleado`)
) ENGINE=InnoDB AUTO_INCREMENT=5001 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Tbl_Empleado`
--

LOCK TABLES `Tbl_Empleado` WRITE;
/*!40000 ALTER TABLE `Tbl_Empleado` DISABLE KEYS */;
INSERT INTO `Tbl_Empleado` VALUES (1,'Ricardu','Esquite',1234567890101,12345676,'ricardo@email.com','5555-5555',_binary '','2000-01-01','2020-01-01'),(2,'Juan','Pérez López',1234567890101,9876542,'juan.perez@example.com','5555-1234',_binary '','1995-08-20','2025-09-21'),(3,'Juan','pruebas',1234,123,'@pruebas','1234',_binary '','2025-09-26','2025-09-26'),(4,'Kenph','Luna',1234567891234,123456789,'correo@miumg.edu.gt','12345678',_binary '','2003-03-02','2025-09-01'),(7,'Marcos','Velazquez',1234,232325,'marcos1@gmail.com','0901-22-3415',_binary '','2005-01-10','2025-10-10'),(8,'Juan','Perez',12345678,12345874,'juan@prueba.com','123456787',_binary '','2003-06-06','2025-02-02'),(9,'Ernesto','Samayoa',1212365656565,222325656,'samayoadavid1@gmail.com','2345-5560',_binary '','2004-01-24','2025-01-15'),(10,'Aron','Edquit',123456788,2345674,'aron1@gmail.com','55667744',_binary '','2005-01-25','2025-02-23'),(11,'Cesar','Estrada',123,123,'cestrada5@miumg.edu.gt','0901-22-10153',_binary '','2003-06-20','2025-10-10'),(12,'Raul','Ramirez',112345,6777785,'raul1@gmail.com','123456',_binary '','2002-01-25','2026-01-25'),(13,'Kenph','Ansonny',12316546,123456123,'kenph','123156',_binary '','2004-02-03','2025-10-13'),(14,'Joge','Saul',12314,1231,'Jorge@gmail.com','123123',_binary '','2000-01-10','2025-10-13'),(16,'123as','asd',134,123,'123','asd',_binary '','2026-10-10','2025-10-10'),(245,'Brandon2','Hernandez2',232323232,223380432,'beandon@mail.com','40472324',_binary '','2003-08-27','2025-10-08'),(255,'Dan','sal',1111111111111,595959595,'dan@gmail.com','45454545',_binary '\0','2003-05-26','2025-06-25'),(324,'Andrea','Suquen',2313,23123335,'andrea@gmail.com','32321',_binary '\0','2009-02-03','2020-05-10'),(400,'marcos','velasquez',7897897897,789789789,'marcos@gmail.com','789789789',_binary '','2025-08-12','2025-08-12'),(414,'Luis','vasquez',4324324267898,111111111,'luis@gmail.com','54345434',_binary '','2003-08-12','2022-09-15'),(900,'mario','vasquez',2343243242,789784443,'hjk@gmail.com','789789',_binary '','2022-08-12','2022-08-12'),(901,'Ismar','Cortez',1234567891234,123456784,'leo@gmail.com','4011-4445',_binary '','2005-09-08','2025-09-08'),(1001,'Ruben ','Luch',1234567890999,123456789,'ruben1@miumg.edu.gt','5460-0441',_binary '','2001-01-11','2025-01-19'),(1010,'Marcos','Guevara',1111111111111,222222222,'marcos1@gmail.com','5555-3333',_binary '','2001-10-11','2025-01-11');
/*!40000 ALTER TABLE `Tbl_Empleado` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Tbl_Modulo`
--

DROP TABLE IF EXISTS `Tbl_Modulo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Tbl_Modulo` (
  `Pk_Id_Modulo` int NOT NULL,
  `Cmp_Nombre_Modulo` varchar(50) DEFAULT NULL,
  `Cmp_Descripcion_Modulo` varchar(50) DEFAULT NULL,
  `Cmp_Estado_Modulo` bit(1) NOT NULL,
  PRIMARY KEY (`Pk_Id_Modulo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Tbl_Modulo`
--

LOCK TABLES `Tbl_Modulo` WRITE;
/*!40000 ALTER TABLE `Tbl_Modulo` DISABLE KEYS */;
INSERT INTO `Tbl_Modulo` VALUES (1,'Pruebas','modulo de pruebas para probar Duh',_binary '\0'),(2,'Navegador','Módulo de navegador',_binary ''),(3,'Estandarizacion ','modulo de estandarizacion ',_binary ''),(4,'Seguridad','Modulo de seguridad de la hoteleria',_binary ''),(5,'RHM','Recursos Humanos',_binary ''),(9,'11111$$$$$$','asd',_binary ''),(10,'##$$$|°','Modulo prueba',_binary '\0'),(14,'asdf','',_binary ''),(45,'Recursos','Quejas',_binary ''),(56,'Utileria','Muñecas prueba r',_binary ''),(91,'Prueba','Esto es una prueba para ver si funciona',_binary ''),(96,'Market','Publicidad',_binary ''),(99,'Rockstar','Games',_binary ''),(435,'Intento1','Intento43553',_binary ''),(543,'Dientes','Cuidar dientes y reparar',_binary ''),(686,'Intento','eferfrf',_binary ''),(866,'Mantenimiento','Cuidar los equipos',_binary '');
/*!40000 ALTER TABLE `Tbl_Modulo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Tbl_Nit_Cliente`
--

DROP TABLE IF EXISTS `Tbl_Nit_Cliente`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Tbl_Nit_Cliente` (
  `Pk_Id_Nit` int NOT NULL,
  `Fk_Id_Cliente` int DEFAULT NULL,
  `Cmp_Nit_Cliente` varchar(15) DEFAULT NULL,
  PRIMARY KEY (`Pk_Id_Nit`),
  KEY `Fk_Nit_Cliente` (`Fk_Id_Cliente`),
  CONSTRAINT `Fk_Nit_Cliente` FOREIGN KEY (`Fk_Id_Cliente`) REFERENCES `Tbl_Cliente` (`Pk_Id_Cliente`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Tbl_Nit_Cliente`
--

LOCK TABLES `Tbl_Nit_Cliente` WRITE;
/*!40000 ALTER TABLE `Tbl_Nit_Cliente` DISABLE KEYS */;
INSERT INTO `Tbl_Nit_Cliente` VALUES (1,1,'0901-22-2929');
/*!40000 ALTER TABLE `Tbl_Nit_Cliente` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Tbl_Numero_Cliente`
--

DROP TABLE IF EXISTS `Tbl_Numero_Cliente`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Tbl_Numero_Cliente` (
  `Pk_Id_Numero` int NOT NULL,
  `Fk_Id_Cliente` int DEFAULT NULL,
  `Cmp_Telefono_Cliente` varchar(15) DEFAULT NULL,
  PRIMARY KEY (`Pk_Id_Numero`),
  KEY `Fk_Numero_Cliente` (`Fk_Id_Cliente`),
  CONSTRAINT `Fk_Numero_Cliente` FOREIGN KEY (`Fk_Id_Cliente`) REFERENCES `Tbl_Cliente` (`Pk_Id_Cliente`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Tbl_Numero_Cliente`
--

LOCK TABLES `Tbl_Numero_Cliente` WRITE;
/*!40000 ALTER TABLE `Tbl_Numero_Cliente` DISABLE KEYS */;
/*!40000 ALTER TABLE `Tbl_Numero_Cliente` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Tbl_Perfil`
--

DROP TABLE IF EXISTS `Tbl_Perfil`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Tbl_Perfil` (
  `Pk_Id_Perfil` int NOT NULL AUTO_INCREMENT,
  `Cmp_Puesto_Perfil` varchar(50) DEFAULT NULL,
  `Cmp_Descripcion_Perfil` varchar(50) DEFAULT NULL,
  `Cmp_Estado_Perfil` bit(1) NOT NULL,
  `Cmp_Tipo_Perfil` int DEFAULT NULL,
  PRIMARY KEY (`Pk_Id_Perfil`)
) ENGINE=InnoDB AUTO_INCREMENT=45 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Tbl_Perfil`
--

LOCK TABLES `Tbl_Perfil` WRITE;
/*!40000 ALTER TABLE `Tbl_Perfil` DISABLE KEYS */;
INSERT INTO `Tbl_Perfil` VALUES (1,'Administrador','Perfil con todos los permisos',_binary '',1),(2,'Contador','Cuenta que más',_binary '\0',1),(4,'Asesor de Publicidad','Testea Código',_binary '',1),(5,'puesto','Puestea',_binary '\0',1),(7,'Asesor de Publicidad','Mira publicidad',_binary '',1),(10,'Operdores','Perfil digitadores',_binary '',1),(11,'proveedor','provee',_binary '',0),(12,'Probador','Persona que prueba codigo',_binary '',1),(16,'Dentista prefesional','Ver dientes y enfermedades de la boca',_binary '',0),(18,'Navegador','aaa',_binary '\0',1),(20,'PruebaNav','abcd',_binary '\0',0),(22,'Pruebadef','pufa',_binary '',1),(26,'puesto','Puestea',_binary '',1),(31,'Dentista prefesional','Mira publicidad',_binary '',1),(32,'Navegador','Persona que prueba codigo',_binary '',1),(33,'tester','provee',_binary '',1),(34,'puesto','Puestea',_binary '',1),(35,'puesto','Mira publicidad',_binary '',1),(36,'Asesor de Publicidad','Puestea',_binary '',1),(38,'GTA6','GTA6',_binary '',1),(39,'PerfilBitacora','aaaa',_binary '',1),(41,'trabajador','1',_binary '',1),(42,'Perfil','Descripcion',_binary '\0',1),(43,'Chapeador','Chapea',_binary '',1),(44,'Puesto','Decripcion',_binary '',0);
/*!40000 ALTER TABLE `Tbl_Perfil` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Tbl_Permiso_Perfil_Aplicacion`
--

DROP TABLE IF EXISTS `Tbl_Permiso_Perfil_Aplicacion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Tbl_Permiso_Perfil_Aplicacion` (
  `Fk_Id_Perfil` int NOT NULL,
  `Fk_Id_Modulo` int NOT NULL,
  `Fk_Id_Aplicacion` int NOT NULL,
  `Cmp_Ingresar_Permisos_Aplicacion_Perfil` bit(1) DEFAULT NULL,
  `Cmp_Consultar_Permisos_Aplicacion_Perfil` bit(1) DEFAULT NULL,
  `Cmp_Modificar_Permisos_Aplicacion_Perfil` bit(1) DEFAULT NULL,
  `Cmp_Eliminar_Permisos_Aplicacion_Perfil` bit(1) DEFAULT NULL,
  `Cmp_Imprimir_Permisos_Aplicacion_Perfil` bit(1) DEFAULT NULL,
  PRIMARY KEY (`Fk_Id_Perfil`,`Fk_Id_Modulo`,`Fk_Id_Aplicacion`),
  KEY `Fk_PermisoPerfil_ModuloAplicacion` (`Fk_Id_Modulo`,`Fk_Id_Aplicacion`),
  CONSTRAINT `Fk_PermisoPerfil` FOREIGN KEY (`Fk_Id_Perfil`) REFERENCES `Tbl_Perfil` (`Pk_Id_Perfil`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `Fk_PermisoPerfil_ModuloAplicacion` FOREIGN KEY (`Fk_Id_Modulo`, `Fk_Id_Aplicacion`) REFERENCES `Tbl_Asignacion_Modulo_Aplicacion` (`Fk_Id_Modulo`, `Fk_Id_Aplicacion`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Tbl_Permiso_Perfil_Aplicacion`
--

LOCK TABLES `Tbl_Permiso_Perfil_Aplicacion` WRITE;
/*!40000 ALTER TABLE `Tbl_Permiso_Perfil_Aplicacion` DISABLE KEYS */;
INSERT INTO `Tbl_Permiso_Perfil_Aplicacion` VALUES (1,1,10,_binary '',_binary '\0',_binary '\0',_binary '\0',_binary '\0'),(1,2,1,_binary '',_binary '',_binary '',_binary '',_binary ''),(1,2,5,_binary '',_binary '\0',_binary '\0',_binary '\0',_binary '\0'),(1,4,301,_binary '',_binary '',_binary '',_binary '',_binary ''),(1,4,306,_binary '\0',_binary '',_binary '\0',_binary '\0',_binary '\0'),(1,4,309,_binary '\0',_binary '',_binary '\0',_binary '\0',_binary '\0'),(4,4,303,_binary '\0',_binary '\0',_binary '\0',_binary '\0',_binary '\0'),(4,4,304,_binary '\0',_binary '\0',_binary '\0',_binary '',_binary '\0'),(4,4,305,_binary '\0',_binary '',_binary '\0',_binary '',_binary '\0'),(4,4,306,_binary '',_binary '\0',_binary '\0',_binary '\0',_binary '\0'),(4,4,309,_binary '\0',_binary '',_binary '\0',_binary '\0',_binary '\0'),(4,9,9,_binary '',_binary '',_binary '',_binary '',_binary ''),(7,4,301,_binary '',_binary '\0',_binary '\0',_binary '\0',_binary '\0'),(7,4,304,_binary '\0',_binary '',_binary '',_binary '',_binary ''),(7,96,100,_binary '',_binary '',_binary '',_binary '\0',_binary ''),(10,1,310,_binary '',_binary '',_binary '\0',_binary '\0',_binary ''),(10,3,3,_binary '',_binary '',_binary '\0',_binary '\0',_binary ''),(10,4,301,_binary '\0',_binary '\0',_binary '',_binary '',_binary ''),(10,4,305,_binary '',_binary '',_binary '\0',_binary '\0',_binary '\0'),(11,1,10,_binary '',_binary '',_binary '',_binary '\0',_binary '\0'),(11,10,865,_binary '',_binary '\0',_binary '',_binary '',_binary ''),(11,96,100,_binary '',_binary '',_binary '',_binary '\0',_binary ''),(12,4,303,_binary '',_binary '\0',_binary '',_binary '\0',_binary '\0'),(12,4,306,_binary '\0',_binary '\0',_binary '\0',_binary '\0',_binary '\0'),(12,96,100,_binary '',_binary '',_binary '',_binary '\0',_binary '\0'),(12,435,483,_binary '',_binary '',_binary '',_binary '\0',_binary '\0'),(16,543,424,_binary '',_binary '',_binary '',_binary '\0',_binary '\0'),(22,4,301,_binary '\0',_binary '\0',_binary '\0',_binary '\0',_binary '\0'),(22,4,302,_binary '\0',_binary '\0',_binary '\0',_binary '\0',_binary '\0'),(22,4,303,_binary '\0',_binary '\0',_binary '',_binary '\0',_binary '\0'),(22,4,304,_binary '\0',_binary '\0',_binary '\0',_binary '\0',_binary '\0'),(22,4,305,_binary '\0',_binary '\0',_binary '\0',_binary '\0',_binary '\0'),(22,4,306,_binary '\0',_binary '\0',_binary '\0',_binary '\0',_binary '\0'),(22,4,307,_binary '\0',_binary '\0',_binary '\0',_binary '\0',_binary '\0'),(22,4,308,_binary '\0',_binary '\0',_binary '\0',_binary '\0',_binary '\0'),(22,4,309,_binary '\0',_binary '\0',_binary '\0',_binary '\0',_binary '\0'),(38,1,10,_binary '',_binary '',_binary '\0',_binary '\0',_binary '\0');
/*!40000 ALTER TABLE `Tbl_Permiso_Perfil_Aplicacion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Tbl_Permiso_Usuario_Aplicacion`
--

DROP TABLE IF EXISTS `Tbl_Permiso_Usuario_Aplicacion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Tbl_Permiso_Usuario_Aplicacion` (
  `Fk_Id_Usuario` int NOT NULL,
  `Fk_Id_Modulo` int NOT NULL,
  `Fk_Id_Aplicacion` int NOT NULL,
  `Cmp_Ingresar_Permiso_Aplicacion_Usuario` bit(1) DEFAULT NULL,
  `Cmp_Consultar_Permiso_Aplicacion_Usuario` bit(1) DEFAULT NULL,
  `Cmp_Modificar_Permiso_Aplicacion_Usuario` bit(1) DEFAULT NULL,
  `Cmp_Eliminar_Permiso_Aplicacion_Usuario` bit(1) DEFAULT NULL,
  `Cmp_Imprimir_Permiso_Aplicacion_Usuario` bit(1) DEFAULT NULL,
  PRIMARY KEY (`Fk_Id_Usuario`,`Fk_Id_Modulo`,`Fk_Id_Aplicacion`),
  KEY `Fk_Permiso_Modulo_Aplicacion` (`Fk_Id_Modulo`,`Fk_Id_Aplicacion`),
  CONSTRAINT `Fk_Permiso_Modulo_Aplicacion` FOREIGN KEY (`Fk_Id_Modulo`, `Fk_Id_Aplicacion`) REFERENCES `Tbl_Asignacion_Modulo_Aplicacion` (`Fk_Id_Modulo`, `Fk_Id_Aplicacion`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `Fk_Permiso_Usuario` FOREIGN KEY (`Fk_Id_Usuario`) REFERENCES `Tbl_Usuario` (`Pk_Id_Usuario`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Tbl_Permiso_Usuario_Aplicacion`
--

LOCK TABLES `Tbl_Permiso_Usuario_Aplicacion` WRITE;
/*!40000 ALTER TABLE `Tbl_Permiso_Usuario_Aplicacion` DISABLE KEYS */;
INSERT INTO `Tbl_Permiso_Usuario_Aplicacion` VALUES (1,1,10,_binary '',_binary '',_binary '\0',_binary '\0',_binary '\0'),(1,2,1,_binary '\0',_binary '\0',_binary '\0',_binary '\0',_binary '\0'),(1,2,5,_binary '\0',_binary '',_binary '\0',_binary '\0',_binary ''),(2,1,10,_binary '\0',_binary '\0',_binary '\0',_binary '\0',_binary '\0'),(2,4,305,_binary '\0',_binary '',_binary '\0',_binary '\0',_binary '\0'),(4,2,5,_binary '',_binary '',_binary '',_binary '',_binary ''),(4,4,301,_binary '',_binary '',_binary '',_binary '',_binary ''),(4,4,302,_binary '',_binary '',_binary '',_binary '',_binary ''),(4,4,303,_binary '',_binary '\0',_binary '',_binary '\0',_binary '\0'),(4,4,304,_binary '',_binary '',_binary '\0',_binary '\0',_binary '\0'),(4,4,305,_binary '',_binary '',_binary '',_binary '',_binary ''),(4,4,306,_binary '',_binary '',_binary '',_binary '',_binary ''),(4,4,307,_binary '',_binary '',_binary '',_binary '',_binary ''),(4,4,308,_binary '',_binary '',_binary '',_binary '',_binary ''),(5,3,3,_binary '\0',_binary '\0',_binary '\0',_binary '\0',_binary '\0'),(9,1,2,_binary '',_binary '\0',_binary '\0',_binary '\0',_binary '\0'),(9,96,100,_binary '',_binary '',_binary '\0',_binary '',_binary '\0'),(12,4,301,_binary '\0',_binary '\0',_binary '\0',_binary '\0',_binary '\0'),(12,4,302,_binary '',_binary '',_binary '',_binary '',_binary ''),(12,4,303,_binary '',_binary '',_binary '',_binary '',_binary ''),(12,4,304,_binary '\0',_binary '\0',_binary '\0',_binary '\0',_binary '\0'),(12,4,305,_binary '',_binary '',_binary '',_binary '',_binary ''),(12,4,306,_binary '',_binary '',_binary '',_binary '',_binary ''),(12,4,307,_binary '',_binary '',_binary '',_binary '',_binary ''),(12,4,308,_binary '',_binary '',_binary '',_binary '',_binary ''),(15,1,10,_binary '\0',_binary '\0',_binary '\0',_binary '\0',_binary '\0'),(15,4,301,_binary '',_binary '',_binary '',_binary '',_binary ''),(15,4,303,_binary '\0',_binary '',_binary '\0',_binary '\0',_binary ''),(15,4,304,_binary '\0',_binary '',_binary '\0',_binary '\0',_binary ''),(15,4,306,_binary '\0',_binary '',_binary '\0',_binary '\0',_binary '\0'),(15,4,307,_binary '\0',_binary '',_binary '\0',_binary '\0',_binary '\0'),(15,4,308,_binary '\0',_binary '',_binary '\0',_binary '\0',_binary '\0'),(19,1,10,_binary '',_binary '',_binary '',_binary '\0',_binary ''),(21,1,10,_binary '',_binary '\0',_binary '\0',_binary '\0',_binary '\0'),(21,2,5,_binary '',_binary '\0',_binary '\0',_binary '\0',_binary '\0'),(22,2,1,_binary '',_binary '',_binary '',_binary '\0',_binary '\0'),(22,4,303,_binary '\0',_binary '',_binary '\0',_binary '\0',_binary '\0'),(23,4,22,_binary '',_binary '',_binary '',_binary '',_binary ''),(23,4,301,_binary '',_binary '',_binary '',_binary '',_binary ''),(23,4,302,_binary '',_binary '',_binary '',_binary '',_binary ''),(23,4,303,_binary '',_binary '',_binary '',_binary '',_binary ''),(23,4,304,_binary '',_binary '',_binary '',_binary '',_binary ''),(23,4,305,_binary '',_binary '',_binary '',_binary '',_binary ''),(23,4,306,_binary '',_binary '',_binary '',_binary '',_binary ''),(23,4,307,_binary '',_binary '',_binary '',_binary '',_binary ''),(23,4,308,_binary '',_binary '',_binary '',_binary '',_binary ''),(23,4,309,_binary '',_binary '',_binary '',_binary '',_binary ''),(24,3,3,_binary '',_binary '\0',_binary '\0',_binary '\0',_binary '\0'),(25,2,1,_binary '\0',_binary '',_binary '\0',_binary '\0',_binary ''),(31,4,301,_binary '',_binary '\0',_binary '\0',_binary '\0',_binary '\0'),(31,4,304,_binary '\0',_binary '',_binary '\0',_binary '\0',_binary '\0'),(32,3,3,_binary '',_binary '\0',_binary '\0',_binary '\0',_binary '\0'),(35,4,301,_binary '\0',_binary '\0',_binary '\0',_binary '\0',_binary '\0'),(35,4,302,_binary '',_binary '\0',_binary '\0',_binary '\0',_binary '\0'),(35,4,306,_binary '\0',_binary '\0',_binary '\0',_binary '\0',_binary '\0'),(36,4,301,_binary '\0',_binary '\0',_binary '\0',_binary '\0',_binary '\0'),(36,4,302,_binary '\0',_binary '\0',_binary '\0',_binary '\0',_binary '\0'),(36,4,303,_binary '\0',_binary '\0',_binary '\0',_binary '\0',_binary '\0'),(36,4,304,_binary '\0',_binary '\0',_binary '\0',_binary '\0',_binary '\0'),(36,4,305,_binary '\0',_binary '\0',_binary '\0',_binary '\0',_binary '\0'),(36,4,306,_binary '\0',_binary '\0',_binary '\0',_binary '\0',_binary '\0'),(36,4,307,_binary '\0',_binary '\0',_binary '\0',_binary '\0',_binary '\0'),(36,4,308,_binary '\0',_binary '\0',_binary '\0',_binary '\0',_binary '\0'),(37,4,305,_binary '\0',_binary '\0',_binary '\0',_binary '\0',_binary '\0'),(40,4,303,_binary '',_binary '\0',_binary '\0',_binary '\0',_binary '\0'),(42,4,301,_binary '',_binary '',_binary '',_binary '\0',_binary '\0'),(42,4,303,_binary '',_binary '\0',_binary '\0',_binary '\0',_binary '\0'),(43,4,309,_binary '\0',_binary '\0',_binary '\0',_binary '\0',_binary '\0'),(44,4,304,_binary '\0',_binary '\0',_binary '\0',_binary '\0',_binary '\0'),(44,4,308,_binary '',_binary '\0',_binary '\0',_binary '\0',_binary '\0'),(46,4,302,_binary '',_binary '\0',_binary '\0',_binary '\0',_binary '\0'),(47,4,301,_binary '',_binary '',_binary '\0',_binary '\0',_binary '\0'),(49,4,303,_binary '\0',_binary '\0',_binary '\0',_binary '\0',_binary '\0'),(49,4,306,_binary '\0',_binary '',_binary '\0',_binary '\0',_binary '\0'),(49,4,307,_binary '',_binary '\0',_binary '\0',_binary '\0',_binary '\0'),(49,4,308,_binary '',_binary '\0',_binary '\0',_binary '\0',_binary '\0'),(51,4,303,_binary '',_binary '\0',_binary '\0',_binary '\0',_binary '\0'),(51,4,306,_binary '\0',_binary '',_binary '',_binary '',_binary ''),(51,4,307,_binary '\0',_binary '',_binary '',_binary '',_binary ''),(51,4,308,_binary '\0',_binary '',_binary '',_binary '',_binary ''),(52,4,304,_binary '\0',_binary '\0',_binary '\0',_binary '\0',_binary '\0'),(53,543,424,_binary '',_binary '',_binary '',_binary '\0',_binary ''),(54,3,3,_binary '',_binary '\0',_binary '\0',_binary '\0',_binary '\0'),(54,4,301,_binary '',_binary '\0',_binary '\0',_binary '\0',_binary '\0'),(54,4,302,_binary '\0',_binary '',_binary '\0',_binary '\0',_binary '\0'),(54,4,303,_binary '\0',_binary '\0',_binary '\0',_binary '\0',_binary '\0'),(54,4,305,_binary '\0',_binary '\0',_binary '\0',_binary '\0',_binary '\0'),(55,4,303,_binary '',_binary '\0',_binary '',_binary '\0',_binary '\0'),(56,4,303,_binary '\0',_binary '\0',_binary '\0',_binary '\0',_binary '\0'),(56,4,304,_binary '\0',_binary '\0',_binary '\0',_binary '\0',_binary '\0'),(56,4,308,_binary '\0',_binary '\0',_binary '\0',_binary '\0',_binary '\0'),(57,4,301,_binary '',_binary '',_binary '',_binary '',_binary ''),(57,4,303,_binary '',_binary '\0',_binary '\0',_binary '\0',_binary '\0'),(57,4,304,_binary '',_binary '',_binary '\0',_binary '\0',_binary '\0'),(57,4,305,_binary '\0',_binary '\0',_binary '\0',_binary '\0',_binary '\0'),(57,4,307,_binary '\0',_binary '',_binary '\0',_binary '\0',_binary '\0'),(57,4,308,_binary '\0',_binary '',_binary '\0',_binary '\0',_binary '\0'),(57,4,309,_binary '\0',_binary '\0',_binary '\0',_binary '\0',_binary '\0'),(58,4,301,_binary '',_binary '',_binary '',_binary '',_binary ''),(58,4,302,_binary '',_binary '',_binary '',_binary '',_binary ''),(58,4,303,_binary '',_binary '',_binary '',_binary '',_binary ''),(58,4,304,_binary '',_binary '',_binary '',_binary '',_binary ''),(58,4,305,_binary '',_binary '',_binary '',_binary '',_binary ''),(62,4,301,_binary '',_binary '',_binary '',_binary '',_binary ''),(62,4,302,_binary '\0',_binary '',_binary '\0',_binary '',_binary '\0'),(62,4,303,_binary '\0',_binary '',_binary '',_binary '\0',_binary '\0'),(62,4,304,_binary '\0',_binary '\0',_binary '\0',_binary '\0',_binary '\0'),(62,4,305,_binary '\0',_binary '\0',_binary '\0',_binary '\0',_binary '\0'),(62,4,306,_binary '',_binary '',_binary '',_binary '',_binary '');
/*!40000 ALTER TABLE `Tbl_Permiso_Usuario_Aplicacion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Tbl_Reportes`
--

DROP TABLE IF EXISTS `Tbl_Reportes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Tbl_Reportes` (
  `Pk_Id_Reporte` int NOT NULL,
  `Cmp_Titulo_Reporte` varchar(50) DEFAULT NULL,
  `Cmp_Ruta_Reporte` varchar(50) DEFAULT NULL,
  `Cmp_Fecha_Reporte` date DEFAULT NULL,
  PRIMARY KEY (`Pk_Id_Reporte`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Tbl_Reportes`
--

LOCK TABLES `Tbl_Reportes` WRITE;
/*!40000 ALTER TABLE `Tbl_Reportes` DISABLE KEYS */;
INSERT INTO `Tbl_Reportes` VALUES (1,'Reporte Inicial','ruta/reporte.pdf','2025-01-01');
/*!40000 ALTER TABLE `Tbl_Reportes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Tbl_Salario_Empleado`
--

DROP TABLE IF EXISTS `Tbl_Salario_Empleado`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Tbl_Salario_Empleado` (
  `Pk_Id_Salario` int NOT NULL,
  `Fk_Id_Empleado` int DEFAULT NULL,
  `Cmp_Monto_Salario_Empleado` float DEFAULT NULL,
  `Cmp_Fecha_Inicio_Salario_Empleado` datetime DEFAULT NULL,
  `Cmp_Fecha_Fin_Salario_Empleado` datetime DEFAULT NULL,
  `Cmp_Estado_Salario_Empleado` bit(1) DEFAULT NULL,
  PRIMARY KEY (`Pk_Id_Salario`),
  KEY `Fk_Salario_Empleado` (`Fk_Id_Empleado`),
  CONSTRAINT `Fk_Salario_Empleado` FOREIGN KEY (`Fk_Id_Empleado`) REFERENCES `Tbl_Empleado` (`Pk_Id_Empleado`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Tbl_Salario_Empleado`
--

LOCK TABLES `Tbl_Salario_Empleado` WRITE;
/*!40000 ALTER TABLE `Tbl_Salario_Empleado` DISABLE KEYS */;
/*!40000 ALTER TABLE `Tbl_Salario_Empleado` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Tbl_Token_RestaurarContrasena`
--

DROP TABLE IF EXISTS `Tbl_Token_RestaurarContrasena`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Tbl_Token_RestaurarContrasena` (
  `Pk_Id_Token` int NOT NULL AUTO_INCREMENT,
  `Fk_Id_Usuario` int DEFAULT NULL,
  `Cmp_Token` varchar(50) DEFAULT NULL,
  `Cmp_Fecha_Creacion_Restaurar_Contrasenea` datetime DEFAULT NULL,
  `Cmp_Expiracion_Restaurar_Contrasenea` datetime DEFAULT NULL,
  `Cmp_Utilizado_Restaurar_Contrasenea` bit(1) DEFAULT NULL,
  `Cmp_Fecha_Uso_Restaurar_Contrasenea` datetime DEFAULT NULL,
  PRIMARY KEY (`Pk_Id_Token`),
  KEY `Fk_Token_Usuario` (`Fk_Id_Usuario`),
  CONSTRAINT `Fk_Token_Usuario` FOREIGN KEY (`Fk_Id_Usuario`) REFERENCES `Tbl_Usuario` (`Pk_Id_Usuario`)
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Tbl_Token_RestaurarContrasena`
--

LOCK TABLES `Tbl_Token_RestaurarContrasena` WRITE;
/*!40000 ALTER TABLE `Tbl_Token_RestaurarContrasena` DISABLE KEYS */;
INSERT INTO `Tbl_Token_RestaurarContrasena` VALUES (1,2,'C43C63DA','2025-09-21 18:24:01','2025-09-21 18:29:01',_binary '','2025-09-21 18:24:38'),(2,1,'901DA0A1','2025-09-21 18:31:36','2025-09-21 18:36:36',_binary '','2025-09-21 18:32:15'),(3,1,'990DD530','2025-09-22 10:05:46','2025-09-22 10:10:46',_binary '\0',NULL),(4,1,'39C03B58','2025-09-24 20:53:40','2025-09-24 20:58:40',_binary '','2025-09-24 20:54:05'),(5,1,'21BE635F','2025-09-25 08:36:46','2025-09-25 08:41:46',_binary '','2025-09-25 08:37:06'),(6,7,'28F08413','2025-09-26 19:21:51','2025-09-26 19:26:51',_binary '\0',NULL),(7,24,'314418EF','2025-09-27 10:09:06','2025-09-27 10:14:06',_binary '','2025-09-27 10:09:27'),(8,7,'C30808F1','2025-09-27 12:22:20','2025-09-27 12:27:20',_binary '','2025-09-27 12:22:29'),(9,7,'B1AE042A','2025-09-27 12:22:53','2025-09-27 12:27:53',_binary '','2025-09-27 12:23:00'),(10,7,'183E762C','2025-09-27 12:30:45','2025-09-27 12:35:45',_binary '','2025-09-27 12:31:30'),(11,7,'AB7B8C02','2025-09-27 12:34:27','2025-09-27 12:39:27',_binary '','2025-09-27 12:34:54'),(12,7,'76A7D51E','2025-09-27 17:50:00','2025-09-27 17:55:00',_binary '\0',NULL),(13,7,'F8C4776A','2025-09-27 23:49:38','2025-09-27 23:54:38',_binary '','2025-09-27 23:49:52'),(14,1,'DE59E51C','2025-10-06 22:27:35','2025-10-06 22:32:35',_binary '','2025-10-06 22:27:56'),(15,29,'C577F481','2025-10-08 13:30:21','2025-10-08 13:35:21',_binary '','2025-10-08 13:31:09'),(16,12,'F7A08D82','2025-10-12 08:03:14','2025-10-12 08:08:14',_binary '','2025-10-12 08:03:29'),(17,12,'B1B0EC64','2025-10-12 08:05:58','2025-10-12 08:10:58',_binary '','2025-10-12 08:06:12'),(18,7,'A8806F00','2025-10-12 14:48:07','2025-10-12 14:53:07',_binary '\0',NULL),(19,7,'A02EE0D6','2025-10-12 14:57:40','2025-10-12 15:02:40',_binary '','2025-10-12 14:58:16'),(20,47,'C319527A','2025-10-13 17:23:42','2025-10-13 17:28:42',_binary '','2025-10-13 17:24:22'),(21,53,'18AE161D','2025-10-14 18:31:41','2025-10-14 18:36:41',_binary '','2025-10-14 18:32:04'),(22,2,'F1E15FAE','2025-10-18 11:49:09','2025-10-18 11:54:09',_binary '','2025-10-18 11:50:16'),(23,4,'B07EF449','2025-10-18 12:07:34','2025-10-18 12:12:34',_binary '','2025-10-18 12:08:27'),(24,4,'0C76A696','2025-10-18 17:08:53','2025-10-18 17:13:53',_binary '','2025-10-18 17:09:11'),(25,2,'9BAAF4CB','2025-10-21 13:44:20','2025-10-21 13:49:20',_binary '','2025-10-21 13:44:51');
/*!40000 ALTER TABLE `Tbl_Token_RestaurarContrasena` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Tbl_Usuario`
--

DROP TABLE IF EXISTS `Tbl_Usuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Tbl_Usuario` (
  `Pk_Id_Usuario` int NOT NULL AUTO_INCREMENT,
  `Fk_Id_Empleado` int DEFAULT NULL,
  `Cmp_Nombre_Usuario` varchar(50) DEFAULT NULL,
  `Cmp_Contrasena_Usuario` varchar(65) DEFAULT NULL,
  `Cmp_Intentos_Fallidos_Usuario` int DEFAULT NULL,
  `Cmp_Estado_Usuario` bit(1) DEFAULT NULL,
  `Cmp_FechaCreacion_Usuario` datetime DEFAULT NULL,
  `Cmp_Ultimo_Cambio_Contrasenea` datetime DEFAULT NULL,
  `Cmp_Pidio_Cambio_Contrasenea` bit(1) DEFAULT NULL,
  PRIMARY KEY (`Pk_Id_Usuario`),
  KEY `Fk_Usuario_Empleado` (`Fk_Id_Empleado`),
  CONSTRAINT `Fk_Usuario_Empleado` FOREIGN KEY (`Fk_Id_Empleado`) REFERENCES `Tbl_Empleado` (`Pk_Id_Empleado`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=63 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Tbl_Usuario`
--

LOCK TABLES `Tbl_Usuario` WRITE;
/*!40000 ALTER TABLE `Tbl_Usuario` DISABLE KEYS */;
INSERT INTO `Tbl_Usuario` VALUES (1,1,'ricardo','5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5',0,_binary '','2025-09-21 23:01:04','2025-10-06 22:27:56',_binary '\0'),(2,1,'Cesar','578bfc33d127e864cf010d2fdda8c66c018757829b7e349653760ce5e36c59c6',0,_binary '','2025-09-22 00:17:20','2025-10-21 13:44:50',_binary '\0'),(4,2,'brandon','45297c633d331e6ac35169ebaaf75bc7fafd206ebb59ba4efd80566936e46eb0',0,_binary '','2025-09-21 20:49:54','2025-10-18 17:09:11',_binary '\0'),(5,1,'carlo','91a73fd806ab2c005c13b4dc19130a884e909dea3f72d46e30266fe1a1f588d8',0,_binary '','2025-09-22 08:56:31','2025-09-22 08:56:31',_binary '\0'),(6,2,'conesultas','a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3',0,_binary '','2025-09-22 18:31:34','2025-09-22 18:31:34',_binary '\0'),(7,2,'ruben','07c4b46160c71a2135063b4c47638ce816fc99968dbce0e52faec985bbbb27fd',0,_binary '','2025-09-22 18:37:21','2025-10-12 14:58:16',_binary '\0'),(8,2,'rhm','a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3',0,_binary '','2025-09-22 18:52:45','2025-09-22 18:52:45',_binary '\0'),(9,2,'Juan','ba7816bf8f01cfea414140de5dae2223b00361a396177a9cb410ff61f20015ad',0,_binary '','2025-09-22 20:59:48','2025-09-22 20:59:48',_binary '\0'),(10,1,'prueba','655e786674d9d3e77bc05ed1de37b4b6bc89f788829f9f3c679e7687b410c89b',0,_binary '','2025-09-23 07:42:45','2025-09-23 07:42:45',_binary '\0'),(11,1,'armando','d74ff0ee8da3b9806b18c877dbf29bbde50b5bd8e4dad7a3a725000feb82e8f1',0,_binary '','2025-09-23 22:56:07','2025-09-23 22:56:07',_binary '\0'),(12,11,'administradorCesar','4813494d137e1631bba301d5acab6e7bb7aa74ce1185d456565ef51d737677b2',0,_binary '','2025-10-12 08:04:12','2025-10-12 08:06:12',_binary '\0'),(13,1,'manolo','b2c56341cc2b9f8bf898bd7528dd39e641b51c4fbd51f241b46ad70872dd1b99',0,_binary '','2025-09-24 01:08:13','2025-09-24 01:08:13',_binary '\0'),(14,2,'aa','4fc82b26aecb47d2868c4efbe3581732a3e7cbcc6c2efb32062c08170a05eeb8',0,_binary '','2025-09-24 18:44:59','2025-09-24 18:44:59',_binary '\0'),(15,2,'jeffer','f0d588a225e6e6ba0501a3f787230abf579f6db2dd55be0fa3450f8acd54e6f3',0,_binary '','2025-09-24 21:58:01','2025-09-24 21:58:01',_binary '\0'),(16,2,'Ernesto','4813494d137e1631bba301d5acab6e7bb7aa74ce1185d456565ef51d737677b2',0,_binary '','2025-09-25 07:30:08','2025-09-25 07:30:08',_binary '\0'),(17,1,'esduardo','c0bc1e08f9743b2d50d5f1607503bf4e849af0e729fca896515bea955d70a33e',0,_binary '','2025-09-25 07:58:15','2025-09-25 07:58:15',_binary '\0'),(18,1,'ricardo','a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3',0,_binary '','2025-09-25 08:36:11','2025-09-25 08:36:11',_binary '\0'),(19,1,'aron','5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5',0,_binary '','2025-09-25 10:30:21','2025-09-25 10:30:21',_binary '\0'),(20,2,'pedro','5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5',0,_binary '','2025-09-25 10:37:20','2025-09-25 10:37:20',_binary '\0'),(21,2,'juan','a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3',0,_binary '','2025-09-25 15:36:06','2025-09-25 15:36:06',_binary '\0'),(22,3,'pruebas','655e786674d9d3e77bc05ed1de37b4b6bc89f788829f9f3c679e7687b410c89b',0,_binary '','2025-09-26 20:38:57','2025-09-26 20:38:57',_binary '\0'),(23,3,'admin','240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9',0,_binary '','2025-09-26 20:45:53','2025-09-26 20:45:53',_binary '\0'),(24,4,'Kenph','e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855',0,_binary '','2025-09-27 09:10:23','2025-09-27 10:09:27',_binary '\0'),(25,4,'Kenph','03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4',0,_binary '','2025-09-27 09:15:22','2025-09-27 09:15:22',_binary '\0'),(26,4,'@123','a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3',0,_binary '','2025-09-27 09:19:55','2025-09-27 09:19:55',_binary '\0'),(27,4,'Kenph','a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3',0,_binary '','2025-09-27 09:42:35','2025-09-27 09:42:35',_binary '\0'),(28,4,'Kenph','a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3',0,_binary '','2025-09-27 09:42:57','2025-09-27 09:42:57',_binary '\0'),(29,8,'Juan Perez','03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4',0,_binary '','2025-09-27 10:08:42','2025-10-08 13:32:02',_binary '\0'),(30,3,'select * from Tbl_empleados;','ed02457b5c41d964dbd2f2a609d63fe1bb7528dbe55e1abf5b52c249cd735797',0,_binary '','2025-09-27 10:51:53','2025-09-27 10:51:53',_binary '\0'),(31,1,'jorge','a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3',0,_binary '','2025-10-07 08:16:42','2025-10-07 08:16:42',_binary '\0'),(32,10,'esquuu','5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5',0,_binary '','2025-10-07 09:23:11','2025-10-07 09:23:11',_binary '\0'),(33,10,'aesquut','5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5',0,_binary '','2025-10-07 09:39:40','2025-10-07 09:39:40',_binary '\0'),(34,9,'ersSam','5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5',0,_binary '','2025-10-07 09:41:47','2025-10-07 09:41:47',_binary '\0'),(35,2,'pancho','a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3',0,_binary '','2025-10-07 23:44:41','2025-10-07 23:44:41',_binary '\0'),(36,1,'adminruben','bf59d6a4564f9f49964ef377f398e35c7da2413e9d792c97dfdbbc9687ce8abc',0,_binary '','2025-10-08 05:48:27','2025-10-08 07:05:26',_binary '\0'),(37,1,'espe','a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3',0,_binary '','2025-10-08 07:24:45','2025-10-08 07:24:45',_binary '\0'),(38,8,'sebastian','5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5',0,_binary '','2025-10-09 16:11:30','2025-10-09 16:11:30',_binary '\0'),(39,11,'cesarPractica','a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3',0,_binary '','2025-10-10 07:55:58','2025-10-10 07:55:58',_binary '\0'),(40,11,'cesarError','03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4',0,_binary '','2025-10-10 07:57:10','2025-10-10 08:01:48',_binary '\0'),(41,11,'cesarCorrecto','ba7816bf8f01cfea414140de5dae2223b00361a396177a9cb410ff61f20015ad',0,_binary '','2025-10-10 08:14:49','2025-10-10 08:14:49',_binary '\0'),(42,12,'raul','a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3',0,_binary '','2025-10-11 22:42:22','2025-10-11 22:42:22',_binary '\0'),(43,11,'administradorCesas','4813494d137e1631bba301d5acab6e7bb7aa74ce1185d456565ef51d737677b2',0,_binary '','2025-10-12 08:04:53','2025-10-12 08:04:53',_binary '\0'),(44,3,'alexander','a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3',0,_binary '','2025-10-12 14:17:24','2025-10-12 14:17:24',_binary '\0'),(45,3,'rebeca','a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3',0,_binary '','2025-10-12 14:53:21','2025-10-12 14:53:21',_binary '\0'),(46,8,'kkk','b3a8e0e1f9ab1bfe3a36f231f676f78bb30a519d2b21e6c530c0eee8ebb4a5d0',0,_binary '','2025-10-12 15:08:16','2025-10-12 15:08:16',_binary '\0'),(47,13,'pruebaKenph','a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3',0,_binary '','2025-10-13 16:18:13','2025-10-13 17:25:22',_binary '\0'),(48,14,'pruebaJorge','a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3',0,_binary '','2025-10-13 16:20:19','2025-10-13 16:20:19',_binary '\0'),(49,400,'marcos','03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4',0,_binary '','2025-10-13 18:18:35','2025-10-13 18:18:35',_binary '\0'),(50,16,'dkplay','5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5',0,_binary '','2025-10-13 20:25:36','2025-10-13 20:25:36',_binary '\0'),(51,900,'mario','6b51d431df5d7f141cbececcf79edf3dd861c3b4069f0b11661a3eefacbba918',0,_binary '','2025-10-14 07:57:31','2025-10-14 07:57:31',_binary '\0'),(52,1,'Mauricio','91a73fd806ab2c005c13b4dc19130a884e909dea3f72d46e30266fe1a1f588d8',0,_binary '','2025-10-14 18:10:25','2025-10-14 18:10:25',_binary '\0'),(53,324,'andres420','edf9cf90718610ee7de53c0dcc250739239044de9ba115bb0ca6026c3e4958a5',0,_binary '','2025-10-14 18:15:23','2025-10-14 18:32:04',_binary '\0'),(54,414,'luis','6b86b273ff34fce19d6b804eff5a3f5747ada4eaa22f1d49c01e52ddb7875b4b',0,_binary '','2025-10-14 19:55:45','2025-10-14 19:55:45',_binary '\0'),(55,324,'PruebaNav','a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3',0,_binary '','2025-10-14 20:24:21','2025-10-14 20:24:21',_binary '\0'),(56,1,'Mauricio1','91a73fd806ab2c005c13b4dc19130a884e909dea3f72d46e30266fe1a1f588d8',0,_binary '','2025-10-15 10:14:47','2025-10-15 10:14:47',_binary '\0'),(57,3,'maria','a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3',0,_binary '','2025-10-15 13:16:10','2025-10-15 13:16:10',_binary '\0'),(58,901,'Icortez','ef797c8118f02dfb649607dd5d3f8c7623048c9c063d532cc95c5ed7a898a64f',0,_binary '','2025-10-18 12:34:28','2025-10-18 12:34:28',_binary '\0'),(59,11,'checha','250fccd5f5f76c7c866647d737ea3af37a8404744a5fc7c2628245194242304d',0,_binary '','2025-10-21 18:51:30','2025-10-21 18:51:30',_binary '\0'),(60,1001,'Ruben1','ba7816bf8f01cfea414140de5dae2223b00361a396177a9cb410ff61f20015ad',0,_binary '','2025-10-21 19:16:31','2025-10-21 19:16:31',_binary '\0'),(61,13,'prueba55','a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3',0,_binary '','2025-10-22 17:41:46','2025-10-22 17:41:46',_binary '\0'),(62,1001,'Prueba66','a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3',0,_binary '','2025-10-22 17:50:59','2025-10-22 17:50:59',_binary '\0');
/*!40000 ALTER TABLE `Tbl_Usuario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Tbl_Usuario_Perfil`
--

DROP TABLE IF EXISTS `Tbl_Usuario_Perfil`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Tbl_Usuario_Perfil` (
  `Fk_Id_Usuario` int NOT NULL,
  `Fk_Id_Perfil` int NOT NULL,
  PRIMARY KEY (`Fk_Id_Usuario`,`Fk_Id_Perfil`),
  KEY `Fk_UsuarioPerfil_Perfil` (`Fk_Id_Perfil`),
  CONSTRAINT `Fk_UsuarioPerfil_Perfil` FOREIGN KEY (`Fk_Id_Perfil`) REFERENCES `Tbl_Perfil` (`Pk_Id_Perfil`),
  CONSTRAINT `Fk_UsuarioPerfil_Usuario` FOREIGN KEY (`Fk_Id_Usuario`) REFERENCES `Tbl_Usuario` (`Pk_Id_Usuario`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Tbl_Usuario_Perfil`
--

LOCK TABLES `Tbl_Usuario_Perfil` WRITE;
/*!40000 ALTER TABLE `Tbl_Usuario_Perfil` DISABLE KEYS */;
INSERT INTO `Tbl_Usuario_Perfil` VALUES (1,1),(4,1),(5,1),(9,1),(10,1),(12,1),(22,1),(51,1),(58,1),(9,2),(11,2),(4,4),(8,4),(9,4),(12,4),(15,4),(20,4),(52,4),(9,5),(12,7),(40,10),(41,10),(44,10),(14,12),(35,12),(47,12),(48,12),(61,12),(26,16),(53,16),(56,22),(57,22);
/*!40000 ALTER TABLE `Tbl_Usuario_Perfil` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-10-24 10:55:53
