using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Modelo_Seguridad;
using System.Data;



namespace Capa_Controlador_Seguridad
{
    public class Cls_Optencion_Permisos_Controlador
    {
        Cls_asignacion_perfil_usuarioDAO DAO = new Cls_asignacion_perfil_usuarioDAO();
        Cls_SentenciaAsignacionUsuarioAplicacion model = new Cls_SentenciaAsignacionUsuarioAplicacion();

    }

    public Cls_Permiso_Aplicacion_Usuario ObtenerPermisosAplicacionUsuarioConectado(int iIdAplicacion)
    {
        int iIdUsuario = Cls_Usuario_Conectado.iIdUsuario;


        DataTable dt = model.ObtenerPermisosUsuarioAplicacion(iIdUsuario, iIdAplicacion);

        if (dt.Rows.Count == 0)
            return null; // o retorna un objeto con todos los permisos en false

        DataRow row = dt.Rows[0];
        return new Cls_Permiso_Aplicacion_Usuario
        {
            Fk_Id_Usuario = iIdUsuario,
            FK_Id_Aplicacion = iIdAplicacion,
            Cmp_Ingresar_Permiso_Aplicacion_Usuario = Convert.ToBoolean(row["bIngresar"]),
            Cmp_Consultar_Permiso_Aplicacion_Usuario = Convert.ToBoolean(row["bConsultar"]),
            Cmp_Modificar_Permiso_Aplicacion_Usuario = Convert.ToBoolean(row["bModificar"]),
            Cmp_Eliminar_Permiso_Aplicacion_Usuario = Convert.ToBoolean(row["bEliminar"]),
            Cmp_Imprimir_Permiso_Aplicacion_Usuario = Convert.ToBoolean(row["bImprimir"])
        };
    }

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



}
