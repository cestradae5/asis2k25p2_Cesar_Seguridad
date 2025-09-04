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

        public void Insertar_Datos()
        {

        }
    }
}
