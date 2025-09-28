using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc; // Paula Leonardo

namespace Capa_Modelo_Reporteador
{
    class Cls_Conexion_Reporteador //Paula Leonardo
    {
        //Método de creación de la conexion via ODBC
        
        public OdbcConnection conexion()
        {
            OdbcConnection conn = new OdbcConnection("Dsn=bd_hoteleria");
            try
            {
                conn.Open();
            }
            catch (OdbcException)
            {
                Console.WriteLine("No Conectó");
            }
            return conn;
        }

        //Método para cerrar la conexion
        public void desconexion(OdbcConnection conn)
        {
            try
            {
                conn.Close();
            }
            catch (OdbcException)
            {
                Console.WriteLine("No Conectó");
            }
        }
       
    }
}
