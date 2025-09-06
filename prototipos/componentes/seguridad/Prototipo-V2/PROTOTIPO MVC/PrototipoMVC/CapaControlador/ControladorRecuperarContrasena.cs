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
    public class ControladorRecuperarContrasena
    {
        SentenciaRecuperarContrasena snrc = new SentenciaRecuperarContrasena();


        // 0901-20-4620 Ruben Armando Lopez Luch
        // Validar token
        public bool ValidarToken(int idUsuario, string token, out int idToken)
        {
            idToken = 0;
            var reader = snrc.validarToken(idUsuario, token);
            if (reader.Read())
            {
                idToken = Convert.ToInt32(reader["pk_id_token_restaurar_contrasena"]);
                reader.Close();
                return true;
            }
            reader.Close();
            return false;
        }


        // 0901-20-4620 Ruben Armando Lopez Luch
        // Cambiar contraseña
        public bool CambiarContrasena(int idUsuario, string nuevaContrasena, int idToken)
        {
            int filasActualizadas = snrc.ActualizarContrasena(idUsuario, nuevaContrasena);
            if (filasActualizadas > 0)
            {
                snrc.MarcarTokenUsado(idToken);
                return true;
            }
            return false;
        }
    }

}
