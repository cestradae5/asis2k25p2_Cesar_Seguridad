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
            return model.ObtenerUsuarios();
        }

        // Obtener todos los módulos
        public DataTable ObtenerModulos()
        {
            return model.ObtenerModulos();
        }

        // Obtener aplicaciones por módulo
        public DataTable ObtenerAplicacionesPorModulo(int idModulo)
        {
            return model.ObtenerAplicacionesPorModulo(idModulo);
        }


        public DataTable ObtenerPermisosPorUsuario(int idUsuario)
        {
            return model.ObtenerPermisosPorUsuario(idUsuario);
        }

        // Insertar permisos de usuario por aplicación
        public bool InsertarPermisoUsuarioAplicacion(int idUsuario, int idModulo, int idAplicacion,
                                                     bool ingresar, bool consultar, bool modificar,
                                                     bool eliminar, bool imprimir)
        {
            int filas = model.InsertarPermisoUsuarioAplicacion(idUsuario, idModulo, idAplicacion,
                                                               ingresar, consultar, modificar,
                                                               eliminar, imprimir);
            return filas > 0;
        }


        //Ruben Armando Lopez lUch
        //0901-20-4620
        public DataTable fun_obtener_permisos_por_usuario_modulo(int iIdUsuario, int iModulo)
        {
            return model.fun_bbtener_permisos_por_usuario_modulo(iIdUsuario, iModulo);
        }

        // fin -> Ruben Armando Lopez lUch

        // Método para obtener los permisos del usuario y aplicación actualmente conectados -> Brandon Hernandez  0901-22-9663

        public Cls_Permiso_Aplicacion_Usuario ObtenerPermisosAplicacionUsuarioConectado(int idAplicacion)
        {
            int idUsuario = Cls_UsuarioConectado.iIdUsuario;
            

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
    }
}

