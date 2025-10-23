// Realizado por: Juan Carlos Sandoval Quej 0901-22-4170 18/09/2025 (Modificación)
using System;
using System.Data;
using System.Data.Odbc;

namespace Capa_Modelo_Componente_Consultas
{
    // Clase encargada de manejar la conexión con la base de datos mediante ODBC
    public sealed class Conexion : IDisposable // "sealed" significa que no se puede heredar
    {
        private readonly string _dsn;        // Guarda el nombre del DSN (fuente de datos configurada en Windows)
        private OdbcConnection _cn;          // Objeto que maneja la conexión ODBC real

        // Constructor por defecto: usa como DSN "Prueba1"
        public Conexion() : this("Prueba1") { }

        // Constructor que recibe el DSN (nombre de la conexión configurada en ODBC)
        public Conexion(string dsn)
        {
            // Si el DSN está vacío o nulo, lanza un error porque no se puede conectar sin DSN
            if (string.IsNullOrWhiteSpace(dsn))
                throw new ArgumentException("Debes especificar el nombre del DSN.", nameof(dsn));

            _dsn = dsn; // Guarda el DSN en la variable interna
        }

        // Método para abrir la conexión
        public OdbcConnection Abrir()
        {
            // Si aún no se ha creado el objeto conexión, se crea y se configura con el DSN
            if (_cn == null)
            {
                _cn = new OdbcConnection();
                _cn.ConnectionString = $"Dsn={_dsn};"; // Se establece la cadena de conexión con el DSN
            }

            // Si la conexión está cerrada, se abre
            if (_cn.State != ConnectionState.Open)
                _cn.Open();

            // Devuelve la conexión lista para usar
            return _cn;
        }

        // Implementación de Dispose: libera recursos cuando ya no se necesita la conexión
        public void Dispose()
        {
            _cn?.Dispose();  // Libera la conexión si existe
            _cn = null;      // Se asegura de limpiar la referencia
        }

        // Alias de Abrir(): otra forma de pedir la conexión
        public OdbcConnection conexion() => Abrir();

        // Método para cerrar una conexión recibida como parámetro
        public void desconexion(OdbcConnection con)
        {
            try
            {
                // Si la conexión existe y está abierta, se cierra
                if (con != null && con.State != ConnectionState.Closed)
                    con.Close();
            }
            catch
            {
                // Si ocurre un error al cerrar, simplemente se ignora
                // (se podría registrar en un log si se desea)
            }
        }
    }
}
