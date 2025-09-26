// Pablo Quiroa 0901-22-2929
using System;

namespace Capa_Modelo_Seguridad
{
    public class Cls_Usuario
    {
        public int PkIdUsuario { get; set; }
        public int FkIdEmpleado { get; set; }
        public string NombreUsuario { get; set; }
        public string ContrasenaUsuario { get; set; }
        public int ContadorIntentosFallidos { get; set; }
        public bool EstadoUsuario { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime UltimoCambioContrasena { get; set; }
        public bool PidioCambioContrasena { get; set; }

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
            PkIdUsuario = pkIdUsuario;
            FkIdEmpleado = fkIdEmpleado;
            NombreUsuario = nombreUsuario;
            ContrasenaUsuario = contrasenaUsuario;
            ContadorIntentosFallidos = contadorIntentosFallidos;
            EstadoUsuario = estadoUsuario;
            FechaCreacion = fechaCreacion;
            UltimoCambioContrasena = ultimoCambioContrasena;
            PidioCambioContrasena = pidioCambioContrasena;
        }
    }
}

