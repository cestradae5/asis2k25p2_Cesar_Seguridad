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
    public class Sentencias_Reporteador
    {
        //Inicio de código de: Bárbara Saldaña 
        //InsertarReporte -> Método para poder insertar reportes
    public void InsertarReporte(string titulo, string ruta, DateTime fecha)
          {
            Conexion_Reporteador cn = new Conexion_Reporteador();
            using (OdbcConnection con = cn.conexion())
            {
                string sql = "INSERT INTO tbl_reportes (titulo_reportes, ruta_reportes, fecha_reportes) VALUES (?,?,?)";
                OdbcCommand cmd = new OdbcCommand(sql, con);
                cmd.Parameters.AddWithValue("titulo", titulo);
                cmd.Parameters.AddWithValue("ruta", ruta);
                cmd.Parameters.AddWithValue("fecha", fecha);
                cmd.ExecuteNonQuery();
            }
          }
        //Fin de código de: Bárbara Saldaña

        // Inicio de código de: María Morales con carné: 0901-22-1226 en la fecha de: 11/09/2025
        public void ModificarRuta(int id, string nuevaRuta)
        {
            Conexion_Reporteador cn = new Conexion_Reporteador();
            using (OdbcConnection con = cn.conexion())
            {
                string sql = "update tbl_reportes set ruta_reportes=? where pk_id_reportes=?";
                OdbcCommand cmd = new OdbcCommand(sql, con);
                cmd.Parameters.AddWithValue("ruta", nuevaRuta);
                cmd.Parameters.AddWithValue("id", id);
                cmd.ExecuteNonQuery();
            }
        }
        // Fin de código de: María Morales con carné: 0901-22-1226 en la fecha de: 11/09/2025

        // Inicio de código de: Rocio Lopez con carné: 9959-23-740 en la fecha de: 11/09/2025

        public DataTable ObtenerReporte()
        {
            DataTable tabla = new DataTable();

            try
            {
                Conexion_Reporteador cn = new Conexion_Reporteador();
                using (OdbcConnection con = cn.conexion())
                {
                    string sql = "SELECT pk_id_reportes, titulo_reportes, ruta_reportes, fecha_reportes FROM tbl_reportes";
                    OdbcDataAdapter da = new OdbcDataAdapter(sql, con);
                    da.Fill(tabla);
                }
            }
            catch (Exception ex)
            {
                // Aquí mostrara mensaje de error 
                Console.WriteLine("Error al obtener reportes: " + ex.Message);
            }

            return tabla;
        }


        // Fin de código de: Rocio Lopez con carné: 9959-23-740 en la fecha de: 11/09/2025
    }
}
