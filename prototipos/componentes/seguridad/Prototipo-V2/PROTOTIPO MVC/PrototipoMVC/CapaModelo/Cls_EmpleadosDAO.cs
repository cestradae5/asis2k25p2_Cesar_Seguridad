// Ernesto David Samayoa Jocol - DAO para Tbl_Empleado
using System;
using System.Collections.Generic;
using System.Data.Odbc;

namespace CapaModelo
{
    public class Cls_EmpleadoDAO
    {
        private Conexion conexion = new Conexion();

        // Consultas SQL
        private static readonly string SQL_SELECT = @"
            SELECT Pk_Id_Empleado, Cmp_Nombres_Empleado, Cmp_Apellidos_Empleado,
                   Cmp_Dpi_Empleado, Cmp_Nit_Empleado, Cmp_Correo_Empleado,
                   Cmp_Telefono_Empleado, Cmp_Genero_Empleado,
                   Cmp_Fecha_Nacimiento_Empleado, Cmp_Fecha_Contratacion__Empleado
            FROM Tbl_Empleado";

        private static readonly string SQL_INSERT = @"
            INSERT INTO Tbl_Empleado
                (Pk_Id_Empleado, Cmp_Nombres_Empleado, Cmp_Apellidos_Empleado,
                 Cmp_Dpi_Empleado, Cmp_Nit_Empleado, Cmp_Correo_Empleado,
                 Cmp_Telefono_Empleado, Cmp_Genero_Empleado,
                 Cmp_Fecha_Nacimiento_Empleado, Cmp_Fecha_Contratacion__Empleado)
            VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";

        private static readonly string SQL_UPDATE = @"
            UPDATE Tbl_Empleado SET
                Cmp_Nombres_Empleado = ?, 
                Cmp_Apellidos_Empleado = ?, 
                Cmp_Dpi_Empleado = ?, 
                Cmp_Nit_Empleado = ?, 
                Cmp_Correo_Empleado = ?, 
                Cmp_Telefono_Empleado = ?, 
                Cmp_Genero_Empleado = ?, 
                Cmp_Fecha_Nacimiento_Empleado = ?, 
                Cmp_Fecha_Contratacion__Empleado = ?
            WHERE Pk_Id_Empleado = ?";

        private static readonly string SQL_DELETE = "DELETE FROM Tbl_Empleado WHERE Pk_Id_Empleado = ?";

        private static readonly string SQL_QUERY = @"
            SELECT Pk_Id_Empleado, Cmp_Nombres_Empleado, Cmp_Apellidos_Empleado,
                   Cmp_Dpi_Empleado, Cmp_Nit_Empleado, Cmp_Correo_Empleado,
                   Cmp_Telefono_Empleado, Cmp_Genero_Empleado,
                   Cmp_Fecha_Nacimiento_Empleado, Cmp_Fecha_Contratacion__Empleado
            FROM Tbl_Empleado
            WHERE Pk_Id_Empleado = ?";

        // --------------------------
        // Obtener todos los empleados
        // --------------------------
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

        // --------------------------
        // Insertar un nuevo empleado
        // --------------------------
        public int InsertarEmpleado(Cls_Empleado emp)
        {
            using (OdbcConnection conn = conexion.conexion())
            {
                OdbcCommand cmd = new OdbcCommand(SQL_INSERT, conn);

                cmd.Parameters.AddWithValue("@Pk_Id_Empleado", emp.PkIdEmpleado);
                cmd.Parameters.AddWithValue("@Cmp_Nombres_Empleado", emp.NombresEmpleado);
                cmd.Parameters.AddWithValue("@Cmp_Apellidos_Empleado", emp.ApellidosEmpleado);
                cmd.Parameters.AddWithValue("@Cmp_Dpi_Empleado", emp.DpiEmpleado);
                cmd.Parameters.AddWithValue("@Cmp_Nit_Empleado", emp.NitEmpleado);
                cmd.Parameters.AddWithValue("@Cmp_Correo_Empleado", emp.CorreoEmpleado);
                cmd.Parameters.AddWithValue("@Cmp_Telefono_Empleado", emp.TelefonoEmpleado);
                cmd.Parameters.AddWithValue("@Cmp_Genero_Empleado", emp.GeneroEmpleado);
                cmd.Parameters.AddWithValue("@Cmp_Fecha_Nacimiento_Empleado", emp.FechaNacimientoEmpleado);
                cmd.Parameters.AddWithValue("@Cmp_Fecha_Contratacion__Empleado", emp.FechaContratacionEmpleado);

                return cmd.ExecuteNonQuery();
            }
        }

        // --------------------------
        // Actualizar empleado existente
        // --------------------------
        public int ActualizarEmpleado(Cls_Empleado emp)
        {
            using (OdbcConnection conn = conexion.conexion())
            {
                OdbcCommand cmd = new OdbcCommand(SQL_UPDATE, conn);

                cmd.Parameters.AddWithValue("@Cmp_Nombres_Empleado", emp.NombresEmpleado);
                cmd.Parameters.AddWithValue("@Cmp_Apellidos_Empleado", emp.ApellidosEmpleado);
                cmd.Parameters.AddWithValue("@Cmp_Dpi_Empleado", emp.DpiEmpleado);
                cmd.Parameters.AddWithValue("@Cmp_Nit_Empleado", emp.NitEmpleado);
                cmd.Parameters.AddWithValue("@Cmp_Correo_Empleado", emp.CorreoEmpleado);
                cmd.Parameters.AddWithValue("@Cmp_Telefono_Empleado", emp.TelefonoEmpleado);
                cmd.Parameters.AddWithValue("@Cmp_Genero_Empleado", emp.GeneroEmpleado);
                cmd.Parameters.AddWithValue("@Cmp_Fecha_Nacimiento_Empleado", emp.FechaNacimientoEmpleado);
                cmd.Parameters.AddWithValue("@Cmp_Fecha_Contratacion__Empleado", emp.FechaContratacionEmpleado);
                cmd.Parameters.AddWithValue("@Pk_Id_Empleado", emp.PkIdEmpleado);

                return cmd.ExecuteNonQuery();
            }
        }

        // --------------------------
        // Borrar un empleado por ID
        // --------------------------
        public int BorrarEmpleado(int idEmpleado)
        {
            using (OdbcConnection conn = conexion.conexion())
            {
                OdbcCommand cmd = new OdbcCommand(SQL_DELETE, conn);
                cmd.Parameters.AddWithValue("@Pk_Id_Empleado", idEmpleado);
                return cmd.ExecuteNonQuery();
            }
        }

        // --------------------------
        // Buscar un empleado por ID
        // --------------------------
        public Cls_Empleado Query(int idEmpleado)
        {
            Cls_Empleado emp = null;
            using (OdbcConnection conn = conexion.conexion())
            {
                OdbcCommand cmd = new OdbcCommand(SQL_QUERY, conn);
                cmd.Parameters.AddWithValue("@Pk_Id_Empleado", idEmpleado);

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
