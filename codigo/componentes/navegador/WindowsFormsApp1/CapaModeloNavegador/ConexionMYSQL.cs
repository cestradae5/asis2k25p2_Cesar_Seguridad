using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModeloNavegador
{
    public class ConexionMYSQL
    {
        public OdbcConnection conexion()
        {
            OdbcConnection conn = new OdbcConnection("Dsn=Prueba1"); // nombre del dsn, esto se cambia dependiendo del nombre del dsn
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
