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
        private DAOGenerico dao = new DAOGenerico();

        // ---------------------VALIDANDO ALIAS-----------------------------------------

        // Asigna alias validando tabla y columnas
        public bool AsignarAlias(string[] alias, Control contenedor, int startX, int startY)
        {
            if (!dao.ExisteTabla(alias[0]))
            {
                MessageBox.Show($"❌ La tabla '{alias[0]}' no existe en la base de datos.");
                return false;
            }

            List<string> columnas = dao.ObtenerColumnas(alias[0]);
            int spacingY = 30;
            int creados = 0;

            for (int i = 1; i < alias.Length; i++)
            {
                string campo = alias[i];

                if (!columnas.Contains(campo))
                {
                    MessageBox.Show($"⚠️ La columna '{campo}' no existe en la tabla '{alias[0]}'.");
                    return false;
                }

                Label lbl = new Label
                {
                    Text = campo + ":",
                    AutoSize = true,
                    Location = new System.Drawing.Point(startX, startY + (creados * spacingY))
                };

                ComboBox Cbo = new ComboBox
                {
                    Name = "Cbo_" + campo,
                    Width = 150,
                    Location = new System.Drawing.Point(startX + 100, startY + (creados * spacingY)),
                };

                List<string> items = sentencias.ObtenerValoresColumna(alias[0], campo); 
                foreach (var item in items)
                {
                    Cbo.Items.Add(item);
                }

                // bloquear combobox de la PK
                if (creados == 0)
                {
                    Cbo.SelectedIndexChanged += (s, e) =>
                    {
                        if (Cbo.SelectedIndex >= 0)
                        {
                            Cbo.Enabled = false;
                        }
                    };
                }

                contenedor.Controls.Add(Cbo);
                contenedor.Controls.Add(lbl);
                creados++;
            }

            return creados > 0;
        }


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
                for (int i = 1; i < alias.Length; i++)
                {
                    // Buscar el TextBox con nombre dinámico
                    ComboBox Cbo = contenedor.Controls.OfType<ComboBox>().FirstOrDefault(t => t.Name == "Cbo_" + alias[i]);

                    if (Cbo != null)
                    {
                        valores[i - 1] = Cbo.Text; // Guardar el texto en la posición correspondiente
                    }
                    else
                    {
                        valores[i - 1] = null; // Si no existe el textbox, poner null
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
                ComboBox CboPK = contenedor.Controls
                    .OfType<ComboBox>()
                    .FirstOrDefault(t => t.Name == "Cbo_" + alias[1]); // Se colocó la posicion 1 del array, ya elimina registros

                if (CboPK == null || string.IsNullOrWhiteSpace(CboPK.Text))
                {
                    MessageBox.Show("No se encontró el campo clave primaria o está vacío.");
                    return;
                }

                object pkValor = CboPK.Text;

                dao.EliminarDatos(alias, pkValor); // llamada directa al DAO
                MessageBox.Show("Registro eliminado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar datos: " + ex.Message);
            }
        }

        // ======================= Modificar / Update = Stevens Cambranes =======================
        // ======================= Actualizar en BD leyendo los ComboBox =======================
        public void Actualizar_Datos(Control contenedor, string[] alias)
        {
            if (alias == null || alias.Length < 3)
            {
                MessageBox.Show("Alias inválido: se espera [tabla, pk, campos...]");
                return;
            }

            string pkNombre = alias[1];
            ComboBox cboPK = contenedor.Controls.OfType<ComboBox>().FirstOrDefault(t => t.Name == "Cbo_" + pkNombre);

            if (cboPK == null || string.IsNullOrWhiteSpace(cboPK.Text))
            {
                MessageBox.Show("Seleccione un valor válido de la clave primaria.");
                return;
            }

            object pkValor = cboPK.Text; // llega como texto; ODBC hará la conversión
            string[] campos = alias.Skip(2).ToArray();
            object[] valores = new object[campos.Length];

            for (int i = 0; i < campos.Length; i++)
            {
                string campo = campos[i];
                ComboBox cboCampo = contenedor.Controls.OfType<ComboBox>()
                    .FirstOrDefault(t => t.Name == "Cbo_" + campo);

                valores[i] = (cboCampo != null) ? (object)cboCampo.Text : null;
            }

            try
            {
                DAOGenerico dao = new DAOGenerico();
                dao.ActualizarDatos(alias, valores, pkValor);
                MessageBox.Show("Registro actualizado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar: " + ex.Message);
            }
        }

        // ======================= Rellenar los ComboBox desde la fila seleccionada del DataGridView =======================
        public void RellenarCombosDesdeFila(Control contenedor, string[] alias, DataGridViewRow fila)
        {
            if (fila == null || alias == null || alias.Length < 2) return;

            // Caso ideal: el DataSource es un DataTable (DataRowView)
            var drv = fila.DataBoundItem as DataRowView;
            if (drv != null)
            {
                DataTable table = drv.Row.Table;

                for (int i = 1; i < alias.Length; i++)
                {
                    string campo = alias[i];
                    var cbo = contenedor.Controls.OfType<ComboBox>()
                                 .FirstOrDefault(c => c.Name == "Cbo_" + campo);
                    if (cbo == null) continue;

                    object valor = table.Columns.Contains(campo) ? drv[campo] : null;
                    cbo.Text = valor?.ToString() ?? string.Empty;
                }
                return; // listo en el caso DataRowView
            }

            // buscar columna en el grid por Name o DataPropertyName
            var grid = fila.DataGridView;
            for (int i = 1; i < alias.Length; i++)
            {
                string campo = alias[i];
                var cbo = contenedor.Controls.OfType<ComboBox>()
                             .FirstOrDefault(c => c.Name == "Cbo_" + campo);
                if (cbo == null) continue;

                var col = grid.Columns.Cast<DataGridViewColumn>()
                           .FirstOrDefault(c =>
                                string.Equals(c.Name, campo, StringComparison.OrdinalIgnoreCase) ||
                                string.Equals(c.DataPropertyName, campo, StringComparison.OrdinalIgnoreCase));
                if (col == null) { cbo.Text = string.Empty; continue; }

                var cell = fila.Cells[col.Index];
                cbo.Text = cell?.Value?.ToString() ?? string.Empty;
            }
        }

        // ======================= Refrescar las opciones de cada ComboBox con valores actuales de la BD =======================
        public void RefrescarCombos(Control contenedor, string tabla, string[] columnas)
        {
            foreach (var campo in columnas)
            {
                var cbo = contenedor.Controls.OfType<ComboBox>()
                             .FirstOrDefault(c => c.Name == "Cbo_" + campo);
                if (cbo == null) continue;

                // Guardar el valor que se ve actualmente para conservarlo
                string valorActual = cbo.Text;

                List<string> items;
                try
                {
                    items = sentencias.ObtenerValoresColumna(tabla, campo);
                }
                catch
                {
                    items = new List<string>();
                }
                cbo.BeginUpdate();
                try
                {
                    cbo.Items.Clear();
                    foreach (var it in items) cbo.Items.Add(it);

                    // Si el valor anterior sigue existiendo, re-seleccionarlo
                    if (!string.IsNullOrEmpty(valorActual) && cbo.Items.Contains(valorActual))
                    {
                        cbo.SelectedItem = valorActual;
                    }
                    else
                    {
                        // Si ya no está, deja el texto tal cual (útil para PK o valores recién cambiados)
                        cbo.Text = valorActual ?? string.Empty;
                    }
                }
                finally
                {
                    cbo.EndUpdate();
                }
            }
        }

        // ======================= Limpiar todos los ComboBox generados =======================
        public void LimpiarCombos(Control contenedor, string[] alias)
        {
            if (alias == null || alias.Length < 2) return;

            for (int i = 1; i < alias.Length; i++)
            {
                string campo = alias[i];
                var cbo = contenedor.Controls.OfType<ComboBox>()
                             .FirstOrDefault(c => c.Name == "Cbo_" + campo);

                if (cbo != null)
                {
                    cbo.SelectedIndex = -1; // quita selección
                    cbo.Text = string.Empty; // limpia el texto mostrado
                }
            }
        }

        // ======================= Diccionario de Datos =======================

    }
}
