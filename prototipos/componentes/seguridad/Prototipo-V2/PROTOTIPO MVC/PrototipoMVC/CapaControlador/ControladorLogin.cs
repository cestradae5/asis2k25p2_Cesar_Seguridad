using System; //0901-22-2929 Pablo Jose Quiroa Martinez
using System.Data.Odbc;
using CapaModelo;

namespace CapaControlador
{
    public class ControladorLogin
    {
        SentenciaLogin sl = new SentenciaLogin();

        public bool autenticarUsuario(string usuario, string contrasena, out string mensaje)
        {
            mensaje = "";
            OdbcDataReader reader = sl.validarLogin(usuario);

            if (reader != null && reader.Read())
            {
                int idUsuario = reader.GetInt32(0);
                string nombreUsuario = reader.GetString(1);
                string contrasenaBD = reader.GetString(2);
                int intentosFallidos = reader.GetInt32(3);
                string estado = reader.GetString(4);

                if (estado == "Bloqueado")
                {
                    mensaje = "El usuario está bloqueado.";
                    return false;
                }

                if (contrasenaBD == contrasena) 
                {
                    sl.actualizarIntentos(idUsuario, 0); 
                    mensaje = "Bienvenido " + nombreUsuario;
                    return true;
                }
                else
                {
                    intentosFallidos++;
                    sl.actualizarIntentos(idUsuario, intentosFallidos);

                    if (intentosFallidos >= 3) 
                    {
                        sl.bloquearUsuario(idUsuario, "Exceso de intentos erroneos");
                        mensaje = "Usuario bloqueado por muchos intentos erroneos.";
                    }
                    else
                    {
                        mensaje = "Contraseña incorrecta. Intentos: " + intentosFallidos;
                    }
                    return false;
                }
            }
            else
            {
                mensaje = "No se encontró el usuario.";
                return false;
            }
        }
    }
}
