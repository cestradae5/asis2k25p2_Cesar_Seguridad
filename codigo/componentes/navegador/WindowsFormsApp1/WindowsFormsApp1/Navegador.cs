using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaControladorNavegador;
namespace WindowsFormsApp1
{
    public partial class Navegador : UserControl
    {
        public Navegador()
        {
            InitializeComponent();
            //string[] alias = { "Clave_empleado", "Nombre", "Apellidos", "Clave_Depto" };
            string[] alias = { "Clave_Depto", "Nombre", "Presupuesto", "Niggas" };
            ControladorNavegador ctrl = new ControladorNavegador(); //crea instancia controlador
            ctrl.AsignarAlias(alias, this, 10, 100); //llama al metodo 
        }

        private void btn_ingresar_Click(object sender, EventArgs e)
        {
         
        }

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            ControladorNavegador ctrl = new ControladorNavegador(); //crea instancia controlador
            ctrl.Insertar_Datos();
        }
    }
}
