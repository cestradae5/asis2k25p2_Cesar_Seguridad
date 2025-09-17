Create Database Bd_ControlEmpleados;
use Bd_ControlEmpleados;

CREATE TABLE `Tbl_Empleados` (
  `Pk_Codigo_empleado` INT NOT NULL PRIMARY KEY,
  `Cmp_Nombre_completo` VARCHAR(75) NOT NULL,
  `Cmp_Puesto` VARCHAR(75) NOT NULL,
  `Cmp_Departamento` VARCHAR(75) NOT NULL,
  `Cmp_Estado` BIT NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;

CREATE TABLE `Tbl_Registro_Empleados` (
  `Pk_Codigo_Registro` INT NOT NULL PRIMARY KEY,
  `Fk_Codigo_Empleado` INT NOT NULL,
  `Cmp_Fecha_Registro` DATE NOT NULL,
  `Cmp_Hora_Entrada` TIME NOT NULL,
  `Cmp_Hora_Salida` TIME DEFAULT NULL,
  `Cmp_Total_de_horas` INT DEFAULT NULL,
  `Cmp_Estado` BIT NOT NULL,
  FOREIGN KEY (`Fk_Codigo_Empleado`) REFERENCES `Tbl_empleados`(`Pk_Codigo_Empleado`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;