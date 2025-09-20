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

namespace CapaModelo
{
    public class Cls_Asignacion_Permiso_PerfilesDAO
    {
        private Conexion conexion = new Conexion();
        public DataTable datObtenerPerfiles()
        {
            DataTable dt = new DataTable();
            string query = "SELECT pk_id_perfil, puesto_perfil FROM tbl_PERFIL";

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
        public DataTable datObtenerAplicaciones()
        {
            DataTable dt = new DataTable();
            string query = "SELECT pk_id_aplicacion, nombre_aplicacion FROM tbl_APLICACION";

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

            string query = @"INSERT INTO tbl_PERMISO_PERFIL_APLICACION
                (fk_id_modulo, fk_id_perfil, fk_id_aplicacion,
                 ingresar_permiso_aplicacion_perfil,
                 consultar_permiso_aplicacion_perfil,
                 modificar_permiso_aplicacion_perfil,
                 eliminar_permiso_aplicacion_perfil,
                 imprimir_permiso_aplicacion_perfil)
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
                             FROM tbl_PERMISO_PERFIL_APLICACION
                             WHERE fk_id_perfil = ? AND fk_id_modulo = ? AND fk_id_aplicacion = ?";

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

            string query = @"UPDATE tbl_PERMISO_PERFIL_APLICACION
                     SET ingresar_permiso_aplicacion_perfil = ?,
                         consultar_permiso_aplicacion_perfil = ?,
                         modificar_permiso_aplicacion_perfil = ?,
                         eliminar_permiso_aplicacion_perfil = ?,
                         imprimir_permiso_aplicacion_perfil = ?
                     WHERE fk_id_perfil = ? AND fk_id_modulo = ? AND fk_id_aplicacion = ?";

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
    }

}
