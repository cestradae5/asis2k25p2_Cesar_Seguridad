using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Odbc;

/* Brandon Alexander Hernandez Salguero
 * 0901-22-9663
 */

namespace Capa_Modelo_Seguridad
{
    public class Cls_Asignacion_Permiso_PerfilesDAO
    {
        private Cls_Conexion conexion = new Cls_Conexion();

        public DataTable datObtenerPerfiles()
        {
            DataTable dt = new DataTable();
            string query = "SELECT Pk_Id_Perfil, Cmp_Puesto_Perfil FROM Tbl_Perfil";

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

        public DataTable datObtenerModulos()
        {
            DataTable dt = new DataTable();
            string query = "SELECT Pk_Id_Modulo, Cmp_Nombre_Modulo FROM Tbl_Modulo";

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

        public DataTable datObtenerAplicaciones()
        {
            DataTable dt = new DataTable();
            string query = "SELECT Pk_Id_Aplicacion, Cmp_Nombre_Aplicacion FROM Tbl_Aplicacion";

            using (OdbcConnection conn = conexion.conexion())
            {
                using (OdbcCommand cmd = new OdbcCommand(query, conn))
                {
                    using (OdbcDataAdapter da = new OdbcDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
                return dt;
            }
        }

        public int iInsertarPermisoPerfilAplicacion(
            int idPerfil,
            int idModulo,
            int idAplicacion,
            bool ingresar,
            bool consultar,
            bool modificar,
            bool eliminar,
            bool imprimir)
        {
            int filasAfectadas = 0;

            string query = @"INSERT INTO Tbl_Permiso_Perfil_Aplicacion
                (Fk_Id_Modulo, Fk_Id_Perfil, Fk_Id_Aplicacion,
                 Cmp_Ingresar_Permisos_Aplicacion_Perfil,
                 Cmp_Consultar_Permisos_Aplicacion_Perfil,
                 Cmp_Modificar_Permisos_Aplicacion_Perfil,
                 Cmp_Eliminar_Permisos_Aplicacion_Perfil,
                 Cmp_Imprimir_Permisos_Aplicacion_Perfil)
                VALUES (?, ?, ?, ?, ?, ?, ?, ?)";

            using (OdbcConnection conn = conexion.conexion())
            {
                using (OdbcCommand cmd = new OdbcCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", idModulo);
                    cmd.Parameters.AddWithValue("?", idPerfil);
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

        public bool bExistePermisoPerfil(int idPerfil, int idModulo, int idAplicacion)
        {
            using (OdbcConnection conn = conexion.conexion())
            {
                string verificar = @"SELECT COUNT(*) 
                             FROM Tbl_Permiso_Perfil_Aplicacion
                             WHERE Fk_Id_Perfil = ? AND Fk_Id_Modulo = ? AND Fk_Id_Aplicacion = ?";

                using (OdbcCommand cmd = new OdbcCommand(verificar, conn))
                {
                    cmd.Parameters.AddWithValue("?", idPerfil);
                    cmd.Parameters.AddWithValue("?", idModulo);
                    cmd.Parameters.AddWithValue("?", idAplicacion);

                    int existe = Convert.ToInt32(cmd.ExecuteScalar());
                    return existe > 0;
                }
            }
        }

        public int iActualizarPermisoPerfilAplicacion(int idPerfil, int idModulo, int idAplicacion,
                                             bool ingresar, bool consultar, bool modificar,
                                             bool eliminar, bool imprimir)
        {
            int filasAfectadas = 0;

            string query = @"UPDATE Tbl_Permiso_Perfil_Aplicacion
                     SET Cmp_Ingresar_Permisos_Aplicacion_Perfil = ?,
                         Cmp_Consultar_Permisos_Aplicacion_Perfil = ?,
                         Cmp_Modificar_Permisos_Aplicacion_Perfil = ?,
                         Cmp_Eliminar_Permisos_Aplicacion_Perfil = ?,
                         Cmp_Imprimir_Permisos_Aplicacion_Perfil = ?
                     WHERE Fk_Id_Perfil = ? AND Fk_Id_Modulo = ? AND Fk_Id_Aplicacion = ?";

            using (OdbcConnection conn = conexion.conexion())
            {
                using (OdbcCommand cmd = new OdbcCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", ingresar);
                    cmd.Parameters.AddWithValue("?", consultar);
                    cmd.Parameters.AddWithValue("?", modificar);
                    cmd.Parameters.AddWithValue("?", eliminar);
                    cmd.Parameters.AddWithValue("?", imprimir);
                    cmd.Parameters.AddWithValue("?", idPerfil);
                    cmd.Parameters.AddWithValue("?", idModulo);
                    cmd.Parameters.AddWithValue("?", idAplicacion);

                    filasAfectadas = cmd.ExecuteNonQuery();
                }
            }

            return filasAfectadas;
        }

        // Dentro de la clase Cls_Asignacion_Permiso_PerfilesDAO
        public DataTable datObtenerAplicacionesPorModulo(int idModulo)
        {
            DataTable dt = new DataTable();
            // Consulta JOIN entre Tbl_Aplicacion y Tbl_Asignacion_Modulo_Aplicacion
            string query = @"
        SELECT a.Pk_Id_Aplicacion, 
        a.Cmp_Nombre_Aplicacion 
        FROM Tbl_Aplicacion a
        INNER JOIN Tbl_Asignacion_Modulo_Aplicacion ma 
        ON a.Pk_Id_Aplicacion = ma.Fk_Id_Aplicacion
        WHERE a.Cmp_Estado_Aplicacion = 1 
        AND ma.Fk_Id_Modulo = ?";

            try
            {
                using (OdbcConnection conn = conexion.conexion())
                {
                    using (OdbcCommand cmd = new OdbcCommand(query, conn))
                    {
                        // Agregamos el parámetro del módulo para el WHERE
                        cmd.Parameters.AddWithValue("?", idModulo);
                        using (OdbcDataAdapter da = new OdbcDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de error
                Console.WriteLine("Error al obtener aplicaciones por módulo: " + ex.Message);
            }
            return dt;
        }
    }
}
