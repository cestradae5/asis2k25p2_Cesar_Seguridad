using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa_Vista_Seguridad
{
    public partial class Frm_Slash : Form
    {
        public Frm_Slash()
        {
            InitializeComponent();
        }

        private void frmSlash_Load(object sender, EventArgs e)
        {
            // Configuración del PictureBox
            Pic_carga.Dock = DockStyle.Fill;          // Que ocupe todo el formulario
            Pic_carga.SizeMode = PictureBoxSizeMode.Zoom; // Mantiene proporción del GIF
            Pic_carga.SendToBack();                  // Lo manda al fondo para no tapar la barra ni el label

            // Inicializa la barra en 0
            Pgb_carga.Value = 0;

            // Configura el Timer
            Tmr_carga.Interval = 100; // 100 ms
            Tmr_carga.Enabled = true;
            Tmr_carga.Start();
        }

        private void Tmr_carga_Tick(object sender, EventArgs e)
        {
            // Avanza la barra
            if (Pgb_carga.Value < Pgb_carga.Maximum)
            {
                Pgb_carga.Increment(2);
                Lbl_carga.Text = Pgb_carga.Value.ToString() + "%";
            }

            // Cuando llega al máximo
            if (Pgb_carga.Value >= Pgb_carga.Maximum)
            {
                Tmr_carga.Stop();

                // Oculta el splash
                this.Hide();

            }
        }
    }
}
