
USE hoteleria;

create table tbl_USUARIO
(
   pk_id_usuario           int not null auto_increment,
   fk_id_empleado          int,
   nombre_usuario       varchar(50),
   contrasena_usuario   varchar(50),
   contador_intentos_fallidos_usuario int,
   estado_usuario       bit,
   fecha_creacion_usuario datetime,
   ultimo_cambio_contrasena_usuario datetime,
   pidio_cambio_contrasena_usuario bit,
   primary key (pk_id_usuario)
);


CREATE TABLE tbl_PERMISO_USUARIO_APLICACION (
   fk_id_usuario           INT,
   fk_id_aplicacion        INT,
   fk_id_modulo            INT,
   ingresar_permiso_aplicacion_usuario BIT,
   consultar_permiso_aplicacion_usuario BIT,
   modificar_permiso_aplicacion_usuario BIT,
   eliminar_permiso_aplicacion_usuario BIT,
   imprimir_permiso_aplicacion_usuario BIT,
   PRIMARY KEY (fk_id_usuario, fk_id_aplicacion, fk_id_modulo) -- clave compuesta
);


CREATE TABLE tbl_ASIGNACION_MODULO_APLICACION (
   fk_id_modulo     INT,
   fk_id_aplicacion INT,
   PRIMARY KEY (fk_id_modulo, fk_id_aplicacion) -- clave compuesta
);


CREATE TABLE tbl_PERMISO_PERFIL_APLICACION (
   fk_id_modulo     INT,
   fk_id_perfil     INT,
   fk_id_aplicacion INT,
   ingresar_permiso_aplicacion_perfil BIT,
   consultar_permiso_aplicacion_perfil BIT,
   modificar_permiso_aplicacion_perfil BIT,
   eliminar_permiso_aplicacion_perfil BIT,
   imprimir_permiso_aplicacion_perfil BIT,
   PRIMARY KEY (fk_id_perfil, fk_id_aplicacion, fk_id_modulo) -- clave compuesta
);


create table tbl_BLOQUEO_USUARIO
(
   pk_id_bloqueo           int not null auto_increment,
   fk_id_usuario           int,
   fk_id_bitacora          int,
   fecha_inicio_bloqueo_usuario datetime,
   fecha_fin_bloqueo_usuario datetime,
   motivo_bloqueo_usuario varchar(50),
   primary key (pk_id_bloqueo)
);


create table tbl_TOKEN_RESTAURAR_CONTRASENA
(
   pk_id_token_restaurar_contrasena int not null auto_increment,
   fk_id_usuario           int,
   token_restaurar_contrasena varchar(50),
   fecha_creacion_token_restaurar_contrasena datetime,
   expiracion_token_restaurar_contrasena datetime,
   utilizado_token_restaurar_contrasena bit,
   fecha_utilizado_restaurar_contrasena datetime,
   primary key (pk_id_token_restaurar_contrasena)
);


create table tbl_EMPLEADO
(
   pk_id_empleado      int not null auto_increment,
   nombres_empleado     varchar(50),
   apellidos_empleado   varchar(50),
   dpi_empleado         bigint,
   nit_empleado         bigint,
   correo_empleado      varchar(50),
   telefono_empleado    varchar(15),
   genero_empleado      bit,
   fecha_nacimiento_empleado date,
   fecha_contratacion_empleado date,
   primary key (pk_id_empleado)
);


CREATE TABLE tbl_PERFIL
(
   pk_id_perfil         int NOT NULL auto_increment,
   puesto_perfil        varchar(50),
   descripcion_perfil   varchar(50),
   estado_perfil        bit NOT NULL, -- 1 = habilitado, 0 = deshabilitado
   tipo_perfil          int,          -- ahora es int
   PRIMARY KEY (pk_id_perfil)
);


create table tbl_MODULO
(
   pk_id_modulo       int not null,
   nombre_modulo      varchar(50),
   descripcion_modulo varchar(50),
   estado_modulo      bit not null, -- 1 = habilitado, 0 = deshabilitado
   primary key (pk_id_modulo)
);


CREATE TABLE tbl_USUARIO_PERFIL (
   fk_id_usuario INT,
   fk_id_perfil  INT,
   PRIMARY KEY (fk_id_usuario, fk_id_perfil) -- clave compuesta
);


CREATE TABLE tbl_APLICACION
(
   pk_id_aplicacion        int NOT NULL,
   fk_id_reporte           int,
   nombre_aplicacion       varchar(50),
   descripcion_aplicacion  varchar(50),
   estado_aplicacion       bit NOT NULL, -- 1 = habilitado, 0 = deshabilitado
   PRIMARY KEY (pk_id_aplicacion)
);


create table tbl_BITACORA
(
   pk_id_bitacora          int not null auto_increment,
   fk_id_usuario           int,
   fk_id_aplicacion        int,
   fecha_bitacora       datetime,
   accion_bitacora      varchar(50),
   ip_bitacora          varchar(50),
   nombre_pc_bitacora   varchar(50),
   login_estado_bitacora bit,
   primary key (pk_id_bitacora)
);


CREATE TABLE tbl_ASIGNAR_PERFIL_CLIENTE (
   fk_id_perfil  INT,
   fk_id_cliente INT,
   PRIMARY KEY (fk_id_perfil, fk_id_cliente) -- clave compuesta
);


create table tbl_CLIENTE
(
   pk_id_cliente        int not null ,
   nombres_cliente      varchar(50),
   apellidos_cliente    varchar(50),
   dni_cliente          bigint,
   fecha_registro       datetime,
   estado_cliente       bit,
   nacionalidad_cliente varchar(50),
   primary key (pk_id_cliente)
);


create table tbl_CORREO_CLIENTE
(
   pk_id_correo_cliente    int not null,
   fk_id_cliente           int,
   correo_cliente       varchar(50),
   primary key (pk_id_correo_cliente)
);


create table tbl_NIT_CLIENTE
(
   pk_id_nit_clinete       int not null,
   fk_id_cliente           int,
   nit_cliente          varchar(15),
   primary key (pk_id_nit_clinete)
);


create table tbl_NUMERO_CLIENTE
(
   pk_id_numero_cliente    int not null,
   fk_id_cliente           int,
   telefono_cliente       varchar(15),
   primary key (pk_id_numero_cliente)
);


create table tbl_REPORTES
(
   pk_id_reportes           int not null,
   titulo_reportes	varchar(50),
   ruta_reportes	varchar(50),
   fecha_reportes	date,
   primary key (pk_id_reportes)
);


create table tbl_SALARIO_EMPLEADO
(
   pk_id_salario           int not null,
   fk_id_empleado          int,
   monto_salario_empleado float,
   fecha_inicio_salario_empleado datetime,
   fecha_fin_salario_empleado datetime,
   estado_salario_empleado bit,
   primary key (pk_id_salario)
);


ALTER TABLE tbl_USUARIO 
   ADD CONSTRAINT fk_usuario_empleado FOREIGN KEY (fk_id_empleado)
   REFERENCES tbl_EMPLEADO (pk_id_empleado) ON DELETE RESTRICT ON UPDATE RESTRICT;

ALTER TABLE tbl_PERMISO_USUARIO_APLICACION 
   ADD CONSTRAINT fk_permiso_usuario FOREIGN KEY (fk_id_usuario)
   REFERENCES tbl_USUARIO (pk_id_usuario) ON DELETE RESTRICT ON UPDATE RESTRICT;

ALTER TABLE tbl_PERMISO_USUARIO_APLICACION 
   ADD CONSTRAINT fk_permiso_aplicacion FOREIGN KEY (fk_id_aplicacion)
   REFERENCES tbl_APLICACION (pk_id_aplicacion) ON DELETE RESTRICT ON UPDATE RESTRICT;

ALTER TABLE tbl_PERMISO_USUARIO_APLICACION 
   ADD CONSTRAINT fk_permiso_modulo FOREIGN KEY (fk_id_modulo)
   REFERENCES tbl_MODULO (pk_id_modulo) ON DELETE RESTRICT ON UPDATE RESTRICT;

ALTER TABLE tbl_ASIGNACION_MODULO_APLICACION 
   ADD CONSTRAINT fk_asignacion_modulo FOREIGN KEY (fk_id_modulo)
   REFERENCES tbl_MODULO (pk_id_modulo) ON DELETE RESTRICT ON UPDATE RESTRICT;

ALTER TABLE tbl_ASIGNACION_MODULO_APLICACION 
   ADD CONSTRAINT fk_asignacion_aplicacion FOREIGN KEY (fk_id_aplicacion)
   REFERENCES tbl_APLICACION (pk_id_aplicacion) ON DELETE RESTRICT ON UPDATE RESTRICT;

ALTER TABLE tbl_PERMISO_PERFIL_APLICACION 
   ADD CONSTRAINT fk_permiso_perfil FOREIGN KEY (fk_id_perfil)
   REFERENCES tbl_PERFIL (pk_id_perfil) ON DELETE RESTRICT ON UPDATE RESTRICT;

ALTER TABLE tbl_PERMISO_PERFIL_APLICACION 
   ADD CONSTRAINT fk_permiso_perfil_aplicacion FOREIGN KEY (fk_id_aplicacion)
   REFERENCES tbl_APLICACION (pk_id_aplicacion) ON DELETE RESTRICT ON UPDATE RESTRICT;

ALTER TABLE tbl_PERMISO_PERFIL_APLICACION 
   ADD CONSTRAINT fk_permiso_perfil_modulo FOREIGN KEY (fk_id_modulo)
   REFERENCES tbl_MODULO (pk_id_modulo) ON DELETE RESTRICT ON UPDATE RESTRICT;

ALTER TABLE tbl_BLOQUEO_USUARIO 
   ADD CONSTRAINT fk_bloqueo_usuario FOREIGN KEY (fk_id_usuario)
   REFERENCES tbl_USUARIO (pk_id_usuario) ON DELETE RESTRICT ON UPDATE RESTRICT;

ALTER TABLE tbl_BLOQUEO_USUARIO 
   ADD CONSTRAINT fk_bloqueo_bitacora FOREIGN KEY (fk_id_bitacora)
   REFERENCES tbl_BITACORA (pk_id_bitacora) ON DELETE RESTRICT ON UPDATE RESTRICT;

ALTER TABLE tbl_TOKEN_RESTAURAR_CONTRASENA 
   ADD CONSTRAINT fk_token_usuario FOREIGN KEY (fk_id_usuario)
   REFERENCES tbl_USUARIO (pk_id_usuario) ON DELETE RESTRICT ON UPDATE RESTRICT;

ALTER TABLE tbl_USUARIO_PERFIL 
   ADD CONSTRAINT fk_usuario_perfil_usuario FOREIGN KEY (fk_id_usuario)
   REFERENCES tbl_USUARIO (pk_id_usuario) ON DELETE RESTRICT ON UPDATE RESTRICT;

ALTER TABLE tbl_USUARIO_PERFIL 
   ADD CONSTRAINT fk_usuario_perfil_perfil FOREIGN KEY (fk_id_perfil)
   REFERENCES tbl_PERFIL (pk_id_perfil) ON DELETE RESTRICT ON UPDATE RESTRICT;

ALTER TABLE tbl_APLICACION 
   ADD CONSTRAINT fk_aplicacion_reporte FOREIGN KEY (fk_id_reporte)
   REFERENCES tbl_REPORTES (pk_id_reportes) ON DELETE RESTRICT ON UPDATE RESTRICT;

ALTER TABLE tbl_BITACORA 
   ADD CONSTRAINT fk_bitacora_usuario FOREIGN KEY (fk_id_usuario)
   REFERENCES tbl_USUARIO (pk_id_usuario) ON DELETE RESTRICT ON UPDATE RESTRICT;

ALTER TABLE tbl_BITACORA 
   ADD CONSTRAINT fk_bitacora_aplicacion FOREIGN KEY (fk_id_aplicacion)
   REFERENCES tbl_APLICACION (pk_id_aplicacion) ON DELETE RESTRICT ON UPDATE RESTRICT;

ALTER TABLE tbl_ASIGNAR_PERFIL_CLIENTE 
   ADD CONSTRAINT fk_asignar_perfil FOREIGN KEY (fk_id_perfil)
   REFERENCES tbl_PERFIL (pk_id_perfil) ON DELETE RESTRICT ON UPDATE RESTRICT;

ALTER TABLE tbl_ASIGNAR_PERFIL_CLIENTE 
   ADD CONSTRAINT fk_asignar_cliente FOREIGN KEY (fk_id_cliente)
   REFERENCES tbl_CLIENTE (pk_id_cliente) ON DELETE RESTRICT ON UPDATE RESTRICT;

ALTER TABLE tbl_CORREO_CLIENTE 
   ADD CONSTRAINT fk_correo_cliente FOREIGN KEY (fk_id_cliente)
   REFERENCES tbl_CLIENTE (pk_id_cliente) ON DELETE RESTRICT ON UPDATE RESTRICT;

ALTER TABLE tbl_NIT_CLIENTE 
   ADD CONSTRAINT fk_nit_cliente FOREIGN KEY (fk_id_cliente)
   REFERENCES tbl_CLIENTE (pk_id_cliente) ON DELETE RESTRICT ON UPDATE RESTRICT;

ALTER TABLE tbl_NUMERO_CLIENTE 
   ADD CONSTRAINT fk_numero_cliente FOREIGN KEY (fk_id_cliente)
   REFERENCES tbl_CLIENTE (pk_id_cliente) ON DELETE RESTRICT ON UPDATE RESTRICT;

ALTER TABLE tbl_SALARIO_EMPLEADO 
   ADD CONSTRAINT fk_salario_empleado FOREIGN KEY (fk_id_empleado)
   REFERENCES tbl_EMPLEADO (pk_id_empleado) ON DELETE RESTRICT ON UPDATE RESTRICT;