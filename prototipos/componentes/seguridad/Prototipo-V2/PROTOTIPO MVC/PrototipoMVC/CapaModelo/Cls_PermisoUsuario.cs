using System;
using System.Data.Odbc;

namespace CapaModelo
{
    public class Cls_PermisoUsuario
    {
        private Conexion conexion = new Conexion();

        /// <summary>
        /// Obtiene los permisos de un usuario para una aplicación y módulo específicos.
        /// </summary>
        /// <param name="idUsuario">ID del usuario.</param>
        /// <param name="idAplicacion">ID de la aplicación.</param>
        /// <param name="idModulo">ID del módulo.</param>
        /// <returns>
        /// Una tupla con los permisos (ingresar, consultar, modificar, eliminar, imprimir) o null si no hay permisos.
        /// </returns>
        public (bool ingresar, bool consultar, bool modificar, bool eliminar, bool imprimir)? ConsultarPermisos(int idUsuario, int idAplicacion, int idModulo)
        {
            string query = @"
                SELECT ingresar_permiso_aplicacion_usuario,
                       consultar_permiso_aplicacion_usuario,
                       modificar_permiso_aplicacion_usuario,
                       eliminar_permiso_aplicacion_usuario,
                       imprimir_permiso_aplicacion_usuario
                FROM tbl_PERMISO_USUARIO_APLICACION
                WHERE fk_id_usuario = ? AND fk_id_aplicacion = ? AND fk_id_modulo = ?
            ";
            using (OdbcConnection conn = conexion.conexion())
            using (OdbcCommand cmd = new OdbcCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                cmd.Parameters.AddWithValue("@idAplicacion", idAplicacion);
                cmd.Parameters.AddWithValue("@idModulo", idModulo);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return (
                            reader.GetBoolean(0),
                            reader.GetBoolean(1),
                            reader.GetBoolean(2),
                            reader.GetBoolean(3),
                            reader.GetBoolean(4)
                        );
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Obtiene el ID de una aplicación por su nombre.
        /// </summary>
        /// <param name="nombreAplicacion">Nombre de la aplicación.</param>
        /// <returns>ID de la aplicación o -1 si no existe.</returns>
        public int ObtenerIdAplicacionPorNombre(string nombreAplicacion)
        {
            string query = "SELECT pk_id_aplicacion FROM tbl_APLICACION WHERE nombre_aplicacion = ?";
            using (OdbcConnection conn = conexion.conexion())
            using (OdbcCommand cmd = new OdbcCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@nombre", nombreAplicacion);
                var result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : -1;
            }
        }

        /// <summary>
        /// Obtiene el ID de un módulo por su nombre.
        /// </summary>
        /// <param name="nombreModulo">Nombre del módulo.</param>
        /// <returns>ID del módulo o -1 si no existe.</returns>
        public int ObtenerIdModuloPorNombre(string nombreModulo)
        {
            string query = "SELECT pk_id_modulo FROM tbl_MODULO WHERE nombre_modulo = ?";
            using (OdbcConnection conn = conexion.conexion())
            using (OdbcCommand cmd = new OdbcCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@nombre", nombreModulo);
                var result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : -1;
            }
        }
    }
}