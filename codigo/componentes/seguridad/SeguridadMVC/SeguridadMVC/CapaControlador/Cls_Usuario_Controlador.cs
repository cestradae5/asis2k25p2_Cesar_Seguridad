using System;
using System.Collections.Generic;
using System.Linq;
using Capa_Modelo_Seguridad;

namespace Capa_Controlador_Seguridad
{
    public class Cls_Usuario_Controlador
    {
        private Cls_UsuarioDAO gDaoUsuario = new Cls_UsuarioDAO();
        private Cls_BitacoraControlador gCtrlBitacora = new Cls_BitacoraControlador();

        public List<Cls_Usuario> ObtenerTodosLosUsuarios()
        {
            return gDaoUsuario.fun_ObtenerUsuarios();
        }

        public (bool bExito, string sMensaje) InsertarUsuario(
            int iFkIdEmpleado,
            string sNombreUsuario,
            string sContrasena,
            string sConfirmarContrasena)
        {
            var vValidar = ValidarCamposUsuario(0, iFkIdEmpleado, sNombreUsuario, sContrasena, sConfirmarContrasena);
            if (!vValidar.bExito) return vValidar;

            Cls_Usuario gNuevoUsuario = new Cls_Usuario
            {
                iFkIdEmpleado = iFkIdEmpleado,
                sNombreUsuario = sNombreUsuario,
                sContrasenaUsuario = Cls_Seguridad_Hash_Controlador.HashearSHA256(sContrasena),
                iContadorIntentosFallidos = 0,
                bEstadoUsuario = true,
                dFechaCreacion = DateTime.Now,
                dUltimoCambioContrasena = DateTime.Now,
                bPidioCambioContrasena = false
            };

            try
            {
                gDaoUsuario.InsertarUsuario(gNuevoUsuario);

                gCtrlBitacora.RegistrarAccion(
                    Cls_Usuario_Conectado.iIdUsuario,
                    1,
                    $"Insertó un nuevo usuario: {sNombreUsuario}",
                    true
                );

                return (true, "Usuario insertado correctamente.");
            }
            catch (Exception ex)
            {
                return (false, "Error al insertar usuario: " + ex.Message);
            }
        }

        public (bool bExito, string sMensaje) ActualizarUsuario(
            int iIdUsuario,
            int iFkIdEmpleado,
            string sNombreUsuario,
            string sContrasena,
            string sConfirmarContrasena)
        {
            var vValidar = ValidarCamposUsuario(iIdUsuario, iFkIdEmpleado, sNombreUsuario, sContrasena, sConfirmarContrasena);
            if (!vValidar.bExito) return vValidar;

            Cls_Usuario gUsuarioActualizado = new Cls_Usuario
            {
                iPkIdUsuario = iIdUsuario,
                iFkIdEmpleado = iFkIdEmpleado,
                sNombreUsuario = sNombreUsuario,
                sContrasenaUsuario = Cls_Seguridad_Hash_Controlador.HashearSHA256(sContrasena),
                iContadorIntentosFallidos = 0,
                bEstadoUsuario = true,
                dFechaCreacion = DateTime.Now,
                dUltimoCambioContrasena = DateTime.Now,
                bPidioCambioContrasena = false
            };

            try
            {
                gDaoUsuario.ActualizarUsuario(gUsuarioActualizado);

                gCtrlBitacora.RegistrarAccion(
                    Cls_Usuario_Conectado.iIdUsuario,
                    2,
                    $"Actualizó usuario: {sNombreUsuario}",
                    true
                );

                return (true, "Usuario actualizado correctamente.");
            }
            catch (Exception ex)
            {
                return (false, "Error al actualizar usuario: " + ex.Message);
            }
        }

        public bool BorrarUsuario(int iIdUsuario)
        {
            if (iIdUsuario <= 0) return false;
            try
            {
                bool bExito = gDaoUsuario.BorrarUsuario(iIdUsuario) > 0;

                if (bExito)
                {
                    gCtrlBitacora.RegistrarAccion(
                        Cls_Usuario_Conectado.iIdUsuario,
                        3,
                        $"Eliminó usuario con ID: {iIdUsuario}",
                        true
                    );
                }

                return bExito;
            }
            catch
            {
                return false;
            }
        }

        public Cls_Usuario BuscarUsuarioPorId(int iIdUsuario)
        {
            if (iIdUsuario <= 0) return null;
            return gDaoUsuario.Query(iIdUsuario);
        }

        private (bool bExito, string sMensaje) ValidarCamposUsuario(
            int iIdUsuario,
            int iFkIdEmpleado,
            string sNombreUsuario,
            string sContrasena,
            string sConfirmarContrasena)
        {
            if (iFkIdEmpleado <= 0)
                return (false, "Debe seleccionar un empleado válido.");

            if (string.IsNullOrWhiteSpace(sNombreUsuario))
                return (false, "El nombre de usuario no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(sContrasena) || string.IsNullOrWhiteSpace(sConfirmarContrasena))
                return (false, "La contraseña y su confirmación no pueden estar vacías.");

            if (sContrasena != sConfirmarContrasena)
                return (false, "Las contraseñas no coinciden.");

            bool bExisteNombre = gDaoUsuario.fun_ObtenerUsuarios()
                .Any(u => u.sNombreUsuario.Equals(sNombreUsuario, StringComparison.OrdinalIgnoreCase) &&
                          (iIdUsuario == 0 || u.iPkIdUsuario != iIdUsuario));

            if (bExisteNombre)
                return (false, "Ya existe un usuario con ese nombre.");

            return (true, string.Empty);
        }

        public int ObtenerIdPerfilDeUsuario(int iIdUsuario)
        {
            return gDaoUsuario.ObtenerIdPerfilDeUsuario(iIdUsuario);
        }

        // NUEVO MÉTODO PARA VALIDACIÓN DESDE LA VISTA
        public bool PuedeGuardarUsuario(int iFkIdEmpleado, string sNombreUsuario, string sContrasena, string sConfirmarContrasena)
        {
            var resultado = ValidarCamposUsuario(0, iFkIdEmpleado, sNombreUsuario, sContrasena, sConfirmarContrasena);
            return resultado.bExito;
        }
    }
}