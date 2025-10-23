using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;

// 0901-20-4620 Ruben Armando Lopez Luch
namespace Capa_Modelo_Seguridad
{
    public class Cls_usuario_cambio_contrasena
    {
        Cls_Conexion cn = new Cls_Conexion();

        // Validar la contraseña actual del usuario
        public bool fun_validar_contrasena_actual(int iIdUsuario, string sContrasenaActual)
        {
            bool bValido = false;
            OdbcConnection conn = cn.conexion();
            try
            {
                string sSql = "SELECT Cmp_Contrasena_Usuario FROM Tbl_Usuario WHERE Pk_Id_Usuario=?;";
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

        // Cambiar la contraseña del usuario
        public bool fun_cambiar_contrasena(int iIdUsuario, string sNuevaContrasena)
        {
            bool bExito = false;
            OdbcConnection conn = cn.conexion();
            try
            {
                string sSql = @"UPDATE Tbl_Usuario 
                                 SET Cmp_Contrasena_Usuario=?, 
                                     Cmp_Ultimo_Cambio_Contrasenea=?
                                 WHERE Pk_Id_Usuario=?;";
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
