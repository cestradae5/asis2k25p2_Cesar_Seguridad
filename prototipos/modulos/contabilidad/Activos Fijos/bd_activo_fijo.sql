CREATE DATABASE bd_pruebaContabilidad;
USE bd_pruebaContabilidad;

-- ===============================================
-- TABLAS PARA EL MÓDULO DE CONTABILIDAD
-- ===============================================

CREATE TABLE Tbl_Catalogo_Cuentas (
    Pk_Codigo_Cuenta VARCHAR(20) PRIMARY KEY,
    Cmp_CtaNombre VARCHAR(100) NOT NULL,
    Cmp_CtaMadre VARCHAR(20) NULL,
    Cmp_CtaSaldoInicial DECIMAL(15,2) DEFAULT 0,
    Cmp_CtaCargoMes DECIMAL(15,2) DEFAULT 0,
    Cmp_CtaAbonoMes DECIMAL(15,2) DEFAULT 0,
    Cmp_CtaSaldoActual DECIMAL(15,2) DEFAULT 0,
    Cmp_CtaCargoActual DECIMAL(15,2) DEFAULT 0,
    Cmp_CtaAbonoActual DECIMAL(15,2) DEFAULT 0,
    Cmp_CtaTipo BIT NOT NULL,
    Cmp_CtaNaturaleza BIT NOT NULL,

    CONSTRAINT Fk_CtaMadre 
        FOREIGN KEY (Cmp_CtaMadre)
        REFERENCES Tbl_Catalogo_Cuentas(Pk_Codigo_Cuenta)
        ON UPDATE CASCADE
        ON DELETE RESTRICT
);

-- Tabla para encabezado de Póliza
CREATE TABLE Tbl_EncabezadoPoliza (
    Pk_EncCodigo_Poliza INT AUTO_INCREMENT PRIMARY KEY,
    Pk_Fecha_Poliza DATE NOT NULL,
    Cmp_Concepto_Poliza VARCHAR(200) NOT NULL,
    Cmp_Valor_Poliza DECIMAL(15,2) DEFAULT 0,
    Cmp_Estado_Poliza BIT NOT NULL DEFAULT 1
);

-- Tabla para detalle de Póliza
CREATE TABLE Tbl_DetallePoliza (
    PkFk_EncCodigo_Poliza INT NOT NULL,
    PkFk_Codigo_Cuenta VARCHAR(20) NOT NULL,
    Cmp_Tipo_Poliza BIT NOT NULL,
    Cmp_Valor_Poliza DECIMAL(15,2) NOT NULL CHECK (Cmp_Valor_Poliza >= 0),
    
    PRIMARY KEY (PkFk_EncCodigo_Poliza, PkFk_Codigo_Cuenta),
    
    CONSTRAINT fk_detalle_poliza_encabezado
        FOREIGN KEY (PkFk_EncCodigo_Poliza)
        REFERENCES Tbl_EncabezadoPoliza(Pk_EncCodigo_Poliza)
        ON UPDATE CASCADE
        ON DELETE CASCADE,

    CONSTRAINT fk_detalle_poliza_cuenta
        FOREIGN KEY (PkFk_Codigo_Cuenta)
        REFERENCES Tbl_Catalogo_Cuentas(Pk_Codigo_Cuenta)
        ON UPDATE CASCADE
        ON DELETE RESTRICT
);

-- ===============================================
-- TABLAS PARA ACTIVOS FIJOS
-- ===============================================

CREATE TABLE Tbl_ActivosFijos (
    Pk_Activo_ID INT AUTO_INCREMENT PRIMARY KEY,
    Cmp_Nombre_Activo VARCHAR(150) NOT NULL,
    Cmp_Descripcion TEXT,
    Cmp_Fecha_Adquisicion DATE NOT NULL,
    Cmp_Costo_Adquisicion DECIMAL(15,2) NOT NULL,
    Cmp_Valor_Residual DECIMAL(15,2) NOT NULL DEFAULT 0,
    Cmp_Vida_Util INT NOT NULL,
    Cmp_Metodo_Depreciacion ENUM('LINEA_RECTA') DEFAULT 'LINEA_RECTA',
    Cmp_Estado TINYINT DEFAULT 1,
    Cmp_CtaActivo VARCHAR(20),
    Cmp_CtaDepreciacion VARCHAR(20),

    CONSTRAINT fk_activo_cta_activo 
        FOREIGN KEY (Cmp_CtaActivo) REFERENCES Tbl_Catalogo_Cuentas(Pk_Codigo_Cuenta)
        ON UPDATE CASCADE ON DELETE RESTRICT,

    CONSTRAINT fk_activo_cta_depreciacion
        FOREIGN KEY (Cmp_CtaDepreciacion) REFERENCES Tbl_Catalogo_Cuentas(Pk_Codigo_Cuenta)
        ON UPDATE CASCADE ON DELETE RESTRICT
);

CREATE TABLE Tbl_DepreciacionActivos (
    Pk_Depreciacion_ID INT AUTO_INCREMENT PRIMARY KEY,
    Fk_Activo_ID INT NOT NULL,
    Cmp_Anio INT NOT NULL,
    Cmp_Valor_En_Libros DECIMAL(15,2) NOT NULL,
    Cmp_Depreciacion_Anual DECIMAL(15,2) NOT NULL,
    Cmp_Depreciacion_Acumulada DECIMAL(15,2) NOT NULL,

    CONSTRAINT fk_depreciacion_activo 
        FOREIGN KEY (Fk_Activo_ID) REFERENCES Tbl_ActivosFijos(Pk_Activo_ID)
        ON UPDATE CASCADE ON DELETE CASCADE
);

USE bd_pruebaContabilidad;

-- ===============================================
-- INSERTS: CUENTAS CONTABLES DE GUATEMALA
-- ===============================================

INSERT INTO Tbl_Catalogo_Cuentas 
(Pk_Codigo_Cuenta, Cmp_CtaNombre, Cmp_CtaMadre, Cmp_CtaSaldoActual, Cmp_CtaTipo, Cmp_CtaNaturaleza) VALUES
-- Activo
('1', 'ACTIVO', NULL, 0, 0, 1),
('1.1', 'ACTIVO CORRIENTE', '1', 0, 0, 1),
('1.1.1', 'Caja y Bancos', '1.1', 0, 0, 1),
('1.1.1.01', 'Caja General Quetzales', '1.1.1', 25000, 1, 1),
('1.1.1.02', 'Banco Industrial S.A.', '1.1.1', 150000, 1, 1),
('1.1.1.03', 'Banco G&T Continental', '1.1.1', 75000, 1, 1),

('1.2', 'ACTIVO NO CORRIENTE', '1', 0, 0, 1),
('1.2.1', 'PROPIEDAD, PLANTA Y EQUIPO', '1.2', 0, 0, 1),
('1.2.1.01', 'Terrenos', '1.2.1', 500000, 1, 1),
('1.2.1.02', 'Edificios', '1.2.1', 1200000, 1, 1),
('1.2.1.03', 'Mobiliario y Equipo', '1.2.1', 150000, 1, 1),
('1.2.1.04', 'Equipo de Computación', '1.2.1', 80000, 1, 1),
('1.2.1.05', 'Vehículos', '1.2.1', 300000, 1, 1),

-- Depreciación Acumulada
('1.2.2', 'DEPRECIACIÓN ACUMULADA', '1.2', 0, 0, 0),
('1.2.2.01', 'Depreciación Acumulada Edificios', '1.2.2', 120000, 1, 0),
('1.2.2.02', 'Depreciación Acumulada Mobiliario', '1.2.2', 45000, 1, 0),
('1.2.2.03', 'Depreciación Acumulada Equipo Computación', '1.2.2', 24000, 1, 0),
('1.2.2.04', 'Depreciación Acumulada Vehículos', '1.2.2', 75000, 1, 0),

-- Pasivo
('2', 'PASIVO', NULL, 0, 0, 0),
('2.1', 'PASIVO CORRIENTE', '2', 0, 0, 0),
('2.1.1', 'Cuentas por Pagar', '2.1', 0, 0, 0),
('2.1.1.01', 'Proveedores Nacionales', '2.1.1', 45000, 1, 0),
('2.1.1.02', 'Proveedores Internacionales', '2.1.1', 28000, 1, 0),

-- Capital
('3', 'CAPITAL', NULL, 0, 0, 0),
('3.1', 'CAPITAL SOCIAL', '3', 0, 0, 0),
('3.1.1', 'Capital Suscrito', '3.1', 2000000, 1, 0),
('3.2', 'RESERVAS', '3', 0, 0, 0),
('3.2.1', 'Reserva Legal', '3.2', 150000, 1, 0),

-- Gastos
('5', 'GASTOS', NULL, 0, 0, 1),
('5.1', 'GASTOS DE OPERACIÓN', '5', 0, 0, 1),
('5.1.1', 'Depreciación del Ejercicio', '5.1', 0, 1, 1);

-- ===============================================
-- INSERTS: ACTIVOS FIJOS
-- ===============================================

INSERT INTO Tbl_ActivosFijos (
    Cmp_Nombre_Activo, Cmp_Descripcion, Cmp_Fecha_Adquisicion,
    Cmp_Costo_Adquisicion, Cmp_Valor_Residual, Cmp_Vida_Util,
    Cmp_CtaActivo, Cmp_CtaDepreciacion
) VALUES 
('Edificio Corporativo Zona 10', 'Edificio de oficinas corporativas en Blvd. Los Próceres, Zona 10', '2020-03-15', 2500000.00, 500000.00, 40, '1.2.1.02', '1.2.2.01'),
('Toyota Hilux 2023', 'Pick-up para distribución en interior del país', '2023-01-10', 285000.00, 57000.00, 8, '1.2.1.05', '1.2.2.04'),
('Hyundai Tucson 2023', 'Vehículo ejecutivo para gerencia', '2023-02-20', 220000.00, 44000.00, 7, '1.2.1.05', '1.2.2.04'),
('Servidores Dell PowerEdge', 'Servidores para centro de datos empresarial', '2023-05-15', 120000.00, 12000.00, 5, '1.2.1.04', '1.2.2.03'),
('Computadoras HP EliteDesk', '30 unidades para personal administrativo', '2023-06-01', 225000.00, 22500.00, 4, '1.2.1.04', '1.2.2.03'),
('Mobiliario Ejecutivo Oficinas', 'Muebles para áreas ejecutivas y salas de reunión', '2023-03-01', 180000.00, 18000.00, 10, '1.2.1.03', '1.2.2.02'),
('Equipo de Cafetería', 'Mobiliario para cafetería de empleados', '2023-04-10', 45000.00, 4500.00, 8, '1.2.1.03', '1.2.2.02'),
('Máquina de Confección JUKI', 'Máquina industrial para fábrica textil', '2023-02-15', 85000.00, 8500.00, 12, '1.2.1.03', '1.2.2.02'),
('Equipo de Empaque Automático', 'Sistema automático para empaque de productos', '2023-07-20', 320000.00, 32000.00, 15, '1.2.1.03', '1.2.2.02');

-- ===============================================
-- INSERTS: PÓLIZAS Y DETALLES
-- ===============================================

INSERT INTO Tbl_EncabezadoPoliza (Pk_Fecha_Poliza, Cmp_Concepto_Poliza, Cmp_Valor_Poliza) VALUES
('2024-01-15', 'Compra de equipo de computación para oficina central', 225000.00),
('2024-01-20', 'Adquisición de vehículo empresarial Toyota Hilux', 285000.00),
('2024-02-01', 'Depreciación mensual de activos fijos', 18500.00);

INSERT INTO Tbl_DetallePoliza (PkFk_EncCodigo_Poliza, PkFk_Codigo_Cuenta, Cmp_Tipo_Poliza, Cmp_Valor_Poliza) VALUES
(1, '1.2.1.04', 1, 225000.00),
(1, '1.1.1.02', 0, 225000.00),
(2, '1.2.1.05', 1, 285000.00),
(2, '1.1.1.03', 0, 285000.00),
(3, '5.1.1', 1, 18500.00),
(3, '1.2.2.01', 0, 8500.00),
(3, '1.2.2.02', 0, 6500.00),
(3, '1.2.2.03', 0, 2500.00),
(3, '1.2.2.04', 0, 1000.00);

