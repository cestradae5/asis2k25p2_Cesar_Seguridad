using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PrototipoPrincipal
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Mostrar Splash
            using (var splash = new CapaVista.frmSlash())
            {
                splash.ShowDialog();
            }

            // esto muestra el Login despues

            Application.Run(new CapaVista.frmLogin());
        }
    }
}
