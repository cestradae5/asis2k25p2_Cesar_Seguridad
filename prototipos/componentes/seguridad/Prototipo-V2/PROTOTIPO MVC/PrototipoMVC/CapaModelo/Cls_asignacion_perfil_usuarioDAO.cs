using System;
using System.Data;
using System.Data.Odbc;
/* Brandon Alexander Hernandez Salguero
 * 0901-22-9663
 */
namespace CapaModelo
{
    public class Cls_asignacion_perfil_usuarioDAO
    {
        private static readonly string SQL_INSERT = @"
            INSERT INTO tbl_USUARIO_PERFIL 
                (fk_id_usuario, fk_id_perfil)
            VALUES (?, ?)";

        private Conexion conexion = new Conexion();

        public DataTable datObtenerUsuarios()
        {
            DataTable dt = new DataTable();
            string query = "SELECT pk_id_usuario, nombre_usuario FROM tbl_USUARIO";

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
            string query = "SELECT pk_id_perfil, puesto_perfil FROM tbl_PERFIL";

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
                    cmd.Parameters.AddWithValue("@fk_id_usuario", rel.fk_id_usuario);
                    cmd.Parameters.AddWithValue("@fk_id_perfil", rel.fk_id_perfil);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public DataTable datObtenerPerfilesPorUsuario(int idUsuario)
        {
            DataTable dt = new DataTable();
            string query = @"
                SELECT p.pk_id_perfil AS IdPerfil, p.puesto_perfil AS Perfil
                FROM tbl_USUARIO_PERFIL up
                INNER JOIN tbl_PERFIL p ON up.fk_id_perfil = p.pk_id_perfil
                WHERE up.fk_id_usuario = ?";
            using (OdbcConnection conn = conexion.conexion())
            {
                using (OdbcCommand cmd = new OdbcCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@fk_id_usuario", idUsuario);
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