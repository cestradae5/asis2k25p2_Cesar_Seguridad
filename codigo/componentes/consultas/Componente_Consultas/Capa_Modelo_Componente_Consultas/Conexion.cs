using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;

namespace Capa_Modelo_Componente_Consultas
{
    class Conexion
    {
        public OdbcConnection conexion()
        {
            //creacion de la conexion via ODBC
            OdbcConnection con = new OdbcConnection("Dsn=Prueba1");
            try
            {
                con.Open();
            }
            catch (OdbcException)
            {
                Console.WriteLine("No Conectó");
            }
            return con;
        }

        //metodo para cerrar la conexion
        public void desconexion(OdbcConnection con)
        {
            try
            {
                con.Close();
            }
            catch (OdbcException)
            {
                Console.WriteLine("No Conectó");
            }
        }

    }
}
