// Ernesto David Samayoa Jocol - DAO para tbl_SALARIO_EMPLEADO
using System;
using System.Collections.Generic;
using System.Data.Odbc;

namespace CapaModelo
{
    public class Cls_SalarioEmpleadosDAO
    {
        private Conexion conexion = new Conexion();

        // Consultas SQL con JOIN para traer nombres del empleado
        private static readonly string SQL_SELECT = @"
            SELECT s.pk_id_salario, s.fk_id_empleado, s.monto_salario_empleado,
                   s.fecha_inicio_salario_empleado, s.fecha_fin_salario_empleado,
                   s.estado_salario_empleado,
                   e.nombres_empleado, e.apellidos_empleado
            FROM tbl_SALARIO_EMPLEADO s
            INNER JOIN tbl_EMPLEADO e ON s.fk_id_empleado = e.pk_id_empleado";

        private static readonly string SQL_QUERY = @"
            SELECT s.pk_id_salario, s.fk_id_empleado, s.monto_salario_empleado,
                   s.fecha_inicio_salario_empleado, s.fecha_fin_salario_empleado,
                   s.estado_salario_empleado,
                   e.nombres_empleado, e.apellidos_empleado
            FROM tbl_SALARIO_EMPLEADO s
            INNER JOIN tbl_EMPLEADO e ON s.fk_id_empleado = e.pk_id_empleado
            WHERE s.pk_id_salario = ?";

        private static readonly string SQL_QUERY_BY_EMPLEADO = @"
            SELECT s.pk_id_salario, s.fk_id_empleado, s.monto_salario_empleado,
                   s.fecha_inicio_salario_empleado, s.fecha_fin_salario_empleado,
                   s.estado_salario_empleado,
                   e.nombres_empleado, e.apellidos_empleado
            FROM tbl_SALARIO_EMPLEADO s
            INNER JOIN tbl_EMPLEADO e ON s.fk_id_empleado = e.pk_id_empleado
            WHERE s.fk_id_empleado = ?";

        private static readonly string SQL_INSERT = @"
            INSERT INTO tbl_SALARIO_EMPLEADO
                (pk_id_salario, fk_id_empleado, monto_salario_empleado,
                 fecha_inicio_salario_empleado, fecha_fin_salario_empleado,
                 estado_salario_empleado)
            VALUES (?, ?, ?, ?, ?, ?)";

        private static readonly string SQL_UPDATE = @"
            UPDATE tbl_SALARIO_EMPLEADO SET
                fk_id_empleado = ?, 
                monto_salario_empleado = ?, 
                fecha_inicio_salario_empleado = ?, 
                fecha_fin_salario_empleado = ?, 
                estado_salario_empleado = ?
            WHERE pk_id_salario = ?";

        private static readonly string SQL_DELETE = @"
            DELETE FROM tbl_SALARIO_EMPLEADO WHERE pk_id_salario = ?";


        // --------------------------
        // Obtener todos los salarios
        // --------------------------
        public List<Cls_SalarioEmpleados> ObtenerSalarios()
        {
            List<Cls_SalarioEmpleados> lista = new List<Cls_SalarioEmpleados>();
            using (OdbcConnection conn = conexion.conexion())
            {
                OdbcCommand cmd = new OdbcCommand(SQL_SELECT, conn);
                OdbcDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Cls_SalarioEmpleados sal = new Cls_SalarioEmpleados
                    {
                        PkIdSalario = reader.GetInt32(0),
                        FkIdEmpleado = reader.GetInt32(1),
                        MontoSalario = (float)reader.GetDouble(2),
                        FechaInicioSalario = reader.GetDateTime(3),
                        FechaFinSalario = reader.GetDateTime(4),
                        EstadoSalario = reader.GetBoolean(5),
                        NombresEmpleado = reader.GetString(6),
                        ApellidosEmpleado = reader.GetString(7)
                    };
                    lista.Add(sal);
                }
            }
            return lista;
        }

        // --------------------------
        // Buscar un salario por ID
        // --------------------------
        public Cls_SalarioEmpleados Query(int idSalario)
        {
            Cls_SalarioEmpleados sal = null;
            using (OdbcConnection conn = conexion.conexion())
            {
                OdbcCommand cmd = new OdbcCommand(SQL_QUERY, conn);
                cmd.Parameters.AddWithValue("@pk_id_salario", idSalario);

                OdbcDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    sal = new Cls_SalarioEmpleados
                    {
                        PkIdSalario = reader.GetInt32(0),
                        FkIdEmpleado = reader.GetInt32(1),
                        MontoSalario = (float)reader.GetDouble(2),
                        FechaInicioSalario = reader.GetDateTime(3),
                        FechaFinSalario = reader.GetDateTime(4),
                        EstadoSalario = reader.GetBoolean(5),
                        NombresEmpleado = reader.GetString(6),
                        ApellidosEmpleado = reader.GetString(7)
                    };
                }
            }
            return sal;
        }

        // --------------------------
        // Buscar salarios por empleado
        // --------------------------
        public List<Cls_SalarioEmpleados> BuscarPorEmpleado(int idEmpleado)
        {
            List<Cls_SalarioEmpleados> lista = new List<Cls_SalarioEmpleados>();
            using (OdbcConnection conn = conexion.conexion())
            {
                OdbcCommand cmd = new OdbcCommand(SQL_QUERY_BY_EMPLEADO, conn);
                cmd.Parameters.AddWithValue("@fk_id_empleado", idEmpleado);

                OdbcDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Cls_SalarioEmpleados sal = new Cls_SalarioEmpleados
                    {
                        PkIdSalario = reader.GetInt32(0),
                        FkIdEmpleado = reader.GetInt32(1),
                        MontoSalario = (float)reader.GetDouble(2),
                        FechaInicioSalario = reader.GetDateTime(3),
                        FechaFinSalario = reader.GetDateTime(4),
                        EstadoSalario = reader.GetBoolean(5),
                        NombresEmpleado = reader.GetString(6),
                        ApellidosEmpleado = reader.GetString(7)
                    };
                    lista.Add(sal);
                }
            }
            return lista;
        }

        // --------------------------
        // Insertar salario
        // --------------------------
        public int InsertarSalario(Cls_SalarioEmpleados sal)
        {
            using (OdbcConnection conn = conexion.conexion())
            {
                OdbcCommand cmd = new OdbcCommand(SQL_INSERT, conn);
                cmd.Parameters.AddWithValue("@pk_id_salario", sal.PkIdSalario);
                cmd.Parameters.AddWithValue("@fk_id_empleado", sal.FkIdEmpleado);
                cmd.Parameters.AddWithValue("@monto_salario_empleado", sal.MontoSalario);
                cmd.Parameters.AddWithValue("@fecha_inicio_salario_empleado", sal.FechaInicioSalario);
                cmd.Parameters.AddWithValue("@fecha_fin_salario_empleado", sal.FechaFinSalario);
                cmd.Parameters.AddWithValue("@estado_salario_empleado", sal.EstadoSalario);
                return cmd.ExecuteNonQuery();
            }
        }

        // --------------------------
        // Actualizar salario
        // --------------------------
        public int ActualizarSalario(Cls_SalarioEmpleados sal)
        {
            using (OdbcConnection conn = conexion.conexion())
            {
                OdbcCommand cmd = new OdbcCommand(SQL_UPDATE, conn);
                cmd.Parameters.AddWithValue("@fk_id_empleado", sal.FkIdEmpleado);
                cmd.Parameters.AddWithValue("@monto_salario_empleado", sal.MontoSalario);
                cmd.Parameters.AddWithValue("@fecha_inicio_salario_empleado", sal.FechaInicioSalario);
                cmd.Parameters.AddWithValue("@fecha_fin_salario_empleado", sal.FechaFinSalario);
                cmd.Parameters.AddWithValue("@estado_salario_empleado", sal.EstadoSalario);
                cmd.Parameters.AddWithValue("@pk_id_salario", sal.PkIdSalario);
                return cmd.ExecuteNonQuery();
            }
        }

        // --------------------------
        // Borrar salario
        // --------------------------
        public int BorrarSalario(int idSalario)
        {
            using (OdbcConnection conn = conexion.conexion())
            {
                OdbcCommand cmd = new OdbcCommand(SQL_DELETE, conn);
                cmd.Parameters.AddWithValue("@pk_id_salario", idSalario);
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
