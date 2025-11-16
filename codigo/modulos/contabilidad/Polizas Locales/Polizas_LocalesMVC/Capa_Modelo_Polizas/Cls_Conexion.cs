using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Modelo_Polizas
{
    internal class Cls_Conexion
    {
        private static readonly string sDsn = "DSN=Bd_Hoteleria;";

        //abre la conexion
        public OdbcConnection AbrirConexion()
        {
            try
            {
                OdbcConnection conexion = new OdbcConnection(sDsn);
                conexion.Open();
                return conexion;
            }
            catch (OdbcException ex)
            {
                throw new Exception("Error al conectar con la base de datos ODBC (Bd_Hoteleria): " + ex.Message);
            }
        }

        //cerrar conexion
        public void CerrarConexion(OdbcConnection conexion)
        {
            try
            {
                if (conexion != null && conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cerrar la conexión: " + ex.Message);
            }
        }
    }
}
