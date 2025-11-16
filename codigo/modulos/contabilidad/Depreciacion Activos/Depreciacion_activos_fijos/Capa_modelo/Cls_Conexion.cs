using System;
using System.Data.Odbc;

namespace Capa_modelo
{
    public class Cls_Conexion
    {
        // Devuelve la cadena DSN configurada en el sistema
        public string ObtenerCadenaConexion()
        {
            return "Dsn=Bd_Hoteleria";
        }

        // Método estándar para abrir conexión con manejo de errores
        public OdbcConnection conexion()
        {
            OdbcConnection conn = new OdbcConnection(ObtenerCadenaConexion());

            try
            {
                conn.Open();
                return conn;
            }
            catch (OdbcException ex)
            {
                Console.WriteLine("❌ Error al conectar con la base de datos: " + ex.Message);
                // Lanzar una excepción más descriptiva
                throw new Exception("No se pudo establecer conexión con la base de datos. Verifica el DSN o el servidor ODBC.", ex);
            }
        }

        // Alternativa más explícita para abrir una nueva conexión
        public static OdbcConnection ObtenerConexion()
        {
            OdbcConnection conn = new OdbcConnection("Dsn=conta");

            try
            {
                conn.Open();
                return conn;
            }
            catch (OdbcException ex)
            {
                Console.WriteLine("❌ Error al conectar con la base de datos: " + ex.Message);
                throw new Exception("Error al abrir conexión ODBC (verifica DSN o servidor).", ex);
            }
        }

        // Cierra la conexión de forma segura
        public void desconexion(OdbcConnection conn)
        {
            if (conn == null) return;

            try
            {
                if (conn.State != System.Data.ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
            catch (OdbcException ex)
            {
                Console.WriteLine("⚠️ Error al cerrar la conexión: " + ex.Message);
                // No relanzamos porque cerrar una conexión no debe detener el sistema
            }
        }
    }
}
