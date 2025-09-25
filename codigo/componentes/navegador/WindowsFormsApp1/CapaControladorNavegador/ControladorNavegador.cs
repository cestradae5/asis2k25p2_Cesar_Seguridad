using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using Capa_Modelo_Navegador;

namespace Capa_Controlador_Navegador
{
    public class ControladorNavegador
    {
        SentenciasMYSQL sentencias = new SentenciasMYSQL();
        private DAOGenerico dao = new DAOGenerico();

        // ---------------------VALIDANDO ALIAS-----------------------------------------
        //===================== Nuevo Método Validar Columnas =============================
        //===================== Kevin Natareno ============================================
        private bool ValidarColumnas(string tabla, string[] columnasEnviadas, out List<string> columnasBD)
        {
            columnasBD = dao.ObtenerColumnas(tabla);

            // Validar cantidad
            if (columnasEnviadas.Length != columnasBD.Count)
            {
                MessageBox.Show($"⚠️ La cantidad de columnas no coincide con la base de datos.\n" +
                                $"Esperadas: {columnasBD.Count}, Enviadas: {columnasEnviadas.Length}");
                return false;
            }

            // Validar nombres
            var columnasFaltantes = new List<string>();
            foreach (var c in columnasEnviadas)
            {
                if (!columnasBD.Contains(c, StringComparer.OrdinalIgnoreCase))
                    columnasFaltantes.Add(c);
            }

            if (columnasFaltantes.Count > 0)
            {
                string msg = "⚠️ Las siguientes columnas no existen en la tabla '" + tabla + "':\n" +
                             string.Join(", ", columnasFaltantes);
                MessageBox.Show(msg);
                return false;
            }

            return true;
        }
        //=======================================================================================================


        // Asigna alias validando tabla y columnas
        // ======================= Pedro Ibañez =======================
        // Creacion de Metodo: Asignar Alias Original, generación de Textboxes antes de las modificaciones
        public bool AsignarAlias(string[] SAlias, Control contenedor, int startX, int startY) //modificacion de método, ahora es tipo bool - Kevin Natareno
        {
            // ================= Hacer las validaciones - Kevin Natareno ==================================
            // Validar que la tabla exista
            if (!dao.ExisteTabla(SAlias[0]))
            {
                MessageBox.Show($"❌ La tabla '{SAlias[0]}' no existe en la base de datos.");
                return false;
            }

            // Validar columnas
            if (!ValidarColumnas(SAlias[0], SAlias.Skip(1).ToArray(), out List<string> columnasBD))
                return false; 
            //==============================================================================================


            // Crear controles
            int spacingY = 30;
            int creados = 0;

            List<Label> labels = new List<Label>();
            List<ComboBox> combos = new List<ComboBox>();

            foreach (var campo in SAlias.Skip(1))
            {
                Label lbl = new Label
                {
                    Text = campo + ":",
                    AutoSize = true,
                    Location = new System.Drawing.Point(startX, startY + (creados * spacingY))
                };

                ComboBox cbo = new ComboBox
                {
                    Name = "Cbo_" + campo,
                    Width = 150,
                    Location = new System.Drawing.Point(startX + 100, startY + (creados * spacingY)),
                };

                List<string> items = sentencias.ObtenerValoresColumna(SAlias[0], campo);
                foreach (var item in items)
                    cbo.Items.Add(item);

                // Bloquear combobox de la PK
                if (creados == 0)
                {
                    cbo.SelectedIndexChanged += (s, e) =>
                    {
                        if (cbo.SelectedIndex >= 0)
                            cbo.Enabled = false;
                    };
                }

                labels.Add(lbl);
                combos.Add(cbo);
                creados++;
            }

            // Agregar controles al contenedor
            foreach (var lbl in labels) contenedor.Controls.Add(lbl);
            foreach (var cbo in combos) contenedor.Controls.Add(cbo);

            return creados > 0;
        }



        private DataGridView dgv;

        public void AsignarDataGridView(DataGridView grid)
        {
            dgv = grid;
        }
        //================Kevin Natareno===================================================
        //===============Botones de mover al inicio y mover al final========================
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
            if (dgv == null || dgv.Rows.Count == 0) return;

            dgv.ClearSelection();

            // Última fila real
            int ultimaFila = dgv.Rows.Count - 1;
            if (dgv.AllowUserToAddRows)
                ultimaFila -= 1;

            if (ultimaFila < 0) return;

            // Primero fijamos el CurrentCell en la primera columna visible
            dgv.CurrentCell = dgv.Rows[ultimaFila].Cells[0];

            // Ahora seleccionamos la fila
            dgv.Rows[ultimaFila].Selected = true;

            // Aseguramos que sea visible
            dgv.FirstDisplayedScrollingRowIndex = ultimaFila;
        }


        //===============================================================================

        public void Insertar_Datos(Control contenedor, string[] SAlias)
        {
            string[] SValores = new string[SAlias.Length - 1]; // crea el arreglo con tamaño necesario para evitar errores

            DAOGenerico dao = new DAOGenerico();
            try
            {
                for (int i = 1; i < SAlias.Length; i++)
                {
                    // Buscar el TextBox con nombre dinámico
                    ComboBox Cbo = contenedor.Controls.OfType<ComboBox>().FirstOrDefault(t => t.Name == "Cbo_" + SAlias[i]);

                    if (Cbo != null)
                    {
                        SValores[i - 1] = Cbo.Text; // Guardar el texto en la posición correspondiente
                    }
                    else
                    {
                        SValores[i - 1] = null; // Si no existe el textbox, poner null
                    }
                }

                MessageBox.Show("Valores: " + string.Join(", ", SValores));

                dao.InsertarDatos(SAlias, SValores);

                MessageBox.Show("Datos insertados correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar datos: " + ex.Message);
            }
        }



        public DataTable LlenarTabla(string tabla, string[] SAlias) 
        {
            return sentencias.LlenarTabla(tabla, SAlias);
        }

        //---------------------------------------------------------------------------------------------

        public void Eliminar_Datos(Control contenedor, string[] SAlias)
        {
            DAOGenerico dao = new DAOGenerico();

            try
            {
                ComboBox CboPK = contenedor.Controls
                    .OfType<ComboBox>()
                    .FirstOrDefault(t => t.Name == "Cbo_" + SAlias[1]); // Se colocó la posicion 1 del array, ya elimina registros

                if (CboPK == null || string.IsNullOrWhiteSpace(CboPK.Text))
                {
                    MessageBox.Show("No se encontró el campo clave primaria o está vacío.");
                    return;
                }

                object pkValor = CboPK.Text;

                dao.EliminarDatos(SAlias, pkValor); // llamada directa al DAO
                MessageBox.Show("Registro eliminado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar datos: " + ex.Message);
            }
        }

        // ======================= Modificar / Update = Stevens Cambranes = 20/09/2025 =======================
        // ======================= Actualizar en BD leyendo los ComboBox = 20/09/2025 =======================
        public void Actualizar_Datos(Control contenedor, string[] SAlias)
        {
            if (SAlias == null || SAlias.Length < 3)
            {
                MessageBox.Show("Alias inválido: se espera [tabla, pk, campos...]");
                return;
            }

            string pkNombre = SAlias[1];
            ComboBox cboPK = contenedor.Controls.OfType<ComboBox>().FirstOrDefault(t => t.Name == "Cbo_" + pkNombre);

            if (cboPK == null || string.IsNullOrWhiteSpace(cboPK.Text))
            {
                MessageBox.Show("Seleccione un valor válido de la clave primaria.");
                return;
            }

            object pkValor = cboPK.Text; // llega como texto; ODBC hará la conversión
            string[] campos = SAlias.Skip(2).ToArray();
            object[] SValores = new object[campos.Length];

            for (int i = 0; i < campos.Length; i++)
            {
                string campo = campos[i];
                ComboBox cboCampo = contenedor.Controls.OfType<ComboBox>()
                    .FirstOrDefault(t => t.Name == "Cbo_" + campo);

                SValores[i] = (cboCampo != null) ? (object)cboCampo.Text : null;
            }

            try
            {
                DAOGenerico dao = new DAOGenerico();
                dao.ActualizarDatos(SAlias, SValores, pkValor);
                MessageBox.Show("Registro actualizado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar: " + ex.Message);
            }
        }

        // ======================= Rellenar los ComboBox desde la fila seleccionada del DataGridView = Stevens Cambranes = 20/09/2025 =======================
        public void RellenarCombosDesdeFila(Control contenedor, string[] SAlias, DataGridViewRow fila)
        {
            if (fila == null || SAlias == null || SAlias.Length < 2) return;

            // Caso ideal: el DataSource es un DataTable (DataRowView)
            var drv = fila.DataBoundItem as DataRowView;
            if (drv != null)
            {
                DataTable table = drv.Row.Table;

                for (int i = 1; i < SAlias.Length; i++)
                {
                    string campo = SAlias[i];
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
            for (int i = 1; i < SAlias.Length; i++)
            {
                string campo = SAlias[i];
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

        // ======================= Refrescar las opciones de cada ComboBox con valores actuales de la BD = Stevens Cambranes = 20/09/2025 =======================
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

        // ======================= Limpiar todos los ComboBox generados = Stevens Cambranes = 20/09/2025 =======================
        public void LimpiarCombos(Control contenedor, string[] SAlias)
        {
            if (SAlias == null || SAlias.Length < 2) return;

            for (int i = 1; i < SAlias.Length; i++)
            {
                string campo = SAlias[i];
                var cbo = contenedor.Controls.OfType<ComboBox>()
                             .FirstOrDefault(c => c.Name == "Cbo_" + campo);

                if (cbo != null)
                {
                    cbo.SelectedIndex = -1; // quita selección
                    cbo.Text = string.Empty; // limpia el texto mostrado
                }
            }
        }
        //======================= Habilitar y Deshabilitar todos los comboBoxes=======================
        // ======================= Pedro Ibañez =======================
        // Creacion de Metodos: Habilitar y deshabilitar ComboBoxes
        public void ActivarTodosComboBoxes(Control contenedor)
        {
            foreach (var cbo in contenedor.Controls.OfType<ComboBox>())
            {
                cbo.Enabled = true;
            }
        }
        public void DesactivarTodosComboBoxes(Control contenedor)
        {
            foreach (var cbo in contenedor.Controls.OfType<ComboBox>())
            {
                cbo.Enabled = false;
            }
        }
        

    }
}
