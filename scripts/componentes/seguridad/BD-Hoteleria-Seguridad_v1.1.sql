CREATE DATABASE IF NOT EXISTS hoteleria;
USE hoteleria;


CREATE TABLE tbl_usuario (
    id_usuario INT AUTO_INCREMENT PRIMARY KEY,
    nombre_usuario_usuario VARCHAR(50) NOT NULL,
    apellido_usuario_usuario VARCHAR(50) NOT NULL,
    contrasena_usuario_usuario VARCHAR(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;


CREATE TABLE tbl_perfil (
    id_perfil INT AUTO_INCREMENT PRIMARY KEY,
    puesto_perfil_perfil VARCHAR(50) NOT NULL,
    descripcion_perfil_perfil VARCHAR(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;


CREATE TABLE tbl_modulo (
    id_modulo INT AUTO_INCREMENT PRIMARY KEY,
    nombre_modulo_modulo VARCHAR(50) NOT NULL,
    descripcion_modulo_modulo VARCHAR(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;


CREATE TABLE tbl_aplicacion (
    id_aplicacion INT AUTO_INCREMENT PRIMARY KEY,
    nombre_aplicacion_aplicacion VARCHAR(50) NOT NULL,
    descripcion_aplicacion_aplicacion VARCHAR(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;


CREATE TABLE tbl_asignar_perfil_usuario (
    id_usuario INT NOT NULL,
    id_perfil INT NOT NULL,
    PRIMARY KEY (id_usuario, id_perfil),
    FOREIGN KEY (id_usuario) REFERENCES tbl_usuario(id_usuario) ON DELETE NO ACTION ON UPDATE NO ACTION,
    FOREIGN KEY (id_perfil) REFERENCES tbl_perfil(id_perfil) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;


CREATE TABLE tbl_asignacion_modulo_aplicacion (
    id_modulo INT NOT NULL,
    id_aplicacion INT NOT NULL,
    PRIMARY KEY (id_modulo, id_aplicacion),
    FOREIGN KEY (id_modulo) REFERENCES tbl_modulo(id_modulo) ON DELETE NO ACTION ON UPDATE NO ACTION,
    FOREIGN KEY (id_aplicacion) REFERENCES tbl_aplicacion(id_aplicacion) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;


CREATE TABLE tbl_permiso_aplicacion_perfil (
    id_perfil INT NOT NULL,
    id_aplicacion INT NOT NULL,
    id_modulo INT NOT NULL,
    ingresar_permiso_aplicacion_perfil BIT,
    consultar_permiso_aplicacion_perfil BIT,
    modificar_permiso_aplicacion_perfil BIT,
    eliminar_permiso_aplicacion_perfil BIT,
    imprimir_permiso_aplicacion_perfil BIT,
    PRIMARY KEY (id_perfil, id_aplicacion, id_modulo),
    FOREIGN KEY (id_perfil) REFERENCES tbl_perfil(id_perfil) ON DELETE NO ACTION ON UPDATE NO ACTION,
    FOREIGN KEY (id_aplicacion) REFERENCES tbl_aplicacion(id_aplicacion) ON DELETE NO ACTION ON UPDATE NO ACTION,
    FOREIGN KEY (id_modulo) REFERENCES tbl_modulo(id_modulo) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;


CREATE TABLE tbl_permisos_aplicacion_usuario (
    id_usuario INT NOT NULL,
    id_aplicacion INT NOT NULL,
    ingresar_permiso_aplicacion_usuario BIT,
    consultar_permiso_aplicacion_usuario BIT,
    modificar_permiso_aplicacion_usuario BIT,
    eliminar_permiso_aplicacion_usuario BIT,
    imprimir_permiso_aplicacion_usuario BIT,
    PRIMARY KEY (id_usuario, id_aplicacion),
    FOREIGN KEY (id_usuario) REFERENCES tbl_usuario(id_usuario) ON DELETE NO ACTION ON UPDATE NO ACTION,
    FOREIGN KEY (id_aplicacion) REFERENCES tbl_aplicacion(id_aplicacion) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;


CREATE TABLE tbl_bitacora (
    id_bitacora INT AUTO_INCREMENT PRIMARY KEY,
    fecha_bitacora_bitacora DATETIME,
    accion_bitacora_bitacora VARCHAR(50),
    id_usuario_bitacora INT,
    id_aplicacion_bitacora INT,
    ip_bitacora VARCHAR(45),
    nombre_pc_bitacora VARCHAR(50),
    intentos_fallidos_bitacora INT DEFAULT 0,
    FOREIGN KEY (id_usuario_bitacora) REFERENCES tbl_usuario(id_usuario) ON DELETE NO ACTION ON UPDATE NO ACTION,
    FOREIGN KEY (id_aplicacion_bitacora) REFERENCES tbl_aplicacion(id_aplicacion) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;


CREATE TABLE tbl_failed_logins (
    id_failed INT AUTO_INCREMENT PRIMARY KEY,
    id_usuario_failed INT NULL,
    username_attempt_failed VARCHAR(50),
    fecha_attempt_failed DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    ip_failed VARCHAR(45),
    user_agent_failed VARCHAR(255),
    motivo_failed VARCHAR(50),
    FOREIGN KEY (id_usuario_failed) REFERENCES tbl_usuario(id_usuario) ON DELETE SET NULL ON UPDATE NO ACTION,
    INDEX idx_failed_usuario (id_usuario_failed)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;


CREATE TABLE tbl_password_resets (
    id_reset INT AUTO_INCREMENT PRIMARY KEY,
    id_usuario_reset INT NOT NULL,
    token_reset CHAR(64) NOT NULL UNIQUE,
    creado_en_reset DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    expiracion_reset DATETIME NOT NULL,
    usado_reset BOOLEAN DEFAULT FALSE,
    FOREIGN KEY (id_usuario_reset) REFERENCES tbl_usuario(id_usuario) ON DELETE CASCADE ON UPDATE NO ACTION,
    INDEX idx_reset_usuario (id_usuario_reset)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;


CREATE TABLE tbl_account_lockout (
    id_lock INT AUTO_INCREMENT PRIMARY KEY,
    id_usuario_lock INT NOT NULL,
    bloqueado_desde_lock DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    bloqueado_hasta_lock DATETIME,
    motivo_lock VARCHAR(50),
    forzado_por_lock INT NULL,
    FOREIGN KEY (id_usuario_lock) REFERENCES tbl_usuario(id_usuario) ON DELETE CASCADE ON UPDATE NO ACTION,
    FOREIGN KEY (forzado_por_lock) REFERENCES tbl_usuario(id_usuario) ON DELETE SET NULL ON UPDATE NO ACTION,
    INDEX idx_lock_usuario (id_usuario_lock)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE tbl_cliente (
    id_cliente INT AUTO_INCREMENT PRIMARY KEY,
    nombre_cliente VARCHAR(50) NOT NULL,
    apellido_cliente VARCHAR(50) NOT NULL,
    correo_cliente VARCHAR(100),
    dpi_pasaporte_cliente VARCHAR(20),
    telefono_cliente VARCHAR(15),
    direccion_cliente VARCHAR(100),
    fecha_registro_cliente DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    fecha_checkin_cliente DATETIME,
    fecha_checkout_cliente DATETIME,
    dias_estadia_cliente INT,
    estado_cliente VARCHAR(50) DEFAULT 'activo',
    contrasena_cliente_cliente VARCHAR(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
