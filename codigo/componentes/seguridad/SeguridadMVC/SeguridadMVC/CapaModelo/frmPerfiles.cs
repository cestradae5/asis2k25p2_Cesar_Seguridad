using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaVista
{
    public partial class frmPerfiles : Form
    {
        public frmPerfiles()
        {
            InitializeComponent();
        }

        private void Btn_nuevo_Click(object sender, EventArgs e)
        {
            Btn_nuevo.Enabled = false;
            Btn_guardar.Enabled = true;
            Btn_modificar.Enabled = false;
        }

        private void Btn_modificar_Click(object sender, EventArgs e)
        {
            Btn_nuevo.Enabled = false;
            Btn_guardar.Enabled = true;
            Btn_modificar.Enabled = false;
        }

        private void Btn_cancelar_Click(object sender, EventArgs e)
        {
            Txt_idperfil.Text = "";
            Txt_puesto.Text = "";
            Txt_descripcion.Text = "";
            Rdb_Habilitado.Checked = false;
            Rdb_inhabilitado.Checked = false;
            Btn_nuevo.Enabled = true;
            Btn_guardar.Enabled = true;
            Btn_modificar.Enabled = true;
        }

        private void Btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
