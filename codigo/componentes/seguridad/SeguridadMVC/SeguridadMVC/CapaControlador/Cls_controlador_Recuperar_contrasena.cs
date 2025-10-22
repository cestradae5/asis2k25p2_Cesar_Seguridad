using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;
using Capa_Modelo_Seguridad;

// 0901-20-4620 Ruben Armando Lopez Luch
namespace Capa_Controlador_Seguridad
{
    public class ClsControladorRecuperarContrasena
    {
        private ClsModeloRecuperarContrasena modelo = new ClsModeloRecuperarContrasena();

        // 0901-20-4620 Ruben Armando Lopez Luch
        public int fun_obtener_IdUsuario(string sNombreUsuario)
        {
            return modelo.fun_obtener_IdUsuario(sNombreUsuario);
        }

        // 0901-20-4620 Ruben Armando Lopez Luch
        public string fun_generar_token(int iIdUsuario)
        {
            string sToken = Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper();
            modelo.fun_guardar_token(iIdUsuario, sToken, DateTime.Now.AddMinutes(5));
            return sToken;
        }

        // 0901-20-4620 Ruben Armando Lopez Luch
        public bool fun_validar_token(int iIdUsuario, string sToken, out int iIdToken)
        {
            var resultado = modelo.fun_validar_token(iIdUsuario, sToken);
            iIdToken = resultado.idToken;
            return resultado.valido;
        }

        // 0901-20-4620 Ruben Armando Lopez Luch
        public bool fun_cambiar_contrasena(int iIdUsuario, string sHashNueva, int iIdToken)
        {
            return modelo.fun_cambiar_contrasena(iIdUsuario, sHashNueva, iIdToken);
        }
    }
}