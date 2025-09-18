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


        private void Actualizar_Estado_Botones()
        {
            Btn_inicio.Enabled = paginaActual > 1;
            Btn_anterior.Enabled = paginaActual > 1;
            Btn_sig.Enabled = paginaActual < totalPaginas;
            Btn_fin.Enabled = paginaActual < totalPaginas;
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
                Dgv_Datos = new DataGridView();
                Dgv_Datos.Name = "Dgv_Datos";
                Dgv_Datos.ScrollBars = ScrollBars.None;
                Dgv_Datos.BackgroundColor = Color.White;
                Dgv_Datos.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Bold);
                Dgv_Datos.Location = new System.Drawing.Point(10, 250);
                Dgv_Datos.Size = new System.Drawing.Size(1100, 200);
                Dgv_Datos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                this.Controls.Add(Dgv_Datos);
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
        }

        private void Btn_guardar_Click_1(object sender, EventArgs e)
        {
            ControladorNavegador ctrl = new ControladorNavegador(); 
            ctrl.Insertar_Datos(this, alias);
        }

        private void Btn_modificar_Click(object sender, EventArgs e)
        {

        }

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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el registro: " + ex.Message);
            }
        }

        private void Btn_consultar_Click(object sender, EventArgs e)
        {

        }

        private void Btn_imprimir_Click_1(object sender, EventArgs e)
        {

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
            Actualizar_Estado_Botones();
        }

        private void Btn_anterior_Click_1(object sender, EventArgs e)
        {
            if (paginaActual == 1)
            {
                return;
            }
            paginaActual -= 1;
            MostrarPagina(paginaActual);
            Actualizar_Estado_Botones();
        }

        private void Btn_sig_Click(object sender, EventArgs e)
        {
            if (paginaActual == totalPaginas)
            {
                return;
            }
            paginaActual += 1;
            MostrarPagina(paginaActual);
            Actualizar_Estado_Botones();
        }

        private void Btn_fin_Click_1(object sender, EventArgs e)
        {
            paginaActual = totalPaginas;
            MostrarPagina(paginaActual);
            ctrl.MoverAlFin();
            Actualizar_Estado_Botones();
        }

        private void Btn_ayuda_Click(object sender, EventArgs e)
        {

        }

        private void Btn_salir_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
