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
            Capa_Controlador_Navegador.ConfiguracionDataGridView config = new Capa_Controlador_Navegador.ConfiguracionDataGridView
            {
                Ancho = 1100,
                Alto = 200,
                PosX = 10,
                PosY = 250,
                ColorFondo = Color.White,
                TipoScrollBars = ScrollBars.Both,
                Nombre = "dgv_empleados"
            };
            
            string[] columnas = { "empleados", "codigo_empleado", "nombre_completo", "puesto", "departamento","estado"};
            navegador1.configurarDataGridView(config);
            navegador1.SNombreTabla = columnas[0];
            navegador1.SAlias = columnas;
            navegador1.mostrarDatos();
        }

    }
}
