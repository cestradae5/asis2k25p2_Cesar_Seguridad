using System.Data;

using System.Linq;
using System.Collections.Generic;

using Capa_Modelo_Seguridad;
/* Brandon Alexander Hernandez Salguero
 * 0901-22-9663
 */

namespace Capa_Controlador_Seguridad
{

    public class AsignacionPerfilUsuarioDTO
    {
        public int UsuarioId { get; set; }
        public int PerfilId { get; set; }
    }

    public class Cls_asignacion_perfil_usuarioControlador
    {
        private Cls_asignacion_perfil_usuarioDAO DAO = new Cls_asignacion_perfil_usuarioDAO();
        private Cls_Usuario_Controlador controladorUsuario = new Cls_Usuario_Controlador();

        // Devuelve todos los usuarios (para combos en la vista)
        public DataTable datObtenerUsuarios()
        {
            return DAO.datObtenerUsuarios();
        }

        // Devuelve todos los perfiles (para combos en la vista)
        public DataTable datObtenerPerfiles()
        {
            return DAO.datObtenerPerfiles();
        }

        // Devuelve los perfiles asignados a un usuario (para consultas)
        public DataTable datObtenerPerfilesPorUsuario(int iIdUsuario)
        {
            return DAO.datObtenerPerfilesPorUsuario(iIdUsuario);
        }

        /// NUEVAS VALIDACIONES

        // Valida si el usuario ya tiene el perfil en la base de datos
        public bool ExisteAsignacionEnBaseDeDatos(int usuarioId, int perfilId)
        {
            // Debes implementar este método en tu DAO (retorna true si existe en BD)
            return DAO.ExisteAsignacionEnBD(usuarioId, perfilId);
        }

        // Valida si el usuario ya tiene asignado algún permiso
        public bool UsuarioTienePermiso(int usuarioId)
        {
            // Debes implementar este método en tu DAO o controlador de permisos
            // Retorna true si el usuario ya tiene permiso asignado
            return DAO.UsuarioTienePermiso(usuarioId);
        }

        // Valida si puede agregarse una asignación a la lista temporal de la vista
        public bool ValidarAsignacion(int usuarioId, int perfilId, List<AsignacionPerfilUsuarioDTO> asignacionesPendientes, out string mensaje)
        {
            mensaje = "";
            if (usuarioId <= 0 || perfilId <= 0)
            {
                mensaje = "Seleccione un usuario y un perfil.";
                return false;
            }

            int perfilAsignado = controladorUsuario.ObtenerIdPerfilDeUsuario(usuarioId);
            if (perfilAsignado != 0)
            {
                mensaje = $"Este usuario ya está asignado a un perfil {perfilAsignado}.";
                return false;
            }

            // Validar si el usuario ya tiene asignado este perfil en la base de datos (evita duplicados)
            if (ExisteAsignacionEnBaseDeDatos(usuarioId, perfilId))
            {
                mensaje = "El usuario ya tiene asignado este perfil en la base de datos.";
                return false;
            }

            // Validar si el usuario ya tiene asignado un permiso
            if (UsuarioTienePermiso(usuarioId))
            {
                mensaje = "El usuario ya tiene asignado un permiso y no puede tener otro.";
                return false;
            }

            if (asignacionesPendientes.Any(x => x.UsuarioId == usuarioId && x.PerfilId == perfilId))
            {
                mensaje = "Esta asignación ya está en la lista.";
                return false;
            }

            return true;
        }

        // Agrega a la lista temporal (usada en la vista) con validación
        public bool AgregarAsignacionPendiente(int usuarioId, int perfilId, List<AsignacionPerfilUsuarioDTO> asignacionesPendientes, out string mensaje)
        {
            if (!ValidarAsignacion(usuarioId, perfilId, asignacionesPendientes, out mensaje))
                return false;

            asignacionesPendientes.Add(new AsignacionPerfilUsuarioDTO
            {
                UsuarioId = usuarioId,
                PerfilId = perfilId
            });
            return true;
        }

        // Verifica si existe una asignación en la lista temporal
        public bool ExisteAsignacionPendiente(int usuarioId, int perfilId, List<AsignacionPerfilUsuarioDTO> asignacionesPendientes)
        {
            return asignacionesPendientes.Any(x => x.UsuarioId == usuarioId && x.PerfilId == perfilId);
        }

        // Inserta la relación usuario-perfil en la base de datos (cuando se finalizan las asignaciones)
        public bool GuardarAsignacion(int usuarioId, int perfilId, out string mensajeError)
        {
            // Aquí podrías validar si la relación ya existe en BD, etc.
            // Si quieres, puedes expandir la lógica.
            Cls_asignacion_perfil_usuario nuevaRelacion = new Cls_asignacion_perfil_usuario
            {
                Fk_Id_Usuario = usuarioId,
                Fk_Id_Perfil = perfilId,
            };

            return DAO.bInsertar(nuevaRelacion, out mensajeError);
        }
    }
}