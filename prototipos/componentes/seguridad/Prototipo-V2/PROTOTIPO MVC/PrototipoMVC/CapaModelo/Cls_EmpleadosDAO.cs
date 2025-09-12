// Ernesto David Samayoa Jocol - DAO para tbl_EMPLEADO
using System;
using System.Collections.Generic;
using System.Data.Odbc;

namespace CapaModelo
{
    public class Cls_EmpleadoDAO
    {
        private Conexion conexion = new Conexion();

        private static readonly string SQL_SELECT = @"
            SELECT pk_id_empleado, nombres_empleado, apellidos_empleado,
                   dpi_empleado, nit_empleado, correo_empleado,
                   telefono_empleado, genero_empleado,
                   fecha_nacimiento_empleado, fecha_contratacion_empleado
            FROM tbl_EMPLEADO";

        private static readonly string SQL_INSERT = @"
            INSERT INTO tbl_EMPLEADO
                (pk_id_empleado, nombres_empleado, apellidos_empleado,
                 dpi_empleado, nit_empleado, correo_empleado,
                 telefono_empleado, genero_empleado,
                 fecha_nacimiento_empleado, fecha_contratacion_empleado)
            VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";

        private static readonly string SQL_UPDATE = @"
            UPDATE tbl_EMPLEADO SET
                nombres_empleado = ?, 
                apellidos_empleado = ?, 
                dpi_empleado = ?, 
                nit_empleado = ?, 
                correo_empleado = ?, 
                telefono_empleado = ?, 
                genero_empleado = ?, 
                fecha_nacimiento_empleado = ?, 
                fecha_contratacion_empleado = ?
            WHERE pk_id_empleado = ?";

        private static readonly string SQL_DELETE = "DELETE FROM tbl_EMPLEADO WHERE pk_id_empleado = ?";

        private static readonly string SQL_QUERY = @"
            SELECT pk_id_empleado, nombres_empleado, apellidos_empleado,
                   dpi_empleado, nit_empleado, correo_empleado,
                   telefono_empleado, genero_empleado,
                   fecha_nacimiento_empleado, fecha_contratacion_empleado
            FROM tbl_EMPLEADO
            WHERE pk_id_empleado = ?";

        // Obtener todos los empleados
        public List<Cls_Empleado> ObtenerEmpleados()
        {
            List<Cls_Empleado> lista = new List<Cls_Empleado>();
            using (OdbcConnection conn = conexion.conexion())
            {
                OdbcCommand cmd = new OdbcCommand(SQL_SELECT, conn);
                OdbcDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Cls_Empleado emp = new Cls_Empleado
                    {
                        PkIdEmpleado = reader.GetInt32(0),
                        NombresEmpleado = reader.GetString(1),
                        ApellidosEmpleado = reader.GetString(2),
                        DpiEmpleado = reader.GetInt64(3),
                        NitEmpleado = reader.GetInt64(4),
                        CorreoEmpleado = reader.GetString(5),
                        TelefonoEmpleado = reader.GetString(6),
                        GeneroEmpleado = reader.GetBoolean(7),
                        FechaNacimientoEmpleado = reader.GetDateTime(8),
                        FechaContratacionEmpleado = reader.GetDateTime(9)
                    };
                    lista.Add(emp);
                }
            }
            return lista;
        }

        // Insertar un nuevo empleado
        public int InsertarEmpleado(Cls_Empleado emp)
        {
            using (OdbcConnection conn = conexion.conexion())
            {
                OdbcCommand cmd = new OdbcCommand(SQL_INSERT, conn);

                cmd.Parameters.AddWithValue("@pk_id_empleado", emp.PkIdEmpleado);
                cmd.Parameters.AddWithValue("@nombres_empleado", emp.NombresEmpleado);
                cmd.Parameters.AddWithValue("@apellidos_empleado", emp.ApellidosEmpleado);
                cmd.Parameters.AddWithValue("@dpi_empleado", emp.DpiEmpleado);
                cmd.Parameters.AddWithValue("@nit_empleado", emp.NitEmpleado);
                cmd.Parameters.AddWithValue("@correo_empleado", emp.CorreoEmpleado);
                cmd.Parameters.AddWithValue("@telefono_empleado", emp.TelefonoEmpleado);
                cmd.Parameters.AddWithValue("@genero_empleado", emp.GeneroEmpleado);
                cmd.Parameters.AddWithValue("@fecha_nacimiento_empleado", emp.FechaNacimientoEmpleado);
                cmd.Parameters.AddWithValue("@fecha_contratacion_empleado", emp.FechaContratacionEmpleado);

                return cmd.ExecuteNonQuery();
            }
        }

        // Actualizar empleado
        public int ActualizarEmpleado(Cls_Empleado emp)
        {
            using (OdbcConnection conn = conexion.conexion())
            {
                OdbcCommand cmd = new OdbcCommand(SQL_UPDATE, conn);

                cmd.Parameters.AddWithValue("@nombres_empleado", emp.NombresEmpleado);
                cmd.Parameters.AddWithValue("@apellidos_empleado", emp.ApellidosEmpleado);
                cmd.Parameters.AddWithValue("@dpi_empleado", emp.DpiEmpleado);
                cmd.Parameters.AddWithValue("@nit_empleado", emp.NitEmpleado);
                cmd.Parameters.AddWithValue("@correo_empleado", emp.CorreoEmpleado);
                cmd.Parameters.AddWithValue("@telefono_empleado", emp.TelefonoEmpleado);
                cmd.Parameters.AddWithValue("@genero_empleado", emp.GeneroEmpleado);
                cmd.Parameters.AddWithValue("@fecha_nacimiento_empleado", emp.FechaNacimientoEmpleado);
                cmd.Parameters.AddWithValue("@fecha_contratacion_empleado", emp.FechaContratacionEmpleado);
                cmd.Parameters.AddWithValue("@pk_id_empleado", emp.PkIdEmpleado);

                return cmd.ExecuteNonQuery();
            }
        }

        // Borrar empleado
        public int BorrarEmpleado(int idEmpleado)
        {
            using (OdbcConnection conn = conexion.conexion())
            {
                OdbcCommand cmd = new OdbcCommand(SQL_DELETE, conn);
                cmd.Parameters.AddWithValue("@pk_id_empleado", idEmpleado);
                return cmd.ExecuteNonQuery();
            }
        }

        // Buscar empleado por ID
        public Cls_Empleado Query(int idEmpleado)
        {
            Cls_Empleado emp = null;
            using (OdbcConnection conn = conexion.conexion())
            {
                OdbcCommand cmd = new OdbcCommand(SQL_QUERY, conn);
                cmd.Parameters.AddWithValue("@pk_id_empleado", idEmpleado);

                OdbcDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    emp = new Cls_Empleado
                    {
                        PkIdEmpleado = reader.GetInt32(0),
                        NombresEmpleado = reader.GetString(1),
                        ApellidosEmpleado = reader.GetString(2),
                        DpiEmpleado = reader.GetInt64(3),
                        NitEmpleado = reader.GetInt64(4),
                        CorreoEmpleado = reader.GetString(5),
                        TelefonoEmpleado = reader.GetString(6),
                        GeneroEmpleado = reader.GetBoolean(7),
                        FechaNacimientoEmpleado = reader.GetDateTime(8),
                        FechaContratacionEmpleado = reader.GetDateTime(9)
                    };
                }
            }
            return emp;
        }
    }
}

