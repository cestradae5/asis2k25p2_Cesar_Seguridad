///Pablo Quiroa 0901-22-2929 
using System;
using System.Data.Odbc;
using CapaModelo;

namespace CapaControlador
{
    public class ControladorLogin
    {
        private SentenciaLogin sl = new SentenciaLogin();

       
     
      
        public bool autenticarUsuario(string usuario, string contrasena, out string mensaje, out int idUsuario)
        {
            idUsuario = 0;
            mensaje = "";
            OdbcDataReader reader = sl.validarLogin(usuario);

            if (reader != null && reader.Read())
            {
                idUsuario = reader.GetInt32(0);
                string nombreUsuario = reader.GetString(1);
                string contrasenaBD = reader.GetString(2);
                int intentosFallidos = reader.GetInt32(3);
                string estado = reader.GetString(4);

               
                if (estado == "Bloqueado")
                {
                    mensaje = "El usuario está bloqueado.";
                    return false;
                }

             
                string hashIngresado = SeguridadHash.HashearSHA256(contrasena);

                if (contrasenaBD == hashIngresado)
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
                        sl.bloquearUsuario(idUsuario, "Exceso de intentos incorrectos");
                        mensaje = "Usuario bloqueado por muchos intentos incorrectos.";
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


