-- MySQL dump 10.13  Distrib 8.0.41, for Win64 (x86_64)
--
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
INSERT INTO `Tbl_Aplicacion` VALUES (1,NULL,'Gestion de empleado','Se gestionan los empleados del hotel',_binary ''),(2,NULL,'Empleado','Prueba Empleado',_binary ''),(3,NULL,'Gestion De Empleados','prueba permisos',_binary ''),(4,NULL,'Empleados','Formulario de empleados',_binary ''),(5,NULL,'Administracion','Formularios de administracion',_binary ''),(6,NULL,'Modulos','Gestion de Modulos',_binary ''),(7,NULL,'Prueba Dll','Prueba de cambios de Dll',_binary '');
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
INSERT INTO `Tbl_Asignacion_Modulo_Aplicacion` VALUES (2,1),(4,2),(3,3),(4,4),(2,5),(5,6),(1,7);
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
  `Cmp_Accion` varchar(50) DEFAULT NULL,
  `Cmp_Ip` varchar(50) DEFAULT NULL,
  `Cmp_Nombre_Pc` varchar(50) DEFAULT NULL,
  `Cmp_Login_Estado` bit(1) DEFAULT NULL,
  PRIMARY KEY (`Pk_Id_Bitacora`),
  KEY `Fk_Bitacora_Usuario` (`Fk_Id_Usuario`),
  KEY `Fk_Bitacora_Aplicacion` (`Fk_Id_Aplicacion`),
  CONSTRAINT `Fk_Bitacora_Aplicacion` FOREIGN KEY (`Fk_Id_Aplicacion`) REFERENCES `Tbl_Aplicacion` (`Pk_Id_Aplicacion`),
  CONSTRAINT `Fk_Bitacora_Usuario` FOREIGN KEY (`Fk_Id_Usuario`) REFERENCES `Tbl_Usuario` (`Pk_Id_Usuario`)
) ENGINE=InnoDB AUTO_INCREMENT=631 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Tbl_Bitacora`
--

LOCK TABLES `Tbl_Bitacora` WRITE;
/*!40000 ALTER TABLE `Tbl_Bitacora` DISABLE KEYS */;
INSERT INTO `Tbl_Bitacora` VALUES (1,2,NULL,'2025-09-21 18:24:42','Recuperar contraseña','192.168.137.1','COMPU_CESAR',_binary ''),(2,1,NULL,'2025-09-21 18:32:18','Recuperar contraseña','192.168.137.1','COMPU_CESAR',_binary ''),(3,2,NULL,'2025-09-21 18:49:08','Ingreso','192.168.137.1','COMPU_CESAR',_binary ''),(4,2,NULL,'2025-09-21 18:53:27','Ingreso','192.168.137.1','COMPU_CESAR',_binary ''),(5,2,NULL,'2025-09-21 18:57:27','Ingreso','192.168.137.1','COMPU_CESAR',_binary ''),(6,2,NULL,'2025-09-21 19:07:36','Ingreso','192.168.137.1','COMPU_CESAR',_binary ''),(7,2,1,'2025-09-21 19:11:32','Guardar aplicación','192.168.137.1','COMPU_CESAR',_binary ''),(8,2,NULL,'2025-09-21 20:35:07','Ingreso','192.168.1.11','DAVID',_binary ''),(9,2,NULL,'2025-09-21 20:36:04','Ingreso','192.168.1.11','DAVID',_binary ''),(10,2,NULL,'2025-09-21 20:41:25','Ingreso','192.168.1.11','DAVID',_binary ''),(11,2,NULL,'2025-09-21 20:42:43','Cierre de sesión','192.168.1.11','DAVID',_binary '\0'),(12,2,NULL,'2025-09-21 20:48:00','Ingreso','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(13,2,NULL,'2025-09-21 20:48:59','Ingreso','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(14,2,1,'2025-09-21 20:49:56','Guardar usuario','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(15,4,NULL,'2025-09-21 20:50:23','Ingreso','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(16,4,NULL,'2025-09-21 20:58:22','Ingreso','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(17,4,1,'2025-09-21 20:58:45','Guardar perfil','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(18,4,NULL,'2025-09-21 21:23:06','Ingreso','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(19,4,1,'2025-09-21 21:23:50','Asignación Perfil a Usuario - Agregar','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(20,4,NULL,'2025-09-21 21:25:09','Ingreso','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(21,4,1,'2025-09-21 21:25:25','Asignación Perfil a Usuario - Agregar','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(22,4,1,'2025-09-21 21:25:37','Asignación Perfil a Usuario - Agregar','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(23,4,NULL,'2025-09-21 21:32:08','Ingreso','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(24,4,1,'2025-09-21 21:32:54','Asignación Perfil a Usuario - Agregar','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(25,4,NULL,'2025-09-21 21:37:45','Ingreso','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(26,4,1,'2025-09-21 21:38:08','Asignación Perfil a Usuario - Agregar','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(27,4,NULL,'2025-09-21 21:47:22','Ingreso','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(28,4,1,'2025-09-21 21:47:40','Asignación Perfil a Usuario - Agregar','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(29,4,NULL,'2025-09-21 21:52:07','Ingreso','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(30,4,1,'2025-09-21 21:52:23','Asignación Perfil a Usuario - Agregar','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(31,4,1,'2025-09-21 21:52:31','Asignación Perfil a Uusario - Guardar','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(32,4,NULL,'2025-09-21 22:06:01','Ingreso','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(33,4,1,'2025-09-21 22:06:30','Asignación Permisos Perfil - Agregar','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(34,4,1,'2025-09-21 22:06:43','Asignación aplicación a perfil - insertar','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(35,2,NULL,'2025-09-22 07:04:27','Ingreso','192.168.137.1','COMPU_CESAR',_binary ''),(36,4,NULL,'2025-09-22 08:06:20','Ingreso','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(37,2,NULL,'2025-09-22 08:45:45','Ingreso','192.168.178.223','DOMITS',_binary ''),(38,2,NULL,'2025-09-22 08:46:15','Ingreso','192.168.178.223','DOMITS',_binary ''),(39,2,NULL,'2025-09-22 08:51:41','Ingreso','192.168.178.223','DOMITS',_binary ''),(40,4,NULL,'2025-09-22 08:55:22','Ingreso','172.20.10.3','BELY',_binary ''),(41,4,1,'2025-09-22 08:56:33','Guardar usuario','172.20.10.3','BELY',_binary ''),(42,4,NULL,'2025-09-22 08:56:36','Cierre de sesión','172.20.10.3','BELY',_binary '\0'),(43,4,NULL,'2025-09-22 08:57:04','Cierre de sesión','172.20.10.3','BELY',_binary '\0'),(44,5,NULL,'2025-09-22 08:57:21','Ingreso','172.20.10.3','BELY',_binary ''),(45,5,NULL,'2025-09-22 09:18:25','Ingreso','172.20.10.3','BELY',_binary ''),(46,5,NULL,'2025-09-22 09:26:33','Ingreso','172.20.10.3','BELY',_binary ''),(47,5,NULL,'2025-09-22 09:31:57','Ingreso','172.20.10.3','BELY',_binary ''),(48,5,NULL,'2025-09-22 09:58:13','Ingreso','172.20.10.3','BELY',_binary ''),(49,2,NULL,'2025-09-22 10:06:48','Ingreso','192.168.140.58','RICARDO',_binary ''),(50,2,1,'2025-09-22 10:09:36','Guardar módulo','192.168.140.58','RICARDO',_binary ''),(51,2,NULL,'2025-09-22 10:11:06','Ingreso','192.168.140.58','RICARDO',_binary ''),(52,4,NULL,'2025-09-22 10:33:23','Ingreso','172.20.10.3','BELY',_binary ''),(53,2,NULL,'2025-09-22 10:44:04','Ingreso','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(54,2,NULL,'2025-09-22 10:52:24','Ingreso','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(55,2,NULL,'2025-09-22 10:54:03','Ingreso','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(56,2,NULL,'2025-09-22 10:55:10','Ingreso','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(57,5,NULL,'2025-09-22 11:01:14','Ingreso','172.20.10.3','BELY',_binary ''),(58,5,NULL,'2025-09-22 11:02:54','Ingreso','172.20.10.3','BELY',_binary ''),(59,5,NULL,'2025-09-22 11:03:32','Ingreso','172.20.10.3','BELY',_binary ''),(60,2,NULL,'2025-09-22 11:05:27','Ingreso','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(61,4,NULL,'2025-09-22 11:08:52','Ingreso','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(62,5,NULL,'2025-09-22 11:12:49','Ingreso','172.20.10.3','BELY',_binary ''),(63,5,NULL,'2025-09-22 11:19:11','Ingreso','172.20.10.3','BELY',_binary ''),(64,5,NULL,'2025-09-22 11:24:29','Ingreso','172.20.10.3','BELY',_binary ''),(65,5,NULL,'2025-09-22 11:32:01','Ingreso','172.20.10.3','BELY',_binary ''),(66,5,NULL,'2025-09-22 11:37:59','Ingreso','172.20.10.3','BELY',_binary ''),(67,5,NULL,'2025-09-22 11:46:52','Ingreso','172.20.10.3','BELY',_binary ''),(68,5,NULL,'2025-09-22 11:48:45','Ingreso','172.20.10.3','BELY',_binary ''),(69,5,NULL,'2025-09-22 11:55:54','Ingreso','172.20.10.3','BELY',_binary ''),(70,4,NULL,'2025-09-22 12:05:00','Ingreso','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(71,2,NULL,'2025-09-22 16:00:30','Ingreso','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(72,2,NULL,'2025-09-22 16:02:24','Ingreso','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(73,2,NULL,'2025-09-22 17:56:01','Ingreso','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(74,2,NULL,'2025-09-22 17:57:46','Ingreso','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(75,2,1,'2025-09-22 17:58:16','Asignación Perfil a Usuario - Agregar','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(76,2,NULL,'2025-09-22 17:59:03','Ingreso','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(77,2,NULL,'2025-09-22 18:21:48','Ingreso','192.168.137.1','COMPU_CESAR',_binary ''),(78,2,1,'2025-09-22 18:22:17','Asignación Aplicación a Usuario - Agregar','192.168.137.1','COMPU_CESAR',_binary ''),(79,2,NULL,'2025-09-22 18:30:31','Ingreso','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(80,4,NULL,'2025-09-22 18:31:12','Ingreso','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(81,4,1,'2025-09-22 18:31:35','Guardar usuario','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(82,2,NULL,'2025-09-22 18:32:56','Ingreso','192.168.137.1','COMPU_CESAR',_binary ''),(83,4,1,'2025-09-22 18:32:52','Guardar módulo','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(84,2,1,'2025-09-22 18:33:22','Asignación Aplicación a Usuario - Agregar','192.168.137.1','COMPU_CESAR',_binary ''),(85,2,1,'2025-09-22 18:33:40','Asignación Aplicación a Usuario - Insertar','192.168.137.1','COMPU_CESAR',_binary ''),(86,4,1,'2025-09-22 18:33:35','Asignación Aplicación a Usuario - Agregar','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(87,2,NULL,'2025-09-22 18:34:06','Cierre de sesión','192.168.137.1','COMPU_CESAR',_binary '\0'),(88,2,NULL,'2025-09-22 18:34:27','Ingreso','192.168.137.1','COMPU_CESAR',_binary ''),(89,4,NULL,'2025-09-22 18:34:53','Ingreso','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(90,4,1,'2025-09-22 18:35:19','Asignación Aplicación a Usuario - Agregar','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(91,4,NULL,'2025-09-22 18:37:01','Ingreso','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(92,4,1,'2025-09-22 18:37:24','Guardar usuario','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(93,2,NULL,'2025-09-22 18:37:30','Ingreso','192.168.1.7','RICARDO',_binary ''),(94,2,NULL,'2025-09-22 18:40:10','Cierre de sesión','192.168.1.7','RICARDO',_binary '\0'),(95,7,NULL,'2025-09-22 18:41:58','Ingreso','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(96,4,NULL,'2025-09-22 18:48:11','Ingreso','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(97,4,1,'2025-09-22 18:48:31','Asignación Aplicación a Usuario - Agregar','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(98,4,1,'2025-09-22 18:48:46','Asignación Aplicación a Usuario - Insertar','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(99,4,NULL,'2025-09-22 18:49:10','Cierre de sesión','192.168.56.1','DESKTOP-01DDSQ2',_binary '\0'),(100,6,NULL,'2025-09-22 18:51:05','Ingreso','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(101,6,NULL,'2025-09-22 18:52:23','Ingreso','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(102,6,1,'2025-09-22 18:52:47','Guardar usuario','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(103,6,1,'2025-09-22 18:53:05','Asignación Aplicación a Usuario - Agregar','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(104,6,1,'2025-09-22 18:53:34','Asignación Aplicación a Usuario - Insertar','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(105,6,1,'2025-09-22 18:53:47','Asignación Aplicación a Usuario - Agregar','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(106,6,1,'2025-09-22 18:54:00','Asignación Aplicación a Usuario - Insertar','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(107,2,NULL,'2025-09-22 19:01:27','Ingreso','192.168.1.7','RICARDO',_binary ''),(108,2,NULL,'2025-09-22 19:06:06','Ingreso','192.168.1.7','RICARDO',_binary ''),(109,4,NULL,'2025-09-22 19:07:07','Ingreso','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(110,2,NULL,'2025-09-22 19:07:11','Ingreso','192.168.1.7','RICARDO',_binary ''),(111,2,NULL,'2025-09-22 19:14:04','Ingreso','192.168.1.7','RICARDO',_binary ''),(112,4,NULL,'2025-09-22 19:14:13','Ingreso','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(113,4,1,'2025-09-22 19:14:38','Asignación Aplicación a Usuario - Agregar','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(114,2,NULL,'2025-09-22 19:15:20','Cierre de sesión','192.168.1.7','RICARDO',_binary '\0'),(115,2,NULL,'2025-09-22 19:28:05','Ingreso','192.168.1.7','RICARDO',_binary ''),(116,2,NULL,'2025-09-22 19:28:25','Cierre de sesión','192.168.1.7','RICARDO',_binary '\0'),(117,2,NULL,'2025-09-22 19:35:52','Ingreso','192.168.1.7','RICARDO',_binary ''),(118,2,NULL,'2025-09-22 19:36:22','Cierre de sesión','192.168.1.7','RICARDO',_binary '\0'),(119,2,NULL,'2025-09-22 20:59:24','Ingreso','192.168.1.4','LAPTOP-6C415UB3',_binary ''),(120,2,1,'2025-09-22 20:59:50','Guardar usuario','192.168.1.4','LAPTOP-6C415UB3',_binary ''),(121,2,NULL,'2025-09-22 21:05:57','Ingreso','192.168.1.4','LAPTOP-6C415UB3',_binary ''),(122,2,NULL,'2025-09-22 21:16:14','Ingreso','192.168.137.1','COMPU_CESAR',_binary ''),(123,2,1,'2025-09-22 21:16:49','Asignación Aplicación a Usuario - Agregar','192.168.137.1','COMPU_CESAR',_binary ''),(124,2,1,'2025-09-22 21:17:03','Asignación Aplicación a Usuario - Insertar','192.168.137.1','COMPU_CESAR',_binary ''),(125,2,NULL,'2025-09-22 21:22:44','Ingreso','192.168.1.4','LAPTOP-6C415UB3',_binary ''),(126,2,NULL,'2025-09-22 21:23:45','Ingreso','192.168.137.1','COMPU_CESAR',_binary ''),(127,2,NULL,'2025-09-22 21:31:13','Ingreso','192.168.1.4','LAPTOP-6C415UB3',_binary ''),(128,2,NULL,'2025-09-22 21:40:54','Ingreso','192.168.1.4','LAPTOP-6C415UB3',_binary ''),(129,2,1,'2025-09-22 21:41:37','Asignación Aplicación a Usuario - Agregar','192.168.1.4','LAPTOP-6C415UB3',_binary ''),(130,2,1,'2025-09-22 21:41:46','Asignación Aplicación a Usuario - Actualizar','192.168.1.4','LAPTOP-6C415UB3',_binary ''),(131,2,1,'2025-09-22 21:43:52','Asignación Aplicación a Usuario - Agregar','192.168.1.4','LAPTOP-6C415UB3',_binary ''),(132,2,1,'2025-09-22 21:44:14','Asignación Aplicación a Usuario - Actualizar','192.168.1.4','LAPTOP-6C415UB3',_binary ''),(133,2,NULL,'2025-09-22 21:52:31','Ingreso','192.168.1.4','LAPTOP-6C415UB3',_binary ''),(134,2,NULL,'2025-09-22 21:53:37','Ingreso','192.168.137.1','COMPU_CESAR',_binary ''),(135,2,1,'2025-09-22 21:53:41','Asignación Aplicación a Usuario - Actualizar','192.168.1.4','LAPTOP-6C415UB3',_binary ''),(136,2,NULL,'2025-09-22 22:00:19','Ingreso','192.168.1.4','LAPTOP-6C415UB3',_binary ''),(137,2,NULL,'2025-09-22 22:18:59','Ingreso','192.168.137.1','COMPU_CESAR',_binary ''),(138,2,NULL,'2025-09-22 22:29:15','Ingreso','192.168.1.4','LAPTOP-6C415UB3',_binary ''),(139,2,NULL,'2025-09-22 22:30:45','Ingreso','192.168.1.4','LAPTOP-6C415UB3',_binary ''),(140,2,NULL,'2025-09-22 22:34:35','Ingreso','192.168.1.4','LAPTOP-6C415UB3',_binary ''),(141,2,NULL,'2025-09-22 22:35:20','Ingreso','192.168.137.1','COMPU_CESAR',_binary ''),(142,2,NULL,'2025-09-23 07:15:08','Ingreso','192.168.137.1','COMPU_CESAR',_binary ''),(143,2,NULL,'2025-09-23 07:15:42','Cierre de sesión','192.168.137.1','COMPU_CESAR',_binary '\0'),(144,2,NULL,'2025-09-23 07:15:57','Ingreso','192.168.137.1','COMPU_CESAR',_binary ''),(145,2,NULL,'2025-09-23 07:40:30','Ingreso','192.168.137.1','COMPU_CESAR',_binary ''),(146,2,1,'2025-09-23 07:42:48','Guardar usuario','192.168.137.1','COMPU_CESAR',_binary ''),(147,10,NULL,'2025-09-23 07:44:03','Ingreso','192.168.137.1','COMPU_CESAR',_binary ''),(148,10,1,'2025-09-23 07:48:12','Asignación Aplicación a Usuario - Agregar','192.168.137.1','COMPU_CESAR',_binary ''),(149,10,NULL,'2025-09-23 07:52:58','Ingreso','192.168.137.1','COMPU_CESAR',_binary ''),(150,10,NULL,'2025-09-23 07:54:15','Cierre de sesión','192.168.137.1','COMPU_CESAR',_binary '\0'),(151,2,NULL,'2025-09-23 07:54:50','Ingreso','192.168.137.1','COMPU_CESAR',_binary ''),(152,2,1,'2025-09-23 07:55:11','Asignación Permisos Perfil - Agregar','192.168.137.1','COMPU_CESAR',_binary ''),(153,2,1,'2025-09-23 07:55:25','Asignación aplicación a perfil - Insertar','192.168.137.1','COMPU_CESAR',_binary ''),(154,2,1,'2025-09-23 07:57:12','Asignación Aplicación a Usuario - Actualizar','192.168.137.1','COMPU_CESAR',_binary ''),(155,2,NULL,'2025-09-23 07:59:21','Cierre de sesión','192.168.137.1','COMPU_CESAR',_binary '\0'),(156,4,NULL,'2025-09-23 08:11:09','Ingreso','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(157,4,1,'2025-09-23 08:11:53','Guardar módulo','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(158,4,1,'2025-09-23 08:12:55','Modificar aplicación','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(159,4,2,'2025-09-23 08:13:24','Asignación Aplicación a Usuario - Agregar','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(160,4,2,'2025-09-23 08:13:41','Asignación Aplicación a Usuario - Insertar','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(161,4,NULL,'2025-09-23 08:13:45','Cierre de sesión','192.168.56.1','DESKTOP-01DDSQ2',_binary '\0'),(162,4,NULL,'2025-09-23 08:14:23','Ingreso','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(163,2,NULL,'2025-09-23 08:20:09','Ingreso','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(164,2,2,'2025-09-23 08:20:23','Asignación Aplicación a Usuario - Agregar','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(165,2,2,'2025-09-23 08:20:37','Asignación Aplicación a Usuario - Insertar','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(166,4,NULL,'2025-09-23 08:22:37','Ingreso','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(167,5,NULL,'2025-09-23 08:23:14','Ingreso','192.168.133.128','DAVID',_binary ''),(168,4,NULL,'2025-09-23 08:25:09','Ingreso','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(169,5,NULL,'2025-09-23 08:27:23','Ingreso','192.168.133.128','DAVID',_binary ''),(170,4,1,'2025-09-23 08:37:19','Modificar aplicación','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(171,4,3,'2025-09-23 08:37:40','Asignación Aplicación a Usuario - Agregar','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(172,4,3,'2025-09-23 08:38:01','Asignación Aplicación a Usuario - Insertar','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(173,4,NULL,'2025-09-23 08:40:04','Ingreso','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(174,4,NULL,'2025-09-23 08:43:10','Ingreso','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(175,4,NULL,'2025-09-23 08:51:20','Ingreso','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(176,4,NULL,'2025-09-23 08:54:13','Ingreso','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(177,4,1,'2025-09-23 08:55:25','Guardar módulo','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(178,4,1,'2025-09-23 08:56:32','Modificar aplicación','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(179,4,NULL,'2025-09-23 08:57:25','Ingreso','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(180,4,4,'2025-09-23 08:57:42','Asignación Aplicación a Usuario - Agregar','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(181,4,4,'2025-09-23 08:58:05','Asignación Aplicación a Usuario - Insertar','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(182,5,NULL,'2025-09-23 09:46:30','Ingreso','172.20.10.3','BELY',_binary ''),(183,2,NULL,'2025-09-23 13:06:28','Ingreso','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(184,2,NULL,'2025-09-23 13:15:16','Ingreso','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(185,2,NULL,'2025-09-23 13:23:00','Ingreso','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(186,2,NULL,'2025-09-23 13:27:12','Ingreso','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(187,2,NULL,'2025-09-23 14:42:31','Ingreso','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(188,2,NULL,'2025-09-23 14:49:12','Ingreso','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(189,2,NULL,'2025-09-23 15:35:57','Ingreso','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(190,2,NULL,'2025-09-23 15:58:22','Ingreso','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(191,2,NULL,'2025-09-23 15:59:44','Ingreso','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(192,2,NULL,'2025-09-23 18:33:27','Ingreso','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(193,2,NULL,'2025-09-23 19:06:25','Ingreso','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(194,7,NULL,'2025-09-23 20:35:17','Ingreso','192.168.1.102','LUCHCODEDEV',_binary ''),(195,7,NULL,'2025-09-23 20:55:27','Ingreso','192.168.1.102','LUCHCODEDEV',_binary ''),(196,7,NULL,'2025-09-23 21:43:31','Ingreso','192.168.1.102','LUCHCODEDEV',_binary ''),(197,4,NULL,'2025-09-23 22:02:00','Ingreso','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(198,4,4,'2025-09-23 22:02:58','Asignación Aplicación a Usuario - Agregar','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(199,4,NULL,'2025-09-23 22:36:53','Ingreso','192.168.1.102','LUCHCODEDEV',_binary ''),(200,4,NULL,'2025-09-23 22:37:16','Cierre de sesión','192.168.1.102','LUCHCODEDEV',_binary '\0'),(201,4,NULL,'2025-09-23 22:47:48','Ingreso','192.168.1.102','LUCHCODEDEV',_binary ''),(202,4,NULL,'2025-09-23 22:48:29','Cierre de sesión','192.168.1.102','LUCHCODEDEV',_binary '\0'),(203,7,NULL,'2025-09-23 22:48:37','Ingreso','192.168.1.102','LUCHCODEDEV',_binary ''),(204,7,NULL,'2025-09-23 22:55:48','Ingreso','192.168.1.102','LUCHCODEDEV',_binary ''),(205,7,1,'2025-09-23 22:56:09','Guardar usuario','192.168.1.102','LUCHCODEDEV',_binary ''),(206,7,NULL,'2025-09-23 22:56:11','Cierre de sesión','192.168.1.102','LUCHCODEDEV',_binary '\0'),(207,11,NULL,'2025-09-23 22:57:02','Ingreso','192.168.1.102','LUCHCODEDEV',_binary ''),(208,11,NULL,'2025-09-23 23:00:58','Ingreso','192.168.1.102','LUCHCODEDEV',_binary ''),(209,11,1,'2025-09-23 23:01:37','Guardar usuario','192.168.1.102','LUCHCODEDEV',_binary ''),(210,11,NULL,'2025-09-23 23:01:43','Cierre de sesión','192.168.1.102','LUCHCODEDEV',_binary '\0'),(211,12,NULL,'2025-09-23 23:01:56','Ingreso','192.168.1.102','LUCHCODEDEV',_binary ''),(212,11,NULL,'2025-09-23 23:13:08','Ingreso','192.168.1.102','LUCHCODEDEV',_binary ''),(213,11,4,'2025-09-23 23:13:33','Asignación Aplicación a Usuario - Agregar','192.168.1.102','LUCHCODEDEV',_binary ''),(214,11,4,'2025-09-23 23:13:38','Asignación Aplicación a Usuario - Insertar','192.168.1.102','LUCHCODEDEV',_binary ''),(215,11,NULL,'2025-09-23 23:14:34','Ingreso','192.168.1.102','LUCHCODEDEV',_binary ''),(216,11,NULL,'2025-09-23 23:14:38','Cierre de sesión','192.168.1.102','LUCHCODEDEV',_binary '\0'),(217,12,NULL,'2025-09-23 23:14:50','Ingreso','192.168.1.102','LUCHCODEDEV',_binary ''),(218,12,NULL,'2025-09-23 23:44:59','Ingreso','192.168.1.102','LUCHCODEDEV',_binary ''),(219,12,NULL,'2025-09-23 23:45:11','Cierre de sesión','192.168.1.102','LUCHCODEDEV',_binary '\0'),(220,7,NULL,'2025-09-24 00:12:57','Ingreso','192.168.1.102','LUCHCODEDEV',_binary ''),(221,7,NULL,'2025-09-24 00:14:07','Ingreso','192.168.1.102','LUCHCODEDEV',_binary ''),(222,7,NULL,'2025-09-24 00:14:16','Cierre de sesión','192.168.1.102','LUCHCODEDEV',_binary '\0'),(223,12,NULL,'2025-09-24 00:14:28','Ingreso','192.168.1.102','LUCHCODEDEV',_binary ''),(224,12,NULL,'2025-09-24 00:14:34','Cierre de sesión','192.168.1.102','LUCHCODEDEV',_binary '\0'),(225,7,NULL,'2025-09-24 00:16:04','Ingreso','192.168.1.102','LUCHCODEDEV',_binary ''),(226,7,NULL,'2025-09-24 00:16:17','Cierre de sesión','192.168.1.102','LUCHCODEDEV',_binary '\0'),(227,7,NULL,'2025-09-24 00:59:38','Ingreso','192.168.1.102','LUCHCODEDEV',_binary ''),(228,7,NULL,'2025-09-24 00:59:59','Cierre de sesión','192.168.1.102','LUCHCODEDEV',_binary '\0'),(229,12,NULL,'2025-09-24 01:00:18','Ingreso','192.168.1.102','LUCHCODEDEV',_binary ''),(230,12,NULL,'2025-09-24 01:04:42','Ingreso','192.168.1.102','LUCHCODEDEV',_binary ''),(231,12,NULL,'2025-09-24 01:04:53','Cierre de sesión','192.168.1.102','LUCHCODEDEV',_binary '\0'),(232,7,NULL,'2025-09-24 01:05:07','Ingreso','192.168.1.102','LUCHCODEDEV',_binary ''),(233,7,NULL,'2025-09-24 01:05:13','Cierre de sesión','192.168.1.102','LUCHCODEDEV',_binary '\0'),(234,7,NULL,'2025-09-24 01:06:01','Ingreso','192.168.1.102','LUCHCODEDEV',_binary ''),(235,7,NULL,'2025-09-24 01:06:09','Cierre de sesión','192.168.1.102','LUCHCODEDEV',_binary '\0'),(236,12,NULL,'2025-09-24 01:06:26','Ingreso','192.168.1.102','LUCHCODEDEV',_binary ''),(237,12,1,'2025-09-24 01:06:52','Asignación Aplicación a Usuario - Insertar','192.168.1.102','LUCHCODEDEV',_binary ''),(238,12,1,'2025-09-24 01:06:58','Asignación Aplicación a Usuario - Actualizar','192.168.1.102','LUCHCODEDEV',_binary ''),(239,12,NULL,'2025-09-24 01:07:02','Cierre de sesión','192.168.1.102','LUCHCODEDEV',_binary '\0'),(240,7,NULL,'2025-09-24 01:07:16','Ingreso','192.168.1.102','LUCHCODEDEV',_binary ''),(241,7,NULL,'2025-09-24 01:07:31','Cierre de sesión','192.168.1.102','LUCHCODEDEV',_binary '\0'),(242,12,NULL,'2025-09-24 01:07:46','Ingreso','192.168.1.102','LUCHCODEDEV',_binary ''),(243,12,1,'2025-09-24 01:08:14','Guardar usuario','192.168.1.102','LUCHCODEDEV',_binary ''),(244,12,NULL,'2025-09-24 01:08:18','Cierre de sesión','192.168.1.102','LUCHCODEDEV',_binary '\0'),(245,13,NULL,'2025-09-24 01:08:30','Ingreso','192.168.1.102','LUCHCODEDEV',_binary ''),(246,13,NULL,'2025-09-24 01:08:40','Cierre de sesión','192.168.1.102','LUCHCODEDEV',_binary '\0'),(247,13,NULL,'2025-09-24 01:09:08','Ingreso','192.168.1.102','LUCHCODEDEV',_binary ''),(248,13,NULL,'2025-09-24 01:09:13','Cierre de sesión','192.168.1.102','LUCHCODEDEV',_binary '\0'),(249,12,NULL,'2025-09-24 01:09:27','Ingreso','192.168.1.102','LUCHCODEDEV',_binary ''),(250,12,2,'2025-09-24 01:09:46','Asignación Aplicación a Usuario - Insertar','192.168.1.102','LUCHCODEDEV',_binary ''),(251,12,2,'2025-09-24 01:09:49','Asignación Aplicación a Usuario - Actualizar','192.168.1.102','LUCHCODEDEV',_binary ''),(252,12,NULL,'2025-09-24 01:09:53','Cierre de sesión','192.168.1.102','LUCHCODEDEV',_binary '\0'),(253,13,NULL,'2025-09-24 01:10:05','Ingreso','192.168.1.102','LUCHCODEDEV',_binary ''),(254,2,NULL,'2025-09-24 08:06:49','Ingreso','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(255,4,NULL,'2025-09-24 08:11:02','Ingreso','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(256,4,NULL,'2025-09-24 08:18:04','Ingreso','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(257,4,NULL,'2025-09-24 08:23:50','Ingreso','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(258,4,NULL,'2025-09-24 08:25:45','Ingreso','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(259,4,NULL,'2025-09-24 08:31:49','Ingreso','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(260,4,NULL,'2025-09-24 08:36:12','Ingreso','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(261,2,NULL,'2025-09-24 08:36:58','Ingreso','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(262,4,NULL,'2025-09-24 10:28:10','Ingreso','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(263,4,1,'2025-09-24 10:29:34','Asignación Aplicación a Usuario - Agregar','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(264,4,1,'2025-09-24 10:29:53','Asignación Aplicación a Usuario - Insertar','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(265,10,NULL,'2025-09-24 10:30:36','Ingreso','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(266,10,NULL,'2025-09-24 10:41:53','Ingreso','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(267,4,NULL,'2025-09-24 10:43:45','Ingreso','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(268,4,2,'2025-09-24 10:50:05','Asignación Aplicación a Usuario - Agregar','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(269,4,2,'2025-09-24 10:50:36','Asignación Aplicación a Usuario - Insertar','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(270,10,NULL,'2025-09-24 10:51:49','Ingreso','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(271,10,NULL,'2025-09-24 10:54:04','Ingreso','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(272,10,NULL,'2025-09-24 11:23:05','Ingreso','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(273,10,NULL,'2025-09-24 11:28:48','Ingreso','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(274,10,NULL,'2025-09-24 11:36:49','Ingreso','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(275,10,NULL,'2025-09-24 11:37:22','Cierre de sesión','192.168.56.1','DESKTOP-6VKCMBO',_binary '\0'),(276,4,NULL,'2025-09-24 11:38:11','Ingreso','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(277,4,NULL,'2025-09-24 12:07:07','Ingreso','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(278,4,NULL,'2025-09-24 12:11:31','Ingreso','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(279,4,NULL,'2025-09-24 12:19:35','Ingreso','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(280,4,NULL,'2025-09-24 12:25:50','Ingreso','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(281,4,NULL,'2025-09-24 12:29:24','Ingreso','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(282,4,NULL,'2025-09-24 12:38:54','Ingreso','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(283,4,NULL,'2025-09-24 12:46:14','Ingreso','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(284,2,NULL,'2025-09-24 16:08:20','Ingreso','192.168.137.1','COMPU_CESAR',_binary ''),(285,2,NULL,'2025-09-24 16:10:55','Cierre de sesión','192.168.137.1','COMPU_CESAR',_binary '\0'),(286,4,NULL,'2025-09-24 16:11:25','Ingreso','192.168.137.1','COMPU_CESAR',_binary ''),(287,4,NULL,'2025-09-24 16:14:42','Cierre de sesión','192.168.137.1','COMPU_CESAR',_binary '\0'),(288,12,NULL,'2025-09-24 16:49:00','Ingreso','192.168.1.102','LUCHCODEDEV',_binary ''),(289,4,NULL,'2025-09-24 17:29:03','Ingreso','192.168.137.1','COMPU_CESAR',_binary ''),(290,12,NULL,'2025-09-24 17:29:14','Ingreso','192.168.1.102','LUCHCODEDEV',_binary ''),(291,4,1,'2025-09-24 17:30:06','Modificar aplicación','192.168.137.1','COMPU_CESAR',_binary ''),(292,12,NULL,'2025-09-24 17:34:49','Ingreso','192.168.1.102','LUCHCODEDEV',_binary ''),(293,12,NULL,'2025-09-24 17:35:10','Cierre de sesión','192.168.1.102','LUCHCODEDEV',_binary '\0'),(294,4,NULL,'2025-09-24 17:35:30','Ingreso','192.168.137.1','COMPU_CESAR',_binary ''),(295,7,NULL,'2025-09-24 17:35:34','Ingreso','192.168.1.102','LUCHCODEDEV',_binary ''),(296,7,NULL,'2025-09-24 17:35:42','Cierre de sesión','192.168.1.102','LUCHCODEDEV',_binary '\0'),(297,4,NULL,'2025-09-24 17:35:55','Ingreso','192.168.1.102','LUCHCODEDEV',_binary ''),(298,4,NULL,'2025-09-24 17:36:02','Cierre de sesión','192.168.1.102','LUCHCODEDEV',_binary '\0'),(299,7,NULL,'2025-09-24 17:36:15','Ingreso','192.168.1.102','LUCHCODEDEV',_binary ''),(300,4,1,'2025-09-24 17:37:44','Eliminar aplicación','192.168.137.1','COMPU_CESAR',_binary ''),(301,7,NULL,'2025-09-24 17:38:23','Cierre de sesión','192.168.1.102','LUCHCODEDEV',_binary '\0'),(302,4,NULL,'2025-09-24 17:38:35','Ingreso','192.168.1.102','LUCHCODEDEV',_binary ''),(303,4,NULL,'2025-09-24 17:39:42','Ingreso','192.168.1.102','LUCHCODEDEV',_binary ''),(304,4,1,'2025-09-24 17:40:06','Asignación Aplicación a Usuario - Agregar','192.168.1.102','LUCHCODEDEV',_binary ''),(305,4,1,'2025-09-24 17:40:16','Asignación Aplicación a Usuario - Insertar','192.168.1.102','LUCHCODEDEV',_binary ''),(306,4,1,'2025-09-24 17:40:30','Asignación Aplicación a Usuario - Actualizar','192.168.1.102','LUCHCODEDEV',_binary ''),(307,4,4,'2025-09-24 17:40:32','Asignación Aplicación a Usuario - Actualizar','192.168.1.102','LUCHCODEDEV',_binary ''),(308,4,1,'2025-09-24 17:40:53','Asignación Aplicación a Usuario - Actualizar','192.168.1.102','LUCHCODEDEV',_binary ''),(309,4,4,'2025-09-24 17:40:55','Asignación Aplicación a Usuario - Actualizar','192.168.1.102','LUCHCODEDEV',_binary ''),(310,4,NULL,'2025-09-24 17:41:05','Cierre de sesión','192.168.1.102','LUCHCODEDEV',_binary '\0'),(311,12,NULL,'2025-09-24 17:42:03','Ingreso','192.168.1.102','LUCHCODEDEV',_binary ''),(312,4,NULL,'2025-09-24 17:45:13','Ingreso','192.168.1.102','LUCHCODEDEV',_binary ''),(313,4,NULL,'2025-09-24 17:45:25','Cierre de sesión','192.168.1.102','LUCHCODEDEV',_binary '\0'),(314,4,NULL,'2025-09-24 17:45:56','Ingreso','192.168.1.102','LUCHCODEDEV',_binary ''),(315,4,NULL,'2025-09-24 17:54:39','Ingreso','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(316,4,4,'2025-09-24 17:55:21','Asignación Aplicación a Usuario - Agregar','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(317,4,4,'2025-09-24 17:55:38','Asignación Aplicación a Usuario - Insertar','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(318,10,NULL,'2025-09-24 17:56:12','Ingreso','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(319,10,NULL,'2025-09-24 17:57:13','Ingreso','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(320,10,NULL,'2025-09-24 18:02:36','Ingreso','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(321,4,NULL,'2025-09-24 18:03:25','Ingreso','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(322,12,NULL,'2025-09-24 18:27:00','Ingreso','192.168.1.102','LUCHCODEDEV',_binary ''),(323,12,NULL,'2025-09-24 18:30:11','Ingreso','192.168.1.102','LUCHCODEDEV',_binary ''),(324,12,NULL,'2025-09-24 18:31:09','Cierre de sesión','192.168.1.102','LUCHCODEDEV',_binary '\0'),(325,4,NULL,'2025-09-24 18:31:20','Ingreso','192.168.1.102','LUCHCODEDEV',_binary ''),(326,4,NULL,'2025-09-24 18:31:56','Cierre de sesión','192.168.1.102','LUCHCODEDEV',_binary '\0'),(327,12,NULL,'2025-09-24 18:32:08','Ingreso','192.168.1.102','LUCHCODEDEV',_binary ''),(328,12,4,'2025-09-24 18:32:28','Asignación Aplicación a Usuario - Agregar','192.168.1.102','LUCHCODEDEV',_binary ''),(329,12,4,'2025-09-24 18:32:37','Asignación Aplicación a Usuario - Insertar','192.168.1.102','LUCHCODEDEV',_binary ''),(330,12,NULL,'2025-09-24 18:32:51','Cierre de sesión','192.168.1.102','LUCHCODEDEV',_binary '\0'),(331,4,NULL,'2025-09-24 18:33:03','Ingreso','192.168.1.102','LUCHCODEDEV',_binary ''),(332,12,NULL,'2025-09-24 18:34:28','Ingreso','192.168.1.102','LUCHCODEDEV',_binary ''),(333,12,1,'2025-09-24 18:34:51','Asignación Aplicación a Usuario - Quitar','192.168.1.102','LUCHCODEDEV',_binary ''),(334,12,4,'2025-09-24 18:34:52','Asignación Aplicación a Usuario - Quitar','192.168.1.102','LUCHCODEDEV',_binary ''),(335,12,1,'2025-09-24 18:35:16','Asignación Aplicación a Usuario - Quitar','192.168.1.102','LUCHCODEDEV',_binary ''),(336,12,4,'2025-09-24 18:35:17','Asignación Aplicación a Usuario - Quitar','192.168.1.102','LUCHCODEDEV',_binary ''),(337,12,1,'2025-09-24 18:35:49','Asignación Aplicación a Usuario - Quitar','192.168.1.102','LUCHCODEDEV',_binary ''),(338,12,4,'2025-09-24 18:35:51','Asignación Aplicación a Usuario - Quitar','192.168.1.102','LUCHCODEDEV',_binary ''),(339,12,NULL,'2025-09-24 18:36:08','Cierre de sesión','192.168.1.102','LUCHCODEDEV',_binary '\0'),(340,4,NULL,'2025-09-24 18:36:18','Ingreso','192.168.1.102','LUCHCODEDEV',_binary ''),(341,4,1,'2025-09-24 18:36:36','Asignación Aplicación a Usuario - Quitar','192.168.1.102','LUCHCODEDEV',_binary ''),(342,4,4,'2025-09-24 18:36:37','Asignación Aplicación a Usuario - Quitar','192.168.1.102','LUCHCODEDEV',_binary ''),(343,4,4,'2025-09-24 18:36:56','Asignación Aplicación a Usuario - Agregar','192.168.1.102','LUCHCODEDEV',_binary ''),(344,4,4,'2025-09-24 18:37:06','Asignación Aplicación a Usuario - Actualizar','192.168.1.102','LUCHCODEDEV',_binary ''),(345,4,NULL,'2025-09-24 18:44:11','Ingreso','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(346,4,1,'2025-09-24 18:45:02','Guardar usuario','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(347,14,NULL,'2025-09-24 18:46:02','Ingreso','192.168.1.102','LUCHCODEDEV',_binary ''),(348,14,NULL,'2025-09-24 18:46:15','Cierre de sesión','192.168.1.102','LUCHCODEDEV',_binary '\0'),(349,4,NULL,'2025-09-24 18:48:43','Ingreso','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(350,4,4,'2025-09-24 18:49:13','Asignación Aplicación a Usuario - Agregar','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(351,14,NULL,'2025-09-24 18:49:24','Cierre de sesión','192.168.1.102','LUCHCODEDEV',_binary '\0'),(352,4,4,'2025-09-24 18:49:35','Asignación Aplicación a Usuario - Insertar','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(353,14,NULL,'2025-09-24 18:49:43','Ingreso','192.168.1.102','LUCHCODEDEV',_binary ''),(354,4,2,'2025-09-24 18:50:47','Asignación Aplicación a Usuario - Agregar','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(355,4,2,'2025-09-24 18:50:55','Asignación Aplicación a Usuario - Quitar','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(356,4,4,'2025-09-24 18:51:03','Asignación Aplicación a Usuario - Agregar','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(357,14,NULL,'2025-09-24 18:51:12','Cierre de sesión','192.168.1.102','LUCHCODEDEV',_binary '\0'),(358,4,4,'2025-09-24 18:51:28','Asignación Aplicación a Usuario - Agregar','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(359,11,NULL,'2025-09-24 18:51:32','Ingreso','192.168.1.102','LUCHCODEDEV',_binary ''),(360,4,4,'2025-09-24 18:52:09','Asignación Aplicación a Usuario - Agregar','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(361,4,4,'2025-09-24 18:52:53','Asignación Aplicación a Usuario - Actualizar','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(362,4,4,'2025-09-24 18:52:55','Asignación Aplicación a Usuario - Actualizar','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(363,4,4,'2025-09-24 18:52:57','Asignación Aplicación a Usuario - Insertar','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(364,11,NULL,'2025-09-24 18:53:08','Cierre de sesión','192.168.1.102','LUCHCODEDEV',_binary '\0'),(365,11,NULL,'2025-09-24 18:53:21','Ingreso','192.168.1.102','LUCHCODEDEV',_binary ''),(366,2,NULL,'2025-09-24 19:15:58','Ingreso','192.168.1.4','LAPTOP-6C415UB3',_binary ''),(367,1,NULL,'2025-09-24 20:54:06','Recuperar contraseña','192.168.1.7','RICARDO',_binary ''),(368,1,NULL,'2025-09-24 20:54:17','Ingreso','192.168.1.7','RICARDO',_binary ''),(369,1,NULL,'2025-09-24 20:54:37','Cierre de sesión','192.168.1.7','RICARDO',_binary '\0'),(370,2,NULL,'2025-09-24 20:56:01','Ingreso','192.168.1.7','RICARDO',_binary ''),(371,2,NULL,'2025-09-24 21:00:45','Ingreso','192.168.1.7','RICARDO',_binary ''),(372,2,NULL,'2025-09-24 21:01:27','Cierre de sesión','192.168.1.7','RICARDO',_binary '\0'),(373,4,NULL,'2025-09-24 21:02:07','Ingreso','192.168.1.7','RICARDO',_binary ''),(374,4,NULL,'2025-09-24 21:05:43','Ingreso','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(375,4,4,'2025-09-24 21:06:40','Asignación Aplicación a Usuario - Agregar','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(376,4,4,'2025-09-24 21:06:57','Asignación Aplicación a Usuario - Actualizar','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(377,4,1,'2025-09-24 21:11:39','Modificar aplicación','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(378,4,5,'2025-09-24 21:12:17','Asignación Aplicación a Usuario - Agregar','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(379,4,4,'2025-09-24 21:12:48','Asignación Aplicación a Usuario - Agregar','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(380,4,4,'2025-09-24 21:14:02','Asignación Aplicación a Usuario - Quitar','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(381,4,2,'2025-09-24 21:14:12','Asignación Aplicación a Usuario - Agregar','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(382,4,5,'2025-09-24 21:14:21','Asignación Aplicación a Usuario - Insertar','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(383,4,2,'2025-09-24 21:14:25','Asignación Aplicación a Usuario - Insertar','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(384,12,NULL,'2025-09-24 21:16:02','Ingreso','192.168.1.102','LUCHCODEDEV',_binary ''),(385,4,NULL,'2025-09-24 21:16:16','Ingreso','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(386,4,4,'2025-09-24 21:18:08','Asignación Aplicación a Usuario - Agregar','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(387,4,4,'2025-09-24 21:18:22','Asignación Aplicación a Usuario - Insertar','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(388,12,NULL,'2025-09-24 21:18:35','Cierre de sesión','192.168.1.102','LUCHCODEDEV',_binary '\0'),(389,12,NULL,'2025-09-24 21:18:49','Ingreso','192.168.1.102','LUCHCODEDEV',_binary ''),(390,4,NULL,'2025-09-24 21:19:06','Ingreso','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(391,4,5,'2025-09-24 21:20:29','Asignación Aplicación a Usuario - Agregar','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(392,4,5,'2025-09-24 21:20:41','Asignación Aplicación a Usuario - Insertar','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(393,4,NULL,'2025-09-24 21:26:42','Ingreso','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(394,4,NULL,'2025-09-24 21:26:49','Ingreso','192.168.0.19','DOMITS',_binary ''),(395,4,NULL,'2025-09-24 21:27:26','Cierre de sesión','192.168.56.1','DESKTOP-01DDSQ2',_binary '\0'),(396,14,NULL,'2025-09-24 21:27:37','Ingreso','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(397,4,NULL,'2025-09-24 21:29:27','Ingreso','192.168.0.19','DOMITS',_binary ''),(398,4,1,'2025-09-24 21:30:04','Guardar módulo','192.168.0.19','DOMITS',_binary ''),(399,4,NULL,'2025-09-24 21:38:23','Ingreso','192.168.0.19','DOMITS',_binary ''),(400,4,1,'2025-09-24 21:38:48','Eliminar módulo','192.168.0.19','DOMITS',_binary ''),(401,4,NULL,'2025-09-24 21:42:36','Ingreso','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(402,4,1,'2025-09-24 21:45:03','Modificar aplicación','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(403,4,6,'2025-09-24 21:45:32','Asignación Aplicación a Usuario - Agregar','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(404,4,6,'2025-09-24 21:45:52','Asignación Aplicación a Usuario - Insertar','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(405,4,6,'2025-09-24 21:46:04','Asignación Aplicación a Usuario - Agregar','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(406,4,1,'2025-09-24 21:46:47','Asignación Aplicación a Usuario - Quitar','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(407,4,2,'2025-09-24 21:46:48','Asignación Aplicación a Usuario - Quitar','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(408,4,4,'2025-09-24 21:46:50','Asignación Aplicación a Usuario - Quitar','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(409,4,5,'2025-09-24 21:46:51','Asignación Aplicación a Usuario - Quitar','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(410,4,4,'2025-09-24 21:46:52','Asignación Aplicación a Usuario - Quitar','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(411,4,6,'2025-09-24 21:47:00','Asignación Aplicación a Usuario - Agregar','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(412,4,6,'2025-09-24 21:47:14','Asignación Aplicación a Usuario - Insertar','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(413,4,1,'2025-09-24 21:48:20','Guardar módulo','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(414,4,1,'2025-09-24 21:48:25','Eliminar módulo','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(415,4,NULL,'2025-09-24 21:57:23','Ingreso','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(416,4,1,'2025-09-24 21:58:03','Guardar usuario','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(417,4,NULL,'2025-09-24 21:58:08','Cierre de sesión','192.168.56.1','DESKTOP-01DDSQ2',_binary '\0'),(418,15,NULL,'2025-09-24 21:58:22','Ingreso','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(419,15,NULL,'2025-09-24 21:58:44','Cierre de sesión','192.168.56.1','DESKTOP-01DDSQ2',_binary '\0'),(420,12,NULL,'2025-09-24 21:59:01','Ingreso','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(421,12,1,'2025-09-24 22:00:07','Asignación Aplicación a Usuario - Agregar','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(422,12,1,'2025-09-24 22:00:15','Asignación Aplicación a Usuario - Insertar','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(423,12,NULL,'2025-09-24 22:00:24','Cierre de sesión','192.168.56.1','DESKTOP-01DDSQ2',_binary '\0'),(424,15,NULL,'2025-09-24 22:00:41','Ingreso','192.168.56.1','DESKTOP-01DDSQ2',_binary ''),(425,4,NULL,'2025-09-24 22:31:07','Ingreso','192.168.1.7','RICARDO',_binary ''),(426,4,NULL,'2025-09-24 22:32:05','Cierre de sesión','192.168.1.7','RICARDO',_binary '\0'),(427,4,NULL,'2025-09-24 22:45:50','Ingreso','192.168.0.19','DOMITS',_binary ''),(428,4,1,'2025-09-24 22:46:23','Guardar módulo','192.168.0.19','DOMITS',_binary ''),(429,4,1,'2025-09-24 22:46:31','Guardar módulo','192.168.0.19','DOMITS',_binary ''),(430,4,NULL,'2025-09-24 23:01:03','Ingreso','192.168.0.19','DOMITS',_binary ''),(431,4,1,'2025-09-24 23:01:38','Guardar módulo','192.168.0.19','DOMITS',_binary ''),(432,4,1,'2025-09-24 23:01:51','Eliminar módulo','192.168.0.19','DOMITS',_binary ''),(433,4,NULL,'2025-09-24 23:05:06','Ingreso','192.168.0.19','DOMITS',_binary ''),(434,4,1,'2025-09-24 23:05:46','Guardar módulo','192.168.0.19','DOMITS',_binary ''),(435,4,1,'2025-09-24 23:06:01','Eliminar módulo','192.168.0.19','DOMITS',_binary ''),(436,4,1,'2025-09-24 23:06:19','Guardar módulo','192.168.0.19','DOMITS',_binary ''),(437,4,1,'2025-09-24 23:06:38','Eliminar módulo','192.168.0.19','DOMITS',_binary ''),(438,4,NULL,'2025-09-24 23:12:02','Ingreso','192.168.0.19','DOMITS',_binary ''),(439,4,NULL,'2025-09-25 06:59:50','Ingreso','192.168.137.1','COMPU_CESAR',_binary ''),(440,4,NULL,'2025-09-25 07:00:58','Cierre de sesión','192.168.137.1','COMPU_CESAR',_binary '\0'),(441,4,NULL,'2025-09-25 07:05:17','Ingreso','192.168.137.1','COMPU_CESAR',_binary ''),(442,4,NULL,'2025-09-25 07:06:10','Cierre de sesión','192.168.137.1','COMPU_CESAR',_binary '\0'),(443,2,NULL,'2025-09-25 07:06:31','Ingreso','192.168.137.1','COMPU_CESAR',_binary ''),(444,2,NULL,'2025-09-25 07:09:29','Cierre de sesión','192.168.137.1','COMPU_CESAR',_binary '\0'),(445,5,NULL,'2025-09-25 07:12:06','Ingreso','172.20.10.3','BELY',_binary ''),(446,12,NULL,'2025-09-25 07:28:50','Ingreso','192.168.133.128','DAVID',_binary ''),(447,12,1,'2025-09-25 07:30:10','Guardar usuario','192.168.133.128','DAVID',_binary ''),(448,12,NULL,'2025-09-25 07:30:26','Cierre de sesión','192.168.133.128','DAVID',_binary '\0'),(449,16,NULL,'2025-09-25 07:30:48','Ingreso','192.168.133.128','DAVID',_binary ''),(450,16,NULL,'2025-09-25 07:30:59','Cierre de sesión','192.168.133.128','DAVID',_binary '\0'),(451,12,NULL,'2025-09-25 07:31:47','Ingreso','192.168.133.128','DAVID',_binary ''),(452,12,4,'2025-09-25 07:32:29','Asignación Aplicación a Usuario - Agregar','192.168.133.128','DAVID',_binary ''),(453,12,NULL,'2025-09-25 07:33:18','Cierre de sesión','192.168.133.128','DAVID',_binary '\0'),(454,16,NULL,'2025-09-25 07:33:36','Ingreso','192.168.133.128','DAVID',_binary ''),(455,12,NULL,'2025-09-25 07:34:28','Ingreso','192.168.150.99','LAPTOP-6C415UB3',_binary ''),(456,16,NULL,'2025-09-25 07:35:39','Cierre de sesión','192.168.133.128','DAVID',_binary '\0'),(457,16,NULL,'2025-09-25 07:37:19','Ingreso','192.168.133.128','DAVID',_binary ''),(458,16,NULL,'2025-09-25 07:37:34','Cierre de sesión','192.168.133.128','DAVID',_binary '\0'),(459,4,NULL,'2025-09-25 07:38:04','Ingreso','192.168.133.128','DAVID',_binary ''),(460,4,1,'2025-09-25 07:38:37','Asignación Aplicación a Usuario - Agregar','192.168.133.128','DAVID',_binary ''),(461,4,1,'2025-09-25 07:38:41','Asignación Aplicación a Usuario - Insertar','192.168.133.128','DAVID',_binary ''),(462,4,NULL,'2025-09-25 07:38:48','Cierre de sesión','192.168.133.128','DAVID',_binary '\0'),(463,16,NULL,'2025-09-25 07:39:15','Ingreso','192.168.133.128','DAVID',_binary ''),(464,4,NULL,'2025-09-25 07:40:55','Ingreso','192.168.178.223','DOMITS',_binary ''),(465,16,NULL,'2025-09-25 07:41:16','Cierre de sesión','192.168.133.128','DAVID',_binary '\0'),(466,12,NULL,'2025-09-25 07:41:56','Ingreso','192.168.133.128','DAVID',_binary ''),(467,12,NULL,'2025-09-25 07:42:30','Ingreso','192.168.140.58','RICARDO',_binary ''),(468,12,4,'2025-09-25 07:42:37','Asignación Aplicación a Usuario - Agregar','192.168.133.128','DAVID',_binary ''),(469,12,4,'2025-09-25 07:42:42','Asignación Aplicación a Usuario - Insertar','192.168.133.128','DAVID',_binary ''),(470,12,6,'2025-09-25 07:43:08','Asignación Aplicación a Usuario - Agregar','192.168.133.128','DAVID',_binary ''),(471,12,6,'2025-09-25 07:43:36','Asignación Aplicación a Usuario - Insertar','192.168.133.128','DAVID',_binary ''),(472,12,NULL,'2025-09-25 07:43:45','Cierre de sesión','192.168.133.128','DAVID',_binary '\0'),(473,12,NULL,'2025-09-25 07:43:55','Cierre de sesión','192.168.133.128','DAVID',_binary '\0'),(474,12,NULL,'2025-09-25 07:44:07','Cierre de sesión','192.168.140.58','RICARDO',_binary '\0'),(475,16,NULL,'2025-09-25 07:44:13','Ingreso','192.168.133.128','DAVID',_binary ''),(476,16,NULL,'2025-09-25 07:44:46','Cierre de sesión','192.168.133.128','DAVID',_binary '\0'),(477,12,NULL,'2025-09-25 07:45:27','Ingreso','192.168.133.128','DAVID',_binary ''),(478,12,3,'2025-09-25 07:46:18','Asignación Aplicación a Usuario - Agregar','192.168.133.128','DAVID',_binary ''),(479,12,3,'2025-09-25 07:46:23','Asignación Aplicación a Usuario - Insertar','192.168.133.128','DAVID',_binary ''),(480,12,4,'2025-09-25 07:46:43','Asignación Aplicación a Usuario - Agregar','192.168.133.128','DAVID',_binary ''),(481,12,4,'2025-09-25 07:46:56','Asignación Aplicación a Usuario - Actualizar','192.168.133.128','DAVID',_binary ''),(482,12,NULL,'2025-09-25 07:47:05','Cierre de sesión','192.168.133.128','DAVID',_binary '\0'),(483,4,NULL,'2025-09-25 07:47:04','Ingreso','192.168.178.223','DOMITS',_binary ''),(484,16,NULL,'2025-09-25 07:47:27','Ingreso','192.168.133.128','DAVID',_binary ''),(485,4,1,'2025-09-25 07:54:26','Guardar módulo','192.168.178.223','DOMITS',_binary ''),(486,4,1,'2025-09-25 07:54:55','Guardar módulo','192.168.178.223','DOMITS',_binary ''),(487,12,NULL,'2025-09-25 07:55:54','Ingreso','192.168.150.99','LAPTOP-6C415UB3',_binary ''),(488,12,NULL,'2025-09-25 07:56:17','Cierre de sesión','192.168.150.99','LAPTOP-6C415UB3',_binary '\0'),(489,4,1,'2025-09-25 07:56:59','Guardar módulo','192.168.178.223','DOMITS',_binary ''),(490,12,NULL,'2025-09-25 07:57:20','Ingreso','192.168.151.174','LUCHCODEDEV',_binary ''),(491,12,1,'2025-09-25 07:58:17','Guardar usuario','192.168.151.174','LUCHCODEDEV',_binary ''),(492,12,NULL,'2025-09-25 07:58:23','Cierre de sesión','192.168.151.174','LUCHCODEDEV',_binary '\0'),(493,17,NULL,'2025-09-25 07:58:48','Ingreso','192.168.151.174','LUCHCODEDEV',_binary ''),(494,17,NULL,'2025-09-25 07:59:08','Cierre de sesión','192.168.151.174','LUCHCODEDEV',_binary '\0'),(495,16,4,'2025-09-25 07:59:25','Guardar empleado','192.168.133.128','DAVID',_binary ''),(496,12,NULL,'2025-09-25 07:59:29','Ingreso','192.168.151.174','LUCHCODEDEV',_binary ''),(497,16,4,'2025-09-25 07:59:44','Eliminar empleado','192.168.133.128','DAVID',_binary ''),(498,12,4,'2025-09-25 08:00:17','Asignación Aplicación a Usuario - Agregar','192.168.151.174','LUCHCODEDEV',_binary ''),(499,12,4,'2025-09-25 08:00:24','Asignación Aplicación a Usuario - Insertar','192.168.151.174','LUCHCODEDEV',_binary ''),(500,12,NULL,'2025-09-25 08:00:31','Cierre de sesión','192.168.151.174','LUCHCODEDEV',_binary '\0'),(501,17,NULL,'2025-09-25 08:00:55','Ingreso','192.168.151.174','LUCHCODEDEV',_binary ''),(502,17,NULL,'2025-09-25 08:02:06','Cierre de sesión','192.168.151.174','LUCHCODEDEV',_binary '\0'),(503,12,NULL,'2025-09-25 08:02:31','Ingreso','192.168.151.174','LUCHCODEDEV',_binary ''),(504,12,NULL,'2025-09-25 08:03:36','Ingreso','192.168.150.99','LAPTOP-6C415UB3',_binary ''),(505,12,4,'2025-09-25 08:04:07','Asignación Aplicación a Usuario - Agregar','192.168.151.174','LUCHCODEDEV',_binary ''),(506,12,4,'2025-09-25 08:06:51','Asignación Aplicación a Usuario - Insertar','192.168.151.174','LUCHCODEDEV',_binary ''),(507,12,NULL,'2025-09-25 08:06:58','Cierre de sesión','192.168.151.174','LUCHCODEDEV',_binary '\0'),(508,12,NULL,'2025-09-25 08:07:51','Cierre de sesión','192.168.150.99','LAPTOP-6C415UB3',_binary '\0'),(509,17,NULL,'2025-09-25 08:08:36','Ingreso','10.38.176.1','LUCHCODEDEV',_binary ''),(510,17,NULL,'2025-09-25 08:11:21','Cierre de sesión','10.38.176.1','LUCHCODEDEV',_binary '\0'),(511,12,NULL,'2025-09-25 08:11:59','Ingreso','10.38.176.1','LUCHCODEDEV',_binary ''),(512,12,4,'2025-09-25 08:16:03','Asignación Aplicación a Usuario - Actualizar','10.38.176.1','LUCHCODEDEV',_binary ''),(513,12,4,'2025-09-25 08:16:08','Asignación Aplicación a Usuario - Actualizar','10.38.176.1','LUCHCODEDEV',_binary ''),(514,12,NULL,'2025-09-25 08:18:12','Cierre de sesión','10.38.176.1','LUCHCODEDEV',_binary '\0'),(515,4,NULL,'2025-09-25 08:18:26','Ingreso','192.168.178.223','DOMITS',_binary ''),(516,17,NULL,'2025-09-25 08:18:55','Ingreso','10.38.176.1','LUCHCODEDEV',_binary ''),(517,17,NULL,'2025-09-25 08:19:49','Cierre de sesión','10.38.176.1','LUCHCODEDEV',_binary '\0'),(518,12,NULL,'2025-09-25 08:20:11','Ingreso','10.38.176.1','LUCHCODEDEV',_binary ''),(519,4,NULL,'2025-09-25 08:20:39','Ingreso','192.168.178.223','DOMITS',_binary ''),(520,12,4,'2025-09-25 08:20:43','Asignación Aplicación a Usuario - Agregar','10.38.176.1','LUCHCODEDEV',_binary ''),(521,12,4,'2025-09-25 08:21:00','Asignación Aplicación a Usuario - Actualizar','10.38.176.1','LUCHCODEDEV',_binary ''),(522,12,NULL,'2025-09-25 08:21:10','Cierre de sesión','10.38.176.1','LUCHCODEDEV',_binary '\0'),(523,17,NULL,'2025-09-25 08:21:42','Ingreso','10.38.176.1','LUCHCODEDEV',_binary ''),(524,17,NULL,'2025-09-25 08:23:23','Cierre de sesión','10.38.176.1','LUCHCODEDEV',_binary '\0'),(525,16,NULL,'2025-09-25 08:24:03','Ingreso','192.168.133.128','DAVID',_binary ''),(526,12,NULL,'2025-09-25 08:24:30','Ingreso','10.38.176.1','LUCHCODEDEV',_binary ''),(527,12,NULL,'2025-09-25 08:24:57','Ingreso','10.38.176.1','LUCHCODEDEV',_binary ''),(528,12,NULL,'2025-09-25 08:27:15','Cierre de sesión','10.38.176.1','LUCHCODEDEV',_binary '\0'),(529,4,NULL,'2025-09-25 08:28:06','Ingreso','192.168.178.223','DOMITS',_binary ''),(530,2,NULL,'2025-09-25 08:28:38','Ingreso','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(531,4,NULL,'2025-09-25 08:28:54','Ingreso','192.168.178.223','DOMITS',_binary ''),(532,4,NULL,'2025-09-25 08:29:37','Ingreso','192.168.140.58','RICARDO',_binary ''),(533,4,NULL,'2025-09-25 08:29:53','Ingreso','192.168.178.223','DOMITS',_binary ''),(534,4,NULL,'2025-09-25 08:31:51','Ingreso','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(535,4,5,'2025-09-25 08:32:37','Asignación Aplicación a Usuario - Agregar','192.168.140.58','RICARDO',_binary ''),(536,4,2,'2025-09-25 08:33:04','Asignación Aplicación a Usuario - Agregar','192.168.140.58','RICARDO',_binary ''),(537,4,6,'2025-09-25 08:33:23','Asignación Aplicación a Usuario - Agregar','192.168.140.58','RICARDO',_binary ''),(538,4,5,'2025-09-25 08:34:02','Asignación Aplicación a Usuario - Insertar','192.168.140.58','RICARDO',_binary ''),(539,4,2,'2025-09-25 08:34:04','Asignación Aplicación a Usuario - Insertar','192.168.140.58','RICARDO',_binary ''),(540,4,6,'2025-09-25 08:34:07','Asignación Aplicación a Usuario - Insertar','192.168.140.58','RICARDO',_binary ''),(541,12,NULL,'2025-09-25 08:34:58','Ingreso','192.168.150.99','LAPTOP-6C415UB3',_binary ''),(542,12,1,'2025-09-25 08:36:13','Guardar usuario','192.168.150.99','LAPTOP-6C415UB3',_binary ''),(543,12,NULL,'2025-09-25 08:36:16','Cierre de sesión','192.168.150.99','LAPTOP-6C415UB3',_binary '\0'),(544,1,NULL,'2025-09-25 08:37:07','Recuperar contraseña','192.168.150.99','LAPTOP-6C415UB3',_binary ''),(545,1,NULL,'2025-09-25 08:37:17','Ingreso','192.168.150.99','LAPTOP-6C415UB3',_binary ''),(546,4,NULL,'2025-09-25 08:46:36','Ingreso','192.168.178.223','DOMITS',_binary ''),(547,4,NULL,'2025-09-25 08:53:38','Ingreso','192.168.178.223','DOMITS',_binary ''),(548,4,NULL,'2025-09-25 10:28:35','Ingreso','192.168.140.58','RICARDO',_binary ''),(549,4,NULL,'2025-09-25 10:28:52','Cierre de sesión','192.168.140.58','RICARDO',_binary '\0'),(550,4,NULL,'2025-09-25 10:29:20','Ingreso','192.168.140.58','RICARDO',_binary ''),(551,4,1,'2025-09-25 10:30:23','Guardar usuario','192.168.140.58','RICARDO',_binary ''),(552,4,NULL,'2025-09-25 10:30:31','Cierre de sesión','192.168.140.58','RICARDO',_binary '\0'),(553,19,NULL,'2025-09-25 10:31:05','Ingreso','192.168.140.58','RICARDO',_binary ''),(554,19,NULL,'2025-09-25 10:31:20','Cierre de sesión','192.168.140.58','RICARDO',_binary '\0'),(555,4,NULL,'2025-09-25 10:31:44','Ingreso','192.168.140.58','RICARDO',_binary ''),(556,4,5,'2025-09-25 10:32:21','Asignación Aplicación a Usuario - Agregar','192.168.140.58','RICARDO',_binary ''),(557,4,5,'2025-09-25 10:32:49','Asignación Aplicación a Usuario - Insertar','192.168.140.58','RICARDO',_binary ''),(558,4,NULL,'2025-09-25 10:32:58','Cierre de sesión','192.168.140.58','RICARDO',_binary '\0'),(559,19,NULL,'2025-09-25 10:33:23','Ingreso','192.168.140.58','RICARDO',_binary ''),(560,19,NULL,'2025-09-25 10:36:00','Cierre de sesión','192.168.140.58','RICARDO',_binary '\0'),(561,4,NULL,'2025-09-25 10:36:44','Ingreso','192.168.140.58','RICARDO',_binary ''),(562,4,1,'2025-09-25 10:37:22','Guardar usuario','192.168.140.58','RICARDO',_binary ''),(563,4,4,'2025-09-25 10:38:19','Asignación Aplicación a Usuario - Agregar','192.168.140.58','RICARDO',_binary ''),(564,4,4,'2025-09-25 10:38:33','Asignación Aplicación a Usuario - Insertar','192.168.140.58','RICARDO',_binary ''),(565,4,NULL,'2025-09-25 10:38:45','Cierre de sesión','192.168.140.58','RICARDO',_binary '\0'),(566,20,NULL,'2025-09-25 10:39:30','Ingreso','192.168.140.58','RICARDO',_binary ''),(567,20,NULL,'2025-09-25 10:39:59','Cierre de sesión','192.168.140.58','RICARDO',_binary '\0'),(568,16,NULL,'2025-09-25 10:40:21','Ingreso','192.168.140.58','RICARDO',_binary ''),(569,4,NULL,'2025-09-25 12:02:16','Ingreso','192.168.1.7','RICARDO',_binary ''),(570,19,NULL,'2025-09-25 12:13:17','Ingreso','192.168.1.7','RICARDO',_binary ''),(571,12,NULL,'2025-09-25 15:32:51','Ingreso','192.168.1.4','LAPTOP-6C415UB3',_binary ''),(572,12,NULL,'2025-09-25 15:33:33','Cierre de sesión','192.168.1.4','LAPTOP-6C415UB3',_binary '\0'),(573,4,NULL,'2025-09-25 15:35:30','Ingreso','192.168.137.1','COMPU_CESAR',_binary ''),(574,12,NULL,'2025-09-25 15:35:38','Ingreso','192.168.1.4','LAPTOP-6C415UB3',_binary ''),(575,12,1,'2025-09-25 15:36:08','Guardar usuario','192.168.1.4','LAPTOP-6C415UB3',_binary ''),(576,4,NULL,'2025-09-25 15:46:49','Ingreso','192.168.137.1','COMPU_CESAR',_binary ''),(577,16,NULL,'2025-09-25 16:02:18','Ingreso','192.168.1.11','DAVID',_binary ''),(578,16,4,'2025-09-25 16:02:56','Modificar empleado','192.168.1.11','DAVID',_binary ''),(579,16,NULL,'2025-09-25 16:03:06','Cierre de sesión','192.168.1.11','DAVID',_binary '\0'),(580,4,NULL,'2025-09-25 16:03:44','Ingreso','192.168.137.1','COMPU_CESAR',_binary ''),(581,7,NULL,'2025-09-25 17:25:34','Ingreso','192.168.1.102','LUCHCODEDEV',_binary ''),(582,4,NULL,'2025-09-25 17:38:54','Ingreso','192.168.137.1','COMPU_CESAR',_binary ''),(583,4,1,'2025-09-25 17:39:57','Modificar aplicación','192.168.137.1','COMPU_CESAR',_binary ''),(584,4,NULL,'2025-09-25 17:46:24','Cierre de sesión','192.168.137.1','COMPU_CESAR',_binary '\0'),(585,2,NULL,'2025-09-25 17:54:46','Ingreso','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(586,4,NULL,'2025-09-25 18:17:02','Ingreso','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(587,4,2,'2025-09-25 18:17:41','Asignación Permisos Perfil - Agregar','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(588,4,2,'2025-09-25 18:18:00','Asignación aplicación a perfil - Insertar','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(589,4,1,'2025-09-25 18:19:34','Asignación Aplicación a Usuario - Agregar','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(590,4,1,'2025-09-25 18:19:58','Asignación Aplicación a Usuario - Insertar','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(591,2,NULL,'2025-09-25 18:20:43','Ingreso','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(592,2,NULL,'2025-09-25 18:23:47','Ingreso','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(593,2,NULL,'2025-09-25 18:37:08','Ingreso','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(594,4,NULL,'2025-09-25 18:38:33','Ingreso','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(595,2,NULL,'2025-09-25 18:52:05','Ingreso','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(596,2,NULL,'2025-09-25 18:54:38','Ingreso','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(597,12,NULL,'2025-09-25 18:56:23','Ingreso','192.168.1.4','LAPTOP-6C415UB3',_binary ''),(598,4,NULL,'2025-09-25 18:56:54','Ingreso','192.168.137.1','COMPU_CESAR',_binary ''),(599,4,1,'2025-09-25 18:58:55','Modificar aplicación','192.168.137.1','COMPU_CESAR',_binary ''),(600,4,NULL,'2025-09-25 19:00:14','Cierre de sesión','192.168.137.1','COMPU_CESAR',_binary '\0'),(601,2,NULL,'2025-09-25 19:05:22','Ingreso','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(602,2,NULL,'2025-09-25 19:06:53','Ingreso','192.168.56.1','DESKTOP-6VKCMBO',_binary ''),(603,4,NULL,'2025-09-25 20:21:29','Ingreso','192.168.137.1','COMPU_CESAR',_binary ''),(604,4,NULL,'2025-09-25 20:45:09','Ingreso','192.168.137.1','COMPU_CESAR',_binary ''),(605,4,NULL,'2025-09-25 20:46:48','Ingreso','192.168.137.1','COMPU_CESAR',_binary ''),(606,4,NULL,'2025-09-25 20:47:09','Cierre de sesión','192.168.137.1','COMPU_CESAR',_binary '\0'),(607,4,NULL,'2025-09-25 20:55:59','Ingreso','192.168.137.1','COMPU_CESAR',_binary ''),(608,7,NULL,'2025-09-25 21:21:27','Ingreso','192.168.1.102','LUCHCODEDEV',_binary ''),(609,4,NULL,'2025-09-25 21:21:56','Ingreso','192.168.137.1','COMPU_CESAR',_binary ''),(610,2,NULL,'2025-09-25 21:22:58','Ingreso','192.168.137.1','COMPU_CESAR',_binary ''),(611,2,NULL,'2025-09-25 21:23:17','Cierre de sesión','192.168.137.1','COMPU_CESAR',_binary '\0'),(612,7,NULL,'2025-09-25 21:23:21','Cierre de sesión','192.168.1.102','LUCHCODEDEV',_binary '\0'),(613,7,NULL,'2025-09-25 21:24:02','Ingreso','192.168.1.102','LUCHCODEDEV',_binary ''),(614,2,NULL,'2025-09-25 21:31:26','Ingreso','192.168.137.1','COMPU_CESAR',_binary ''),(615,2,NULL,'2025-09-25 21:32:08','Cierre de sesión','192.168.137.1','COMPU_CESAR',_binary '\0'),(616,5,NULL,'2025-09-25 21:36:34','Ingreso','192.168.1.55','BELY',_binary ''),(617,5,NULL,'2025-09-25 21:36:58','Cierre de sesión','192.168.1.55','BELY',_binary '\0'),(618,12,NULL,'2025-09-25 21:37:20','Ingreso','192.168.1.55','BELY',_binary ''),(619,12,2,'2025-09-25 21:38:10','Asignación Aplicación a Usuario - Agregar','192.168.1.55','BELY',_binary ''),(620,12,2,'2025-09-25 21:38:29','Asignación Aplicación a Usuario - Insertar','192.168.1.55','BELY',_binary ''),(621,12,NULL,'2025-09-25 21:38:58','Cierre de sesión','192.168.1.55','BELY',_binary '\0'),(622,5,NULL,'2025-09-25 21:39:09','Ingreso','192.168.1.55','BELY',_binary ''),(623,5,NULL,'2025-09-25 21:39:41','Cierre de sesión','192.168.1.55','BELY',_binary '\0'),(624,12,NULL,'2025-09-25 21:39:56','Ingreso','192.168.1.55','BELY',_binary ''),(625,12,NULL,'2025-09-25 21:45:41','Cierre de sesión','192.168.1.55','BELY',_binary '\0'),(626,2,NULL,'2025-09-26 15:13:16','Ingreso','192.168.137.1','COMPU_CESAR',_binary ''),(627,2,NULL,'2025-09-26 15:20:57','Ingreso','192.168.137.1','COMPU_CESAR',_binary ''),(628,2,NULL,'2025-09-26 15:21:51','Cierre de sesión','192.168.137.1','COMPU_CESAR',_binary '\0'),(629,2,NULL,'2025-09-26 15:32:53','Ingreso','192.168.137.1','COMPU_CESAR',_binary ''),(630,2,NULL,'2025-09-26 15:33:13','Ingreso','192.168.137.1','COMPU_CESAR',_binary '');
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
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Tbl_Empleado`
--

LOCK TABLES `Tbl_Empleado` WRITE;
/*!40000 ALTER TABLE `Tbl_Empleado` DISABLE KEYS */;
INSERT INTO `Tbl_Empleado` VALUES (1,'Ricardo','Esquit',1234567890101,1234567,'ricardo@email.com','5555-5555',_binary '','2000-01-01','2020-01-01'),(2,'Juan','Pérez López',1234567890101,9876542,'juan.perez@example.com','5555-1234',_binary '','1995-08-20','2025-09-21');
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
INSERT INTO `Tbl_Modulo` VALUES (1,'Pruebas','modulo de pruebas',_binary ''),(2,'Seguridad','Módulo de seguridad',_binary ''),(3,'Estandarizacion ','modulo de estandarizacion ',_binary ''),(4,'Empleado','empleado permiso pruebas',_binary ''),(5,'RHM','Recursos Humanos',_binary ''),(45,'Recursos','Quejas',_binary '');
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
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Tbl_Perfil`
--

LOCK TABLES `Tbl_Perfil` WRITE;
/*!40000 ALTER TABLE `Tbl_Perfil` DISABLE KEYS */;
INSERT INTO `Tbl_Perfil` VALUES (1,'Administrador','Perfil con todos los permisos',_binary '',1),(2,'Contador','Hace cuentas',_binary '\0',1);
/*!40000 ALTER TABLE `Tbl_Perfil` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Tbl_Permiso_Perfil_Aplicacion`
--

DROP TABLE IF EXISTS `Tbl_Permiso_Perfil_Aplicacion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Tbl_Permiso_Perfil_Aplicacion` (
  `Fk_Id_Modulo` int NOT NULL,
  `Fk_Id_Perfil` int NOT NULL,
  `Fk_Id_Aplicacion` int NOT NULL,
  `Cmp_Ingresar_Permisos_Aplicacion_Perfil` bit(1) DEFAULT NULL,
  `Cmp_Consultar_Permisos_Aplicacion_Perfil` bit(1) DEFAULT NULL,
  `Cmp_Modificar_Permisos_Aplicacion_Perfil` bit(1) DEFAULT NULL,
  `Cmp_Eliminar_Permisos_Aplicacion_Perfil` bit(1) DEFAULT NULL,
  `Cmp_Imprimir_Permisos_Aplicacion_Perfil` bit(1) DEFAULT NULL,
  PRIMARY KEY (`Fk_Id_Perfil`,`Fk_Id_Aplicacion`,`Fk_Id_Modulo`),
  KEY `Fk_PermisoPerfil_Aplic` (`Fk_Id_Aplicacion`),
  KEY `Fk_PermisoPerfil_Modulo` (`Fk_Id_Modulo`),
  CONSTRAINT `Fk_PermisoPerfil` FOREIGN KEY (`Fk_Id_Perfil`) REFERENCES `Tbl_Perfil` (`Pk_Id_Perfil`),
  CONSTRAINT `Fk_PermisoPerfil_Aplic` FOREIGN KEY (`Fk_Id_Aplicacion`) REFERENCES `Tbl_Aplicacion` (`Pk_Id_Aplicacion`),
  CONSTRAINT `Fk_PermisoPerfil_Modulo` FOREIGN KEY (`Fk_Id_Modulo`) REFERENCES `Tbl_Modulo` (`Pk_Id_Modulo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Tbl_Permiso_Perfil_Aplicacion`
--

LOCK TABLES `Tbl_Permiso_Perfil_Aplicacion` WRITE;
/*!40000 ALTER TABLE `Tbl_Permiso_Perfil_Aplicacion` DISABLE KEYS */;
INSERT INTO `Tbl_Permiso_Perfil_Aplicacion` VALUES (1,1,1,_binary '',_binary '',_binary '',_binary '\0',_binary '\0'),(2,1,2,_binary '',_binary '',_binary '',_binary '',_binary '');
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
  `Fk_Id_Aplicacion` int NOT NULL,
  `Fk_Id_Modulo` int NOT NULL,
  `Cmp_Ingresar_Permiso_Aplicacion_Usuario` bit(1) DEFAULT NULL,
  `Cmp_Consultar_Permiso_Aplicacion_Usuario` bit(1) DEFAULT NULL,
  `Cmp_Modificar_Permiso_Aplicacion_Usuario` bit(1) DEFAULT NULL,
  `Cmp_Eliminar_Permiso_Aplicacion_Usuario` bit(1) DEFAULT NULL,
  `Cmp_Imprimir_Permiso_Aplicacion_Usuario` bit(1) DEFAULT NULL,
  PRIMARY KEY (`Fk_Id_Usuario`,`Fk_Id_Aplicacion`,`Fk_Id_Modulo`),
  KEY `Fk_PermisoAplicacion` (`Fk_Id_Aplicacion`),
  KEY `Fk_PermisoModulo` (`Fk_Id_Modulo`),
  CONSTRAINT `Fk_PermisoAplicacion` FOREIGN KEY (`Fk_Id_Aplicacion`) REFERENCES `Tbl_Aplicacion` (`Pk_Id_Aplicacion`),
  CONSTRAINT `Fk_PermisoModulo` FOREIGN KEY (`Fk_Id_Modulo`) REFERENCES `Tbl_Modulo` (`Pk_Id_Modulo`),
  CONSTRAINT `Fk_PermisoUsuario` FOREIGN KEY (`Fk_Id_Usuario`) REFERENCES `Tbl_Usuario` (`Pk_Id_Usuario`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Tbl_Permiso_Usuario_Aplicacion`
--

LOCK TABLES `Tbl_Permiso_Usuario_Aplicacion` WRITE;
/*!40000 ALTER TABLE `Tbl_Permiso_Usuario_Aplicacion` DISABLE KEYS */;
INSERT INTO `Tbl_Permiso_Usuario_Aplicacion` VALUES (1,2,5,_binary '',_binary '',_binary '',_binary '',_binary ''),(1,5,2,_binary '',_binary '',_binary '',_binary '',_binary ''),(1,6,5,_binary '',_binary '',_binary '',_binary '',_binary ''),(2,1,2,_binary '',_binary '',_binary '',_binary '',_binary ''),(2,1,4,_binary '',_binary '',_binary '',_binary '',_binary ''),(4,1,3,_binary '',_binary '',_binary '',_binary '',_binary ''),(4,2,4,_binary '',_binary '',_binary '',_binary '',_binary ''),(4,3,3,_binary '',_binary '',_binary '',_binary '',_binary ''),(4,4,2,_binary '',_binary '',_binary '',_binary '',_binary ''),(4,4,5,_binary '',_binary '',_binary '',_binary '',_binary ''),(4,5,2,_binary '',_binary '',_binary '',_binary '',_binary ''),(4,6,5,_binary '',_binary '',_binary '',_binary '',_binary ''),(5,2,2,_binary '',_binary '',_binary '',_binary '',_binary ''),(6,1,3,_binary '\0',_binary '',_binary '\0',_binary '\0',_binary ''),(6,2,3,_binary '',_binary '\0',_binary '\0',_binary '\0',_binary '\0'),(7,1,2,_binary '\0',_binary '\0',_binary '\0',_binary '\0',_binary '\0'),(8,1,3,_binary '',_binary '',_binary '',_binary '\0',_binary ''),(9,1,1,_binary '',_binary '',_binary '',_binary '',_binary ''),(10,1,3,_binary '\0',_binary '',_binary '\0',_binary '\0',_binary '\0'),(10,2,1,_binary '\0',_binary '',_binary '\0',_binary '\0',_binary '\0'),(10,4,2,_binary '',_binary '',_binary '',_binary '',_binary ''),(11,4,2,_binary '\0',_binary '',_binary '\0',_binary '\0',_binary '\0'),(12,1,2,_binary '',_binary '',_binary '',_binary '',_binary ''),(12,2,2,_binary '',_binary '',_binary '',_binary '',_binary ''),(12,4,2,_binary '\0',_binary '\0',_binary '\0',_binary '\0',_binary '\0'),(12,4,5,_binary '',_binary '',_binary '',_binary '',_binary ''),(12,5,2,_binary '',_binary '',_binary '',_binary '',_binary ''),(12,6,5,_binary '',_binary '',_binary '',_binary '',_binary ''),(13,2,2,_binary '\0',_binary '\0',_binary '\0',_binary '\0',_binary '\0'),(14,4,2,_binary '',_binary '',_binary '',_binary '',_binary ''),(15,1,2,_binary '\0',_binary '\0',_binary '\0',_binary '\0',_binary '\0'),(16,1,2,_binary '\0',_binary '\0',_binary '\0',_binary '\0',_binary '\0'),(16,3,5,_binary '\0',_binary '\0',_binary '\0',_binary '\0',_binary '\0'),(16,4,5,_binary '',_binary '',_binary '',_binary '',_binary '\0'),(16,6,5,_binary '',_binary '',_binary '',_binary '',_binary '\0'),(17,4,2,_binary '\0',_binary '\0',_binary '\0',_binary '\0',_binary '\0'),(17,4,5,_binary '\0',_binary '',_binary '\0',_binary '\0',_binary '\0'),(19,5,2,_binary '\0',_binary '',_binary '\0',_binary '\0',_binary '\0'),(20,4,5,_binary '\0',_binary '',_binary '\0',_binary '\0',_binary '\0');
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
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Tbl_Token_RestaurarContrasena`
--

LOCK TABLES `Tbl_Token_RestaurarContrasena` WRITE;
/*!40000 ALTER TABLE `Tbl_Token_RestaurarContrasena` DISABLE KEYS */;
INSERT INTO `Tbl_Token_RestaurarContrasena` VALUES (1,2,'C43C63DA','2025-09-21 18:24:01','2025-09-21 18:29:01',_binary '','2025-09-21 18:24:38'),(2,1,'901DA0A1','2025-09-21 18:31:36','2025-09-21 18:36:36',_binary '','2025-09-21 18:32:15'),(3,1,'990DD530','2025-09-22 10:05:46','2025-09-22 10:10:46',_binary '\0',NULL),(4,1,'39C03B58','2025-09-24 20:53:40','2025-09-24 20:58:40',_binary '','2025-09-24 20:54:05'),(5,1,'21BE635F','2025-09-25 08:36:46','2025-09-25 08:41:46',_binary '','2025-09-25 08:37:06');
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
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Tbl_Usuario`
--

LOCK TABLES `Tbl_Usuario` WRITE;
/*!40000 ALTER TABLE `Tbl_Usuario` DISABLE KEYS */;
INSERT INTO `Tbl_Usuario` VALUES (1,1,'ricardo','a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3',0,_binary '','2025-09-21 23:01:04','2025-09-25 08:37:05',_binary '\0'),(2,1,'Cesar','578bfc33d127e864cf010d2fdda8c66c018757829b7e349653760ce5e36c59c6',0,_binary '','2025-09-22 00:17:20','2025-09-21 18:24:37',_binary '\0'),(4,2,'brandon','45297c633d331e6ac35169ebaaf75bc7fafd206ebb59ba4efd80566936e46eb0',0,_binary '','2025-09-21 20:49:54','2025-09-21 20:49:54',_binary '\0'),(5,1,'carlo','91a73fd806ab2c005c13b4dc19130a884e909dea3f72d46e30266fe1a1f588d8',0,_binary '','2025-09-22 08:56:31','2025-09-22 08:56:31',_binary '\0'),(6,2,'conesultas','a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3',0,_binary '','2025-09-22 18:31:34','2025-09-22 18:31:34',_binary '\0'),(7,2,'ruben','a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3',0,_binary '','2025-09-22 18:37:21','2025-09-22 18:37:21',_binary '\0'),(8,2,'rhm','a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3',0,_binary '','2025-09-22 18:52:45','2025-09-22 18:52:45',_binary '\0'),(9,2,'Juan','ba7816bf8f01cfea414140de5dae2223b00361a396177a9cb410ff61f20015ad',0,_binary '','2025-09-22 20:59:48','2025-09-22 20:59:48',_binary '\0'),(10,1,'prueba','655e786674d9d3e77bc05ed1de37b4b6bc89f788829f9f3c679e7687b410c89b',0,_binary '','2025-09-23 07:42:45','2025-09-23 07:42:45',_binary '\0'),(11,1,'armando','d74ff0ee8da3b9806b18c877dbf29bbde50b5bd8e4dad7a3a725000feb82e8f1',0,_binary '','2025-09-23 22:56:07','2025-09-23 22:56:07',_binary '\0'),(12,1,'administradorCesar','4813494d137e1631bba301d5acab6e7bb7aa74ce1185d456565ef51d737677b2',0,_binary '','2025-09-23 23:01:35','2025-09-23 23:01:35',_binary '\0'),(13,1,'manolo','b2c56341cc2b9f8bf898bd7528dd39e641b51c4fbd51f241b46ad70872dd1b99',0,_binary '','2025-09-24 01:08:13','2025-09-24 01:08:13',_binary '\0'),(14,2,'aa','4fc82b26aecb47d2868c4efbe3581732a3e7cbcc6c2efb32062c08170a05eeb8',0,_binary '','2025-09-24 18:44:59','2025-09-24 18:44:59',_binary '\0'),(15,2,'jeffer','f0d588a225e6e6ba0501a3f787230abf579f6db2dd55be0fa3450f8acd54e6f3',0,_binary '','2025-09-24 21:58:01','2025-09-24 21:58:01',_binary '\0'),(16,2,'Ernesto','4813494d137e1631bba301d5acab6e7bb7aa74ce1185d456565ef51d737677b2',0,_binary '','2025-09-25 07:30:08','2025-09-25 07:30:08',_binary '\0'),(17,1,'esduardo','c0bc1e08f9743b2d50d5f1607503bf4e849af0e729fca896515bea955d70a33e',0,_binary '','2025-09-25 07:58:15','2025-09-25 07:58:15',_binary '\0'),(18,1,'ricardo','a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3',0,_binary '','2025-09-25 08:36:11','2025-09-25 08:36:11',_binary '\0'),(19,1,'aron','5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5',0,_binary '','2025-09-25 10:30:21','2025-09-25 10:30:21',_binary '\0'),(20,2,'pedro','5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5',0,_binary '','2025-09-25 10:37:20','2025-09-25 10:37:20',_binary '\0'),(21,2,'juan','a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3',0,_binary '','2025-09-25 15:36:06','2025-09-25 15:36:06',_binary '\0');
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
INSERT INTO `Tbl_Usuario_Perfil` VALUES (1,1),(4,1);
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

-- Dump completed on 2025-09-26 15:47:30
