using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using System.Drawing;
using Capa_Modelo_Navegador;

namespace Capa_Controlador_Navegador
{
    public class Cls_ControladorNavegador
    {
        Cls_SentenciasMYSQL sentencias = new Cls_SentenciasMYSQL();
        private Cls_DAOGenerico dao = new Cls_DAOGenerico();

        // ---------------------VALIDANDO ALIAS-----------------------------------------
        //===================== Nuevo Método Validar Columnas - 23/09/2025 =============================
        //===================== Kevin Natareno ============================================
        private bool ValidarColumnas(string tabla, string[] columnasEnviadas, out List<string> columnasBD)
        {
            columnasBD = dao.ObtenerColumnas(tabla);

            // Validar cantidad
            if (columnasEnviadas.Length != columnasBD.Count)
            {
                MessageBox.Show($" La cantidad de columnas no coincide con la base de datos.\n" +
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
                string msg = " Las siguientes columnas no existen en la tabla '" + tabla + "':\n" +
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
        //Modificación de metodo: Validación de tipo de campo para cada dato
        public bool AsignarAlias(string[] SAlias, Control contenedor, int startX, int startY, int maxPorFila = 3)
        {
            // Validar tabla
            if (!dao.ExisteTabla(SAlias[0]))
            {
                MessageBox.Show($" La tabla '{SAlias[0]}' no existe en la base de datos.");
                return false;
            }

            // Validar columnas
            if (!ValidarColumnas(SAlias[0], SAlias.Skip(1).ToArray(), out List<string> columnasBD))
                return false;


            // Validacion tipos de columna
            string SnombreTabla = SAlias[0];
            Dictionary<string, string> tiposColumnas;
            try
            {
                tiposColumnas = dao.ObtenerTiposDeColumnas(SnombreTabla);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

          

            // Configuración inicial
            int spacingX = 300; // espacio horizontal entre controles
            int spacingY = 40;  // espacio vertical entre filas
            int creados = 0;

            List<Label> labels = new List<Label>();
            List<ComboBox> combos = new List<ComboBox>();
            List<Control> controles = new List<Control>();


            int fila = 0;
            int columna = 0;

            foreach (var campo in SAlias.Skip(1))
            {
                int posX = startX + (columna * spacingX);
                int posY = startY + (fila * spacingY);

                // Label
                Label lbl = new Label
                {
                    Font = new Font("Rockwell", 10, FontStyle.Bold),
                    Text = campo + ":",
                    AutoSize = true,
                    Location = new Point(posX, posY)
                };

                Size textSize = TextRenderer.MeasureText(lbl.Text, lbl.Font);
                int controlX = lbl.Location.X + textSize.Width + 5;

                // Detectar tipo de dato
                string tipoDato = tiposColumnas.ContainsKey(campo) ? tiposColumnas[campo] : "varchar";
                Control controlGenerado;

                // Según el tipo de dato, crear DateTimePicker,checkbox o ComboBox
                if (tipoDato.Contains("date"))
                {
                    DateTimePicker dtp = new DateTimePicker
                    {
                        Name = "Dtp_" + campo,
                        Font = new Font("Rockwell", 10, FontStyle.Regular),
                        Width = 150,
                        Format = DateTimePickerFormat.Short,
                        Location = new Point(controlX, posY)
                    };
                    controlGenerado = dtp;
                }
                else if (tipoDato.Contains("bit") || tipoDato.Contains("tinyint"))
                {
                    CheckBox chk = new CheckBox
                    {
                        Name = "Chk_" + campo,
                        Font = new Font("Rockwell", 10, FontStyle.Regular),
                        Text = "Activo",
                        AutoSize = true,
                        Location = new Point(controlX, posY)
                    };
                    controlGenerado = chk;
                }
                else
                {
                    ComboBox cbo = new ComboBox
                    {
                        Name = "Cbo_" + campo,
                        Font = new Font("Rockwell", 10, FontStyle.Regular),
                        Width = 150,
                        Location = new Point(controlX, posY)
                    };

                    try
                    {
                        List<string> items = sentencias.ObtenerValoresColumna(SnombreTabla, campo);
                        cbo.Items.AddRange(items.ToArray());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al cargar {campo}: {ex.Message}", "Advertencia",
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    // Bloquear PK
                    if (creados == 0)
                    {
                        cbo.SelectedIndexChanged += (s, e) =>
                        {
                            if (cbo.SelectedIndex >= 0)
                                cbo.Enabled = false;
                        };
                    }

                    controlGenerado = cbo;
                }

                // Agregar controles a listas
                labels.Add(lbl);
                controles.Add(controlGenerado);
                creados++;

                // Ajustar posiciones
                columna++;
                spacingX = textSize.Width + controlGenerado.Width + 40;

                if (columna >= maxPorFila)
                {
                    columna = 0;
                    fila++;
                }
            }

            // Finalmente, agregar al formulario/contenedor
            foreach (var lbl in labels) contenedor.Controls.Add(lbl);
            foreach (var ctrl in controles) contenedor.Controls.Add(ctrl);

            return creados > 0;
        }


        private DataGridView dgv;

        public void AsignarDataGridView(DataGridView grid)
        {
            dgv = grid;
        }
        //================ Kevin Natareno ===================================
        //=============== Metodos de mover al inicio y mover al final========================

        public void MoverAlInicio()
        {
            if (dgv != null && dgv.Rows.Count > 0)
            {
                dgv.ClearSelection();
                dgv.Rows[0].Selected = true;
                dgv.CurrentCell = dgv.Rows[0].Cells[0];
            }
        }

        public void MoverAlFin() //Correcciones de funcionamiento - 23/09/2025
        {
            if (dgv == null || dgv.Rows.Count == 0) return;
            dgv.ClearSelection();
            int ultimaFila = dgv.Rows.Count - 1;
            if (dgv.AllowUserToAddRows)
                ultimaFila -= 1;
            if (ultimaFila < 0) return;  
            dgv.CurrentCell = dgv.Rows[ultimaFila].Cells[0];
            dgv.Rows[ultimaFila].Selected = true;
            dgv.FirstDisplayedScrollingRowIndex = ultimaFila;
        }
        //===============================================================================

        public void Insertar_Datos(Control contenedor, string[] SAlias)
        {
            object[] SValores = new object[SAlias.Length - 1];
            Cls_DAOGenerico dao = new Cls_DAOGenerico();

            try
            {
                for (int i = 1; i < SAlias.Length; i++)
                {
                    string alias = SAlias[i];
                    object valor = "";

                    // Buscar control con coincidencia por nombre
                    var txt = contenedor.Controls.OfType<TextBox>().FirstOrDefault(t => t.Name == "Txt_" + alias);
                    var cbo = contenedor.Controls.OfType<ComboBox>().FirstOrDefault(c => c.Name == "Cbo_" + alias);
                    var dtp = contenedor.Controls.OfType<DateTimePicker>().FirstOrDefault(d => d.Name == "Cmp_" + alias || d.Name == "Dtp_" + alias);
                    var chkCampo = contenedor.Controls.OfType<CheckBox>().FirstOrDefault(ch => ch.Name == "Chk_" + alias);


                    if (txt != null)
                    {
                        valor = txt.Text;
                    }
                    else if (cbo != null)
                    {
                        valor = cbo.Text;
                    }
                    else if (dtp != null)
                    {
                        valor = dtp.Value.ToString("yyyy-MM-dd"); // formato estándar SQL
                    }
                    else if (chkCampo != null)
                    {
                        valor = chkCampo.Checked;// Guardar como 1 o 0
                    }

                    if (valor is string s && string.IsNullOrWhiteSpace(s))
                    {
                        MessageBox.Show($"El campo '{alias}' no puede estar vacío.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    SValores[i - 1] = valor;
                }

                // Si pasa validación, insertar
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

        // ====================== Eliminar / Delete = Fernando Miranda = 20/09/2025 =======================
        public void Eliminar_Datos(Control contenedor, string[] SAlias)
        {
            Cls_DAOGenerico dao = new Cls_DAOGenerico();

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
                MessageBox.Show("Alias inválido: se espera [tabla, pk, campos...]", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string pkNombre = SAlias[1];
            ComboBox cboPK = contenedor.Controls.OfType<ComboBox>().FirstOrDefault(t => t.Name == "Cbo_" + pkNombre);

            if (cboPK == null || string.IsNullOrWhiteSpace(cboPK.Text))
            {
                MessageBox.Show("Seleccione un valor válido de la clave primaria.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            object pkValor = cboPK.Text;
            string[] campos = SAlias.Skip(2).ToArray();
            object[] SValores = new object[campos.Length];

            try
            {
                for (int i = 0; i < campos.Length; i++)
                {
                    string campo = campos[i];
                    object valor = "";

                    // Detectar tipo de control
                    var cboCampo = contenedor.Controls.OfType<ComboBox>().FirstOrDefault(c => c.Name == "Cbo_" + campo);
                    var txtCampo = contenedor.Controls.OfType<TextBox>().FirstOrDefault(t => t.Name == "Txt_" + campo);
                    var dtpCampo = contenedor.Controls.OfType<DateTimePicker>().FirstOrDefault(d => d.Name == "Cmp_" + campo || d.Name == "Dtp_" + campo);
                    var chkCampo = contenedor.Controls.OfType<CheckBox>().FirstOrDefault(ch => ch.Name == "Chk_" + campo);


                    if (txtCampo != null)
                    {
                        valor = txtCampo.Text;
                    }
                    else if (cboCampo != null)
                    {
                        valor = cboCampo.Text;
                    }
                    else if (dtpCampo != null)
                    {
                        valor = dtpCampo.Value.ToString("yyyy-MM-dd"); // formato estándar SQL
                    }
                    else if (chkCampo != null)
                    {
                        valor = chkCampo.Checked; // TRUE=1, FALSE=0
                    }

                    // Validar que no esté vacío
                    if (valor is string s && string.IsNullOrWhiteSpace(s))
                    {
                        MessageBox.Show($"El campo '{campo}' no puede estar vacío.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    SValores[i] = valor;
                }

                Cls_DAOGenerico dao = new Cls_DAOGenerico();
                dao.ActualizarDatos(SAlias, SValores, pkValor);

                MessageBox.Show("Registro actualizado correctamente.", "Actualización", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

       //======================= Pedro Ibañez ======================
        //Modificacion de metodo: Crea DataGridView y recibe parametros para no chocar con ComboBoxes
        public DataGridView CrearDataGridView()
        {
           // int PosYdgv = startY + 20; ver posiciones despues


            DataGridView dgv = new DataGridView();
            dgv.Name = "Dgv_Datos";
            dgv.ScrollBars = ScrollBars.None;
            dgv.BackgroundColor = Color.White;

            // Fuente de encabezados
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Rockwell", 10, FontStyle.Bold);

            // Fuente de celdas
            dgv.DefaultCellStyle.Font = new Font("Rockwell", 10, FontStyle.Regular);

            dgv.Location = new System.Drawing.Point(10, 250);
            dgv.Size = new System.Drawing.Size(1100, 200);
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.ReadOnly = true;

            // Asignar al atributo privado
            this.dgv = dgv;

            return dgv; 
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
        //======================= Habilitar y Deshabilitar todos los comboBoxes =======================
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
