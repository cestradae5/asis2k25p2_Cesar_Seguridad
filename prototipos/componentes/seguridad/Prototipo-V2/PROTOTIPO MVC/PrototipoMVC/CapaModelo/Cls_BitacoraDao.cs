/// Autor: Arón Ricardo Esquit Silva    0901-22-13036
// Fecha: 12/09/2025
using System;
using System.Data;
using System.Data.Odbc;

namespace CapaModelo
{
    public class Cls_BitacoraDao
    {
        // Objeto de conexión a la base de datos
        private readonly Conexion con = new Conexion();

        // Para SELECT
        public DataTable EjecutarConsulta(string sSql)
        {
            try
            {
                using (var cn = con.conexion())
                using (var da = new OdbcDataAdapter(sSql, cn))
                {
                    var dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar la consulta en BitacoraDao: " + ex.Message, ex);
            }
        }

        // INSERT, UPDATE y DELETE
        public void EjecutarComando(string sSql)
        {
            try
            {
                using (var cn = con.conexion())
                using (var cmd = new OdbcCommand(sSql, cn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar comando en BitacoraDao: " + ex.Message, ex);
            }
        }
    }
}

