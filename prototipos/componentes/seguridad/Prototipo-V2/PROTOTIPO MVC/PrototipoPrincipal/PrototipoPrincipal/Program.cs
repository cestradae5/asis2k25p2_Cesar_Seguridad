using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Controlador_Seguridad;   //Agregar para usar la bitácora

namespace PrototipoPrincipal
{
    static class Program
    {
        //Variable para evitar duplicar cierre
        private static bool bSesionCerrada = false;

        [STAThread]
        static void Main()
        {
            //Registrar eventos globales de cierre o error
            Application.ApplicationExit += new EventHandler(OnApplicationExit);
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnApplicationExit);
            Application.ThreadException += new ThreadExceptionEventHandler(OnThreadException);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Mostrar Splash
            using (var splash = new Capa_Vista_Seguridad.Frm_Slash())
            {
                splash.ShowDialog();
            }

            //Esto muestra el Login después
            Application.Run(new Capa_Vista_Seguridad.Frm_Login());
        }

        //Registrar desconexión cuando la aplicación se cierra normalmente
        private static void OnApplicationExit(object sender, EventArgs e)
        {
            RegistrarDesconexionSegura();
        }

        //Registrar desconexión cuando ocurre un error inesperado
        private static void OnThreadException(object sender, ThreadExceptionEventArgs e)
        {
            RegistrarDesconexionSegura();
        }

        //Evita duplicar y asegura el cierre
        private static void RegistrarDesconexionSegura()
        {
            try
            {
                if (!bSesionCerrada && Cls_UsuarioConectado.iIdUsuario != 0)
                {
                    var ctrlBitacora = new Cls_BitacoraControlador();
                    ctrlBitacora.RegistrarCierreSesion(Cls_UsuarioConectado.iIdUsuario);
                    bSesionCerrada = true; //Bloquea más registros
                }
            }
            catch
            {
                //Evitar errores si ya se cerró la conexión o el programa
            }
        }
    }
}
