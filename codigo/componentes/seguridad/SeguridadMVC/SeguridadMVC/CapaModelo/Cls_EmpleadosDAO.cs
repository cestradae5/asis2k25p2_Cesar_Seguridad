// Ernesto David Samayoa Jocol - DAO para Tbl_Empleado
using System;
using System.Collections.Generic;
using System.Data.Odbc;

namespace Capa_Modelo_Seguridad
{
    public class Cls_EmpleadoDAO
    {
        private Cls_Conexion conexion = new Cls_Conexion();

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
        public List<Cls_Empleado> fun_ObtenerEmpleados()
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
                        iPkIdEmpleado = reader.GetInt32(0),
                        sNombresEmpleado = reader.GetString(1),
                        sApellidosEmpleado = reader.GetString(2),
                        lDpiEmpleado = reader.GetInt64(3),
                        lNitEmpleado = reader.GetInt64(4),
                        sCorreoEmpleado = reader.GetString(5),
                        sTelefonoEmpleado = reader.GetString(6),
                        bGeneroEmpleado = reader.GetBoolean(7),
                        dFechaNacimientoEmpleado = reader.GetDateTime(8),
                        dFechaContratacionEmpleado = reader.GetDateTime(9)
                    };
                    lista.Add(emp);
                }
            }
            return lista;
        }

        // --------------------------
        // Insertar un nuevo empleado
        // --------------------------
        public int fun_InsertarEmpleado(Cls_Empleado emp)
        {
            using (OdbcConnection conn = conexion.conexion())
            {
                OdbcCommand cmd = new OdbcCommand(SQL_INSERT, conn);

                cmd.Parameters.AddWithValue("@Pk_Id_Empleado", emp.iPkIdEmpleado);
                cmd.Parameters.AddWithValue("@Cmp_Nombres_Empleado", emp.sNombresEmpleado);
                cmd.Parameters.AddWithValue("@Cmp_Apellidos_Empleado", emp.sApellidosEmpleado);
                cmd.Parameters.AddWithValue("@Cmp_Dpi_Empleado", emp.lDpiEmpleado);
                cmd.Parameters.AddWithValue("@Cmp_Nit_Empleado", emp.lNitEmpleado);
                cmd.Parameters.AddWithValue("@Cmp_Correo_Empleado", emp.sCorreoEmpleado);
                cmd.Parameters.AddWithValue("@Cmp_Telefono_Empleado", emp.sTelefonoEmpleado);
                cmd.Parameters.AddWithValue("@Cmp_Genero_Empleado", emp.bGeneroEmpleado);
                cmd.Parameters.AddWithValue("@Cmp_Fecha_Nacimiento_Empleado", emp.dFechaNacimientoEmpleado);
                cmd.Parameters.AddWithValue("@Cmp_Fecha_Contratacion__Empleado", emp.dFechaContratacionEmpleado);

                return cmd.ExecuteNonQuery();
            }
        }

        // --------------------------
        // Actualizar empleado existente
        // --------------------------
        public int fun_ActualizarEmpleado(Cls_Empleado emp)
        {
            using (OdbcConnection conn = conexion.conexion())
            {
                OdbcCommand cmd = new OdbcCommand(SQL_UPDATE, conn);

                cmd.Parameters.AddWithValue("@Cmp_Nombres_Empleado", emp.sNombresEmpleado);
                cmd.Parameters.AddWithValue("@Cmp_Apellidos_Empleado", emp.sApellidosEmpleado);
                cmd.Parameters.AddWithValue("@Cmp_Dpi_Empleado", emp.lDpiEmpleado);
                cmd.Parameters.AddWithValue("@Cmp_Nit_Empleado", emp.lNitEmpleado);
                cmd.Parameters.AddWithValue("@Cmp_Correo_Empleado", emp.sCorreoEmpleado);
                cmd.Parameters.AddWithValue("@Cmp_Telefono_Empleado", emp.sTelefonoEmpleado);
                cmd.Parameters.AddWithValue("@Cmp_Genero_Empleado", emp.bGeneroEmpleado);
                cmd.Parameters.AddWithValue("@Cmp_Fecha_Nacimiento_Empleado", emp.dFechaNacimientoEmpleado);
                cmd.Parameters.AddWithValue("@Cmp_Fecha_Contratacion__Empleado", emp.dFechaContratacionEmpleado);
                cmd.Parameters.AddWithValue("@Pk_Id_Empleado", emp.iPkIdEmpleado);

                return cmd.ExecuteNonQuery();
            }
        }

        // --------------------------
        // Borrar un empleado por ID
        // --------------------------
        public int fun_BorrarEmpleado(int iIdEmpleado)
        {
            using (OdbcConnection conn = conexion.conexion())
            {
                OdbcCommand cmd = new OdbcCommand(SQL_DELETE, conn);
                cmd.Parameters.AddWithValue("@Pk_Id_Empleado", iIdEmpleado);
                return cmd.ExecuteNonQuery();
            }
        }


        //Nuevo metodo Ernesto Samayoa Jocol 0901-22-3415
        public bool fun_EmpleadoTieneUsuario(int idEmpleado)
        {
            string query = "SELECT COUNT(*) FROM Tbl_Usuario WHERE Fk_Id_Empleado = ?";
            using (OdbcConnection conn = conexion.conexion())
            using (OdbcCommand cmd = new OdbcCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@idEmpleado", idEmpleado);
                int cantidad = Convert.ToInt32(cmd.ExecuteScalar());
                return cantidad > 0;
            }
        }




        // --------------------------
        // Buscar un empleado por ID
        // --------------------------
        public Cls_Empleado Query(int iIdEmpleado)
        {
            Cls_Empleado emp = null;
            using (OdbcConnection conn = conexion.conexion())
            {
                OdbcCommand cmd = new OdbcCommand(SQL_QUERY, conn);
                cmd.Parameters.AddWithValue("@Pk_Id_Empleado", iIdEmpleado);

                OdbcDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    emp = new Cls_Empleado
                    {
                        iPkIdEmpleado = reader.GetInt32(0),
                        sNombresEmpleado = reader.GetString(1),
                        sApellidosEmpleado = reader.GetString(2),
                        lDpiEmpleado = reader.GetInt64(3),
                        lNitEmpleado = reader.GetInt64(4),
                        sCorreoEmpleado = reader.GetString(5),
                        sTelefonoEmpleado = reader.GetString(6),
                        bGeneroEmpleado = reader.GetBoolean(7),
                        dFechaNacimientoEmpleado = reader.GetDateTime(8),
                        dFechaContratacionEmpleado = reader.GetDateTime(9)
                    };
                }
            }
            return emp;
        }
    }
}
