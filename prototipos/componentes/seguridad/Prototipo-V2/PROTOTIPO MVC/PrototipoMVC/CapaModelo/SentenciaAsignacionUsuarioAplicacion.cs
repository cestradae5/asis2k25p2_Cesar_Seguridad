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
            string query = "SELECT Pk_Id_Usuario, Cmp_Nombre_Usuario AS nombre_usuario FROM Tbl_Usuario";

            using (OdbcConnection conn = conexion.conexion())
            using (OdbcCommand cmd = new OdbcCommand(query, conn))
            using (OdbcDataAdapter da = new OdbcDataAdapter(cmd))
            {
                da.Fill(dt);
            }
            return dt;
        }

        // Obtener todos los módulos
        public DataTable ObtenerModulos()
        {
            DataTable dt = new DataTable();
            string query = "SELECT Pk_Id_Modulo, Cmp_Nombre_Modulo AS nombre_modulo FROM Tbl_Modulo";

            using (OdbcConnection conn = conexion.conexion())
            using (OdbcCommand cmd = new OdbcCommand(query, conn))
            using (OdbcDataAdapter da = new OdbcDataAdapter(cmd))
            {
                da.Fill(dt);
            }
            return dt;
        }

        // Pablo Quiroa 0901-22-2929
        public DataTable ObtenerAplicacionesPorModulo(int idModulo)
        {
            DataTable dt = new DataTable();
            string query = @"SELECT Pk_Id_Aplicacion, 
                                    Cmp_Nombre_Aplicacion AS nombre_aplicacion
                             FROM Tbl_Aplicacion 
                             WHERE Cmp_Estado_Aplicacion = 1 AND Fk_Id_Modulo = ?";

            using (OdbcConnection conn = conexion.conexion())
            using (OdbcCommand cmd = new OdbcCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("?", idModulo);
                using (OdbcDataAdapter da = new OdbcDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }
            return dt;
        }

        // Obtener permisos por usuario
        public DataTable ObtenerPermisosPorUsuario(int idUsuario)
        {
            DataTable dt = new DataTable();
            string query = @"SELECT u.Cmp_Nombre_Usuario AS nombre_usuario,
                                    m.Cmp_Nombre_Modulo AS nombre_modulo,
                                    a.Cmp_Nombre_Aplicacion AS nombre_aplicacion,
                                    p.Cmp_Ingresar_Permiso_Aplicacion_Usuario AS ingresar_permiso_aplicacion_usuario,
                                    p.Cmp_Consultar_Permiso_Aplicacion_Usuario AS consultar_permiso_aplicacion_usuario,
                                    p.Cmp_Modificar_Permiso_Aplicacion_Usuario AS modificar_permiso_aplicacion_usuario,
                                    p.Cmp_Eliminar_Permiso_Aplicacion_Usuario AS eliminar_permiso_aplicacion_usuario,
                                    p.Cmp_Imprimir_Permiso_Aplicacion_Usuario AS imprimir_permiso_aplicacion_usuario,
                                    p.Fk_Id_Usuario AS fk_id_usuario,
                                    p.Fk_Id_Modulo AS fk_id_modulo,
                                    p.Fk_Id_Aplicacion AS fk_id_aplicacion
                             FROM Tbl_Permiso_Usuario_Aplicacion p
                             INNER JOIN Tbl_Usuario u ON u.Pk_Id_Usuario = p.Fk_Id_Usuario
                             INNER JOIN Tbl_Aplicacion a ON a.Pk_Id_Aplicacion = p.Fk_Id_Aplicacion
                             INNER JOIN Tbl_Modulo m ON m.Pk_Id_Modulo = p.Fk_Id_Modulo
                             WHERE p.Fk_Id_Usuario = ?";

            using (OdbcConnection conn = conexion.conexion())
            using (OdbcCommand cmd = new OdbcCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("?", idUsuario);
                using (OdbcDataAdapter da = new OdbcDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }
            return dt;
        }

        // Verificar si existe un permiso
        public bool ExistePermiso(int idUsuario, int idModulo, int idAplicacion)
        {
            string verificar = @"SELECT COUNT(*) 
                                 FROM Tbl_Permiso_Usuario_Aplicacion
                                 WHERE Fk_Id_Usuario = ? AND Fk_Id_Modulo = ? AND Fk_Id_Aplicacion = ?";

            using (OdbcConnection conn = conexion.conexion())
            using (OdbcCommand cmd = new OdbcCommand(verificar, conn))
            {
                cmd.Parameters.AddWithValue("?", idUsuario);
                cmd.Parameters.AddWithValue("?", idModulo);
                cmd.Parameters.AddWithValue("?", idAplicacion);

                int existe = Convert.ToInt32(cmd.ExecuteScalar());
                return existe > 0;
            }
        }

        // Insertar permisos de usuario por aplicación
        public int InsertarPermisoUsuarioAplicacion(int idUsuario, int idModulo, int idAplicacion,
                                                    bool ingresar, bool consultar, bool modificar,
                                                    bool eliminar, bool imprimir)
        {
            int filasAfectadas = 0;
            string query = @"INSERT INTO Tbl_Permiso_Usuario_Aplicacion
                             (Fk_Id_Usuario, Fk_Id_Modulo, Fk_Id_Aplicacion,
                              Cmp_Ingresar_Permiso_Aplicacion_Usuario,
                              Cmp_Consultar_Permiso_Aplicacion_Usuario,
                              Cmp_Modificar_Permiso_Aplicacion_Usuario,
                              Cmp_Eliminar_Permiso_Aplicacion_Usuario,
                              Cmp_Imprimir_Permiso_Aplicacion_Usuario)
                             VALUES (?, ?, ?, ?, ?, ?, ?, ?)";

            using (OdbcConnection conn = conexion.conexion())
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
            return filasAfectadas;
        }

        // Actualizar permisos de usuario por aplicación
        public int ActualizarPermisoUsuarioAplicacion(int idUsuario, int idModulo, int idAplicacion,
                                                      bool ingresar, bool consultar, bool modificar,
                                                      bool eliminar, bool imprimir)
        {
            int filasAfectadas = 0;
            string query = @"UPDATE Tbl_Permiso_Usuario_Aplicacion
                             SET Cmp_Ingresar_Permiso_Aplicacion_Usuario = ?,
                                 Cmp_Consultar_Permiso_Aplicacion_Usuario = ?,
                                 Cmp_Modificar_Permiso_Aplicacion_Usuario = ?,
                                 Cmp_Eliminar_Permiso_Aplicacion_Usuario = ?,
                                 Cmp_Imprimir_Permiso_Aplicacion_Usuario = ?
                             WHERE Fk_Id_Usuario = ? AND Fk_Id_Modulo = ? AND Fk_Id_Aplicacion = ?";

            using (OdbcConnection conn = conexion.conexion())
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
            return filasAfectadas;
        }

        //Ruben Armando Lopez Luch
        //0901-20-4620
        public DataTable fun_bbtener_permisos_por_usuario_modulo(int iIdUsuario, int iIdModulo)
        {
            DataTable dt = new DataTable();
            using (OdbcConnection conn = conexion.conexion())
            {
                string sSql = @"SELECT * 
                         FROM Tbl_Permiso_Usuario_Aplicacion
                         WHERE Fk_Id_Usuario = ? AND Fk_Id_Modulo = ?";

                using (OdbcCommand cmd = new OdbcCommand(sSql, conn))
                {
                    cmd.Parameters.AddWithValue("?", iIdUsuario);
                    cmd.Parameters.AddWithValue("?", iIdModulo);

                    using (OdbcDataAdapter da = new OdbcDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        // fin -> Ruben Armando Lopez Luch
    }
}
