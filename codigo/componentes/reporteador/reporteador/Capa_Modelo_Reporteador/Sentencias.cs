using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; //Paula Leonardo
using System.Data.Odbc; // Paula Leonardo

namespace Capa_Modelo_Reporteador
{
    //Clase Publica
    public class Sentencias
    {
        //Bárbara Saldaña 
        //InsertarReporte -> Método para poder insertar reportes




        // Inicio de código de: María Morales con carné: 0901-22-1226 en la fecha de: 11/09/2025
        public void Modificar_Ruta(int id, string nuevaRuta)
        {
            using (OdbcConnection con = Conexion.ObtenerConexion())
            {
                string sql = "update tbl_reportes set ruta_reportes=? where pk_id_reportes=?";
                OdbcCommand cmd = new OdbcCommand(sql, con);
                cmd.Parameters.AddWithValue("ruta", nuevaRuta);
                cmd.Parameters.AddWithValue("id", id);
                cmd.ExecuteNonQuery();
            }
        }
        // Fin de código de: María Morales con carné: 0901-22-1226 en la fecha de: 11/09/2025
    }
}
