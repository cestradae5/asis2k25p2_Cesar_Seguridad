using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CapaControlador;
using CapaModelo;

namespace CapaVista
{
    public partial class FrmUsuario : Form
    {
        private Cls_UsuarioControlador usuarioControlador = new Cls_UsuarioControlador();
        private Cls_EmpleadoControlador empleadoControlador = new Cls_EmpleadoControlador();
        private List<Cls_Empleado> listaEmpleados = new List<Cls_Empleado>();
        private int idUsuarioSeleccionado = 0; // Para saber si modificamos un usuario existente

        public FrmUsuario()
        {
            InitializeComponent();
            CargarEmpleados();
            ConfigurarComboBoxEmpleados();
            ConfiguracionInicial();
        }

        private void ConfiguracionInicial()
        {
            Btn_Guardar.Enabled = false;
            Btn_Modificar.Enabled = false;
            Btn_Nuevo.Enabled = true;
        }

        private void CargarEmpleados()
        {
            listaEmpleados = empleadoControlador.ObtenerTodosLosEmpleados();
        }

        private void ConfigurarComboBoxEmpleados()
        {
            Cbo_Empleado.DisplayMember = "Display";
            Cbo_Empleado.ValueMember = "Id";

            foreach (var emp in listaEmpleados)
            {
                Cbo_Empleado.Items.Add(new
                {
                    Display = $"{emp.PkIdEmpleado} - {emp.NombresEmpleado} {emp.ApellidosEmpleado}",
                    Id = emp.PkIdEmpleado
                });
            }
        }

        private void Btn_Nuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            Btn_Guardar.Enabled = false; // habilitar solo si hay texto
            Btn_Modificar.Enabled = false;
            idUsuarioSeleccionado = 0;
        }

        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Cbo_Empleado.SelectedItem == null)
                {
                    MessageBox.Show("Debe seleccionar un empleado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var selected = (dynamic)Cbo_Empleado.SelectedItem;
                int fkIdEmpleado = selected.Id;

              //esto lo puse para hashear la contraseña
                string contraseñaHasheada = SeguridadHash.HashearSHA256(Txt_Contraseña.Text);

                usuarioControlador.InsertarUsuario(
                    fkIdEmpleado,
                    Txt_Nombre.Text,
                    contraseñaHasheada,
                    0,              
                    true,          
                    DateTime.Now,   
                    DateTime.Now,  
                    false         
                );

                MessageBox.Show("Usuario creado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                ConfiguracionInicial();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_Modificar_Click(object sender, EventArgs e)
        {
            if (idUsuarioSeleccionado == 0)
            {
                MessageBox.Show("Seleccione primero un usuario para modificar");
                return;
            }

            try
            {
                var selected = (dynamic)Cbo_Empleado.SelectedItem;
                int fkIdEmpleado = selected.Id;

               
                string contraseñaHasheada = SeguridadHash.HashearSHA256(Txt_Contraseña.Text);

                usuarioControlador.ActualizarUsuario(
                    idUsuarioSeleccionado,
                    fkIdEmpleado,
                    Txt_Nombre.Text,
                    contraseñaHasheada,
                    0,
                    true,
                    DateTime.Now,
                    DateTime.Now,
                    false
                );

                MessageBox.Show("Usuario modificado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                ConfiguracionInicial();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_Limpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            ConfiguracionInicial();
        }

        private void Btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LimpiarCampos()
        {
            Cbo_Empleado.SelectedIndex = -1;
            Txt_Nombre.Clear();
            Txt_Contraseña.Clear();
            idUsuarioSeleccionado = 0;
        }

        //aqui es para validar los campos

        private void Txt_Nombre_TextChanged(object sender, EventArgs e)
        {
            ValidarCampos();
        }

        private void Txt_Contraseña_TextChanged(object sender, EventArgs e)
        {
            ValidarCampos();
        }

        private void Cbo_Empleado_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidarCampos();
        }

        private void ValidarCampos()
        {
            Btn_Guardar.Enabled =
                Cbo_Empleado.SelectedItem != null &&
                !string.IsNullOrWhiteSpace(Txt_Nombre.Text) &&
                !string.IsNullOrWhiteSpace(Txt_Contraseña.Text);
        }
    }
}




