//Registrar en Bitácora - Arón Ricardo Esquit Silva - 0901-22-13036 - 12/09/2025
using System;
using System.Data;
using System.Data.Odbc;

namespace Capa_Modelo_Seguridad
{
    public class Cls_BitacoraDao
    {
        // Objeto de conexión a la base de datos
        private readonly Cls_Conexion ctrlConexion = new Cls_Conexion();

        // Para SELECT
        public DataTable EjecutarConsulta(string sSql)
        {
            try
            {
                using (var cn = ctrlConexion.conexion())
                using (var da = new OdbcDataAdapter(sSql, cn))
                {
                    var dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar la consulta en Cls_BitacoraDao: " + ex.Message, ex);
            }
        }

        // INSERT, UPDATE y DELETE
        public void EjecutarComando(string sSql)
        {
            try
            {
                using (var cn = ctrlConexion.conexion())
                using (var cmd = new OdbcCommand(sSql, cn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar comando en Cls_BitacoraDao: " + ex.Message, ex);
            }
        }
    }
}
