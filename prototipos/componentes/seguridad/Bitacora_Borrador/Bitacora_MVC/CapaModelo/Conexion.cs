using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;


namespace CapaModelo
{
    class Conexion
    {
        public OdbcConnection conexion()
        {
            // Creación de la conexión vía ODBC
            OdbcConnection conn = new OdbcConnection("Dsn=hotel_San_Carlos");
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

        // Método para cerrar la conexión
        public void desconexion(OdbcConnection conn)
        {
            try
            {
                conn.Close();
            }
            catch (OdbcException)
            {
                Console.WriteLine("Error al cerrar la conexión");
            }
        }
    }
}
