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
    public class Cls_Sentencias_Reporteador
    {
        // ==========================
        // Métodos de creación
        // ==========================

        //Inicio de código de: Bárbara Saldaña 
        public void InsertarReporte(string titulo, string ruta, DateTime fecha)
        {
            Cls_Conexion_Reporteador cn = new Cls_Conexion_Reporteador();
            using (OdbcConnection con = cn.conexion())
            {
                string sql = "INSERT INTO tbl_reportes (Cmp_Titulo_Reporte, Cmp_Ruta_Reporte, Cmp_Fecha_Reporte) VALUES (?,?,?)";
 
                using (OdbcCommand cmd = new OdbcCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("", titulo);
                    cmd.Parameters.AddWithValue("", ruta);
                    cmd.Parameters.AddWithValue("", fecha);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public bool ExisteTitulo(string titulo)
        {
            Cls_Conexion_Reporteador cn = new Cls_Conexion_Reporteador();
            using (OdbcConnection con = cn.conexion())
            {
                con.Open();
                string sql = "SELECT 1 FROM tbl_reportes WHERE Cmp_Titulo_Reporte = ? LIMIT 1";
                using (OdbcCommand cmd = new OdbcCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("", titulo);
                    object result = cmd.ExecuteScalar();
                    return result != null;
                }
            }
        }
        //Fin código bárbara saldaña 0901-22-9136 --> 26/09/2025

        // ==========================
        // Métodos de modificación
        // ==========================

        // Inicio de código de: María Morales con carné: 0901-22-1226 en la fecha de: 11/09/2025
        public void ModificarRuta(int id, string sNuevaRuta)
        {
            Cls_Conexion_Reporteador cn = new Cls_Conexion_Reporteador();
            using (OdbcConnection con = cn.conexion())
            {
                string sql = "UPDATE tbl_reportes SET Cmp_Ruta_Reporte=? WHERE Pk_Id_Reporte=?";
                OdbcCommand cmd = new OdbcCommand(sql, con);
                cmd.Parameters.AddWithValue("ruta", sNuevaRuta);
                cmd.Parameters.AddWithValue("id", id);
                cmd.ExecuteNonQuery();
            }
        }
        // Fin de código de: María Morales con carné: 0901-22-1226 en la fecha de: 11/09/2025

        // Inicio de código de: Anderson Trigueros con carné: 0901-22-6961 en la fecha de: 23/09/2025
        public void ModificarTitulo(int id, string stitulo)
        {
            Cls_Conexion_Reporteador cn = new Cls_Conexion_Reporteador();
            using (OdbcConnection con = cn.conexion())
            {
                string sqlTitulo = "UPDATE tbl_reportes SET Cmp_Titulo_Reporte=? WHERE Pk_Id_Reporte=?";
                OdbcCommand cmdActualizar = new OdbcCommand(sqlTitulo, con);
                cmdActualizar.Parameters.AddWithValue("", stitulo);
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
            Cls_Conexion_Reporteador cn = new Cls_Conexion_Reporteador();
            using (OdbcConnection con = cn.conexion())
            {
                string sql = "DELETE FROM tbl_reportes WHERE Pk_Id_Reporte=?";
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
                Cls_Conexion_Reporteador cn = new Cls_Conexion_Reporteador();
                using (OdbcConnection con = cn.conexion())
                {
                    string sql = "SELECT Pk_Id_Reporte, Cmp_Titulo_Reporte, Cmp_Ruta_Reporte, Cmp_Fecha_Reporte FROM tbl_reportes";
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
        public int verificarExistencia(string stitulo)
        {
            Cls_Conexion_Reporteador cn = new Cls_Conexion_Reporteador();
            using (OdbcConnection con = cn.conexion())
            {
                string sql = "SELECT 1 FROM tbl_reportes WHERE Cmp_Titulo_Reporte = ? LIMIT 1";
                OdbcCommand cmd = new OdbcCommand(sql, con);
                cmd.Parameters.AddWithValue("Cmp_Titulo_Reporte", stitulo);

                object result = cmd.ExecuteScalar();
                return result != null ? 1 : 0;
            }
        }
        //fin de codigo de Sergio Izeppi
        // ==========================
        // APLICACIÓN

        // Inicio de código de: Anderson Trigueros con carné: 0901-22-6961 en la fecha de: 24/09/2025
        // Inicio de código de: Leticia Sontay con carné: 9959-21-9664 en la fecha de: 24/09/2025

        public string consultaReporteAplicacion(int idAplicacion)
        {
            Cls_Conexion_Reporteador cn = new Cls_Conexion_Reporteador();
            using (OdbcConnection con = cn.conexion())
            {
                string sql = $@"SELECT R.Cmp_Ruta_Reporte
                                FROM Tbl_Aplicacion A
                                JOIN Tbl_Reportes R ON A.Fk_Id_Reporte_Aplicacion = R.Pk_Id_Reporte
                                WHERE A.Pk_Id_Aplicacion = ?";
                OdbcCommand cmd = new OdbcCommand(sql, con);
                cmd.Parameters.AddWithValue("idAplicacion", idAplicacion);
                object resultadoConsulta = cmd.ExecuteScalar();
                if (resultadoConsulta != DBNull.Value && resultadoConsulta != null)
                {
                    return resultadoConsulta.ToString();
                }
                else
                {
                    return null;
                }
            }
        }
        // Fin de código de: Anderson Trigueros con carné: 0901-22-6961 en la fecha de: 24/09/2025
        // Fin de código de: Leticia Sontay con carné: 9959-21-9664  en la fecha de: 24/09/2025
        // ==========================
    }
}




