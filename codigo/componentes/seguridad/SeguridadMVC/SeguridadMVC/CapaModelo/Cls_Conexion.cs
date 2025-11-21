using System;
using System.Data.Odbc;


//Inicio de codigo de coexion con la bd  Carlo Sosa 0901-22-1106  04/09/2025

namespace Capa_Modelo_Seguridad
{
    public class Cls_Conexion
    {
        // Devuelve la cadena de conexión ODBC
        public string ObtenerCadenaConexion()
        {
            return "Dsn=bd_hoteleria";
        }

        // Abre y retorna una nueva conexión ODBC
        public OdbcConnection conexion()
        {
            OdbcConnection conn = new OdbcConnection(ObtenerCadenaConexion());
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

        // Alternativo: método estándar para abrir conexión (sin try/catch interno)
        public OdbcConnection AbrirConexion()
        {
            OdbcConnection conn = new OdbcConnection(ObtenerCadenaConexion());
            conn.Open();
            return conn;
        }

        // Cierra la conexión recibida
        public void desconexion(OdbcConnection conn)
        {
            try
            {
                conn.Close();
            }
            catch (OdbcException)
            {
                Console.WriteLine("No se pudo cerrar la conexión");
            }
        }
    }
}