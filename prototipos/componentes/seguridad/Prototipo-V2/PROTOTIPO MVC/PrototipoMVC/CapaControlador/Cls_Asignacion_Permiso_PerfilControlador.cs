//Brandon Alexander Hernandez Salguero - 0901-22-9663
using System.Data;
using Capa_Modelo_Seguridad;
using System;


namespace Capa_Controlador_Seguridad
{
    public class Cls_Asignacion_Permiso_PerfilControlador
    {
        Cls_Asignacion_Permiso_PerfilesDAO DAO = new Cls_Asignacion_Permiso_PerfilesDAO();

        public DataTable datObtenerPerfiles()
        {
            return DAO.datObtenerPerfiles();
        }
        public DataTable datObtenerModulos()
        {
            return DAO.datObtenerModulos();
        }
        public DataTable datObtenerAplicaciones()
        {
            return DAO.datObtenerAplicaciones();
        }

         public bool bExistePermisoPerfil(int iIdPerfil, int iIdModulo, int iIdAplicacion)
            {
                return DAO.bExistePermisoPerfil(iIdPerfil, iIdModulo, iIdAplicacion);
            }

        public int iActualizarPermisoPerfilAplicacion(int iIdPerfil, int iIdModulo, int iIdAplicacion,
                                                     bool bIngresar, bool bConsultar, bool bModificar,
                                                     bool bEliminar, bool bImprimir)
        {
            return DAO.iActualizarPermisoPerfilAplicacion(iIdPerfil, iIdModulo, iIdAplicacion,
                                                             bIngresar, bConsultar, bModificar,
                                                             bEliminar, bImprimir);
        }
        public int iInsertarPermisoPerfilAplicacion(int iIdPerfil, int iIdModulo, int iIdAplicacion,
                                                    bool bIngresar, bool bConsultar, bool bModificar,
                                                    bool bEliminar, bool bImprimir)
        {
            return DAO.iInsertarPermisoPerfilAplicacion(iIdPerfil, iIdModulo, iIdAplicacion,
                                                           bIngresar, bConsultar, bModificar, bEliminar, bImprimir);
        }

        public DataTable datObtenerAplicacionesPorModulo(int iIdModulo)
        {
            return DAO.datObtenerAplicacionesPorModulo(iIdModulo);
        }

        public DataTable datObtenerPermisosPorPerfil(int iIdPerfil)
        {
            return DAO.datObtenerPermisosPorPerfil(iIdPerfil);
        }
    }
}


/*Carlo Sosa 0901-22-1106
 */

public class Cls_ControladorAsignacionPerfilAplicacion
        {
            Cls_Asignacion_Permiso_PerfilesDAO DAO = new Cls_Asignacion_Permiso_PerfilesDAO();

            public Cls_Asignacion_Perrmisos_Perfiles ObtenerPermisosAplicacionPerfil(int iIdPerfil, int iIdAplicacion)
            {
                DataTable dt = DAO.ObtenerPermisosPerfilAplicacion(iIdPerfil, iIdAplicacion);

                if (dt.Rows.Count == 0)
                    return null;

                DataRow row = dt.Rows[0];
                return new Cls_Asignacion_Perrmisos_Perfiles
                {
                    iFk_id_modulo = Convert.ToInt32(row["iFk_id_modulo"]),
                    iFk_id_perfil = Convert.ToInt32(row["iFk_id_perfil"]),
                    iFk_id_aplicacion = Convert.ToInt32(row["iFk_id_aplicacion"]),
                    bIngresar_permiso_aplicacion_perfil = Convert.ToBoolean(row["ingresar"]),
                    bConsultar_permiso_aplicacion_perfil = Convert.ToBoolean(row["consultar"]),
                    bModificar_permiso_aplicacion_perfil = Convert.ToBoolean(row["modificar"]),
                    bEliminar_permiso_aplicacion_perfil = Convert.ToBoolean(row["eliminar"]),
                    bImprimir_permiso_aplicacion_perfil = Convert.ToBoolean(row["imprimir"])
                };
            }
        }
        

    


