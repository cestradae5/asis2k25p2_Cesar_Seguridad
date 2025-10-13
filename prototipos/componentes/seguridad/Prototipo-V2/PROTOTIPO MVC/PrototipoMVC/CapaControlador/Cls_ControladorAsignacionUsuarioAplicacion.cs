using System.Data;
using Capa_Modelo_Seguridad;
using System;

namespace Capa_Controlador_Seguridad
{
    /* Brandon Alexander Hernandez Salguero 0901-22-9663 */
    public class Cls_ControladorAsignacionUsuarioAplicacion
    {
        Cls_SentenciaAsignacionUsuarioAplicacion model = new Cls_SentenciaAsignacionUsuarioAplicacion();

        // Obtener todos los usuarios
        public DataTable ObtenerUsuarios()
        {
            return model.fun_ObtenerUsuarios();
        }

        // Obtener todos los módulos
        public DataTable ObtenerModulos()
        {
            return model.fun_ObtenerModulos();
        }

        // Obtener aplicaciones por módulo
        public DataTable ObtenerAplicacionesPorModulo(int idModulo)
        {
            return model.fun_ObtenerAplicacionesPorModulo(idModulo);
        }


        public DataTable ObtenerPermisosPorUsuario(int idUsuario)
        {
            return model.fun_ObtenerPermisosPorUsuario(idUsuario);
        }

        public DataTable ObtenerPermisosPorUsuarioYModulo(int idUsuario, int idModulo)
        {
            return model.fun_bbtener_permisos_por_usuario_modulo(idUsuario, idModulo);
        }


        // Insertar permisos de usuario por aplicación
        public bool InsertarPermisoUsuarioAplicacion(int iIdUsuario, int iIdModulo, int iIdAplicacion,
                                                     bool bIngresar, bool bConsultar, bool bModificar,
                                                     bool bEliminar, bool bImprimir)
        {
            int filas = model.InsertarPermisoUsuarioAplicacion(iIdUsuario, iIdModulo, iIdAplicacion,
                                                               bIngresar, bConsultar, bModificar,
                                                               bEliminar, bImprimir);
            return filas > 0;
        }


        //Ruben Armando Lopez lUch
        //0901-20-4620
        //public DataTable fun_obtener_permisos_por_usuario_modulo(int iIdUsuario, int iModulo)
        //{
        //    return model.fun_bbtener_permisos_por_usuario_modulo(iIdUsuario, iModulo);
        //}

        // fin -> Ruben Armando Lopez lUch

        // Método para obtener los permisos del usuario y aplicación actualmente conectados -> Brandon Hernandez  0901-22-9663

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
    }
}

