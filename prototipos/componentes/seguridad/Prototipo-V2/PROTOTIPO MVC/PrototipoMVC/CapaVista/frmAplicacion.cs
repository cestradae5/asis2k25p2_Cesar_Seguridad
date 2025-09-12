//Cesar Armando Estrtada Elias 0901-22-10153
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaControlador;
using CapaModelo;




namespace CapaVista
{
    public partial class FrmAplicacion : Form
    {
        private Cls_AplicacionControlador controlador = new Cls_AplicacionControlador();
        private List<Cls_Aplicacion> listaAplicaciones = new List<Cls_Aplicacion>();
        public FrmAplicacion()
        {
            InitializeComponent();
            CargarAplicaciones();
            ConfigurarComboBox();
        }
        private void CargarAplicaciones()
        {
            listaAplicaciones = controlador.ObtenerTodasLasAplicaciones();
        }
        private void ConfigurarComboBox()
        {
            // Configurar AutoComplete
            Cbo_buscar.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            Cbo_buscar.AutoCompleteSource = AutoCompleteSource.CustomSource;

            // Crear fuente de autocompletado
            AutoCompleteStringCollection autoComplete = new AutoCompleteStringCollection();
            autoComplete.AddRange(listaAplicaciones.Select(a => a.PkIdAplicacion.ToString()).ToArray());
            autoComplete.AddRange(listaAplicaciones.Select(a => a.NombreAplicacion).ToArray());
            Cbo_buscar.AutoCompleteCustomSource = autoComplete;

            // Configurar display
            Cbo_buscar.DisplayMember = "Display";
            Cbo_buscar.ValueMember = "Id";

            // Crear items combinados (ID + Nombre)
            foreach (var app in listaAplicaciones)
            {
                Cbo_buscar.Items.Add(new
                {
                    Display = $"{app.PkIdAplicacion} - {app.NombreAplicacion}",
                    Id = app.PkIdAplicacion
                });
            }
        }
        private void MostrarAplicacion(Cls_Aplicacion app)
        {
            Txt_id_aplicacion.Text = app.PkIdAplicacion.ToString();
            Txt_Nombre_aplicacion.Text = app.NombreAplicacion;
            Txt_descripcion.Text = app.DescripcionAplicacion;
            Rdb_estado_activo.Checked = app.HabilitadoAplicacion;
            Rdb_inactivo.Checked = app.DeshabilitadoAplicacion;
        }
        private void Btn_buscar_Click(object sender, EventArgs e)
        {
            string busqueda = Cbo_buscar.Text.Trim();

            if (string.IsNullOrEmpty(busqueda))
            {
                MessageBox.Show("Ingrese un ID o nombre para buscar");
                return;
            }

            Cls_Aplicacion appEncontrada = null;

            // Buscar por ID si es numérico
            if (int.TryParse(busqueda, out int id))
            {
                appEncontrada = listaAplicaciones.FirstOrDefault(a => a.PkIdAplicacion == id);
            }

            // Si no encontró por ID, buscar por nombre
            if (appEncontrada == null)
            {
                appEncontrada = listaAplicaciones.FirstOrDefault(a =>
                    a.NombreAplicacion.Equals(busqueda, StringComparison.OrdinalIgnoreCase));
            }

            if (appEncontrada != null)
            {
                MostrarAplicacion(appEncontrada);
            }
            else
            {
                MessageBox.Show("Aplicación no encontrada");
                LimpiarCampos();
            }
        }

        private void Cbo_buscar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Txt_id_aplicacion_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Txt_Nombre_aplicacion_TextChanged(object sender, EventArgs e)
        {

        }

        private void Txt_descripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void Btn_eliminar_Click(object sender, EventArgs e)
        {
            int id;
            if (!int.TryParse(Txt_id_aplicacion.Text, out id))
            {
                MessageBox.Show("Ingrese un ID válido para eliminar.");
                return;
            }

            bool exito = controlador.BorrarAplicacion(id);
            MessageBox.Show(exito ? "Aplicación eliminada" : "Error al eliminar");
            LimpiarCampos();
        }

        private void Btn_modificar_Click(object sender, EventArgs e)
        {
            int id;
            if (!int.TryParse(Txt_id_aplicacion.Text, out id))
            {
                MessageBox.Show("Ingrese un ID válido para modificar.");
                return;
            }

            bool exito = controlador.ActualizarAplicacion(
                id,
                Txt_Nombre_aplicacion.Text,
                Txt_descripcion.Text,
                Rdb_estado_activo.Checked,
                Rdb_inactivo.Checked,
                null // fk_id_reporte opcional
            );

            MessageBox.Show(exito ? "Aplicación modificada" : "Error al modificar");


        }

        private void Btn_nuevo_Click(object sender, EventArgs e)
        {
            Txt_id_aplicacion.Clear();
            Txt_Nombre_aplicacion.Clear();
            Txt_descripcion.Clear();
            Rdb_estado_activo.Checked = true;
            Rdb_inactivo.Checked = false;
        }

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            var app = new Cls_Aplicacion
            {
                PkIdAplicacion = int.Parse(Txt_id_aplicacion.Text), // <- manual
                NombreAplicacion = Txt_Nombre_aplicacion.Text,
                DescripcionAplicacion = Txt_descripcion.Text,
                HabilitadoAplicacion = Rdb_estado_activo.Checked,
                DeshabilitadoAplicacion = Rdb_inactivo.Checked,
                FkIdReporte = null // si no usas reporte
            };

            int resultado = controlador.InsertarAplicacion(
                app.PkIdAplicacion,
                app.NombreAplicacion,
                app.DescripcionAplicacion,
                app.HabilitadoAplicacion,
                app.DeshabilitadoAplicacion,
                app.FkIdReporte
            );

            if (resultado > 0)
                MessageBox.Show("Aplicación guardada correctamente");
            else
                MessageBox.Show("Error al guardar");
        }



        private void Rdb_estado_activo_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Rdb_inactivo_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void LimpiarCampos()
        {
            Txt_id_aplicacion.Clear();
            Txt_Nombre_aplicacion.Clear();
            Txt_descripcion.Clear();
            Rdb_estado_activo.Checked = true;
            Rdb_inactivo.Checked = false;
        }

       
    }
}
