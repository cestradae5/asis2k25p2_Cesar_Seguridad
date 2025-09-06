using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaControladorNavegador
{
    public class ControladorNavegador
    {
        public void AsignarAlias(string[] alias, Control contenedor, int startX, int startY)
        {
            int spacingY = 30; // Espacio vertical entre cada par Label/TextBox

            for (int i = 0; i < alias.Length; i++)
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

        public void Insertar_Datos()
        {

        }
    }
}
