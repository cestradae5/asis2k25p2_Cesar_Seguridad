// Pablo Jose Quiroa Martínez - 0901-22-2929
using System;
using System.Data.Odbc;
using Capa_Modelo_Seguridad;

namespace Capa_Controlador_Seguridad
{
    public class Cls_ControladorLogin
    {
        private Cls_SentenciaLogin gClsSentenciaLogin = new Cls_SentenciaLogin();

        
        // MÉTODO: Autenticar Usuario
        
        public bool bAutenticarUsuario(
            string sUsuario,
            string sContrasena,
            out string sMensaje,
            out int iIdUsuario,
            out string sNombreUsuarioReal)
        {
            iIdUsuario = 0;
            sNombreUsuarioReal = "";
            sMensaje = "";

            OdbcDataReader oReader = gClsSentenciaLogin.fun_ValidarLogin(sUsuario);

            if (oReader != null && oReader.Read())
            {
                iIdUsuario = oReader.GetInt32(0);
                sNombreUsuarioReal = oReader.GetString(1);
                string sContrasenaBD = oReader.GetString(2);
                int iIntentosFallidos = oReader.GetInt32(3);
                string sEstado = oReader.GetString(4);

                // Validar si el usuario está bloqueado
                if (sEstado == "Bloqueado")
                {
                    sMensaje = "El usuario está bloqueado.";
                    return false;
                }

                // Hash de la contraseña ingresada
                string sHashIngresado = Cls_Seguridad_Hash_Controlador.HashearSHA256(sContrasena);

                if (sContrasenaBD == sHashIngresado)
                {
                    // Reiniciar intentos fallidos
                    gClsSentenciaLogin.fun_ActualizarIntentos(iIdUsuario, 0);
                    sMensaje = "Bienvenido " + sNombreUsuarioReal;
                    return true;
                }
                else
                {
                    // Aumentar intentos fallidos
                    iIntentosFallidos++;
                    gClsSentenciaLogin.fun_ActualizarIntentos(iIdUsuario, iIntentosFallidos);

                    if (iIntentosFallidos >= 3)
                    {
                        gClsSentenciaLogin.fun_BloquearUsuario(iIdUsuario, "Exceso de intentos incorrectos");
                        sMensaje = "Usuario bloqueado por múltiples intentos incorrectos.";
                    }
                    else
                    {
                        sMensaje = $"Contraseña incorrecta. Intentos: {iIntentosFallidos}";
                    }

                    return false;
                }
            }
            else
            {
                sMensaje = "No se encontró el usuario.";
                return false;
            }
        }
    }
}

// Pablo Jose Quiroa Martínez - 0901-22-2929 12/10/2025