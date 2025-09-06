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
            // deshabilitar botones
            Btn_modificar.Enabled = false;
            Btn_guardar.Enabled = false;
            Btn_cancelar.Enabled = false;
            Btn_eliminar.Enabled = false;
            Btn_consultar.Enabled = false;
            Btn_imprimir.Enabled = false;
            Btn_refrescar.Enabled = false;
            Btn_inicio.Enabled = false;
            Btn_anterior.Enabled = false;
            Btn_sig.Enabled = false;
            Btn_fin.Enabled = false;
        }

        private void Btn_ingresar_Click(object sender, EventArgs e)
        {
            //string[] alias = { "Clave_empleado", "Nombre", "Apellidos", "Clave_Depto" };
            string[] alias = { "Clave_Depto", "Nombre", "Presupuesto", "Otra Area" };
            ControladorNavegador ctrl = new ControladorNavegador(); //crea instancia controlador
            ctrl.AsignarAlias(alias, this, 10, 100); //llama al metodo

            // habilitar botones
            Btn_modificar.Enabled = true;
            Btn_guardar.Enabled = true;
            Btn_cancelar.Enabled = true;
            Btn_eliminar.Enabled = true;
            Btn_consultar.Enabled = true;
            Btn_imprimir.Enabled = true;
            Btn_refrescar.Enabled = true;
            Btn_inicio.Enabled = true;
            Btn_anterior.Enabled = true;
            Btn_sig.Enabled = true;
            Btn_fin.Enabled = true;
        }

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            ControladorNavegador ctrl = new ControladorNavegador(); //crea instancia controlador
            ctrl.Insertar_Datos();
        }

        private void Btn_cancelar_Click(object sender, EventArgs e)
        {
            Btn_modificar.Enabled = false;
            Btn_guardar.Enabled = false;
            Btn_cancelar.Enabled = false;
            Btn_eliminar.Enabled = false;
            Btn_consultar.Enabled = false;
            Btn_imprimir.Enabled = false;
            Btn_refrescar.Enabled = false;
            Btn_inicio.Enabled = false;
            Btn_anterior.Enabled = false;
            Btn_sig.Enabled = false;
            Btn_fin.Enabled = false;
        }
        ControladorNavegador ctrl = new ControladorNavegador();
        //ctrl.AsignarDataGridView();  Aquí se coloca el nombre del DataGridView

        private void Btn_inicio_Click(object sender, EventArgs e)
        {
            
            ctrl.MoverAlInicio();
        }

        private void Btn_fin_Click(object sender, EventArgs e)
        {
            
            ctrl.MoverAlFin();
        }
    }
}
