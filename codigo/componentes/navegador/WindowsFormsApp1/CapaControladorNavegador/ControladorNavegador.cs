using CapaModeloNavegador;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
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

        // ---------------------VALIDANDO ALIAS-----------------------------------------

        private ConexionMYSQL conexion = new ConexionMYSQL();
        private bool ExisteTabla(string nombreTabla)
        {
            OdbcConnection conn = conexion.conexion();
            try
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM information_schema.tables WHERE table_schema = DATABASE() AND table_name = ?";
                OdbcCommand cmd = new OdbcCommand(query, conn);
                cmd.Parameters.AddWithValue("?", nombreTabla);

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al verificar la tabla: " + ex.Message);
                return false;
            }
            finally
            {
                conexion.desconexion(conn);
            }
        }

        // Obtiene todas las columnas de la tabla
        private List<string> ObtenerColumnas(string nombreTabla)
        {
            List<string> columnas = new List<string>();
            OdbcConnection conn = conexion.conexion();

            try
            {
                conn.Open();
                string query = "SELECT column_name FROM information_schema.columns WHERE table_schema = DATABASE() AND table_name = ?";
                OdbcCommand cmd = new OdbcCommand(query, conn);
                cmd.Parameters.AddWithValue("?", nombreTabla);

                OdbcDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    columnas.Add(reader.GetString(0));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener columnas: " + ex.Message);
            }
            finally
            {
                conexion.desconexion(conn);
            }

            return columnas;
        }



        // METODO ASIGNAR ALIAS NUEVO
        public bool AsignarAlias(string tabla, string[] alias, Control contenedor, int startX, int startY)
        {
            if (!ExisteTabla(tabla))
            {
                MessageBox.Show($"❌ La tabla '{tabla}' no existe en la base de datos.");
                return false;
            }

            List<string> columnas = ObtenerColumnas(tabla);
            int spacingY = 30;
            int creados = 0;

            foreach (string campo in alias)
            {
                if (!columnas.Contains(campo))
                {
                    MessageBox.Show($"⚠️ La columna '{campo}' no existe en la tabla '{tabla}'.");
                    continue;
                }

                Label lbl = new Label
                {
                    Text = campo + ":",
                    AutoSize = true,
                    Location = new System.Drawing.Point(startX, startY + (creados * spacingY))
                };

                TextBox txt = new TextBox
                {
                    Name = "txt_" + campo,
                    Width = 150,
                    Location = new System.Drawing.Point(startX + 100, startY + (creados * spacingY))
                };

                contenedor.Controls.Add(lbl);
                contenedor.Controls.Add(txt);

                creados++;
            }

            return creados > 0;
        }


        //-----------------------------------------------------------------------------





        /*public void AsignarAlias(string[] alias, Control contenedor, int startX, int startY)
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

         }*/
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

        public void Insertar_Datos(Control contenedor, string[] alias)
        {
            string[] valores = new string[alias.Length - 1]; // crea el arreglo con tamaño necesario para evitar errores

            DAOGenerico dao = new DAOGenerico();
            try
            {
                for (int i = 2; i < alias.Length; i++)
                {
                    // Buscar el TextBox con nombre dinámico
                    TextBox txt = contenedor.Controls.OfType<TextBox>().FirstOrDefault(t => t.Name == "txt_" + alias[i]);

                    if (txt != null)
                    {
                        valores[i - 2] = txt.Text; // Guardar el texto en la posición correspondiente
                    }
                    else
                    {
                        valores[i - 2] = null; // Si no existe el textbox, poner null
                    }
                }

                MessageBox.Show("Valores: " + string.Join(", ", valores));

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

        //---------------------------------------------------------------------------------------------

        public void Eliminar_Datos(Control contenedor, string[] alias)
        {
            DAOGenerico dao = new DAOGenerico();

            try
            {
                TextBox txtPK = contenedor.Controls
                    .OfType<TextBox>()
                    .FirstOrDefault(t => t.Name == "txt_" + alias[0]);

                if (txtPK == null || string.IsNullOrWhiteSpace(txtPK.Text))
                {
                    MessageBox.Show("No se encontró el campo clave primaria o está vacío.");
                    return;
                }

                object pkValor = txtPK.Text;

                dao.EliminarDatos(alias, pkValor); // llamada directa al DAO
                MessageBox.Show("Registro eliminado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar datos: " + ex.Message);
            }
        }

    }
}
