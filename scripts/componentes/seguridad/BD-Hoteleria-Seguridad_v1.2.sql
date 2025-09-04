CREATE DATABASE IF NOT EXISTS hoteleria;
USE hoteleria;
create table tbl_USUARIO
(
   pk_id_usuario           int not null,
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


create table tbl_PERMISO_USUARIO_APLICACION
(
   fk_id_usuario           int,
   fk_id_aplicacion        int,
   fk_id_modulo            int,
   ingresar_permiso_aplicacion_usuario bit,
   consultar_permiso_aplicacion_usuario bit,
   modificar_permiso_aplicacion_usuario bit,
   eliminar_permiso_aplicacion_usuario bit,
   imprimir_permiso_aplicacion_usuario bit
);


create table tbl_ASIGNACION_MODULO_APLICACION 
(
   fk_id_modulo            int,
   fk_id_aplicacion        int
);


create table tbl_PERMISO_PERFIL_APLICACION
(
   fk_id_modulo            int,
   fk_id_perfil            int,
   fk_id_aplicacion        int,
   ingresar_permiso_aplicacion_perfil bit,
   consultar_permiso_aplicacion_perfil bit,
   modificar_permiso_aplicacion_perfil bit,
   eliminar_permiso_aplicacion_perfil bit,
   imprimir_permiso_aplicacion_perfil bit
);


create table tbl_BLOQUEO_USUARIO
(
   pk_id_bloqueo           int not null,
   fk_id_usuario           int,
   fk_id_bitacora          int,
   fecha_inicio_bloqueo_usuario datetime,
   fecha_fin_bloqueo_usuario datetime,
   motivo_bloqueo_usuario varchar(50),
   primary key (pk_id_bloqueo)
);


create table tbl_TOKEN_RESTAURAR_CONTRASENA
(
   pk_id_token_restaurar_contrasena int not null,
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
   pk_id_empleado          int not null,
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


create table tbl_PERFIL
(
   pk_id_perfil            int not null,
   puesto_perfil        varchar(50),
   descripcion_perfil   varchar(50),
   habilitado_perfil    bit,
   inabilitado_perfil   bit,
   tipo_perfil          bit,
   primary key (pk_id_perfil)
);




create table tbl_MODULO
(
   pk_id_modulo            int not null,
   nombre_modulo        varchar(50),
   descripcion_modulo   varchar(50),
   habilitado_modulo    bit,
   inabilitado_modulo   bit,
   primary key (pk_id_modulo)
);


create table tbl_USUARIO_PERFIL
(
   fk_id_usuario           int,
   fk_id_perfil            int
);


create table tbl_APLICACION
(
   pk_id_aplicacion        int not null,
   fk_id_reporte           int,
   nombre_aplicacion    varchar(50),
   descripcion_aplicacion varchar(50),
   habilitado_aplicacion bit,
   desabilitado_aplicacion bit,
   primary key (pk_id_aplicacion)
);


create table tbl_BITACORA
(
   pk_id_bitacora          int not null,
   fk_id_usuario           int,
   fk_id_aplicacion        int,
   fecha_bitacora       datetime,
   accion_bitacora      varchar(50),
   ip_bitacora          varchar(50),
   nombre_pc_bitacora   varchar(50),
   login_estado_bitacora bit,
   primary key (pk_id_bitacora)
);


create table tbl_ASIGNAR_PERFIL_CLIENTE
(
   fk_id_perfil            int,
   fk_id_cliente           int
);


create table tbl_CLIENTE
(
   pk_id_cliente           int not null,
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
   numero_clinete       varchar(15),
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


alter table tbl_USUARIO add constraint fk_reference_16 foreign key (fk_id_empleado)
      references tbl_EMPLEADO (pk_id_empleado) on delete restrict on update restrict;

alter table tbl_PERMISO_USUARIO_APLICACION add constraint fk_reference_2 foreign key (fk_id_usuario)
      references tbl_USUARIO (pk_id_usuario) on delete restrict on update restrict;

alter table tbl_PERMISO_USUARIO_APLICACION add constraint fk_reference_3 foreign key (fk_id_aplicacion)
      references tbl_APLICACION (pk_id_aplicacion) on delete restrict on update restrict;

alter table tbl_PERMISO_USUARIO_APLICACION add constraint fk_reference_8 foreign key (fk_id_modulo)
      references tbl_MODULO (pk_id_modulo) on delete restrict on update restrict;

alter table tbl_ASIGNACION_MODULO_APLICACION add constraint fk_reference_6 foreign key (fk_id_modulo)
      references tbl_MODULO (pk_id_modulo) on delete restrict on update restrict;

alter table tbl_ASIGNACION_MODULO_APLICACION add constraint fk_reference_7 foreign key (fk_id_aplicacion)
      references tbl_APLICACION (pk_id_aplicacion) on delete restrict on update restrict;

alter table tbl_PERMISO_PERFIL_APLICACION add constraint fk_reference_10 foreign key (fk_id_perfil)
      references tbl_PERFIL (pk_id_perfil) on delete restrict on update restrict;

alter table tbl_PERMISO_PERFIL_APLICACION add constraint fk_reference_11 foreign key (fk_id_aplicacion)
      references tbl_APLICACION (pk_id_aplicacion) on delete restrict on update restrict;

alter table tbl_PERMISO_PERFIL_APLICACION add constraint fk_reference_9 foreign key (fk_id_modulo)
      references tbl_MODULO (pk_id_modulo) on delete restrict on update restrict;

alter table tbl_BLOQUEO_USUARIO add constraint fk_reference_14 foreign key (fk_id_usuario)
      references tbl_USUARIO (pk_id_usuario) on delete restrict on update restrict;

alter table tbl_BLOQUEO_USUARIO add constraint fk_reference_15 foreign key (fk_id_bitacora)
      references tbl_BITACORA (pk_id_bitacora) on delete restrict on update restrict;

alter table tbl_TOKEN_RESTAURAR_CONTRASENA add constraint fk_reference_17 foreign key (fk_id_usuario)
      references tbl_USUARIO (pk_id_usuario) on delete restrict on update restrict;

alter table tbl_USUARIO_PERFIL add constraint fk_reference_4 foreign key (fk_id_usuario)
      references tbl_USUARIO (pk_id_usuario) on delete restrict on update restrict;

alter table tbl_USUARIO_PERFIL add constraint fk_reference_5 foreign key (fk_id_perfil)
      references tbl_PERFIL (pk_id_perfil) on delete restrict on update restrict;

alter table tbl_APLICACION add constraint fk_reference_21 foreign key (fk_id_reporte)
      references tbl_REPORTES (pk_id_reportes) on delete restrict on update restrict;

alter table tbl_BITACORA add constraint fk_reference_1 foreign key (fk_id_usuario)
      references tbl_USUARIO (pk_id_usuario) on delete restrict on update restrict;

alter table tbl_BITACORA add constraint fk_reference_13 foreign key (fk_id_aplicacion)
      references tbl_APLICACION (pk_id_aplicacion) on delete restrict on update restrict;

alter table tbl_ASIGNAR_PERFIL_CLIENTE add constraint fk_reference_22 foreign key (fk_id_perfil)
      references tbl_PERFIL (pk_id_perfil) on delete restrict on update restrict;

alter table tbl_ASIGNAR_PERFIL_CLIENTE add constraint fk_reference_23 foreign key (fk_id_cliente)
      references tbl_CLIENTE (pk_id_cliente) on delete restrict on update restrict;

alter table tbl_CORREO_CLIENTE add constraint fk_reference_18 foreign key (fk_id_cliente)
      references tbl_CLIENTE (pk_id_cliente) on delete restrict on update restrict;

alter table tbl_NIT_CLIENTE add constraint fk_reference_20 foreign key (fk_id_cliente)
      references tbl_CLIENTE (pk_id_cliente) on delete restrict on update restrict;

alter table tbl_NUMERO_CLIENTE add constraint fk_reference_19 foreign key (fk_id_cliente)
      references tbl_CLIENTE (pk_id_cliente) on delete restrict on update restrict;

alter table tbl_SALARIO_EMPLEADO add constraint fk_reference_12 foreign key (fk_id_empleado)
      references tbl_EMPLEADO (pk_id_empleado) on delete restrict on update restrict;