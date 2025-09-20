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
namespace CapaVistaNavegador
{
    public partial class Navegador : UserControl
    {
        public string[] alias { get; set; }
        public string nombreTabla { get; set; } // Nueva propiedad para el nombre de la tabla

        public ConfiguracionDataGridView configuracionDataGridView;

        public Navegador()
        {
            InitializeComponent();
            // deshabilitar botones
            deshabilitar_botones();
        }

        private void Btn_ingresar_Click(object sender, EventArgs e)
        {
            /*ControladorNavegador ctrl = new ControladorNavegador(); //crea instancia controlador
            ctrl.AsignarAlias(alias, this, 10, 100); //llama al metodo
            // habilitar botones
            habilitar_botones();*/


            if (alias == null || alias.Length < 2)
            {
                MessageBox.Show("No se han definido los alias de la tabla.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Parámetros para validar 
            string tabla = nombreTabla;
            string[] columnas = alias;

            // Asigna los alias al controlador y crea los controles necesarios
            if (ctrl.AsignarAlias(alias, this, 10, 100))
            {
                habilitar_botones();
                mostrarDatos();
            }
        }

        ControladorNavegador ctrl = new ControladorNavegador();


        // parte del datagridview con la funcion del boton imprimir

        private DataGridView Dgv_Datos;
        private int registrosPorPagina = 9;
        private int paginaActual = 1;
        private int totalPaginas = 0;
        private DataTable dtCompleto;

        private void MostrarPagina(int pagina)
        {
            DataTable dtPagina = dtCompleto.Clone();
            int inicio = (pagina - 1) * registrosPorPagina;
            int fin = Math.Min(inicio + registrosPorPagina, dtCompleto.Rows.Count);
            for (int i = inicio; i < fin; i++)
            {
                dtPagina.ImportRow(dtCompleto.Rows[i]);
            }
            Dgv_Datos.DataSource = dtPagina;
        }

        public void mostrarDatos()
        {
            /* if (Dgv_Datos == null)
             {
                 Dgv_Datos = new DataGridView();
                 Dgv_Datos.Name = "Dgv_Datos";
                 Dgv_Datos.ScrollBars = ScrollBars.None;
                 Dgv_Datos.BackgroundColor = Color.White;
                 Dgv_Datos.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Bold);
                 Dgv_Datos.Location = new System.Drawing.Point(10, 250); // aqui se cambia la posicion (por si hay que agregar otra cosa)
                 Dgv_Datos.Size = new System.Drawing.Size(1100, 200); // aqui se cambia el tamaño (tambien por si acaso ajaj)
                 Dgv_Datos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                 this.Controls.Add(Dgv_Datos);
                 ctrl.AsignarDataGridView(Dgv_Datos);
             }

             // aqui se llena la tabla y tambien se le pone el nombre (dependiendo de la tabla que se vaya a usar)
             dtCompleto = ctrl.LlenarTabla(alias[0], alias.Skip(1).ToArray());
             Dgv_Datos.DataSource = dtCompleto;


             totalPaginas = (int)Math.Ceiling(dtCompleto.Rows.Count / (double)registrosPorPagina);
             paginaActual = 1;
             MostrarPagina(paginaActual);*/

            if (Dgv_Datos == null)
            {
<<<<<<< HEAD
                Dgv_Datos = new DataGridView();
                Dgv_Datos.Name = "Dgv_Datos";
                Dgv_Datos.ScrollBars = ScrollBars.None;
                Dgv_Datos.BackgroundColor = Color.White;
                Dgv_Datos.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Bold);
                Dgv_Datos.Location = new System.Drawing.Point(10, 250);
                Dgv_Datos.Size = new System.Drawing.Size(1100, 200);
                Dgv_Datos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                this.Controls.Add(Dgv_Datos);

                // preguntar a Stevens
                ctrl.AsignarDataGridView(Dgv_Datos);
                Dgv_Datos.SelectionChanged += Dgv_Datos_SelectionChanged;
=======
                //Dgv_Datos = new DataGridView();
                //Dgv_Datos.Name = "Dgv_Datos";
                //Dgv_Datos.ScrollBars = ScrollBars.None;
                //Dgv_Datos.BackgroundColor = Color.White;
                //Dgv_Datos.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Bold);
                //Dgv_Datos.Location = new System.Drawing.Point(10, 250);
                //Dgv_Datos.Size = new System.Drawing.Size(1100, 200);
                //Dgv_Datos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                //this.Controls.Add(Dgv_Datos);
>>>>>>> d36fa1eed5afa9529183c4515d3d3a8980adac4c
            }

            // Asegurarse de que alias no sea null
            if (alias == null || alias.Length < 2)
            {
                MessageBox.Show("Alias no configurado correctamente.");
                return;
            }

            dtCompleto = ctrl.LlenarTabla(alias[0], alias.Skip(1).ToArray());
            Dgv_Datos.DataSource = dtCompleto;

            totalPaginas = (int)Math.Ceiling(dtCompleto.Rows.Count / (double)registrosPorPagina);
            paginaActual = 1;
            MostrarPagina(paginaActual);
        }

        public void habilitar_botones()
        {
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

        public void deshabilitar_botones()
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

        private void Btn_cancelar_Click_1(object sender, EventArgs e)
        {
            deshabilitar_botones();
            // Limpiar Cbo
            ctrl.LimpiarCombos(this, alias);
        }

        private void Btn_guardar_Click_1(object sender, EventArgs e)
        {
            ControladorNavegador ctrl = new ControladorNavegador();
            ctrl.Insertar_Datos(this, alias);

            // Recarga despues de insertar = Stevens Cambranes
            mostrarDatos();
            ctrl.RefrescarCombos(this, alias[0], alias.Skip(1).ToArray());
        }

        // ======================= Modificar / Update = Stevens Cambranes =======================
        private void Btn_modificar_Click(object sender, EventArgs e)
        {
            ctrl.Actualizar_Datos(this, alias);

            mostrarDatos();
            ctrl.RefrescarCombos(this, alias[0], alias.Skip(1).ToArray());
            ctrl.LimpiarCombos(this, alias);
        }
        // ======================= Modificar / Update = Stevens Cambranes =======================

        // ======================= Esta funcion es para seleccionar la fila del Dgv y Rellenar los Cbo =======================
        private void Dgv_Datos_SelectionChanged(object sender, EventArgs e)
        {
            if (Dgv_Datos?.CurrentRow == null || alias == null || alias.Length < 2) return;
            // Llama directamente a tu función del controlador: RellenarCombosDesdeFila
            ctrl.RellenarCombosDesdeFila(this, alias, Dgv_Datos.CurrentRow);
        }
        // ======================= Esta funcion es para seleccionar la fila del Dgv y Rellenar los Cbo =======================

        private void Btn_eliminar_Click(object sender, EventArgs e)
        {
            if (alias == null || alias.Length < 2)
            {
                MessageBox.Show("Alias no configurado correctamente.");
                return;
            }

            try
            {
                ctrl.Eliminar_Datos(this, alias);
                mostrarDatos();
                // Recarga despues de eliminar = Stevens Cambranes
                ctrl.RefrescarCombos(this, alias[0], alias.Skip(1).ToArray());
                // limpia Cbo despues de eliminar = Stevens Cambranes
                ctrl.LimpiarCombos(this, alias);
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
            try
            {
                mostrarDatos(); // vuelve a cargar los datos en el DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al refrescar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_inicio_Click_1(object sender, EventArgs e)
        {
            paginaActual = 1;
            MostrarPagina(paginaActual);
            ctrl.MoverAlInicio();
        }

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
            paginaActual = totalPaginas;
            MostrarPagina(paginaActual);
            ctrl.MoverAlFin();
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
            }
        }

    }
}
