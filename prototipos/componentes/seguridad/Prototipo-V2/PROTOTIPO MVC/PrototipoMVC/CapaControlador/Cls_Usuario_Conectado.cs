//Registrar en Bitácora - Brandon Alexander Hernandez Salguero - 6/10/2025
using System;

namespace Capa_Controlador_Seguridad
{
    public static class Cls_Usuario_Conectado
    {
        //ID del usuario logueado
        public static int iIdUsuario { get; set; }

        //Nombre del usuario logueado
        public static string sNombreUsuario { get; set; }

        //ID del perfil del usuario logueado
        public static int iIdPerfil { get; set; }

        //Estado de login true = conectado, false = desconectado
        public static bool bLoginEstado { get; set; }

        public static void IniciarSesion(int idUsuario, string nombreUsuario, int idPerfil)
        {
            iIdUsuario = idUsuario;
            sNombreUsuario = nombreUsuario;
            bLoginEstado = true;
            iIdPerfil = idPerfil;
        }

        public static void CerrarSesion()
        {
            bLoginEstado = false;
        }
    }
}