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
            string query = "SELECT Pk_Id_Usuario, Cmp_Nombre_Usuario FROM Tbl_Usuario";

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
            string query = "SELECT Pk_Id_Modulo, Cmp_Nombre_Modulo FROM Tbl_Modulo";

            using (OdbcConnection conn = conexion.conexion())
            using (OdbcCommand cmd = new OdbcCommand(query, conn))
            using (OdbcDataAdapter da = new OdbcDataAdapter(cmd))
            {
                da.Fill(dt);
            }

            return dt;
        }

        // Obtener aplicaciones filtradas por módulo
        public DataTable ObtenerAplicacionesPorModulo(int idModulo)
        {
            DataTable dt = new DataTable();
            string query = @"SELECT Pk_Id_Aplicacion, Cmp_Nombre_Aplicacion 
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

        // Verificar si existe un permiso
        public bool ExistePermiso(int idUsuario, int idModulo, int idAplicacion)
        {
            using (OdbcConnection conn = conexion.conexion())
            {
                string verificar = @"SELECT COUNT(*) 
                                     FROM Tbl_Permiso_Usuario_Aplicacion
                                     WHERE Fk_Id_Usuario = ? AND Fk_Id_Modulo = ? AND Fk_Id_Aplicacion = ?";

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
                string query = @"INSERT INTO Tbl_Permiso_Usuario_Aplicacion
                 (Fk_Id_Usuario, Fk_Id_Modulo, Fk_Id_Aplicacion,
                  Cmp_Ingresar_Permiso_Aplicacion_Usuario,
                  Cmp_Consultar_Permiso_Aplicacion_Usuario,
                  Cmp_Modificar_Permiso_Aplicacion_Usuario,
                  Cmp_Eliminar_Permiso_Aplicacion_Usuario,
                  Cmp_Imprimir_Permiso_Aplicacion_Usuario)
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
    }
}