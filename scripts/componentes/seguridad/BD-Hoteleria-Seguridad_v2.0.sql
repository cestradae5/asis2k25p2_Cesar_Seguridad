CREATE DATABASE Bd_Hoteleria;
USE Bd_Hoteleria;

CREATE TABLE Tbl_Empleado (
   Pk_Id_Empleado      INT NOT NULL AUTO_INCREMENT,
   Cmp_Nombres_Empleado         VARCHAR(50),
   Cmp_Apellidos_Empleado        VARCHAR(50),
   Cmp_Dpi_Empleado               BIGINT,
   Cmp_Nit_Empleado               BIGINT,
   Cmp_Correo_Empleado            VARCHAR(50),
   Cmp_Telefono_Empleado          VARCHAR(15),
   Cmp_Genero_Empleado            BIT,
   Cmp_Fecha_Nacimiento_Empleado   DATE,
   Cmp_Fecha_Contratacion__Empleado   DATE,
   PRIMARY KEY (Pk_Id_Empleado)
);

CREATE TABLE Tbl_Perfil (
   Pk_Id_Perfil       INT NOT NULL AUTO_INCREMENT,
   Cmp_Puesto_Perfil         VARCHAR(50),
   Cmp_Descripcion_Perfil     VARCHAR(50),
   Cmp_Estado_Perfil         BIT NOT NULL,
   Cmp_Tipo_Perfil           INT,
   PRIMARY KEY (Pk_Id_Perfil)
);

CREATE TABLE Tbl_Reportes (
   Pk_Id_Reporte   INT NOT NULL,
   Cmp_Titulo_Reporte      VARCHAR(50),
   Cmp_Ruta_Reporte       VARCHAR(50),
   Cmp_Fecha_Reporte       DATE,
   PRIMARY KEY (Pk_Id_Reporte)
);

CREATE TABLE Tbl_Modulo (
   Pk_Id_Modulo     INT NOT NULL,
   Cmp_Nombre_Modulo         VARCHAR(50),
   Cmp_Descripcion_Modulo    VARCHAR(50),
   Cmp_Estado_Modulo         BIT NOT NULL,
   PRIMARY KEY (Pk_Id_Modulo)
);

CREATE TABLE Tbl_Cliente (
   Pk_Id_Cliente    INT NOT NULL,
   Cmp_Nombres_Cliente  VARCHAR(50),
   Cmp_Apellidos_Cliente    VARCHAR(50),
   Cmp_Dni_Cliente        BIGINT,
   Cmp_Fecha_Registro_Cliente DATETIME,
   Cmp_Estado_Cliente     BIT,
   Cmp_Nacionalidad_Cliente  VARCHAR(50),
   PRIMARY KEY (Pk_Id_Cliente)
);

CREATE TABLE Tbl_Usuario (
   Pk_Id_Usuario      INT NOT NULL AUTO_INCREMENT,
   Fk_Id_Empleado     INT,
   Cmp_Nombre_Usuario  VARCHAR(50),
   Cmp_Contrasena_Usuario     VARCHAR(65),
   Cmp_Intentos_Fallidos_Usuario INT,
   Cmp_Estado_Usuario         BIT,
   Cmp_FechaCreacion_Usuario  DATETIME,
   Cmp_Ultimo_Cambio_Contrasenea   DATETIME,
   Cmp_Pidio_Cambio_Contrasenea    BIT,
   PRIMARY KEY (Pk_Id_Usuario),
   CONSTRAINT Fk_Usuario_Empleado FOREIGN KEY (Fk_Id_Empleado)
       REFERENCES Tbl_Empleado (Pk_Id_Empleado)
       ON DELETE RESTRICT ON UPDATE RESTRICT
);

CREATE TABLE Tbl_Aplicacion (
   Pk_Id_Aplicacion  INT NOT NULL,
   Fk_Id_Reporte_Aplicacion INT,
   Cmp_Nombre_Aplicacion VARCHAR(50),
   Cmp_Descripcion_Aplicacion VARCHAR(50),
   Cmp_Estado_Aplicacion BIT NOT NULL,
   PRIMARY KEY (Pk_Id_Aplicacion),
   CONSTRAINT Fk_Aplicacion_Reporte FOREIGN KEY (Fk_Id_Reporte_Aplicacion)
       REFERENCES Tbl_Reportes (Pk_Id_Reporte)
);

CREATE TABLE Tbl_Usuario_Perfil (
   Fk_Id_Usuario INT,
   Fk_Id_Perfil  INT,
   PRIMARY KEY (Fk_Id_Usuario, Fk_Id_Perfil),
   CONSTRAINT Fk_UsuarioPerfil_Usuario FOREIGN KEY (Fk_Id_Usuario)
       REFERENCES Tbl_Usuario (Pk_Id_Usuario),
   CONSTRAINT Fk_UsuarioPerfil_Perfil FOREIGN KEY (Fk_Id_Perfil)
       REFERENCES Tbl_Perfil (Pk_Id_Perfil)
);

CREATE TABLE Tbl_Asignacion_Modulo_Aplicacion (
   Fk_Id_Modulo     INT,
   Fk_Id_Aplicacion INT,
   PRIMARY KEY (Fk_Id_Modulo, Fk_Id_Aplicacion),
   CONSTRAINT Fk_AsigModulo FOREIGN KEY (Fk_Id_Modulo)
       REFERENCES Tbl_Modulo (Pk_Id_Modulo),
   CONSTRAINT Fk_AsigAplicacion FOREIGN KEY (Fk_Id_Aplicacion)
       REFERENCES Tbl_Aplicacion (Pk_Id_Aplicacion)
);

CREATE TABLE Tbl_Permiso_Usuario_Aplicacion (
   Fk_Id_Usuario    INT,
   Fk_Id_Aplicacion INT,
   Fk_Id_Modulo     INT,
   Cmp_Ingresar_Permiso_Aplicacion_Usuario     BIT,
   Cmp_Consultar_Permiso_Aplicacion_Usuario     BIT,
   Cmp_Modificar_Permiso_Aplicacion_Usuario     BIT,
   Cmp_Eliminar_Permiso_Aplicacion_Usuario      BIT,
   Cmp_Imprimir_Permiso_Aplicacion_Usuario      BIT,
   PRIMARY KEY (Fk_Id_Usuario, Fk_Id_Aplicacion, Fk_Id_Modulo),
   CONSTRAINT Fk_PermisoUsuario FOREIGN KEY (Fk_Id_Usuario)
       REFERENCES Tbl_Usuario (Pk_Id_Usuario),
   CONSTRAINT Fk_PermisoAplicacion FOREIGN KEY (Fk_Id_Aplicacion)
       REFERENCES Tbl_Aplicacion (Pk_Id_Aplicacion),
   CONSTRAINT Fk_PermisoModulo FOREIGN KEY (Fk_Id_Modulo)
       REFERENCES Tbl_Modulo (Pk_Id_Modulo)
);

CREATE TABLE Tbl_Permiso_Perfil_Aplicacion (
   Fk_Id_Modulo     INT,
   Fk_Id_Perfil     INT,
   Fk_Id_Aplicacion INT,
   Cmp_Ingresar_Permisos_Aplicacion_Perfil     BIT,
   Cmp_Consultar_Permisos_Aplicacion_Perfil    BIT,
   Cmp_Modificar_Permisos_Aplicacion_Perfil    BIT,
   Cmp_Eliminar_Permisos_Aplicacion_Perfil     BIT,
   Cmp_Imprimir_Permisos_Aplicacion_Perfil     BIT,
   PRIMARY KEY (Fk_Id_Perfil, Fk_Id_Aplicacion, Fk_Id_Modulo),
   CONSTRAINT Fk_PermisoPerfil FOREIGN KEY (Fk_Id_Perfil)
       REFERENCES Tbl_Perfil (Pk_Id_Perfil),
   CONSTRAINT Fk_PermisoPerfil_Aplic FOREIGN KEY (Fk_Id_Aplicacion)
       REFERENCES Tbl_Aplicacion (Pk_Id_Aplicacion),
   CONSTRAINT Fk_PermisoPerfil_Modulo FOREIGN KEY (Fk_Id_Modulo)
       REFERENCES Tbl_Modulo (Pk_Id_Modulo)
);

CREATE TABLE Tbl_Asignar_Perfil_Cliente (
   Fk_Id_Perfil  INT,
   Fk_Id_Cliente INT,
   PRIMARY KEY (Fk_Id_Perfil, Fk_Id_Cliente),
   CONSTRAINT Fk_AsigPerfil FOREIGN KEY (Fk_Id_Perfil)
       REFERENCES Tbl_Perfil (Pk_Id_Perfil),
   CONSTRAINT Fk_AsigCliente FOREIGN KEY (Fk_Id_Cliente)
       REFERENCES Tbl_Cliente (Pk_Id_Cliente)
);

CREATE TABLE Tbl_Salario_Empleado (
   Pk_Id_Salario   INT NOT NULL,
   Fk_Id_Empleado  INT,
   Cmp_Monto_Salario_Empleado        FLOAT,
   Cmp_Fecha_Inicio_Salario_Empleado  DATETIME,
   Cmp_Fecha_Fin_Salario_Empleado     DATETIME,
   Cmp_Estado_Salario_Empleado       BIT,
   PRIMARY KEY (Pk_Id_Salario),
   CONSTRAINT Fk_Salario_Empleado FOREIGN KEY (Fk_Id_Empleado)
       REFERENCES Tbl_Empleado (Pk_Id_Empleado)
);

CREATE TABLE Tbl_Bitacora (
   Pk_Id_Bitacora       INT NOT NULL AUTO_INCREMENT,
   Fk_Id_Usuario        INT,
   Fk_Id_Aplicacion     INT,
   Cmp_Fecha            DATETIME,
   Cmp_Accion           VARCHAR(50),
   Cmp_Ip               VARCHAR(50),
   Cmp_Nombre_Pc         VARCHAR(50),
   Cmp_Login_Estado      BIT(1),
   PRIMARY KEY (Pk_Id_Bitacora),
   CONSTRAINT Fk_Bitacora_Usuario FOREIGN KEY (Fk_Id_Usuario)
       REFERENCES Tbl_Usuario (Pk_Id_Usuario),
   CONSTRAINT Fk_Bitacora_Aplicacion FOREIGN KEY (Fk_Id_Aplicacion)
       REFERENCES Tbl_Aplicacion (Pk_Id_Aplicacion)
);

CREATE TABLE Tbl_Bloqueo_Usuario (
   Pk_Id_Bloqueo    INT NOT NULL AUTO_INCREMENT,
   Fk_Id_Usuario    INT,
   Fk_Id_Bitacora   INT,
   Cmp_Fecha_Inicio_Bloqueo_Usuario  DATETIME,
   Cmp_Fecha_Fin_Bloqueo_Usuario      DATETIME,
   Cmp_Motivo__Bloqueo_Usuario        VARCHAR(50),
   PRIMARY KEY (Pk_Id_Bloqueo),
   CONSTRAINT Fk_Bloqueo_Usuario FOREIGN KEY (Fk_Id_Usuario)
       REFERENCES Tbl_Usuario (Pk_Id_Usuario),
   CONSTRAINT Fk_Bloqueo_Bitacora FOREIGN KEY (Fk_Id_Bitacora)
       REFERENCES Tbl_Bitacora (Pk_Id_Bitacora)
);

CREATE TABLE Tbl_Token_RestaurarContrasena (
   Pk_Id_Token      INT NOT NULL AUTO_INCREMENT,
   Fk_Id_Usuario    INT,
   Cmp_Token        VARCHAR(50),
   Cmp_Fecha_Creacion_Restaurar_Contrasenea DATETIME,
   Cmp_Expiracion_Restaurar_Contrasenea   DATETIME,
   Cmp_Utilizado_Restaurar_Contrasenea    BIT,
   Cmp_Fecha_Uso_Restaurar_Contrasenea     DATETIME,
   PRIMARY KEY (Pk_Id_Token),
   CONSTRAINT Fk_Token_Usuario FOREIGN KEY (Fk_Id_Usuario)
       REFERENCES Tbl_Usuario (Pk_Id_Usuario)
);

CREATE TABLE Tbl_Correo_Cliente (
   Pk_Id_Correo   INT NOT NULL,
   Fk_Id_Cliente  INT,
   Cmp_Correo_Cliente     VARCHAR(50),
   PRIMARY KEY (Pk_Id_Correo),
   CONSTRAINT Fk_Correo_Cliente FOREIGN KEY (Fk_Id_Cliente)
       REFERENCES Tbl_Cliente (Pk_Id_Cliente)
);

CREATE TABLE Tbl_Nit_Cliente (
   Pk_Id_Nit      INT NOT NULL,
   Fk_Id_Cliente  INT,
   Cmp_Nit_Cliente        VARCHAR(15),
   PRIMARY KEY (Pk_Id_Nit),
   CONSTRAINT Fk_Nit_Cliente FOREIGN KEY (Fk_Id_Cliente)
       REFERENCES Tbl_Cliente (Pk_Id_Cliente)
);

CREATE TABLE Tbl_Numero_Cliente (
   Pk_Id_Numero   INT NOT NULL,
   Fk_Id_Cliente  INT,
   Cmp_Telefono_Cliente    VARCHAR(15),
   PRIMARY KEY (Pk_Id_Numero),
   CONSTRAINT Fk_Numero_Cliente FOREIGN KEY (Fk_Id_Cliente)
       REFERENCES Tbl_Cliente (Pk_Id_Cliente)
);

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
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Tbl_Usuario`
--

LOCK TABLES `Tbl_Usuario` WRITE;
/*!40000 ALTER TABLE `Tbl_Usuario` DISABLE KEYS */;
INSERT INTO `Tbl_Usuario` VALUES (1,1,'ricardo','88567ae16a27e6271ffe2ea5e78df7f527ec90ee933de5992a76909ebed266bb',0,_binary '','2025-09-21 23:01:04','2025-09-21 18:32:13',_binary '\0'),(2,1,'Cesar','578bfc33d127e864cf010d2fdda8c66c018757829b7e349653760ce5e36c59c6',0,_binary '','2025-09-22 00:17:20','2025-09-21 18:24:37',_binary '\0'),(4,2,'brandon','45297c633d331e6ac35169ebaaf75bc7fafd206ebb59ba4efd80566936e46eb0',0,_binary '','2025-09-21 20:49:54','2025-09-21 20:49:54',_binary '\0'),(5,1,'carlo','91a73fd806ab2c005c13b4dc19130a884e909dea3f72d46e30266fe1a1f588d8',0,_binary '','2025-09-22 08:56:31','2025-09-22 08:56:31',_binary '\0'),(6,2,'conesultas','a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3',0,_binary '','2025-09-22 18:31:34','2025-09-22 18:31:34',_binary '\0'),(7,2,'ruben','a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3',0,_binary '','2025-09-22 18:37:21','2025-09-22 18:37:21',_binary '\0'),(8,2,'rhm','a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3',0,_binary '','2025-09-22 18:52:45','2025-09-22 18:52:45',_binary '\0'),(9,2,'Juan','ba7816bf8f01cfea414140de5dae2223b00361a396177a9cb410ff61f20015ad',0,_binary '','2025-09-22 20:59:48','2025-09-22 20:59:48',_binary '\0'),(10,1,'prueba','655e786674d9d3e77bc05ed1de37b4b6bc89f788829f9f3c679e7687b410c89b',0,_binary '','2025-09-23 07:42:45','2025-09-23 07:42:45',_binary '\0');
/*!40000 ALTER TABLE `Tbl_Usuario` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-09-23  8:28:16

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
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Tbl_Empleado`
--

LOCK TABLES `Tbl_Empleado` WRITE;
/*!40000 ALTER TABLE `Tbl_Empleado` DISABLE KEYS */;
INSERT INTO `Tbl_Empleado` VALUES (1,'Ricardo','Esquit',1234567890101,1234567,'ricardo@email.com','5555-5555',_binary '','2000-01-01','2020-01-01'),(2,'Juan','Pérez López',1234567890101,9876543,'juan.perez@example.com','5555-1234',_binary '','1995-08-20','2025-09-21');
/*!40000 ALTER TABLE `Tbl_Empleado` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-09-23  8:28:28




