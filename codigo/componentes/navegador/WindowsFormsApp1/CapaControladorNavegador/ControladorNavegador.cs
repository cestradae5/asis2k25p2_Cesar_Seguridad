using CapaModeloNavegador;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace CapaControladorNavegador
{
    public class ControladorNavegador
    {
        SentenciasMYSQL sentencias = new SentenciasMYSQL();
        public void AsignarAlias(string[] alias, Control contenedor, int startX, int startY)
        {
            int spacingY = 30; // Espacio vertical entre cada par Label/TextBox

            for (int i = 1; i < alias.Length; i++)
            {
                // Crear Label
                Label lbl = new Label();
                lbl.Text = alias[i] + ":";
                lbl.AutoSize = true;
                lbl.Location = new System.Drawing.Point(startX, startY + (i * spacingY));

                // Crear TextBox
                TextBox txt = new TextBox();
                txt.Name = "txt_" + alias[i]; // ejemplo: txtNombre, txtEdad...
                txt.Width = 150;
                txt.Location = new System.Drawing.Point(startX + 100, startY + (i * spacingY));

                // Agregar al contenedor (Form o Panel)
                contenedor.Controls.Add(lbl);
                contenedor.Controls.Add(txt);
            }

        }
    //-----------------------------------------------------------------------
        private DataGridView dgv;

        public void AsignarDataGridView(DataGridView grid)
        {
            dgv = grid;
        }

        public void MoverAlInicio()
        {
            if (dgv != null && dgv.Rows.Count > 0)
            {
                dgv.ClearSelection();
                dgv.Rows[0].Selected = true;
                dgv.CurrentCell = dgv.Rows[0].Cells[0];
            }
        }

        public void MoverAlFin()
        {
            if (dgv != null && dgv.Rows.Count > 0)
            {
                int ultimaFila = dgv.Rows.Count - 1;
                dgv.ClearSelection();
                dgv.Rows[ultimaFila].Selected = true;
                dgv.CurrentCell = dgv.Rows[ultimaFila].Cells[0];
            }
        }
//---------------------------------------------------------------------------------------------------------

        public void Insertar_Datos(Control contenedor)
        {
            // Ejemplo de alias y valores, en la práctica estos vendrían de los TextBox generados dinámicamente
            string[] alias = { "medico", "DPI", "Nombre", "Especialidad", "Edad"};
            string[] valores = { }; //{ 1, "Juan Perez", 50000.00m, "Recursos Humanos" }; // Asegúrate de que los tipos coincidan
            DAOGenerico dao = new DAOGenerico();
            try
            {
                for (int i = 1; i < alias.Length; i++)
                {
                    // Buscar el TextBox que tenga el nombre generado
                    TextBox txt = contenedor.Controls.OfType<TextBox>().FirstOrDefault(t => t.Name == "txt_" + alias[i]);

                    if (txt != null)
                    {
                        valores[i - 1] = txt.Text; // Guardar el texto en la posición correspondiente
                    }
                    else
                    {
                        valores[i - 1] = null; // Si no existe el textbox, poner null
                    }
                }

                dao.InsertarDatos(alias, valores);

                MessageBox.Show("Datos insertados correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar datos: " + ex.Message);
            }
        }

        public DataTable LlenarTabla(string tabla, string[] alias) 
        {
            return sentencias.LlenarTabla(tabla, alias);
        }
    }
}
