//Inicio de código de Arón Ricardo Esquit Silva   0901-22-13036   14/10/2025

using System;
using System.Data;
using System.Data.Odbc;

namespace Capa_Modelo_Seguridad
{
    public class Cls_Consulta_Asignaciones_Bitacora
    {
        private readonly Cls_Conexion ctrlConexion = new Cls_Conexion();

        // Permisos con usuarios
        public Cls_Permisos fun_ConsultarPermisosAsignados(int iIdUsuario, int iIdModulo, int iIdAplicacion)
        {
            Cls_Permisos gPermisos = new Cls_Permisos();

            string sSql = @"
                SELECT 
                    Cmp_Ingresar_Permiso_Aplicacion_Usuario,
                    Cmp_Consultar_Permiso_Aplicacion_Usuario,
                    Cmp_Modificar_Permiso_Aplicacion_Usuario,
                    Cmp_Eliminar_Permiso_Aplicacion_Usuario,
                    Cmp_Imprimir_Permiso_Aplicacion_Usuario
                FROM Tbl_Permiso_Usuario_Aplicacion
                WHERE Fk_Id_Usuario = ?
                  AND Fk_Id_Modulo = ?
                  AND Fk_Id_Aplicacion = ?;";

            using (OdbcConnection gConexion = ctrlConexion.conexion())
            using (OdbcCommand gComando = new OdbcCommand(sSql, gConexion))
            {
                gComando.Parameters.AddWithValue("@idUsuario", iIdUsuario);
                gComando.Parameters.AddWithValue("@idModulo", iIdModulo);
                gComando.Parameters.AddWithValue("@idAplicacion", iIdAplicacion);

                using (OdbcDataReader gLector = gComando.ExecuteReader())
                {
                    if (gLector.Read())
                    {
                        gPermisos.bIngresar = gLector["Cmp_Ingresar_Permiso_Aplicacion_Usuario"] != DBNull.Value && Convert.ToBoolean(gLector["Cmp_Ingresar_Permiso_Aplicacion_Usuario"]);
                        gPermisos.bConsultar = gLector["Cmp_Consultar_Permiso_Aplicacion_Usuario"] != DBNull.Value && Convert.ToBoolean(gLector["Cmp_Consultar_Permiso_Aplicacion_Usuario"]);
                        gPermisos.bModificar = gLector["Cmp_Modificar_Permiso_Aplicacion_Usuario"] != DBNull.Value && Convert.ToBoolean(gLector["Cmp_Modificar_Permiso_Aplicacion_Usuario"]);
                        gPermisos.bEliminar = gLector["Cmp_Eliminar_Permiso_Aplicacion_Usuario"] != DBNull.Value && Convert.ToBoolean(gLector["Cmp_Eliminar_Permiso_Aplicacion_Usuario"]);
                        gPermisos.bImprimir = gLector["Cmp_Imprimir_Permiso_Aplicacion_Usuario"] != DBNull.Value && Convert.ToBoolean(gLector["Cmp_Imprimir_Permiso_Aplicacion_Usuario"]);
                    }
                }

                ctrlConexion.desconexion(gConexion);
            }

            return gPermisos;
        }

        // Permisos por pefil

        public Cls_Permisos fun_ConsultarPermisosPerfil(int iIdPerfil, int iIdModulo, int iIdAplicacion)
        {
            Cls_Permisos gPermisos = new Cls_Permisos();

            string sSql = @"
                SELECT 
                    Cmp_Ingresar_Permisos_Aplicacion_Perfil,
                    Cmp_Consultar_Permisos_Aplicacion_Perfil,
                    Cmp_Modificar_Permisos_Aplicacion_Perfil,
                    Cmp_Eliminar_Permisos_Aplicacion_Perfil,
                    Cmp_Imprimir_Permisos_Aplicacion_Perfil
                  FROM Tbl_Permiso_Perfil_Aplicacion
                  WHERE Fk_Id_Perfil = ?
                    AND Fk_Id_Modulo = ?
                    AND Fk_Id_Aplicacion = ?;";

            using (OdbcConnection gConexion = ctrlConexion.conexion())
            using (OdbcCommand gComando = new OdbcCommand(sSql, gConexion))
            {
                gComando.Parameters.AddWithValue("@idPerfil", iIdPerfil);
                gComando.Parameters.AddWithValue("@idModulo", iIdModulo);
                gComando.Parameters.AddWithValue("@idAplicacion", iIdAplicacion);

                using (OdbcDataReader gLector = gComando.ExecuteReader())
                {
                    if (gLector.Read())
                    {
                        gPermisos.bIngresar = gLector["Cmp_Ingresar_Permisos_Aplicacion_Perfil"] != DBNull.Value && Convert.ToBoolean(gLector["Cmp_Ingresar_Permisos_Aplicacion_Perfil"]);
                        gPermisos.bConsultar = gLector["Cmp_Consultar_Permisos_Aplicacion_Perfil"] != DBNull.Value && Convert.ToBoolean(gLector["Cmp_Consultar_Permisos_Aplicacion_Perfil"]);
                        gPermisos.bModificar = gLector["Cmp_Modificar_Permisos_Aplicacion_Perfil"] != DBNull.Value && Convert.ToBoolean(gLector["Cmp_Modificar_Permisos_Aplicacion_Perfil"]);
                        gPermisos.bEliminar = gLector["Cmp_Eliminar_Permisos_Aplicacion_Perfil"] != DBNull.Value && Convert.ToBoolean(gLector["Cmp_Eliminar_Permisos_Aplicacion_Perfil"]);
                        gPermisos.bImprimir = gLector["Cmp_Imprimir_Permisos_Aplicacion_Perfil"] != DBNull.Value && Convert.ToBoolean(gLector["Cmp_Imprimir_Permisos_Aplicacion_Perfil"]);
                    }
                }

                ctrlConexion.desconexion(gConexion);
            }

            return gPermisos;
        }
    }


    // Clase para los permisos
    public class Cls_Permisos
    {
        public bool bIngresar { get; set; }
        public bool bConsultar { get; set; }
        public bool bModificar { get; set; }
        public bool bEliminar { get; set; }
        public bool bImprimir { get; set; }
    }
}

//Fin del código de Arón Ricardo Esquit Silva   0901-22-13036   14/10/2025
