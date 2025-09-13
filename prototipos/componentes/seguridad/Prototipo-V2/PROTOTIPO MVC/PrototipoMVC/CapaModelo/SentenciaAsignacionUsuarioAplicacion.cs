using System;
using System.Data;
using System.Data.Odbc;

namespace CapaModelo
{
    /* Marcos Andres Velásquez Alcántara
 * 0901-22-1115
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
        public DataTable ObtenerAplicaciones()
        {
            DataTable dt = new DataTable();
            string query = "SELECT pk_id_aplicacion, nombre_aplicacion FROM tbl_APLICACION WHERE estado_aplicacion = 1";

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





        // Insertar permisos de usuario por aplicación
        public int InsertarPermisoUsuarioAplicacion(int idUsuario, int idModulo, int idAplicacion,
                                                    bool ingresar, bool consultar, bool modificar,
                                                    bool eliminar, bool imprimir)
        {
            int filasAfectadas = 0;

            string query = @"INSERT INTO tbl_PERMISO_USUARIO_APLICACION
                     (fk_id_usuario, fk_id_modulo, fk_id_aplicacion,
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
                    cmd.Parameters.AddWithValue("?", idUsuario);
                    cmd.Parameters.AddWithValue("?", idModulo);
                    cmd.Parameters.AddWithValue("?", idAplicacion);
                    cmd.Parameters.AddWithValue("?", ingresar);
                    cmd.Parameters.AddWithValue("?", consultar);
                    cmd.Parameters.AddWithValue("?", modificar);
                    cmd.Parameters.AddWithValue("?", eliminar);
                    cmd.Parameters.AddWithValue("?", imprimir);

                    filasAfectadas = cmd.ExecuteNonQuery();
                }
            }

            return filasAfectadas;
        }

        // Aquí puedes agregar métodos para eliminar permisos si lo necesitas
    }
}
