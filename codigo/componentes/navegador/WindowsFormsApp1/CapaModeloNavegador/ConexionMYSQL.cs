using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Trabajado por Fernando Jose Cahuex Gonzalez 0901-22-14979
namespace Capa_Modelo_Navegador
{
    public class Cls_ConexionMYSQL
    {
        private readonly string ConexionODBC = "Dsn=Prueba1"; // DSN de odbc

        //retorna conexion cerrada para que el DAO la abra y cierre cuando sea necesario
        public OdbcConnection conexion()
        {
            return new OdbcConnection(ConexionODBC); // crea una nueva conexión
        }

        // Cierra la conexión si está abierta
        public void desconexion(OdbcConnection conn)
        {
            if (conn != null && conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }
}
//======================================================================================
