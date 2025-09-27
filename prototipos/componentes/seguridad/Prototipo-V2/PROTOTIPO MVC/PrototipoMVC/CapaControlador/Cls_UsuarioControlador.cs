// Pablo Quiroa 0901-22-2929
using System;
using System.Collections.Generic;
using System.Linq;
using Capa_Modelo_Seguridad;

namespace Capa_Controlador_Seguridad
{
    public class Cls_UsuarioControlador
    {
        // Variables globales
        private Cls_UsuarioDAO gDaoUsuario = new Cls_UsuarioDAO();

        // Obtener todos los usuarios
        public List<Cls_Usuario> ObtenerTodosLosUsuarios()
        {
            return gDaoUsuario.ObtenerUsuarios();
        }

        // Insertar nuevo usuario
        public (bool bExito, string sMensaje) InsertarUsuario(int pFkIdEmpleado, string pNombreUsuario, string pContrasena, string pConfirmarContrasena)
        {
            // Validaciones
            if (pFkIdEmpleado <= 0)
                return (false, "Debe seleccionar un empleado válido.");

            if (string.IsNullOrWhiteSpace(pNombreUsuario))
                return (false, "El nombre de usuario no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(pContrasena) || string.IsNullOrWhiteSpace(pConfirmarContrasena))
                return (false, "La contraseña y su confirmación no pueden estar vacías.");

            if (pContrasena != pConfirmarContrasena)
                return (false, "Las contraseñas no coinciden.");

            if (gDaoUsuario.ObtenerUsuarios().Any(u => u.sNombreUsuario.Equals(pNombreUsuario, StringComparison.OrdinalIgnoreCase)))
                return (false, "Ya existe un usuario con ese nombre.");

            // Crear usuario
            Cls_Usuario gNuevoUsuario = new Cls_Usuario
            {
                iFkIdEmpleado = pFkIdEmpleado,
                sNombreUsuario = pNombreUsuario,
                sContrasenaUsuario = Cls_SeguridadHashControlador.HashearSHA256(pContrasena),
                iContadorIntentosFallidos = 0,
                bEstadoUsuario = true,
                dFechaCreacion = DateTime.Now,
                dUltimoCambioContrasena = DateTime.Now,
                bPidioCambioContrasena = false
            };

            try
            {
                gDaoUsuario.InsertarUsuario(gNuevoUsuario);
                return (true, "Usuario insertado correctamente.");
            }
            catch (Exception ex)
            {
                return (false, "Error al insertar usuario: " + ex.Message);
            }
        }

        // Actualizar usuario existente
        public (bool bExito, string sMensaje) ActualizarUsuario(int pIdUsuario, int pFkIdEmpleado, string pNombreUsuario, string pContrasena, string pConfirmarContrasena)
        {
            // Validaciones
            if (pIdUsuario <= 0)
                return (false, "Seleccione un usuario válido.");

            if (pFkIdEmpleado <= 0)
                return (false, "Debe seleccionar un empleado válido.");

            if (string.IsNullOrWhiteSpace(pNombreUsuario))
                return (false, "El nombre de usuario no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(pContrasena) || string.IsNullOrWhiteSpace(pConfirmarContrasena))
                return (false, "La contraseña y su confirmación no pueden estar vacías.");

            if (pContrasena != pConfirmarContrasena)
                return (false, "Las contraseñas no coinciden.");

            if (gDaoUsuario.ObtenerUsuarios().Any(u => u.sNombreUsuario.Equals(pNombreUsuario, StringComparison.OrdinalIgnoreCase) && u.iPkIdUsuario != pIdUsuario))
                return (false, "Ya existe otro usuario con ese nombre.");

            // Actualizar usuario
            Cls_Usuario gUsuarioActualizado = new Cls_Usuario
            {
                iPkIdUsuario = pIdUsuario,
                iFkIdEmpleado = pFkIdEmpleado,
                sNombreUsuario = pNombreUsuario,
                sContrasenaUsuario = Cls_SeguridadHashControlador.HashearSHA256(pContrasena),
                iContadorIntentosFallidos = 0,
                bEstadoUsuario = true,
                dFechaCreacion = DateTime.Now,
                dUltimoCambioContrasena = DateTime.Now,
                bPidioCambioContrasena = false
            };

            try
            {
                gDaoUsuario.ActualizarUsuario(gUsuarioActualizado);
                return (true, "Usuario actualizado correctamente.");
            }
            catch (Exception ex)
            {
                return (false, "Error al actualizar usuario: " + ex.Message);
            }
        }

        // Borrar usuario
        public bool BorrarUsuario(int pIdUsuario)
        {
            if (pIdUsuario <= 0) return false;

            try
            {
                return gDaoUsuario.BorrarUsuario(pIdUsuario) > 0;
            }
            catch
            {
                return false;
            }
        }


        public Cls_Usuario BuscarUsuarioPorId(int pIdUsuario)
        {
            if (pIdUsuario <= 0) return null;
            return gDaoUsuario.Query(pIdUsuario);
        }
    }
}
