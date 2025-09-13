/// Autor: Arón Ricardo Esquit Silva    0901-22-13036
// Fecha: 12/09/2025
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
    public static class Cls_UsuarioConectado
    {
        // ID del usuario logueado
        public static int iIdUsuario { get; set; }

        // Nombre del usuario logueado
        public static string sNombreUsuario { get; set; }

        // Estado de login: true = conectado, false = desconectado
        public static bool bLoginEstado { get; set; }

        // Método para establecer datos al iniciar sesión
        public static void IniciarSesion(int idUsuario, string nombreUsuario)
        {
            iIdUsuario = idUsuario;
            sNombreUsuario = nombreUsuario;
            bLoginEstado = true;
        }

        // Método para cerrar sesión
        public static void CerrarSesion()
        {
            bLoginEstado = false;
        }
    }
}
