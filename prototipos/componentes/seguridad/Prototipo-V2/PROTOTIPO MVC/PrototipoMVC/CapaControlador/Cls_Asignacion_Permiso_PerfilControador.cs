//Brandon Alexander Hernandez Salguero - 0901-22-9663
using System.Data;
using Capa_Modelo_Seguridad;

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

         public bool bExistePermisoPerfil(int idPerfil, int idModulo, int idAplicacion)
            {
                return DAO.bExistePermisoPerfil(idPerfil, idModulo, idAplicacion);
            }
        
        public int iActualizarPermisoPerfilAplicacion(int idPerfil, int idModulo, int idAplicacion,
                                                      bool ingresar, bool consultar, bool modificar,
                                                      bool eliminar, bool imprimir)
        {
            return DAO.iActualizarPermisoPerfilAplicacion(idPerfil, idModulo, idAplicacion,
                                                            ingresar, consultar, modificar,
                                                            eliminar, imprimir);
        }
        public int iInsertarPermisoPerfilAplicacion(int idPerfil, int idModulo, int idAplicacion,
                                                    bool ingresar, bool consultar, bool modificar,
                                                    bool eliminar, bool imprimir)
        {
            return DAO.iInsertarPermisoPerfilAplicacion(idPerfil, idModulo, idAplicacion,
                                                        ingresar, consultar, modificar, eliminar, imprimir);
        }

       

    }

}
