using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; //Paula Leonardo
using System.Data.Odbc; //Paula Leonardo

namespace Capa_Modelo_Reporteador
{
    //Clase Publica
    public class Sentencias_Reporteador
    {
        // ==========================
        // Métodos de creación
        // ==========================

        //Inicio de código de: Bárbara Saldaña 
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


        // ==========================
        // Métodos de modificación
        // ==========================

        // Inicio de código de: María Morales con carné: 0901-22-1226 en la fecha de: 11/09/2025
        public void ModificarRuta(int id, string nuevaRuta)
        {
            Conexion_Reporteador cn = new Conexion_Reporteador();
            using (OdbcConnection con = cn.conexion())
            {
                string sql = "UPDATE tbl_reportes SET ruta_reportes=? WHERE pk_id_reportes=?";
                OdbcCommand cmd = new OdbcCommand(sql, con);
                cmd.Parameters.AddWithValue("ruta", nuevaRuta);
                cmd.Parameters.AddWithValue("id", id);
                cmd.ExecuteNonQuery();
            }
        }
        // Fin de código de: María Morales con carné: 0901-22-1226 en la fecha de: 11/09/2025

        // Inicio de código de: Anderson Trigueros con carné: 0901-22-6961 en la fecha de: 23/09/2025
        public void ModificarTitulo(int id, string titulo)
        {
            Conexion_Reporteador cn = new Conexion_Reporteador();
            using (OdbcConnection con = cn.conexion())
            {
                string sqlTitulo = "UPDATE tbl_reportes SET titulo_reportes=? WHERE pk_id_reportes=?";
                OdbcCommand cmdActualizar = new OdbcCommand(sqlTitulo, con);
                cmdActualizar.Parameters.AddWithValue("", titulo);
                cmdActualizar.Parameters.AddWithValue("", id);
                cmdActualizar.ExecuteNonQuery();
            }
        }
        // Fin de código de: Anderson Trigueros con carné: 0901-22-6961 en la fecha de: 23/09/2025


        // ==========================
        // Métodos de eliminación
        // ==========================

        // Inicio de código de: Leticia Sontay con carné: 9959-21-9664 en la fecha de: 12/09/2025
        public void EliminarReporte(int id)
        {
            Conexion_Reporteador cn = new Conexion_Reporteador();
            using (OdbcConnection con = cn.conexion())
            {
                string sql = "DELETE FROM tbl_reportes WHERE pk_id_reportes=?";
                OdbcCommand cmd = new OdbcCommand(sql, con);
                cmd.Parameters.AddWithValue("id", id);
                cmd.ExecuteNonQuery();
            }
        }
        // Fin de código de: Leticia Sontay con carné: 9959-21-9664 en la fecha de: 12/09/2025


        // ==========================
        // Métodos de consulta
        // ==========================

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


        // ==========================
        // Métodos de verificación
        // ==========================

        // inicio codigo de: Sergio Izeppi 0901-22-8946 en la fecha de: 16/09/2025
        public int verificarExistencia(string titulo)
        {
            Conexion_Reporteador cn = new Conexion_Reporteador();
            using (OdbcConnection con = cn.conexion())
            {
                string sql = "SELECT 1 FROM tbl_reportes WHERE titulo_reportes = ? LIMIT 1";
                OdbcCommand cmd = new OdbcCommand(sql, con);
                cmd.Parameters.AddWithValue("titulo_reportes", titulo);

                object result = cmd.ExecuteScalar();
                return result != null ? 1 : 0;
            }
        }
        //fin de codigo de Sergio Izeppi
    }
}




