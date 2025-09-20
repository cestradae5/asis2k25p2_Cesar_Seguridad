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
<<<<<<< Updated upstream
<<<<<<< HEAD
            
            string[] columnas = { "empleados", "codigo_empleado", "nombre_completo", "puesto", "departamento", "estado" };
=======
            CapaControladorNavegador.ConfiguracionDataGridView config = new CapaControladorNavegador.ConfiguracionDataGridView
            {
                Ancho = 1100,
                Alto = 200,
                PosX = 10,
                PosY = 250,
                ColorFondo = Color.White,
                TipoScrollBars = ScrollBars.Both,
                Nombre = "dgv_empleados"
            };
=======
            
            string[] columnas = { "empleados", "codigo_empleado", "nombre_completo", "puesto", "departamento", "estado" };
            navegador1.nombreTabla = columnas[0]; 
            navegador1.alias = columnas;
>>>>>>> Stashed changes

            string[] columnas = { "empleados", "codigo_empleado", "nombre_completo", "puesto", "departamento", "estado" };
            navegador1.configurarDataGridView(config);
>>>>>>> d36fa1eed5afa9529183c4515d3d3a8980adac4c
            navegador1.nombreTabla = columnas[0];
            navegador1.alias = columnas;
            navegador1.mostrarDatos();
        }

    }
}
