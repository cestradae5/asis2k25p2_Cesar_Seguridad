drop database Bd_Hoteleria;
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
   Pk_Id_Reporte INT NOT NULL AUTO_INCREMENT,
   Cmp_Titulo_Reporte VARCHAR(50),
   Cmp_Ruta_Reporte VARCHAR(500),
   Cmp_Fecha_Reporte DATE,
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


-- DATOS DE PRUEBA PARA REPORTES
USE Bd_Hoteleria;

SELECT *  FROM Tbl_Empleado;


INSERT INTO Tbl_Empleado 
(Cmp_Nombres_Empleado, Cmp_Apellidos_Empleado, Cmp_Dpi_Empleado, Cmp_Nit_Empleado, 
 Cmp_Correo_Empleado, Cmp_Telefono_Empleado, Cmp_Genero_Empleado, 
 Cmp_Fecha_Nacimiento_Empleado, Cmp_Fecha_Contratacion__Empleado)
VALUES
('Paula', 'Leonardo', 3050123456789, 987654321, 'paula.leonardo@example.com', '50212345678', 0, '1995-04-12', '2022-06-15'),

('Maria', 'Morales', 3045123987654, 112233445, 'maria.morales@example.com', '50287654321', 0, '1992-09-25', '2021-03-01'),

('Barbara', 'Salguero', 3011987654321, 556677889, 'barbara.salguero@example.com', '50233445566', 0, '1998-01-30', '2023-01-10'),

('Kevin', 'Natareno', 3098765432123, 223344556, 'kevin.natareno@example.com', '50299887766', 1, '1994-07-18', '2020-11-20'),

('Anderson', 'Trigeros', 1234567890123, 235694786, 'Anderson.Trigeros@example.com', '48573876', 1, '1996-04-11', '2021-05-24');



INSERT INTO Tbl_Empleado -- PRUEBA DE JUEVES
(Cmp_Nombres_Empleado, Cmp_Apellidos_Empleado, Cmp_Dpi_Empleado, Cmp_Nit_Empleado, 
 Cmp_Correo_Empleado, Cmp_Telefono_Empleado, Cmp_Genero_Empleado, 
 Cmp_Fecha_Nacimiento_Empleado, Cmp_Fecha_Contratacion__Empleado)
VALUES
('Esduardo', 'Del Aguila', 9999999999999, 123456786, 'EdelA@example.com', '30623363', 1, '1990-04-11', '2025-09-25');
