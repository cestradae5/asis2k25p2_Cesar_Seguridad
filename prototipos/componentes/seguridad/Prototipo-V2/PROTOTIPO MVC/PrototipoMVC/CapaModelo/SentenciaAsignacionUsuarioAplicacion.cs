using System;
using System.Data;
using System.Data.Odbc;

namespace CapaModelo
{
    /* Brandon Alexander Hernandez Salguero
 * 0901-22-9663
 * */
    public class SentenciaAsignacionUsuarioAplicacion
    {
        Conexion conexion = new Conexion();

        // Obtener todos los usuarios
        public DataTable ObtenerUsuarios()
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

        // Obtener todos los módulos
        public DataTable ObtenerModulos()
        {
            DataTable dt = new DataTable();
            string query = "SELECT pk_id_modulo, nombre_modulo FROM tbl_MODULO";

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

        // Obtener aplicaciones por módulo
        public DataTable ObtenerAplicacionesPorModulo(int idModulo)
        {
            DataTable dt = new DataTable();
            string query = @"SELECT a.pk_id_aplicacion, a.nombre_aplicacion
                             FROM tbl_ASIGNACION_MODULO_APLICACION ama
                             INNER JOIN tbl_APLICACION a ON ama.fk_id_aplicacion = a.pk_id_aplicacion
                             WHERE ama.fk_id_modulo = ?";

            using (OdbcConnection conn = conexion.conexion())
            {
                using (OdbcCommand cmd = new OdbcCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idModulo", idModulo);
                    using (OdbcDataAdapter da = new OdbcDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }

            return dt;
        }

        // Insertar permisos de usuario por aplicación
        public int InsertarPermisoUsuarioAplicacion(int idUsuario, int idModulo, int idAplicacion,
                                                    bool ingresar, bool consultar, bool modificar,
                                                    bool eliminar, bool imprimir)
        {
            int filasAfectadas = 0;

            string query = @"INSERT INTO tbl_PERMISO_USUARIO_APLICACION
                             (fk_id_usuario, fk_id_aplicacion, fk_id_modulo,
                              ingresar_permiso_aplicacion_usuario,
                              consultar_permiso_aplicacion_usuario,
                              modificar_permiso_aplicacion_usuario,
                              eliminar_permiso_aplicacion_usuario,
                              imprimir_permiso_aplicacion_usuario)
                             VALUES (?, ?, ?, ?, ?, ?, ?, ?)";

            using (OdbcConnection conn = conexion.conexion())
            {
                using (OdbcCommand cmd = new OdbcCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@usuario", idUsuario);
                    cmd.Parameters.AddWithValue("@aplicacion", idAplicacion);
                    cmd.Parameters.AddWithValue("@modulo", idModulo);
                    cmd.Parameters.AddWithValue("@ingresar", ingresar);
                    cmd.Parameters.AddWithValue("@consultar", consultar);
                    cmd.Parameters.AddWithValue("@modificar", modificar);
                    cmd.Parameters.AddWithValue("@eliminar", eliminar);
                    cmd.Parameters.AddWithValue("@imprimir", imprimir);

                    filasAfectadas = cmd.ExecuteNonQuery();
                }
            }

            return filasAfectadas;
        }

        // Aquí puedes agregar métodos para eliminar permisos si lo necesitas
    }
}
