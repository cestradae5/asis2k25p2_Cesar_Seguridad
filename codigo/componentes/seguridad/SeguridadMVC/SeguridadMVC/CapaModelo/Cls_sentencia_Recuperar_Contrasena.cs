using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;

// 0901-20-4620 Ruben Armando Lopez Luch
namespace Capa_Modelo_Seguridad
{
    public class ClsModeloRecuperarContrasena
    {
        private Cls_Conexion cn = new Cls_Conexion();

        // 0901-20-4620 Ruben Armando Lopez Luch
        public int fun_obtener_IdUsuario(string sNombreUsuario)
        {
            using (OdbcConnection conn = cn.conexion())
            {
                string sSql = "SELECT Pk_Id_Usuario FROM Tbl_Usuario WHERE Cmp_Nombre_Usuario = ?";
                using (OdbcCommand cmd = new OdbcCommand(sSql, conn))
                {
                    cmd.Parameters.AddWithValue("@nombre", sNombreUsuario);
                    object result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : 0;
                }
            }
        }

        // 0901-20-4620 Ruben Armando Lopez Luch
        public void fun_guardar_token(int iIdUsuario, string sToken, DateTime dExpiracion)
        {
            using (OdbcConnection conn = cn.conexion())
            {
                string sSql = @"INSERT INTO Tbl_Token_RestaurarContrasena
                               (Fk_Id_Usuario, Cmp_Token, Cmp_Fecha_Creacion_Restaurar_Contrasenea, 
                                Cmp_Expiracion_Restaurar_Contrasenea, Cmp_Utilizado_Restaurar_Contrasenea)
                               VALUES (?, ?, ?, ?, 0)";
                using (OdbcCommand cmd = new OdbcCommand(sSql, conn))
                {
                    cmd.Parameters.AddWithValue("@Fk_Id_Usuario", iIdUsuario);
                    cmd.Parameters.AddWithValue("@Cmp_Token", sToken);
                    cmd.Parameters.AddWithValue("@Cmp_Fecha_Creacion_Restaurar_Contrasenea", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Cmp_Expiracion_Restaurar_Contrasenea", DateTime.Now.AddMinutes(5));
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // 0901-20-4620 Ruben Armando Lopez Luch
        public (bool valido, int idToken) fun_validar_token(int iIdUsuario, string sToken)
        {
            using (OdbcConnection conn = cn.conexion())
            {
                string sSql = @"SELECT Pk_Id_Token, Cmp_Expiracion_Restaurar_Contrasenea, Cmp_Utilizado_Restaurar_Contrasenea
                               FROM Tbl_Token_RestaurarContrasena
                               WHERE Fk_Id_Usuario = ? AND Cmp_Token = ?";
                using (OdbcCommand cmd = new OdbcCommand(sSql, conn))
                {
                    cmd.Parameters.AddWithValue("@Fk_Id_Usuario", iIdUsuario);
                    cmd.Parameters.AddWithValue("@Cmp_Token", sToken);
                    using (OdbcDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            DateTime expiracion = Convert.ToDateTime(dr["Cmp_Expiracion_Restaurar_Contrasenea"]);
                            bool bUsado = Convert.ToBoolean(dr["Cmp_Utilizado_Restaurar_Contrasenea"]);
                            if (!bUsado && DateTime.Now <= expiracion)
                                return (true, Convert.ToInt32(dr["Pk_Id_Token"]));
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
                        string sSql1 = @"UPDATE Tbl_Usuario
                                SET Cmp_Contrasena_Usuario = ?, Cmp_Ultimo_Cambio_Contrasenea = ?
                                WHERE Pk_Id_Usuario = ?";
                        using (OdbcCommand cmd1 = new OdbcCommand(sSql1, conn, trans))
                        {
                            cmd1.Parameters.AddWithValue("@hash", sHashNueva);
                            cmd1.Parameters.AddWithValue("@fecha", DateTime.Now);
                            cmd1.Parameters.AddWithValue("@id", iIdUsuario);
                            cmd1.ExecuteNonQuery();
                        }

                        // Marca el token como utilizado
                        string sSql2 = @"UPDATE Tbl_Token_RestaurarContrasena
                                SET Cmp_Utilizado_Restaurar_Contrasenea = 1, Cmp_Fecha_Uso_Restaurar_Contrasenea = ?
                                WHERE Pk_Id_Token = ?";
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
