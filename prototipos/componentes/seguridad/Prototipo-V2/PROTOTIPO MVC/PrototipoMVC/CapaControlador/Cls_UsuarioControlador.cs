// Pablo Quiroa 0901-22-2929
using System;
using System.Collections.Generic;
using System.Linq;
using Capa_Modelo_Seguridad;

namespace Capa_Controlador_Seguridad
{
    public class Cls_UsuarioControlador
    {
        
        // VARIABLES GLOBALES
       
        private Cls_UsuarioDAO gDaoUsuario = new Cls_UsuarioDAO();
        private Cls_BitacoraControlador gCtrlBitacora = new Cls_BitacoraControlador();

      
        // OBTENER TODOS LOS USUARIOS
        
        public List<Cls_Usuario> ObtenerTodosLosUsuarios()
        {
            return gDaoUsuario.ObtenerUsuarios();
        }

        
        // INSERTAR NUEVO USUARIO
       
        public (bool bExito, string sMensaje) InsertarUsuario(
            int iFkIdEmpleado,
            string sNombreUsuario,
            string sContrasena,
            string sConfirmarContrasena)
        {
            // Validaciones básicas
            var vValidar = ValidarCamposUsuario(0, iFkIdEmpleado, sNombreUsuario, sContrasena, sConfirmarContrasena);
            if (!vValidar.bExito) return vValidar;

            // Crear objeto usuario
            Cls_Usuario gNuevoUsuario = new Cls_Usuario
            {
                iFkIdEmpleado = iFkIdEmpleado,
                sNombreUsuario = sNombreUsuario,
                sContrasenaUsuario = Cls_SeguridadHashControlador.HashearSHA256(sContrasena),
                iContadorIntentosFallidos = 0,
                bEstadoUsuario = true,
                dFechaCreacion = DateTime.Now,
                dUltimoCambioContrasena = DateTime.Now,
                bPidioCambioContrasena = false
            };

            try
            {
                gDaoUsuario.InsertarUsuario(gNuevoUsuario);

                // Registro en bitácora
                gCtrlBitacora.RegistrarAccion(
                    Cls_UsuarioConectado.iIdUsuario,  // Usuario logueado
                    1,                                // Código de acción: insertar
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

        
        // ACTUALIZAR USUARIO EXISTENTE
        
        public (bool bExito, string sMensaje) ActualizarUsuario(
            int iIdUsuario,
            int iFkIdEmpleado,
            string sNombreUsuario,
            string sContrasena,
            string sConfirmarContrasena)
        {
            // Validaciones
            var vValidar = ValidarCamposUsuario(iIdUsuario, iFkIdEmpleado, sNombreUsuario, sContrasena, sConfirmarContrasena);
            if (!vValidar.bExito) return vValidar;

            Cls_Usuario gUsuarioActualizado = new Cls_Usuario
            {
                iPkIdUsuario = iIdUsuario,
                iFkIdEmpleado = iFkIdEmpleado,
                sNombreUsuario = sNombreUsuario,
                sContrasenaUsuario = Cls_SeguridadHashControlador.HashearSHA256(sContrasena),
                iContadorIntentosFallidos = 0,
                bEstadoUsuario = true,
                dFechaCreacion = DateTime.Now,
                dUltimoCambioContrasena = DateTime.Now,
                bPidioCambioContrasena = false
            };

            try
            {
                gDaoUsuario.ActualizarUsuario(gUsuarioActualizado);

                // Registro en bitácora
                gCtrlBitacora.RegistrarAccion(
                    Cls_UsuarioConectado.iIdUsuario,
                    2, // Código de acción: actualizar
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

     
        // BORRAR USUARIO
        
        public bool BorrarUsuario(int iIdUsuario)
        {
            if (iIdUsuario <= 0) return false;
            try
            {
                bool bExito = gDaoUsuario.BorrarUsuario(iIdUsuario) > 0;

                if (bExito)
                {
                    // Registro en bitácora
                    gCtrlBitacora.RegistrarAccion(
                        Cls_UsuarioConectado.iIdUsuario,
                        3, // Código de acción: eliminar
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

        
        // BUSCAR USUARIO POR ID
        
        public Cls_Usuario BuscarUsuarioPorId(int iIdUsuario)
        {
            if (iIdUsuario <= 0) return null;
            return gDaoUsuario.Query(iIdUsuario);
        }

       
        // VALIDACIONES
        
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

            bool bExisteNombre = gDaoUsuario.ObtenerUsuarios()
                .Any(u => u.sNombreUsuario.Equals(sNombreUsuario, StringComparison.OrdinalIgnoreCase) &&
                          (iIdUsuario == 0 || u.iPkIdUsuario != iIdUsuario));

            if (bExisteNombre)
                return (false, "Ya existe un usuario con ese nombre.");

            return (true, string.Empty);
        }

      
        // OBTENER ID PERFIL DE USUARIO
    
        public int ObtenerIdPerfilDeUsuario(int iIdUsuario)
        {
            return gDaoUsuario.ObtenerIdPerfilDeUsuario(iIdUsuario);
        }
    }
}

// Pablo Quiroa 0901-22-2929 12/10/2025