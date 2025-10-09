using System.Data;
using System;

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

       
        /// Obtiene la lista de perfiles (para llenar combo en la vista).
     
        public DataTable datObtenerPerfiles()
        {
            return DAO.datObtenerPerfiles();
        }


        /// Inserta la relación usuario-perfil. Devuelve true si se pudo insertar,
  
        public bool bInsertar(int iId_usuario, int iId_perfil, out string smensajeError)
        {
            Cls_asignacion_perfil_usuario nuevaRelacion = new Cls_asignacion_perfil_usuario
            {
                Fk_Id_Usuario = iId_usuario,
                Fk_Id_Perfil = iId_perfil,
            };

            // Llama al método DAO que maneja el error y retorna el mensaje personalizado
            return DAO.bInsertar(nuevaRelacion, out smensajeError);
        }

       

        
    }



}
