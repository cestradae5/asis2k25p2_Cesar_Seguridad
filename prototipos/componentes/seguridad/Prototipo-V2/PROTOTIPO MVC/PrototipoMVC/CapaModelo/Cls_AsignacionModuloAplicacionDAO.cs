using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;
using System.Data;


namespace CapaModelo
{
    public class Cls_AsignacionModuloAplicacionDAO
    {
        private Conexion conexion = new Conexion();

        private static readonly string SQL_INSERT =
            "INSERT INTO tbl_ASIGNACION_MODULO_APLICACION (fk_id_modulo, fk_id_aplicacion) VALUES (?, ?)";
        private static readonly string SQL_EXISTE =
            "SELECT COUNT(*) FROM tbl_ASIGNACION_MODULO_APLICACION WHERE fk_id_modulo = ? AND fk_id_aplicacion = ?";
        private static readonly string SQL_SELECT =
            @"SELECT a.fk_id_aplicacion, app.nombre_aplicacion,
                     a.fk_id_modulo, m.nombre_modulo
              FROM tbl_ASIGNACION_MODULO_APLICACION a
              INNER JOIN tbl_APLICACION app ON a.fk_id_aplicacion = app.pk_id_aplicacion
              INNER JOIN tbl_MODULO m ON a.fk_id_modulo = m.pk_id_modulo";

        // Insertar nueva asignación
        public int InsertarAsignacion(int idModulo, int idAplicacion)
        {
            using (OdbcConnection conn = conexion.conexion())
            {
                using (OdbcCommand cmd = new OdbcCommand(SQL_INSERT, conn))
                {
                    // ODBC usa parámetros en orden
                    cmd.Parameters.AddWithValue("?", idModulo);
                    cmd.Parameters.AddWithValue("?", idAplicacion);

                    int filas = cmd.ExecuteNonQuery();
                    conexion.desconexion(conn); // cerramos la conexión
                    return filas;
                }
            }
        }

        // Verificar si ya existe la asignación
        public bool ExisteAsignacion(int idModulo, int idAplicacion)
        {
            using (OdbcConnection conn = conexion.conexion())
            {
                using (OdbcCommand cmd = new OdbcCommand(SQL_EXISTE, conn))
                {
                    cmd.Parameters.AddWithValue("?", idModulo);
                    cmd.Parameters.AddWithValue("?", idAplicacion);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    conexion.desconexion(conn); // cerramos la conexión
                    return count > 0;
                }
            }
        }

        // Obtener todas las asignaciones con JOIN
        public DataTable ObtenerAsignaciones()
        {
            using (OdbcConnection conn = conexion.conexion())
            {
                using (OdbcDataAdapter da = new OdbcDataAdapter(SQL_SELECT, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    conexion.desconexion(conn); // cerramos la conexión
                    return dt;
                }
            }
        }
    }
}