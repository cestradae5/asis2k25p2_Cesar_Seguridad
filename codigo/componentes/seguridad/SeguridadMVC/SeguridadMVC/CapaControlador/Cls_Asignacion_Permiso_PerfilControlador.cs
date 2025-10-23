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



    


