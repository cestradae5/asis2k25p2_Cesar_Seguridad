//Brandon Alexander Hernandez Salguero - 0901-22-9663
using System.Data;
using Capa_Modelo_Seguridad;
using System;


namespace Capa_Controlador_Seguridad
{
    public class Cls_Asignacion_Permiso_PerfilControador
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

         public bool bExistePermisoPerfil(int IidPerfil, int IidModulo, int IidAplicacion)
            {
                return DAO.bExistePermisoPerfil(IidPerfil, IidModulo, IidAplicacion);
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

            public Cls_Asignacion_Perrmisos_Perfiles ObtenerPermisosAplicacionPerfil(int idPerfil, int idAplicacion)
            {
                DataTable dt = DAO.ObtenerPermisosPerfilAplicacion(idPerfil, idAplicacion);

                if (dt.Rows.Count == 0)
                    return null;

                DataRow row = dt.Rows[0];
                return new Cls_Asignacion_Perrmisos_Perfiles
                {
                    fk_id_modulo = Convert.ToInt32(row["fk_id_modulo"]),
                    fk_id_perfil = Convert.ToInt32(row["fk_id_perfil"]),
                    fk_id_aplicacion = Convert.ToInt32(row["fk_id_aplicacion"]),
                    ingresar_permiso_aplicacion_perfil = Convert.ToBoolean(row["ingresar"]),
                    consultar_permiso_aplicacion_perfil = Convert.ToBoolean(row["consultar"]),
                    modificar_permiso_aplicacion_perfil = Convert.ToBoolean(row["modificar"]),
                    eliminar_permiso_aplicacion_perfil = Convert.ToBoolean(row["eliminar"]),
                    imprimir_permiso_aplicacion_perfil = Convert.ToBoolean(row["imprimir"])
                };
            }
        }
        

    


