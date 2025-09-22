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
        public (bool ingresar, bool consultar, bool modificar, bool eliminar, bool imprimir)? ConsultarPermisos(int idUsuario, int idAplicacion, int idModulo)
        {
            string query = @"
                SELECT Cmp_Ingresar_Permiso_Aplicacion_Usuario,
                       Cmp_Consultar_Permiso_Aplicacion_Usuario,
                       Cmp_Modificar_Permiso_Aplicacion_Usuario,
                       Cmp_Eliminar_Permiso_Aplicacion_Usuario,
                       Cmp_Imprimir_Permiso_Aplicacion_Usuario
                FROM Tbl_Permiso_Usuario_Aplicacion
                WHERE Fk_Id_Usuario = ? AND Fk_Id_Aplicacion = ? AND Fk_Id_Modulo = ?;
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
        public int ObtenerIdAplicacionPorNombre(string nombreAplicacion)
        {
            string query = "SELECT Pk_Id_Aplicacion FROM Tbl_Aplicacion WHERE Cmp_Nombre_Aplicacion = ?";
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
        public int ObtenerIdModuloPorNombre(string nombreModulo)
        {
            string query = "SELECT Pk_Id_Modulo FROM Tbl_Modulo WHERE Cmp_Nombre_Modulo = ?";
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
