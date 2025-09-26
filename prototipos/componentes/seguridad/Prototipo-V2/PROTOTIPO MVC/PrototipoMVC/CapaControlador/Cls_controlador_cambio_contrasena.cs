using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Modelo_Seguridad;

// 0901-20-4620 Ruben Armando Lopez Luch
namespace Capa_Controlador_Seguridad
{
    public class Cls_controlador_cambio_contrasena
    {
        private Cls_usuario_cambio_contrasena modelo = new Cls_usuario_cambio_contrasena();

        // 0901-20-4620 Ruben Armando Lopez Luch
        public bool fun_validar_contrasena(int iIdUsuario, string sContrasenaActual)
        {

            string sHashActual = Cls_SeguridadHashControlador.HashearSHA256(sContrasenaActual);
            return modelo.fun_validar_contrasena_actual(iIdUsuario, sHashActual);
        }

        // 0901-20-4620 Ruben Armando Lopez Luch
        public bool fun_actualizar_Contrasena(int idUsuario, string nuevaContrasena)
        {
            
            string fHashNueva = Cls_SeguridadHashControlador.HashearSHA256(nuevaContrasena);
            return modelo.fun_cambiar_contrasena(idUsuario, fHashNueva);
        }
    }
}