using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Odbc;
using CapaModelo;


// 0901-20-4620 Ruben Armando Lopez Luch
namespace CapaControlador
{
    public class Cls_controladorRecuperarContrasena
    {
        Cls_sentenciaRecuperarContrasena clsRecuperar = new Cls_sentenciaRecuperarContrasena();


        // 0901-20-4620 Ruben Armando Lopez Luch
        // Validar token
        public bool funValidarToken(int iIdUsuario, string sToken, out int iIdToken)
        {
            iIdToken = 0;
            var reader = clsRecuperar.funValidarToken(iIdUsuario, sToken);
            if (reader.Read())
            {
                iIdToken = Convert.ToInt32(reader["pk_id_token_restaurar_contrasena"]);
                reader.Close();
                return true;
            }
            reader.Close();
            return false;
        }


        // 0901-20-4620 Ruben Armando Lopez Luch
        // Cambiar contraseña
        public bool funCambiarContrasena(int iIdUsuario, string sNuevaContrasena, int iIdToken)
        {
            int iFilasActualizadas = clsRecuperar.funActualizarContrasena(iIdUsuario, sNuevaContrasena);
            if (iFilasActualizadas > 0)
            {
                clsRecuperar.funMarcarTokenUsado(iIdToken);
                return true;
            }
            return false;
        }
    }

}
