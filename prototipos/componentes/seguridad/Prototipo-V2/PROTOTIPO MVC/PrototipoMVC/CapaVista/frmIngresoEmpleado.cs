using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using CapaControlador;

namespace CapaVista
{
    public partial class frmIngresoEmpleado : Form
    {
        ControladorEmpleado controlador = new ControladorEmpleado();

        public frmIngresoEmpleado()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(Txt_id.Text);
                string nombre = Txt_nombre.Text;
                string apellido = Txt_apellido.Text;
                string dpi = Txt_dpi.Text;
                string nit = Txt_nit.Text;
                string genero = Txt_genero.Text;
                string telefono = Txt_telefono.Text;
                string correo = Txt_correo.Text;
                string fechaNacimiento = Dtp_nacimiento.Text;
                string fechaContrato = Dtp_contrato.Text;

                bool guardado = controlador.GuardarEmpleado(id, nombre, apellido, dpi, nit, genero, telefono, correo, fechaNacimiento, fechaContrato);

                if (guardado)
                    MessageBox.Show("Empleado guardado correctamente");
                else
                    MessageBox.Show("No se pudo guardar el empleado");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void frmIngresoEmpleado_Load(object sender, EventArgs e)
        {

        }
    }
}