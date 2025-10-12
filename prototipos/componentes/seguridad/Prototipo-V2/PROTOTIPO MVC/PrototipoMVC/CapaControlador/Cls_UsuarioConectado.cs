//Registrar en Bitácora - Arón Ricardo Esquit Silva - 0901-22-13036 - 6/10/2025
using System;

namespace Capa_Controlador_Seguridad
{
    public static class Cls_UsuarioConectado
    {
        //ID del usuario logueado
        public static int iIdUsuario { get; set; }

        //Nombre del usuario logueado
        public static string sNombreUsuario { get; set; }

        //ID del perfil del usuario logueado
        public static int iIdPerfil { get; set; } // <-- AGREGA ESTA LINEA

        //Estado de login: true = conectado, false = desconectado
        public static bool bLoginEstado { get; set; }

        public static void IniciarSesion(int idUsuario, string nombreUsuario, int idPerfil)
        {
            iIdUsuario = idUsuario;
            sNombreUsuario = nombreUsuario;
            bLoginEstado = true;
            iIdPerfil = idPerfil; // <-- AHORA ESTA ASIGNACION FUNCIONA
        }

        public static void CerrarSesion()
        {
            bLoginEstado = false;
        }
    }
}