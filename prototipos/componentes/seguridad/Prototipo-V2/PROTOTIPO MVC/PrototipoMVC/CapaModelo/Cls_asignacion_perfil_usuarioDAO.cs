using System;
using System.Data;
using System.Data.Odbc;
/* Brandon Alexander Hernandez Salguero
 * 0901-22-9663
 */
namespace Capa_Modelo_Seguridad
{
    /// <summary>
    /// DAO para la asignación de perfil a usuario. Permite insertar, consultar usuarios y perfiles,
    /// y obtener perfiles asignados a un usuario.
    /// </summary>
    public class Cls_asignacion_perfil_usuarioDAO
    {
        // Consulta para insertar una asignación de perfil a usuario.
        private static readonly string SQL_INSERT = @"
            INSERT INTO Tbl_Usuario_Perfil 
                (Fk_Id_Usuario, Fk_Id_Perfil)
            VALUES (?, ?)";

        // Objeto de conexión a la base de datos.
        private Cls_Conexion conexion = new Cls_Conexion();

        /// <summary>
        /// Obtiene la lista de usuarios desde la tabla Tbl_Usuario.
        /// </summary>
        /// <returns>DataTable con los usuarios (ID y nombre)</returns>
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
                        da.Fill(dt); // Llena el DataTable con los datos de usuarios
                    }
                }
            }
            return dt;
        }

        /// <summary>
        /// Obtiene la lista de perfiles desde la tabla Tbl_Perfil.
        /// </summary>
        /// <returns>DataTable con los perfiles (ID y puesto)</returns>
        public DataTable datObtenerPerfiles()
        {
            DataTable dt = new DataTable();
            string query = "SELECT Pk_Id_Perfil, Cmp_Puesto_Perfil FROM Tbl_Perfil"; // Consulta perfiles

            using (OdbcConnection conn = conexion.conexion())
            {
                using (OdbcCommand cmd = new OdbcCommand(query, conn))
                {
                    using (OdbcDataAdapter da = new OdbcDataAdapter(cmd))
                    {
                        da.Fill(dt); // Llena el DataTable con los datos de perfiles
                    }
                }
            }
            return dt;
        }

        /// <summary>
        /// Inserta una relación usuario-perfil en la tabla Tbl_Usuario_Perfil.
        /// Si ya existe la relación, devuelve un mensaje de error personalizado.
        /// </summary>
        /// <param name="rel">Objeto de relación usuario-perfil</param>
        /// <param name="mensajeError">Mensaje de error si ocurre (por ejemplo, si ya existe la relación)</param>
        /// <returns>True si se insertó correctamente, False si hubo error</returns>
        public bool bInsertar(Cls_asignacion_perfil_usuario rel, out string mensajeError)
        {
            mensajeError = "";
            try
            {
                using (OdbcConnection conn = conexion.conexion())
                {
                    using (OdbcCommand cmd = new OdbcCommand(SQL_INSERT, conn))
                    {
                        // Asigna los parámetros de usuario y perfil
                        cmd.Parameters.AddWithValue("@Fk_Id_Usuario", rel.Fk_Id_Usuario);
                        cmd.Parameters.AddWithValue("@Fk_Id_Perfil", rel.Fk_Id_Perfil);
                        // Ejecuta la consulta y retorna true si se insertó
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (OdbcException ex)
            {
                // Si el error es por clave duplicada (ya existe la relación), retorna mensaje personalizado
                if (ex.Message.Contains("Duplicate entry") || ex.Message.Contains("clave duplicada") || ex.Message.Contains("PRIMARY"))
                {
                    mensajeError = "Este usuario ya está asignado al Perfil ingresado.";
                }
                else
                {
                    mensajeError = "Error al asignar perfil al usuario: " + ex.Message;
                }
                return false;
            }
        }

        /// <summary>
        /// Obtiene los perfiles asignados a un usuario específico.
        /// </summary>
        /// <param name="idUsuario">ID del usuario</param>
        /// <returns>DataTable con los perfiles (ID y nombre) asignados al usuario</returns>
        /// //0901-22-9663 Brandon Hernandez 12/10/2025
        public DataTable datObtenerPerfilesPorUsuario(int iIdUsuario)
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
                    cmd.Parameters.AddWithValue("@Fk_Id_Usuario", iIdUsuario);
                    using (OdbcDataAdapter da = new OdbcDataAdapter(cmd))
                    {
                        da.Fill(dt); // Llena el DataTable con los perfiles asignados al usuario
                    }
                }
            }
            return dt;
        }

        /// <summary>
        /// Valida si el usuario ya tiene el perfil asignado en la BD.
        /// </summary>
        public bool ExisteAsignacionEnBD(int usuarioId, int perfilId)
        {
            string query = @"SELECT COUNT(*) FROM Tbl_Usuario_Perfil WHERE Fk_Id_Usuario = ? AND Fk_Id_Perfil = ?";
            using (OdbcConnection conn = conexion.conexion())
            {
                using (OdbcCommand cmd = new OdbcCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Fk_Id_Usuario", usuarioId);
                    cmd.Parameters.AddWithValue("@Fk_Id_Perfil", perfilId);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        /// <summary>
        /// Valida si el usuario ya tiene algún permiso asignado en la BD.
        /// (adaptar la tabla/columna según tu modelo real)
        /// </summary>
        public bool UsuarioTienePermiso(int usuarioId)
        {
            string query = @"SELECT COUNT(*) FROM Tbl_Usuario_Perfil WHERE Fk_Id_Usuario = ?";
            using (OdbcConnection conn = conexion.conexion())
            {
                using (OdbcCommand cmd = new OdbcCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Fk_Id_Usuario", usuarioId);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }

    }
}