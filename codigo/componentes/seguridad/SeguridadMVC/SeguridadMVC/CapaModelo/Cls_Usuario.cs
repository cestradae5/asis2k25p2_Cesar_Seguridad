// Pablo Quiroa 0901-22-2929
using System;

namespace Capa_Modelo_Seguridad
{
    public class Cls_Usuario
    {
        public int iPkIdUsuario { get; set; }
        public int iFkIdEmpleado { get; set; }
        public string sNombreUsuario { get; set; }
        public string sContrasenaUsuario { get; set; }
        public int iContadorIntentosFallidos { get; set; }
        public bool bEstadoUsuario { get; set; }
        public DateTime dFechaCreacion { get; set; }
        public DateTime dUltimoCambioContrasena { get; set; }
        public bool bPidioCambioContrasena { get; set; }

        public Cls_Usuario() { }

        public Cls_Usuario(
            int pkIdUsuario,
            int fkIdEmpleado,
            string nombreUsuario,
            string contrasenaUsuario,
            int contadorIntentosFallidos,
            bool estadoUsuario,
            DateTime fechaCreacion,
            DateTime ultimoCambioContrasena,
            bool pidioCambioContrasena
        )
        {
            iPkIdUsuario = pkIdUsuario;
            iFkIdEmpleado = fkIdEmpleado;
            sNombreUsuario = nombreUsuario;
            sContrasenaUsuario = contrasenaUsuario;
            iContadorIntentosFallidos = contadorIntentosFallidos;
            bEstadoUsuario = estadoUsuario;
            dFechaCreacion = fechaCreacion;
            dUltimoCambioContrasena = ultimoCambioContrasena;
            bPidioCambioContrasena = pidioCambioContrasena;
        }
    }
}

// Pablo Quiroa 0901-22-2929 12/10/2025