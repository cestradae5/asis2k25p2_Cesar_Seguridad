using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Controlador_Navegador;
namespace Capa_Vista_Navegador
{
    public partial class Navegador : UserControl
    {
        public string[] SAlias { get; set; }
        public string SNombreTabla { get; set; } // Nueva propiedad para el nombre de la tabla

        public ConfiguracionDataGridView configuracionDataGridView;

        public Navegador()
        {
            InitializeComponent();
            // Los botones se inicializan en su estado inicial, Reportes, ingresar e imprimir
            BotonesEstadoInicial();
        }

        private void Btn_ingresar_Click(object sender, EventArgs e)
        {
            /*ControladorNavegador ctrl = new ControladorNavegador(); //crea instancia controlador
            ctrl.AsignarAlias(alias, this, 10, 100); //llama al metodo
            // habilitar botones
            habilitar_botones();*/


            if (SAlias == null || SAlias.Length < 2)
            {
                MessageBox.Show("No se han definido los alias de la tabla.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Parámetros para validar 
            string tabla = SNombreTabla;
            string[] columnas = SAlias;

            // Asigna los alias al controlador y crea los controles necesarios
            if (ctrl.AsignarAlias(SAlias, this, 10, 100))
            {
                Btn_ingresar.Enabled = false;
                BotonesEstadoCRUD();
                mostrarDatos();
                ctrl.ActivarTodosComboBoxes(this);
            }
        }

        ControladorNavegador ctrl = new ControladorNavegador();


        // parte del datagridview con la funcion del boton imprimir

        // Cambio para que ya no sea paginado Fernando Jose cahuex Gonzalez 0901-22-14979
        private DataGridView Dgv_Datos;
        //private int registrosPorPagina = 9;
        //private int paginaActual = 1;
        //private int totalPaginas = 0;
        private DataTable dtCompleto;

        //private void MostrarPagina(int pagina)
        //{
        //    DataTable dtPagina = dtCompleto.Clone();
        //    int inicio = (pagina - 1) * registrosPorPagina;
        //    int fin = Math.Min(inicio + registrosPorPagina, dtCompleto.Rows.Count);
        //    for (int i = inicio; i < fin; i++)
        //    {
        //        dtPagina.ImportRow(dtCompleto.Rows[i]);
        //    }
        //    Dgv_Datos.DataSource = dtPagina;
        //}


        public void mostrarDatos()
        {
            if (Dgv_Datos == null)
            {
                Dgv_Datos = new DataGridView();
                Dgv_Datos.Name = "Dgv_Datos";
                Dgv_Datos.ScrollBars = ScrollBars.None;
                Dgv_Datos.BackgroundColor = Color.White;
                Dgv_Datos.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Bold);
                Dgv_Datos.Location = new System.Drawing.Point(10, 250);
                Dgv_Datos.Size = new System.Drawing.Size(1100, 200);
                Dgv_Datos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                Dgv_Datos.ReadOnly = true; 
                this.Controls.Add(Dgv_Datos);

                // preguntar a Stevens
                ctrl.AsignarDataGridView(Dgv_Datos);
                Dgv_Datos.SelectionChanged += Dgv_Datos_SelectionChanged;
            }

            // Asegurarse de que alias no sea null
            if (SAlias == null || SAlias.Length < 2)
            {
                MessageBox.Show("Alias no configurado correctamente.");
                return;
            }

            dtCompleto = ctrl.LlenarTabla(SAlias[0], SAlias.Skip(1).ToArray());
            Dgv_Datos.DataSource = dtCompleto;

            //totalPaginas = (int)Math.Ceiling(dtCompleto.Rows.Count / (double)registrosPorPagina);
            //paginaActual = 1;
            //MostrarPagina(paginaActual);

            // Enganchar el evento solo una vez
            Dgv_Datos.DataBindingComplete -= Dgv_Datos_DataBindingComplete;
            Dgv_Datos.DataBindingComplete += Dgv_Datos_DataBindingComplete;

        }


        private void Dgv_Datos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (Dgv_Datos.Rows.Count > 0)
            {
                Dgv_Datos.ClearSelection();
                //Dgv_Datos.CurrentCell = null;
            }
        }

        public void BotonesEstadoCRUD()
        {
            Btn_modificar.Enabled = true;
            Btn_guardar.Enabled = true;
            Btn_cancelar.Enabled = true;
            Btn_eliminar.Enabled = true;
            Btn_consultar.Enabled = false;
            Btn_imprimir.Enabled = false;
            Btn_refrescar.Enabled = true;
            Btn_inicio.Enabled = true;
            Btn_anterior.Enabled = true;
            Btn_sig.Enabled = true;
            Btn_fin.Enabled = true;
        }

        public void BotonesEstadoInicial()
        {
            Btn_ingresar.Enabled = true;
            Btn_modificar.Enabled = false;
            Btn_guardar.Enabled = false;
            Btn_cancelar.Enabled = false;
            Btn_eliminar.Enabled = false;
            Btn_consultar.Enabled = true;
            Btn_imprimir.Enabled = true;
            Btn_refrescar.Enabled = false;
            Btn_inicio.Enabled = false;
            Btn_anterior.Enabled = false;
            Btn_sig.Enabled = false;
            Btn_fin.Enabled = false;
        }

        private void Btn_cancelar_Click_1(object sender, EventArgs e)
        {
            BotonesEstadoInicial();
            // Limpiar Cbo
            ctrl.LimpiarCombos(this, SAlias);
            ctrl.DesactivarTodosComboBoxes(this);
        }

        private void Btn_guardar_Click_1(object sender, EventArgs e)
        {
            ControladorNavegador ctrl = new ControladorNavegador();
            ctrl.Insertar_Datos(this, SAlias);

            // Recarga despues de insertar = Stevens Cambranes
            mostrarDatos();
            ctrl.RefrescarCombos(this, SAlias[0], SAlias.Skip(1).ToArray());
        }

        // ======================= Modificar / Update = Stevens Cambranes =======================
        private void Btn_modificar_Click(object sender, EventArgs e)
        {
            ctrl.Actualizar_Datos(this, SAlias);

            mostrarDatos();
            ctrl.RefrescarCombos(this, SAlias[0], SAlias.Skip(1).ToArray());
            ctrl.LimpiarCombos(this, SAlias);
        }
        // ======================= Modificar / Update = Stevens Cambranes =======================

        // ======================= Esta funcion es para seleccionar la fila del Dgv y Rellenar los Cbo =======================
        private void Dgv_Datos_SelectionChanged(object sender, EventArgs e)
        {
            // ======================= Pedro Ibañez =======================
            // Modificacion: Se hace la seleccion solo si el usuario hizo clic o usó teclado
            if (Control.MouseButtons == MouseButtons.None && !Dgv_Datos.Focused) return;

            if (Dgv_Datos?.CurrentRow == null || SAlias == null || SAlias.Length < 2) return;
            ctrl.RellenarCombosDesdeFila(this, SAlias, Dgv_Datos.CurrentRow);
        }
        // ======================= Esta funcion es para seleccionar la fila del Dgv y Rellenar los Cbo =======================

        private void Btn_eliminar_Click(object sender, EventArgs e)
        {
            if (SAlias == null || SAlias.Length < 2)
            {
                MessageBox.Show("Alias no configurado correctamente.");
                return;
            }

            try
            {
                // ======================= Pedro Ibañez =======================
                // Modificacion: MessageBox de confirmación simple
                DialogResult resultado = MessageBox.Show(
                    "¿Está seguro que desea eliminar el registro seleccionado?",
                    "Confirmar Eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2);

                if (resultado != DialogResult.Yes)
                    return;

                ctrl.Eliminar_Datos(this, SAlias);
                mostrarDatos();
                ctrl.RefrescarCombos(this, SAlias[0], SAlias.Skip(1).ToArray());
                ctrl.LimpiarCombos(this, SAlias);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el registro: " + ex.Message);
            }
        }

        private void Btn_consultar_Click(object sender, EventArgs e)
        {
            // Llamar al componente consultas inteligentes
        }

        private void Btn_imprimir_Click_1(object sender, EventArgs e)
        {
            // Llamar al componente reporteadores
        }
        
        private void Btn_refrescar_Click(object sender, EventArgs e)
        {
            // ======================= Pedro Ibañez =======================
            // Creacion Metodo: vuelve a cargar los datos en el DataGridView y limpiar comboBoxes
            ctrl.LimpiarCombos(this, SAlias);
            ctrl.ActivarTodosComboBoxes(this);
            try
            {
                mostrarDatos(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al refrescar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_inicio_Click_1(object sender, EventArgs e)
        {
            if (Dgv_Datos == null || Dgv_Datos.Rows.Count == 0)
                return;

            int primeraFila = 0;

            Dgv_Datos.ClearSelection();
            Dgv_Datos.Rows[primeraFila].Selected = true;
            Dgv_Datos.CurrentCell = Dgv_Datos.Rows[primeraFila].Cells[0];

            // Forzar scroll para mostrar la primera fila en pantalla
            Dgv_Datos.FirstDisplayedScrollingRowIndex = primeraFila;
        }

        // ======================= Boton para posicionarse en el registro anterior - Fredy Reyes 0901-22-9800 =======================
        private void Btn_anterior_Click_1(object sender, EventArgs e)
        {
            if (Dgv_Datos == null || Dgv_Datos.Rows.Count == 0)
                return;

            int filaActual = Dgv_Datos.CurrentCell?.RowIndex ?? -1;
            if (filaActual > 0)
            {
                int filaAnterior = filaActual - 1;
                Dgv_Datos.ClearSelection();
                Dgv_Datos.Rows[filaAnterior].Selected = true;
                Dgv_Datos.CurrentCell = Dgv_Datos.Rows[filaAnterior].Cells[0];
            }
        }

        // ======================= Boton para posicionarse en el registro siguiente - Fredy Reyes 0901-22-9800 =======================
        private void Btn_sig_Click(object sender, EventArgs e)
        {
            if (Dgv_Datos == null || Dgv_Datos.Rows.Count == 0)
                return;

            int filaActual = Dgv_Datos.CurrentCell?.RowIndex ?? -1;
            if (filaActual >= 0 && filaActual < Dgv_Datos.Rows.Count - 1)
            {
                int filaSiguiente = filaActual + 1;
                Dgv_Datos.ClearSelection();
                Dgv_Datos.Rows[filaSiguiente].Selected = true;
                Dgv_Datos.CurrentCell = Dgv_Datos.Rows[filaSiguiente].Cells[0];
            }
        }

        private void Btn_fin_Click_1(object sender, EventArgs e)
        {
            if (Dgv_Datos == null || Dgv_Datos.Rows.Count == 0)
                return;

            int ultimaFila = Dgv_Datos.Rows.Count - 1;

            // Si AllowUserToAddRows está activo, restar 1 para seleccionar la última fila real
            if (Dgv_Datos.AllowUserToAddRows)
                ultimaFila -= 1;

            if (ultimaFila < 0) return; // no hay filas reales

            Dgv_Datos.ClearSelection();

            // Primero fijar CurrentCell para activar la fila
            Dgv_Datos.CurrentCell = Dgv_Datos.Rows[ultimaFila].Cells[0];

            // Luego seleccionar la fila completa
            Dgv_Datos.Rows[ultimaFila].Selected = true;

            // Asegurar que se vea en pantalla
            Dgv_Datos.FirstDisplayedScrollingRowIndex = ultimaFila;

        }

        private void Btn_ayuda_Click(object sender, EventArgs e)
        {

        }

        private void Btn_salir_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Configuracion de data grid view
        public void configurarDataGridView(ConfiguracionDataGridView configuracion)
        {
            configuracionDataGridView = configuracion;

            if (Dgv_Datos == null)
            {
                Dgv_Datos = new DataGridView();
                Dgv_Datos.Name = configuracionDataGridView.Nombre;

                // ScrollBars
                Dgv_Datos.ScrollBars = configuracionDataGridView.TipoScrollBars;

                // Colores y estilos
                Dgv_Datos.BackgroundColor = configuracionDataGridView.ColorFondo;
                Dgv_Datos.RowsDefaultCellStyle.BackColor = configuracionDataGridView.ColorFilas;
                Dgv_Datos.RowsDefaultCellStyle.ForeColor = configuracionDataGridView.ColorTextoFilas;
                Dgv_Datos.AlternatingRowsDefaultCellStyle.BackColor = configuracionDataGridView.ColorFilasAlternas;

                // Encabezados
                Dgv_Datos.ColumnHeadersDefaultCellStyle.Font = configuracionDataGridView.FuenteEncabezado;
                Dgv_Datos.EnableHeadersVisualStyles = false;
                Dgv_Datos.ColumnHeadersDefaultCellStyle.BackColor = configuracionDataGridView.ColorEncabezado;
                Dgv_Datos.ColumnHeadersDefaultCellStyle.ForeColor = configuracionDataGridView.ColorTextoEncabezado;

                // Ubicación y tamaño
                Dgv_Datos.Location = new Point(configuracionDataGridView.PosX, configuracionDataGridView.PosY);
                Dgv_Datos.Size = new Size(configuracionDataGridView.Ancho, configuracionDataGridView.Alto);
                Dgv_Datos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Agregar al formulario
                this.Controls.Add(Dgv_Datos);

                // Mandarlo al controlador
                ctrl.AsignarDataGridView(Dgv_Datos);

                // ======================= Stevens Cambranes =======================
                // Enganchar siempre el handler (si el grid se creó desde aquí)
                Dgv_Datos.SelectionChanged -= Dgv_Datos_SelectionChanged;
                Dgv_Datos.SelectionChanged += Dgv_Datos_SelectionChanged;

            }
        }

    }
}
