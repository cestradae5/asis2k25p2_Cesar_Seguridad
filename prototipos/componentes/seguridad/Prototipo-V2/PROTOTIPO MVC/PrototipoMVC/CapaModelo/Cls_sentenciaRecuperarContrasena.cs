using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;

// 0901-20-4620 Ruben Armando Lopez Luch
namespace CapaModelo
{
    public class ClsModeloRecuperarContrasena
    {
        private Conexion cn = new Conexion();

        // 0901-20-4620 Ruben Armando Lopez Luch
        public int fun_obtener_IdUsuario(string sNombreUsuario)
        {
            using (OdbcConnection conn = cn.conexion())
            {
                string sSql = "SELECT pk_id_usuario FROM tbl_USUARIO WHERE nombre_usuario = ?";
                using (OdbcCommand cmd = new OdbcCommand(sSql, conn))
                {
                    cmd.Parameters.AddWithValue("@nombre", sNombreUsuario);
                    object result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : 0;
                }
            }
        }

        // 0901-20-4620 Ruben Armando Lopez Luch
        public void fun_guardar_token(int iIdUsuario, string sToken, DateTime expiracion)
        {
            using (OdbcConnection conn = cn.conexion())
            {
                string sSql = @"INSERT INTO tbl_TOKEN_RESTAURAR_CONTRASENA
                               (fk_id_usuario, token_restaurar_contrasena, fecha_creacion_token_restaurar_contrasena, expiracion_token_restaurar_contrasena, utilizado_token_restaurar_contrasena)
                               VALUES (?, ?, ?, ?, 0)";
                using (OdbcCommand cmd = new OdbcCommand(sSql, conn))
                {
                    cmd.Parameters.AddWithValue("@fk_id_usuario", iIdUsuario);
                    cmd.Parameters.AddWithValue("@token", sToken);
                    cmd.Parameters.AddWithValue("@fecha_creacion", DateTime.Now);
                    cmd.Parameters.AddWithValue("@expiracion", DateTime.Now.AddMinutes(5));
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // 0901-20-4620 Ruben Armando Lopez Luch
        public (bool valido, int idToken) fun_validar_token(int iIdUsuario, string sToken)
        {
            using (OdbcConnection conn = cn.conexion())
            {
                string sSql = @"SELECT pk_id_token_restaurar_contrasena, expiracion_token_restaurar_contrasena, utilizado_token_restaurar_contrasena
                               FROM tbl_TOKEN_RESTAURAR_CONTRASENA
                               WHERE fk_id_usuario = ? AND token_restaurar_contrasena = ?";
                using (OdbcCommand cmd = new OdbcCommand(sSql, conn))
                {
                    cmd.Parameters.AddWithValue("@fk_id_usuario", iIdUsuario);
                    cmd.Parameters.AddWithValue("@token", sToken);
                    using (OdbcDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            DateTime expiracion = Convert.ToDateTime(dr["expiracion_token_restaurar_contrasena"]);
                            bool bUsado = Convert.ToBoolean(dr["utilizado_token_restaurar_contrasena"]);
                            if (!bUsado && DateTime.Now <= expiracion)
                                return (true, Convert.ToInt32(dr["pk_id_token_restaurar_contrasena"]));
                        }
                    }
                }
            }
            return (false, 0);
        }

        // 0901-20-4620 Ruben Armando Lopez Luch
        public bool fun_cambiar_contrasena(int iIdUsuario, string sHashNueva, int iIdToken)
        {
            using (OdbcConnection conn = cn.conexion())
            {
                using (OdbcTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        // Actualiza solo la contraseña y la fecha del último cambio
                        string sSql1 = @"UPDATE tbl_USUARIO
                                SET contrasena_usuario = ?, ultimo_cambio_contrasena_usuario = ?
                                WHERE pk_id_usuario = ?";
                        using (OdbcCommand cmd1 = new OdbcCommand(sSql1, conn, trans))
                        {
                            cmd1.Parameters.AddWithValue("@hash", sHashNueva);
                            cmd1.Parameters.AddWithValue("@fecha", DateTime.Now);
                            cmd1.Parameters.AddWithValue("@id", iIdUsuario);
                            cmd1.ExecuteNonQuery();
                        }

                        // Marca el token como utilizado
                        string sSql2 = @"UPDATE tbl_TOKEN_RESTAURAR_CONTRASENA
                                SET utilizado_token_restaurar_contrasena = 1, fecha_utilizado_restaurar_contrasena = ?
                                WHERE pk_id_token_restaurar_contrasena = ?";
                        using (OdbcCommand cmd2 = new OdbcCommand(sSql2, conn, trans))
                        {
                            cmd2.Parameters.AddWithValue("@fecha", DateTime.Now);
                            cmd2.Parameters.AddWithValue("@idToken", iIdToken);
                            cmd2.ExecuteNonQuery();
                        }

                        trans.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        Console.WriteLine("Error en fun_cambiar_contrasena: " + ex.Message);
                        return false;
                    }
                }
            }
        }
    }
}