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
            
            string[] columnas = { "empleados","codigo_empleado", "nombre_completo", "puesto", "departamento", "estado" };
            navegador1.nombreTabla = columnas[0];
            navegador1.alias = columnas;

            navegador1.mostrarDatos();
        }
    }
}
