using System.Data;
using System.Data.Odbc;


//0901-22-13036 Arón Ricardo Esquit Silva
namespace CapaModelo
{
    public class BitacoraDao
    {
        private readonly Conexion con = new Conexion(); // usa tu DSN hotel_San_Carlos

        // Lista la bitácora con joins (nombres de columnas estandarizados)
        public DataTable Listar()
        {
            const string sql = @"
                SELECT  b.pk_id_bitacora        AS id,
                        COALESCE(u.nombre_usuario,'')    AS usuario,
                        COALESCE(a.nombre_aplicacion,'') AS aplicacion,
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
