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
            mostrarDatos();
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
            string[] alias = { "pacientes", "id_paciente", "nombre", "apellido" };

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
            ctrl.Insertar_Datos(this);
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

        private void Btn_inicio_Click(object sender, EventArgs e)
        {
            paginaActual = 1;
            MostrarPagina(paginaActual);
            ctrl.MoverAlInicio();
        }

        private void Btn_fin_Click(object sender, EventArgs e)
        {
            paginaActual = totalPaginas;
            MostrarPagina(paginaActual);
            ctrl.MoverAlFin();
        }


        // parte del datagridview con la funcion del boton imprimir

        private DataGridView Dgv_Datos;
        private int registrosPorPagina = 9; // aqui se cambia el numero de registros por pagina
        private int paginaActual = 1;
        private int totalPaginas = 0;
        private DataTable dtCompleto;
        private void Btn_imprimir_Click(object sender, EventArgs e)
        {
            
        }
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

        private void Btn_salir_Click(object sender, EventArgs e)
        {

        }

        private void Btn_anterior_Click(object sender, EventArgs e){
            if (paginaActual == 1){
                return;
            }
            paginaActual -= 1;
            MostrarPagina(paginaActual);
            ActualizarBotonesSegunPaginasDisponibles();
        }

        private void Btn_siguiente_Click(object sender, EventArgs e){
            if (paginaActual == totalPaginas){
                return;
            }
            paginaActual += 1;
            MostrarPagina(paginaActual);
            ActualizarBotonesSegunPaginasDisponibles();
        }

        private void ActualizarBotonesSegunPaginasDisponibles() {
            Btn_inicio.Enabled = paginaActual > 1;
            Btn_anterior.Enabled = paginaActual > 1;
            Btn_sig.Enabled = paginaActual < totalPaginas;
            Btn_fin.Enabled = paginaActual < totalPaginas;
        }

        public void mostrarDatos()
        {
            if (Dgv_Datos == null)
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

            // Definir los alias de la tabla (dependiendo de la tabla que se use)
            string[] alias = { "id_paciente", "nombre", "apellido"};

            // aqui se llena la tabla y tambien se le pone el nombre (dependiendo de la tabla que se vaya a usar)
            dtCompleto = ctrl.LlenarTabla("pacientes", alias);
            Dgv_Datos.DataSource = dtCompleto;

            totalPaginas = (int)Math.Ceiling(dtCompleto.Rows.Count / (double)registrosPorPagina);
            paginaActual = 1; MostrarPagina(paginaActual);
        }
    }
}