using System;
using System.Data.Odbc;

// ================================================
// Clase de Conexión ODBC para el módulo contable
// Autor: [Tu Nombre]
// Fecha: 27/10/2025
// ================================================

namespace Capa_Modelo_Contabilidad
{
    public class Cls_Conexion
    {
        // Devuelve la cadena de conexión ODBC
        public string ObtenerCadenaConexion()
        {
            // Aquí debe estar configurado tu DSN de ODBC (Administrador ODBC de Windows)
            return "Dsn=conta";
        }

        // Abre y retorna una nueva conexión ODBC
        public OdbcConnection conexion()
        {
            OdbcConnection conn = new OdbcConnection(ObtenerCadenaConexion());
            try
            {
                conn.Open();
            }
            catch (OdbcException ex)
            {
                Console.WriteLine("No conectó con la base de datos: " + ex.Message);
            }
            return conn;
        }

        // Alternativo: abre sin capturar errores
        public OdbcConnection AbrirConexion()
        {
            OdbcConnection conn = new OdbcConnection(ObtenerCadenaConexion());
            conn.Open();
            return conn;
        }

        // Cierra la conexión ODBC
        public void desconexion(OdbcConnection conn)
        {
            try
            {
                conn.Close();
            }
            catch (OdbcException ex)
            {
                Console.WriteLine("Error al cerrar la conexión: " + ex.Message);
            }
        }
    }
}
