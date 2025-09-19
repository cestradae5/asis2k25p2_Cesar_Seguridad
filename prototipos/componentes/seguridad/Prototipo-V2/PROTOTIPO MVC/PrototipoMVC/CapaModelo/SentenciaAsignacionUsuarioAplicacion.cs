using System;
using System.Data;
using System.Data.Odbc;

namespace CapaModelo
{
    /* Marcos Andres Velásquez Alcántara 0901-22-1115 */
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

        // Obtener aplicaciones filtradas por módulo
        public DataTable ObtenerAplicacionesPorModulo(int idModulo)
        {
            DataTable dt = new DataTable();
            string query = @"SELECT pk_id_aplicacion, nombre_aplicacion 
                             FROM tbl_APLICACION 
                             WHERE estado_aplicacion = 1 AND fk_id_modulo = ?";

            using (OdbcConnection conn = conexion.conexion())
            {
                using (OdbcCommand cmd = new OdbcCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", idModulo);

                    using (OdbcDataAdapter da = new OdbcDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }

            return dt;
        }

        // Verificar si existe un permiso
        public bool ExistePermiso(int idUsuario, int idModulo, int idAplicacion)
        {
            using (OdbcConnection conn = conexion.conexion())
            {
                string verificar = @"SELECT COUNT(*) 
                                     FROM tbl_PERMISO_USUARIO_APLICACION
                                     WHERE fk_id_usuario = ? AND fk_id_modulo = ? AND fk_id_aplicacion = ?";

                using (OdbcCommand cmd = new OdbcCommand(verificar, conn))
                {
                    cmd.Parameters.AddWithValue("?", idUsuario);
                    cmd.Parameters.AddWithValue("?", idModulo);
                    cmd.Parameters.AddWithValue("?", idAplicacion);

                    int existe = Convert.ToInt32(cmd.ExecuteScalar());
                    return existe > 0;
                }
            }
        }

        // Insertar permisos de usuario por aplicación
        public int InsertarPermisoUsuarioAplicacion(int idUsuario, int idModulo, int idAplicacion,
                                                    bool ingresar, bool consultar, bool modificar,
                                                    bool eliminar, bool imprimir)
        {
            int filasAfectadas = 0;

            using (OdbcConnection conn = conexion.conexion())
            {
                string query = @"INSERT INTO tbl_PERMISO_USUARIO_APLICACION
                                 (fk_id_usuario, fk_id_modulo, fk_id_aplicacion,
                                  ingresar_permiso_aplicacion_usuario,
                                  consultar_permiso_aplicacion_usuario,
                                  modificar_permiso_aplicacion_usuario,
                                  eliminar_permiso_aplicacion_usuario,
                                  imprimir_permiso_aplicacion_usuario)
                                 VALUES (?, ?, ?, ?, ?, ?, ?, ?)";

                using (OdbcCommand cmdInsertar = new OdbcCommand(query, conn))
                {
                    cmdInsertar.Parameters.AddWithValue("?", idUsuario);
                    cmdInsertar.Parameters.AddWithValue("?", idModulo);
                    cmdInsertar.Parameters.AddWithValue("?", idAplicacion);
                    cmdInsertar.Parameters.AddWithValue("?", ingresar);
                    cmdInsertar.Parameters.AddWithValue("?", consultar);
                    cmdInsertar.Parameters.AddWithValue("?", modificar);
                    cmdInsertar.Parameters.AddWithValue("?", eliminar);
                    cmdInsertar.Parameters.AddWithValue("?", imprimir);

                    filasAfectadas = cmdInsertar.ExecuteNonQuery();
                }
            }

            return filasAfectadas;
        }

        // Pablo Quiroa 0901-22-2929
        public int ActualizarPermisoUsuarioAplicacion(int idUsuario, int idModulo, int idAplicacion,
                                                      bool ingresar, bool consultar, bool modificar,
                                                      bool eliminar, bool imprimir)
        {
            int filasAfectadas = 0;

            string query = @"UPDATE tbl_PERMISO_USUARIO_APLICACION
                             SET ingresar_permiso_aplicacion_usuario = ?,
                                 consultar_permiso_aplicacion_usuario = ?,
                                 modificar_permiso_aplicacion_usuario = ?,
                                 eliminar_permiso_aplicacion_usuario = ?,
                                 imprimir_permiso_aplicacion_usuario = ?
                             WHERE fk_id_usuario = ? AND fk_id_modulo = ? AND fk_id_aplicacion = ?";

            using (OdbcConnection conn = conexion.conexion())
            {
                using (OdbcCommand cmd = new OdbcCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", ingresar);
                    cmd.Parameters.AddWithValue("?", consultar);
                    cmd.Parameters.AddWithValue("?", modificar);
                    cmd.Parameters.AddWithValue("?", eliminar);
                    cmd.Parameters.AddWithValue("?", imprimir);
                    cmd.Parameters.AddWithValue("?", idUsuario);
                    cmd.Parameters.AddWithValue("?", idModulo);
                    cmd.Parameters.AddWithValue("?", idAplicacion);

                    filasAfectadas = cmd.ExecuteNonQuery();
                }
            }

            return filasAfectadas;
        }
    }
}
