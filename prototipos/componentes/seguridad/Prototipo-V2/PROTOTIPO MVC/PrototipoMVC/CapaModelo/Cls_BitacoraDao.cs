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

        public DataTable EjecutarConsulta(string sSql)
        {
            try
            {
                // Abrir conexión y ejecutar la consulta
                using (var cn = con.conexion())
                using (var da = new OdbcDataAdapter(sSql, cn))
                {
                    var dt = new DataTable(); // tabla para guardar los datos
                    da.Fill(dt);              // llenar la tabla con los resultados
                    return dt;                // devolver los resultados
                }
            }
            catch (Exception ex)
            {

                //Excepción 
                throw new Exception("Error al ejecutar la consulta en BitacoraDao: " + ex.Message, ex);
            }
        }
    }
}
