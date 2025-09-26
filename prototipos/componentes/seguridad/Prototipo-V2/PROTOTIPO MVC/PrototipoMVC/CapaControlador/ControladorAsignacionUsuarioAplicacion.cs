using System.Data;
using Capa_Modelo_Seguridad;

namespace Capa_Controlador_Seguridad
{
    /* Brandon Alexander Hernandez Salguero 0901-22-9663 */
    public class ControladorAsignacionUsuarioAplicacion
    {
        SentenciaAsignacionUsuarioAplicacion model = new SentenciaAsignacionUsuarioAplicacion();

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
    }
}

