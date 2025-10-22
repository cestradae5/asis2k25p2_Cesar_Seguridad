using System;
using System.Data.Odbc;

namespace Capa_Modelo_Seguridad
{
    public class Cls_Permiso_Usuario
    {
        private Cls_Conexion conexion = new Cls_Conexion();

        /// <summary>
        /// Obtiene los permisos de un usuario para una aplicación y módulo específicos.
        /// </summary>
        /// <returns>
        /// Una tupla con los permisos (ingresar, consultar, modificar, eliminar, imprimir) o null si no hay registro.
        /// </returns>
        public (bool ingresar, bool consultar, bool modificar, bool eliminar, bool imprimir)? ConsultarPermisos(int iIdUsuario, int iIdAplicacion, int iIdModulo)
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
                cmd.Parameters.AddWithValue("@Fk_Id_Usuario", iIdUsuario);
                cmd.Parameters.AddWithValue("@Fk_Id_Aplicacion", iIdAplicacion);
                cmd.Parameters.AddWithValue("@Fk_Id_Modulo", iIdModulo);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return (
                            reader.GetBoolean(0), // Ingresar
                            reader.GetBoolean(1), // Consultar
                            reader.GetBoolean(2), // Modificar
                            reader.GetBoolean(3), // Eliminar
                            reader.GetBoolean(4)  // Imprimir
                        );
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Obtiene el ID de una aplicación por su nombre.
        /// </summary>
        public int ObtenerIdAplicacionPorNombre(string sNombreAplicacion)
        {
            string query = "SELECT Pk_Id_Aplicacion FROM Tbl_Aplicacion WHERE Cmp_Nombre_Aplicacion = ?";
            using (OdbcConnection conn = conexion.conexion())
            using (OdbcCommand cmd = new OdbcCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Cmp_Nombre_Aplicacion", sNombreAplicacion);
                var result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : -1;
            }
        }

        /// <summary>
        /// Obtiene el ID de un módulo por su nombre.
        /// </summary>
        public int ObtenerIdModuloPorNombre(string sNombreModulo)
        {
            string query = "SELECT Pk_Id_Modulo FROM Tbl_Modulo WHERE Cmp_Nombre_Modulo = ?";
            using (OdbcConnection conn = conexion.conexion())
            using (OdbcCommand cmd = new OdbcCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Cmp_Nombre_Modulo", sNombreModulo);
                var result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : -1;
            }
        }
    }
}