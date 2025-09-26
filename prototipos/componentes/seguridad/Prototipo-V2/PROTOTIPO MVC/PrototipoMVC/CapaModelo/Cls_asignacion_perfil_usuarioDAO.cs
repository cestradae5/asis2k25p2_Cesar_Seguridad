using System;
using System.Data;
using System.Data.Odbc;
/* Brandon Alexander Hernandez Salguero
 * 0901-22-9663
 */
namespace Capa_Modelo_Seguridad
{
    public class Cls_asignacion_perfil_usuarioDAO
    {
        private static readonly string SQL_INSERT = @"
            INSERT INTO Tbl_Usuario_Perfil 
                (Fk_Id_Usuario, Fk_Id_Perfil)
            VALUES (?, ?)";

        private Conexion conexion = new Conexion();

        public DataTable datObtenerUsuarios()
        {
            DataTable dt = new DataTable();
            string query = "SELECT Pk_Id_Usuario, Cmp_Nombre_Usuario FROM Tbl_Usuario";

            using (OdbcConnection conn = conexion.conexion())
            {
                using (OdbcCommand cmd = new OdbcCommand(query, conn))
                {
                    using (OdbcDataAdapter da = new OdbcDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }

            return dt;
        }

        public DataTable datObtenerPerfiles()
        {
            DataTable dt = new DataTable();
            string query = "SELECT Pk_Id_Perfil, Cmp_Puesto_Perfil FROM Tbl_Perfil";

            using (OdbcConnection conn = conexion.conexion())
            {
                using (OdbcCommand cmd = new OdbcCommand(query, conn))
                {
                    using (OdbcDataAdapter da = new OdbcDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }

            return dt;
        }

        public bool bInsertar(Cls_asignacion_perfil_usuario rel)
        {
            using (OdbcConnection conn = conexion.conexion())
            {
                using (OdbcCommand cmd = new OdbcCommand(SQL_INSERT, conn))
                {
                    cmd.Parameters.AddWithValue("@Fk_Id_Usuario", rel.Fk_Id_Usuario);
                    cmd.Parameters.AddWithValue("@Fk_Id_Perfil", rel.Fk_Id_Perfil);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public DataTable datObtenerPerfilesPorUsuario(int idUsuario)
        {
            DataTable dt = new DataTable();
            string query = @"
                SELECT p.Pk_Id_Perfil AS IdPerfil, p.Cmp_Puesto_Perfil AS Perfil
                FROM Tbl_Usuario_Perfil up
                INNER JOIN Tbl_Perfil p ON up.Fk_Id_Perfil = p.Pk_Id_Perfil
                WHERE up.Fk_Id_Usuario = ?";
            using (OdbcConnection conn = conexion.conexion())
            {
                using (OdbcCommand cmd = new OdbcCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Fk_Id_Usuario", idUsuario);
                    using (OdbcDataAdapter da = new OdbcDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

    }
}