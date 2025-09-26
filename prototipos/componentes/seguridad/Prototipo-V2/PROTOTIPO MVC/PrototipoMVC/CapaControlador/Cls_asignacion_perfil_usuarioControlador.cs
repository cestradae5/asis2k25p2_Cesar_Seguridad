using System.Data;
using Capa_Modelo_Seguridad;
/* Brandon Alexander Hernandez Salguero
 * 0901-22-9663
 */

namespace Capa_Controlador_Seguridad
{
    public class Cls_asignacion_perfil_usuarioControlador
    {
        Cls_asignacion_perfil_usuarioDAO DAO = new Cls_asignacion_perfil_usuarioDAO();

        public DataTable datObtenerUsuarios()
        {
            return DAO.datObtenerUsuarios();
        }

        public DataTable datObtenerPerfiles()
        {
            return DAO.datObtenerPerfiles();
        }

        public bool bInsertar(int id_usuario, int id_perfil)
        {
            Cls_asignacion_perfil_usuario nuevaRelacion = new Cls_asignacion_perfil_usuario
            {
                Fk_Id_Usuario = id_usuario,
                Fk_Id_Perfil = id_perfil,
            };

            return DAO.bInsertar(nuevaRelacion);
        }
    }
}