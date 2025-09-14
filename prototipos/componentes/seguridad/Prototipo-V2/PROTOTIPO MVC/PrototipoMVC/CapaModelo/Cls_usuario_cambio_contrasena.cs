using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;

// 0901-20-4620 Ruben Armando Lopez Luch
namespace CapaModelo
{
    public class Cls_usuario_cambio_contrasena
    {
        Conexion cn = new Conexion();

        // 0901-20-4620 Ruben Armando Lopez Luch
        public bool fun_validar_contrasena_actual(int iIdUsuario, string sContrasenaActual)
        {
            bool bValido = false;
            OdbcConnection conn = cn.conexion();
            try
            {
                string sSql = "SELECT contrasena_usuario FROM tbl_USUARIO WHERE pk_id_usuario=?;";
                OdbcCommand cmd = new OdbcCommand(sSql, conn);
                cmd.Parameters.AddWithValue("@idUsuario", iIdUsuario);

                object resultado = cmd.ExecuteScalar();
                if (resultado != null)
                {
                    string sContrasenaBD = resultado.ToString();
                    bValido = sContrasenaBD == sContrasenaActual;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                cn.desconexion(conn);
            }

            return bValido;
        }

        // 0901-20-4620 Ruben Armando Lopez Luch
        public bool fun_cambiar_contrasena(int iIdUsuario, string sNuevaContrasena)
        {
            bool bExito = false;
            OdbcConnection conn = cn.conexion();
            try
            {
                string sSql = @"UPDATE tbl_USUARIO 
                                 SET contrasena_usuario=?, 
                                     ultimo_cambio_contrasena_usuario=?
                                 WHERE pk_id_usuario=?;";
                OdbcCommand cmd = new OdbcCommand(sSql, conn);
                cmd.Parameters.AddWithValue("@nuevaContrasena", sNuevaContrasena);
                cmd.Parameters.AddWithValue("@fecha", DateTime.Now);
                cmd.Parameters.AddWithValue("@idUsuario", iIdUsuario);

                bExito = cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                cn.desconexion(conn);
            }

            return bExito;
        }
    }
}