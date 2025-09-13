//Pablo Quiroa 0901-22-2929
using System;
using System.Collections.Generic;
using CapaModelo;

namespace CapaControlador
{
    public class Cls_UsuarioControlador
    {
        private Cls_UsuarioDAO daoUsuario = new Cls_UsuarioDAO();

       
        public List<Cls_Usuario> ObtenerTodosLosUsuarios()
        {
            return daoUsuario.ObtenerUsuarios();
        }

        
        public void InsertarUsuario(int fkIdEmpleado, string nombreUsuario, string contrasena,
                                    int intentosFallidos, bool estado, DateTime fechaCreacion,
                                    DateTime ultimoCambio, bool pidioCambio)
        {
            Cls_Usuario nuevoUsuario = new Cls_Usuario
            {
                FkIdEmpleado = fkIdEmpleado,
                NombreUsuario = nombreUsuario,
                ContrasenaUsuario = contrasena,
                ContadorIntentosFallidos = intentosFallidos,
                EstadoUsuario = estado,
                FechaCreacion = fechaCreacion,
                UltimoCambioContrasena = ultimoCambio,
                PidioCambioContrasena = pidioCambio
            };

            daoUsuario.InsertarUsuario(nuevoUsuario);
        }

        
        public bool ActualizarUsuario(int idUsuario, int fkIdEmpleado, string nombreUsuario, string contrasena,
                                      int intentosFallidos, bool estado, DateTime fechaCreacion,
                                      DateTime ultimoCambio, bool pidioCambio)
        {
            Cls_Usuario usuarioActualizado = new Cls_Usuario
            {
                PkIdUsuario = idUsuario,
                FkIdEmpleado = fkIdEmpleado,
                NombreUsuario = nombreUsuario,
                ContrasenaUsuario = contrasena,
                ContadorIntentosFallidos = intentosFallidos,
                EstadoUsuario = estado,
                FechaCreacion = fechaCreacion,
                UltimoCambioContrasena = ultimoCambio,
                PidioCambioContrasena = pidioCambio
            };

            daoUsuario.ActualizarUsuario(usuarioActualizado);
            return true;
        }

        
        public bool BorrarUsuario(int idUsuario)
        {
            return daoUsuario.BorrarUsuario(idUsuario) > 0;
        }

        
        public Cls_Usuario BuscarUsuarioPorId(int idUsuario)
        {
            return daoUsuario.Query(idUsuario);
        }
    }
}

