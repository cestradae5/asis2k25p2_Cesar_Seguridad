using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Capa_Modelo_Seguridad;

namespace Capa_Controlador_Seguridad
{
  
   public  class Cls_PermisosControlador
    {
        Cls_Asignacion_Permiso_PerfilesDAO DAO = new Cls_Asignacion_Permiso_PerfilesDAO();
        Cls_SentenciaAsignacionUsuarioAplicacion model = new Cls_SentenciaAsignacionUsuarioAplicacion();
        //Brandon Hernandez 0901-22-9663 15/10/2025
        public Cls_Permiso_Aplicacion_Usuario ObtenerPermisosAplicacionUsuarioConectado(int idAplicacion)
        {
            int idUsuario = Cls_Usuario_Conectado.iIdUsuario;


            DataTable dt = model.ObtenerPermisosUsuarioAplicacion(idUsuario, idAplicacion);

            if (dt.Rows.Count == 0)
                return null; // o retorna un objeto con todos los permisos en false

            DataRow row = dt.Rows[0];
            return new Cls_Permiso_Aplicacion_Usuario
            {
                Fk_Id_Usuario = idUsuario,
                FK_Id_Aplicacion = idAplicacion,
                Cmp_Ingresar_Permiso_Aplicacion_Usuario = Convert.ToBoolean(row["ingresar"]),
                Cmp_Consultar_Permiso_Aplicacion_Usuario = Convert.ToBoolean(row["consultar"]),
                Cmp_Modificar_Permiso_Aplicacion_Usuario = Convert.ToBoolean(row["modificar"]),
                Cmp_Eliminar_Permiso_Aplicacion_Usuario = Convert.ToBoolean(row["eliminar"]),
                Cmp_Imprimir_Permiso_Aplicacion_Usuario = Convert.ToBoolean(row["imprimir"])
            };
        }
        /*Carlo Sosa 0901-22-1106 15/10/2025
  */
        public class Cls_ControladorAsignacionPerfilAplicacion
        {
            Cls_Asignacion_Permiso_PerfilesDAO DAO = new Cls_Asignacion_Permiso_PerfilesDAO();

           
           public Cls_Asignacion_Perrmisos_Perfiles ObtenerPermisosAplicacionPerfil(int idAplicacion)
            {
                int idPerfil = Cls_Usuario_Conectado.iIdPerfil;
                DataTable dt = DAO.ObtenerPermisosPerfilAplicacion(idPerfil, idAplicacion);

                if (dt.Rows.Count == 0)
                    return null;

                DataRow row = dt.Rows[0];
                return new Cls_Asignacion_Perrmisos_Perfiles
                {
                    iFk_id_modulo = Convert.ToInt32(row["fk_id_modulo"]),
                    iFk_id_perfil = Convert.ToInt32(row["fk_id_perfil"]),
                    iFk_id_aplicacion = Convert.ToInt32(row["fk_id_aplicacion"]),
                    bIngresar_permiso_aplicacion_perfil = Convert.ToBoolean(row["ingresar"]),
                    bConsultar_permiso_aplicacion_perfil = Convert.ToBoolean(row["consultar"]),
                    bModificar_permiso_aplicacion_perfil = Convert.ToBoolean(row["modificar"]),
                    bEliminar_permiso_aplicacion_perfil = Convert.ToBoolean(row["eliminar"]),
                    bImprimir_permiso_aplicacion_perfil = Convert.ToBoolean(row["imprimir"])
                };
            }
        }
    }
}
