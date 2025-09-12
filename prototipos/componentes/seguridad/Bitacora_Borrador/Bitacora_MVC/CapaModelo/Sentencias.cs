using System;
using System.Data;
using System.Data.Odbc;

namespace CapaModelo
{
    public class Sentencias
    {
        private readonly Conexion con = new Conexion();

        // Devuelve un DataAdapter con SELECT * de la tabla indicada
        public OdbcDataAdapter llenarTbl(string tabla)
        {
            string sql = $"SELECT * FROM {tabla};";
            return new OdbcDataAdapter(sql, con.conexion());
        }

        // Consulta de bitácora con joins y alias
        public DataTable ObtenerBitacora()
        {
            string sql = @"
                SELECT  b.pk_id_bitacora        AS id,
                        COALESCE(u.nombre_usuario, '')    AS usuario,
                        COALESCE(a.nombre_aplicacion, '') AS aplicacion,
                        b.fecha_bitacora        AS fecha,
                        b.accion_bitacora       AS accion,
                        b.ip_bitacora           AS ip,
                        b.nombre_pc_bitacora    AS equipo,
                        b.login_estado_bitacora AS login
                FROM tbl_BITACORA b
                LEFT JOIN tbl_USUARIO u    ON u.pk_id_usuario = b.fk_id_usuario
                LEFT JOIN tbl_APLICACION a ON a.pk_id_aplicacion = b.fk_id_aplicacion
                ORDER BY b.fecha_bitacora DESC, b.pk_id_bitacora DESC;";

            using (var cn = con.conexion())
            using (var da = new OdbcDataAdapter(sql, cn))
            {
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}
