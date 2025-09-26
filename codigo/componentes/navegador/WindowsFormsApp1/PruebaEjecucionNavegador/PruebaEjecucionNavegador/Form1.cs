using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebaEjecucionNavegador
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Capa_Controlador_Navegador.Cls_ConfiguracionDataGridView config = new Capa_Controlador_Navegador.Cls_ConfiguracionDataGridView
            {
                Ancho = 1100,
                Alto = 200,
                PosX = 10,
                PosY = 250,
                ColorFondo = Color.White,
                TipoScrollBars = ScrollBars.Both,
                Nombre = "dgv_empleados"
            };
            
            string[] columnas = { "padre", "id_padre", "nombre", "apellido", "id_hijo" };
            navegador1.configurarDataGridView(config);
            navegador1.SNombreTabla = columnas[0];
            navegador1.SAlias = columnas;
            navegador1.mostrarDatos();
        }

        private void Btn_Siguiente_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();  // Crear una nueva instancia de Form2
            frm.Show();
        }
    }
}
