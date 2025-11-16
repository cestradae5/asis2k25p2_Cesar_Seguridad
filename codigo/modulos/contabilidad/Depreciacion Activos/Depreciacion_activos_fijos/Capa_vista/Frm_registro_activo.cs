using System;
using System.Windows.Forms;
using System.Data;
using Capa_controlador;
using System.Drawing;

namespace Capa_vista
{
    public partial class Frm_registro_activo : Form
    {
        private Cls_Depreciacion_Controlador controlador = new Cls_Depreciacion_Controlador();
        private DataTable dtPolizasDepreciacion = new DataTable();
        private Cls_envio_poliza_depreciacion polizaService = new Cls_envio_poliza_depreciacion();
        public int IdActivoSeleccionado { get; private set; }
        public string NombreActivoSeleccionado { get; private set; }


        public Frm_registro_activo()
        {
            InitializeComponent();
            CargarGruposActivos();
            CargarCuentasContables();
            Rdb_activo.Checked = true;
            Txt_fecha_adquisicion.Text = DateTime.Now.ToString("yyyy-MM-dd");
            Cbo_seleccion_activo.SelectedIndexChanged += Cbo_seleccion_activo_SelectedIndexChanged;
            ConfigurarTabDepreciacion();
            ConfigurarGridDepreciacion();
            ConfigurarTabPolizas();
            Dtp_fecha_poliza.Value = DateTime.Now;
            Txt_activo_fijo.KeyPress += Txt_activo_fijo_KeyPress;
            Txt_descripcion.KeyPress += Txt_descripcion_KeyPress;
            Txt_vida_util.KeyPress += Txt_vida_util_KeyPress;
            Txt_vida_util.Leave += Txt_vida_util_Leave;
            Btn_limpiar.Click += Btn_limpiar_Click_1;
            Txt_costo_adquisicion.Leave += Txt_costo_adquisicion_Leave;
            Txt_costo_adquisicion.TextChanged += Txt_costo_adquisicion_TextChanged;
        }
        private void Txt_costo_adquisicion_Leave(object sender, EventArgs e)
        {
            CalcularCostoSinIVA();
        }

        private void Txt_costo_adquisicion_TextChanged(object sender, EventArgs e)
        {
            // Mostrar mensaje informativo cuando el usuario esté escribiendo
            if (Txt_costo_adquisicion.Focused && !string.IsNullOrEmpty(Txt_costo_adquisicion.Text) && Txt_costo_adquisicion.Text != "0.00")
            {
                MostrarMensajeIVA();
            }
        }

        private void CalcularCostoSinIVA()
        {
            try
            {
                if (string.IsNullOrEmpty(Txt_costo_adquisicion.Text.Trim()) ||
                    Txt_costo_adquisicion.Text == "0.00" ||
                    Txt_costo_adquisicion.Text == "0")
                {
                    return;
                }

                // Convertir el valor ingresado a decimal
                if (decimal.TryParse(Txt_costo_adquisicion.Text, out decimal costoConIVA))
                {
                    if (costoConIVA > 0)
                    {
                        // Calcular el costo sin IVA (dividir entre 1.12)
                        decimal costoSinIVA = costoConIVA / 1.12m;

                        // Mostrar el cálculo al usuario
                        string mensaje = $"Costo con IVA: {costoConIVA:C2}\n" +
                                       $"IVA (12%): {(costoConIVA - costoSinIVA):C2}\n" +
                                       $"Costo sin IVA a guardar: {costoSinIVA:C2}";

                        MessageBox.Show(mensaje, "Cálculo Automático de IVA",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Actualizar el texto con el valor sin IVA (opcional, puedes comentar esta línea si no quieres modificar lo que ve el usuario)
                        // Txt_costo_adquisicion.Text = costoSinIVA.ToString("F2");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al calcular IVA: {ex.Message}");
            }
        }

        private void MostrarMensajeIVA()
        {
            Txt_costo_adquisicion.BackColor = Color.LightYellow;
            Timer timer = new Timer();
            timer.Interval = 2000; // 2 segundos
            timer.Tick += (s, e) =>
            {
                Txt_costo_adquisicion.BackColor = SystemColors.ActiveBorder;
                timer.Stop();
                timer.Dispose();
            };
            timer.Start();
        }


        private void ConfigurarGridDepreciacion()
        {
            try
            {
                Dgv_depreciacion_lineal.Columns.Clear();

                // Agregar columnas si no existen
                if (Dgv_depreciacion_lineal.Columns.Count == 0)
                {
                    Dgv_depreciacion_lineal.Columns.Add("Año", "Año");
                    Dgv_depreciacion_lineal.Columns.Add("ValorEnLibros", "Valor en Libros");
                    Dgv_depreciacion_lineal.Columns.Add("DepreciacionAnual", "Depreciación Anual");
                    Dgv_depreciacion_lineal.Columns.Add("DepreciacionAcumulada", "Depreciación Acumulada");

                    // Configurar anchos de columnas
                    Dgv_depreciacion_lineal.Columns["Año"].Width = 80;
                    Dgv_depreciacion_lineal.Columns["ValorEnLibros"].Width = 150;
                    Dgv_depreciacion_lineal.Columns["DepreciacionAnual"].Width = 150;
                    Dgv_depreciacion_lineal.Columns["DepreciacionAcumulada"].Width = 150;
                }

                Console.WriteLine("Grid de depreciación configurado correctamente");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error configurando grid: {ex.Message}");
            }
        }

        private void ConfigurarTabDepreciacion()
        {
            // Cargar activos en el ComboBox
            CargarActivosEnComboBox();

            // Configurar el grid de depreciación
            ConfigurarGridDepreciacion();

            // Configurar valores iniciales de labels
            Lbl_activo_gpb.Text = "---";
            Lbl_grupo_gpb.Text = "---";
            Lbl_adquisicion.Text = "---";
            Lbl_resultado.Text = "---";

            Tbc_calculo_activo_fijo.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
        }

        private void VerDatosActivoEnBD(int idActivo)
        {
            try
            {
                Console.WriteLine($"=== VERIFICANDO DATOS EN BD PARA ACTIVO {idActivo} ===");

                string[] datos = controlador.ObtenerDatosActivo(idActivo);
                if (datos != null && datos.Length >= 5)
                {
                    Console.WriteLine($"Nombre: {datos[0]}");
                    Console.WriteLine($"Grupo: {datos[1]}");
                    Console.WriteLine($"Costo: {datos[2]}");
                    Console.WriteLine($"Valor Residual: {datos[3]}");
                    Console.WriteLine($"Vida Útil: {datos[4]} años");

                    // Convertir a valores numéricos para verificación
                    if (decimal.TryParse(datos[2].Replace("Q", "").Replace("$", "").Replace(",", ""), out decimal costo) &&
                        decimal.TryParse(datos[3].Replace("Q", "").Replace("$", "").Replace(",", ""), out decimal residual) &&
                        int.TryParse(datos[4], out int vidaUtil))
                    {
                        Console.WriteLine($"Valores numéricos - Costo: {costo}, Residual: {residual}, Vida Útil: {vidaUtil}");

                        // Verificar que los datos sean válidos para el cálculo
                        if (costo <= 0)
                            Console.WriteLine("ERROR: El costo debe ser mayor a 0");
                        if (residual < 0)
                            Console.WriteLine("ERROR: El valor residual no puede ser negativo");
                        if (residual >= costo)
                            Console.WriteLine("ERROR: El valor residual no puede ser mayor o igual al costo");
                        if (vidaUtil <= 0)
                            Console.WriteLine("ERROR: La vida útil debe ser mayor a 0");
                    }
                }
                else
                {
                    Console.WriteLine("No se pudieron obtener los datos del activo");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al ver datos: {ex.Message}");
            }
        }

        private void CargarActivosEnComboBox()
        {
            try
            {
                DataTable dtActivos = controlador.ObtenerActivosParaCombo();

                Console.WriteLine($"Número de activos cargados: {dtActivos.Rows.Count}");

                if (dtActivos.Rows.Count > 0)
                {
                    Cbo_seleccion_activo.DataSource = dtActivos;
                    Cbo_seleccion_activo.DisplayMember = "Cmp_Nombre_Activo";
                    Cbo_seleccion_activo.ValueMember = "Pk_Activo_ID";

                    Console.WriteLine($"Primer activo: ID={dtActivos.Rows[0]["Pk_Activo_ID"]}, Nombre={dtActivos.Rows[0]["Cmp_Nombre_Activo"]}");
                }
                else
                {
                    MessageBox.Show("No hay activos registrados en la base de datos.", "Información",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar activos: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Error detallado: {ex.ToString()}");
            }
        }

        private void Cbo_seleccion_activo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine($"=== SelectedIndexChanged ===");
            Console.WriteLine($"SelectedValue: {Cbo_seleccion_activo.SelectedValue}");
            Console.WriteLine($"SelectedValue tipo: {Cbo_seleccion_activo.SelectedValue?.GetType()}");
            Console.WriteLine($"SelectedIndex: {Cbo_seleccion_activo.SelectedIndex}");

            int idActivo = 0;

            // Manejar diferentes tipos de SelectedValue
            if (Cbo_seleccion_activo.SelectedValue != null)
            {
                if (Cbo_seleccion_activo.SelectedValue is DataRowView rowView)
                {
                    // Cuando SelectedValue es DataRowView
                    idActivo = Convert.ToInt32(rowView["Pk_Activo_ID"]);
                    Console.WriteLine($"Convertido desde DataRowView: {idActivo}");
                }
                else if (Cbo_seleccion_activo.SelectedValue is int)
                {
                    // Cuando SelectedValue es int directamente
                    idActivo = (int)Cbo_seleccion_activo.SelectedValue;
                    Console.WriteLine($"Convertido desde int: {idActivo}");
                }
                else
                {
                    // Intentar conversión desde string u otros tipos
                    if (int.TryParse(Cbo_seleccion_activo.SelectedValue.ToString(), out int tempId))
                    {
                        idActivo = tempId;
                        Console.WriteLine($"Convertido desde string: {idActivo}");
                    }
                    else
                    {
                        Console.WriteLine("No se pudo convertir SelectedValue a int");
                    }
                }
            }

            if (idActivo > 0)
            {
                Console.WriteLine($"ID Activo seleccionado: {idActivo}");
                MostrarDatosActivo(idActivo);
                CargarDepreciacionesExistentes(idActivo);
            }
            else
            {
                Console.WriteLine("ID Activo no válido (probablemente el elemento de selección)");
                LimpiarCamposDepreciacion();
            }
        }

        private void MostrarDatosActivo(int idActivo)
        {
            try
            {
                Console.WriteLine($"Buscando datos para activo ID: {idActivo}");

                string[] datos = controlador.ObtenerDatosActivo(idActivo);

                Console.WriteLine($"Datos recibidos: {datos != null}, Cantidad: {datos?.Length}");

                if (datos != null && datos.Length >= 3)
                {
                    // Mostrar en los GroupBox
                    Lbl_activo_gpb.Text = datos[0]; // Nombre del Activo
                    Lbl_grupo_gpb.Text = datos[1];  // Grupo
                    Lbl_adquisicion.Text = datos[2]; // Costo de Adquisición

                    Console.WriteLine($"Datos cargados en labels:");
                    Console.WriteLine($"  Activo: {datos[0]}");
                    Console.WriteLine($"  Grupo: {datos[1]}");
                    Console.WriteLine($"  Costo: {datos[2]}");

                    // Forzar actualización de la interfaz
                    Lbl_activo_gpb.Refresh();
                    Lbl_grupo_gpb.Refresh();
                    Lbl_adquisicion.Refresh();
                }
                else
                {
                    Console.WriteLine("Datos insuficientes o nulos");
                    LimpiarCamposDepreciacion();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en MostrarDatosActivo: {ex.Message}");
                MessageBox.Show($"Error al cargar datos del activo: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                LimpiarCamposDepreciacion();
            }
        }

        private void CargarDepreciacionesExistentes(int idActivo)
        {
            try
            {
                Console.WriteLine($"Cargando depreciaciones existentes para activo {idActivo}");

                DataTable dtDepreciaciones = controlador.ObtenerDepreciacionesExistentes(idActivo);

                Console.WriteLine($"Depreciaciones encontradas: {dtDepreciaciones.Rows.Count}");

                if (dtDepreciaciones.Rows.Count > 0)
                {
                    MostrarDepreciacionesEnGrid(dtDepreciaciones);
                    decimal depreciacionTotal = controlador.ObtenerDepreciacionTotal(idActivo);
                    Lbl_resultado.Text = depreciacionTotal.ToString("C2");

                    Console.WriteLine($"Depreciación total cargada: {depreciacionTotal:C2}");
                }
                else
                {
                    LimpiarGridDepreciacion();
                    Lbl_resultado.Text = "0.00";
                    Console.WriteLine("No hay depreciaciones guardadas para este activo");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar depreciaciones existentes: {ex.Message}");
                LimpiarGridDepreciacion();
                Lbl_resultado.Text = "0.00";
            }
        }

        private void MostrarDepreciacionesEnGrid(DataTable dtDepreciaciones)
        {
            try
            {
                Console.WriteLine($"Mostrando {dtDepreciaciones.Rows.Count} filas en el grid");

                Dgv_depreciacion_lineal.Rows.Clear();

                if (dtDepreciaciones.Rows.Count == 0)
                {
                    Console.WriteLine("No hay datos para mostrar en el grid");
                    return;
                }

                foreach (DataRow row in dtDepreciaciones.Rows)
                {
                    int index = Dgv_depreciacion_lineal.Rows.Add();
                    Dgv_depreciacion_lineal.Rows[index].Cells["Año"].Value = row["Año"];
                    Dgv_depreciacion_lineal.Rows[index].Cells["ValorEnLibros"].Value = row["ValorEnLibros"];
                    Dgv_depreciacion_lineal.Rows[index].Cells["DepreciacionAnual"].Value = row["DepreciacionAnual"];
                    Dgv_depreciacion_lineal.Rows[index].Cells["DepreciacionAcumulada"].Value = row["DepreciacionAcumulada"];
                }

                Console.WriteLine("Grid actualizado correctamente");

                // Forzar actualización visual
                Dgv_depreciacion_lineal.Refresh();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al mostrar datos en grid: {ex.Message}");
                throw;
            }
        }

        private void LimpiarGridDepreciacion()
        {
            Dgv_depreciacion_lineal.Rows.Clear();
        }

        private void LimpiarCamposDepreciacion()
        {
            Lbl_activo_gpb.Text = "---";
            Lbl_grupo_gpb.Text = "---";
            Lbl_adquisicion.Text = "---";
            LimpiarGridDepreciacion();
            Lbl_resultado.Text = "---";
        }

        private void Btn_calcular_activo_fijo_Click(object sender, EventArgs e)
        {
            int idActivo = 0;

            // Usar la misma lógica de conversión que en SelectedIndexChanged
            if (Cbo_seleccion_activo.SelectedValue != null)
            {
                if (Cbo_seleccion_activo.SelectedValue is DataRowView rowView)
                {
                    idActivo = Convert.ToInt32(rowView["Pk_Activo_ID"]);
                }
                else if (Cbo_seleccion_activo.SelectedValue is int)
                {
                    idActivo = (int)Cbo_seleccion_activo.SelectedValue;
                }
                else if (int.TryParse(Cbo_seleccion_activo.SelectedValue.ToString(), out int tempId))
                {
                    idActivo = tempId;
                }
            }

            if (idActivo == 0)
            {
                MessageBox.Show("Por favor seleccione un activo primero.", "Advertencia",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Console.WriteLine($"=== INICIANDO CÁLCULO DESDE INTERFAZ ===");
                Console.WriteLine($"Calculando depreciación para activo ID: {idActivo}");

                // Verificar datos del activo antes de calcular
                VerDatosActivoEnBD(idActivo);

                // Calcular depreciación
                DataTable dtDepreciaciones = controlador.CalcularDepreciacionLineal(idActivo);

                Console.WriteLine($"Cálculo completado. Filas generadas: {dtDepreciaciones.Rows.Count}");

                if (dtDepreciaciones.Rows.Count == 0)
                {
                    MessageBox.Show("No se generaron datos de depreciación. Verifique los datos del activo.", "Información",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Mostrar en el grid
                MostrarDepreciacionesEnGrid(dtDepreciaciones);

                // Calcular y mostrar depreciación total
                decimal depreciacionTotal = 0;
                if (dtDepreciaciones.Rows.Count > 0)
                {
                    // La depreciación total es la depreciación acumulada del último año
                    string ultimaDepreciacion = dtDepreciaciones.Rows[dtDepreciaciones.Rows.Count - 1]["DepreciacionAcumulada"].ToString();

                    // Limpiar el formato de moneda para convertir a decimal
                    string valorLimpio = ultimaDepreciacion.Replace("Q", "").Replace("$", "").Replace(",", "").Trim();
                    if (decimal.TryParse(valorLimpio, out decimal total))
                    {
                        depreciacionTotal = total;
                    }

                    Lbl_resultado.Text = depreciacionTotal.ToString("C2");

                    Console.WriteLine($"Depreciación total: {depreciacionTotal:C2}");
                }

                MessageBox.Show($"Cálculo de depreciación completado.\n\n" +
                               $"Activo: {Cbo_seleccion_activo.Text}\n" +
                               $"Depreciación total: {depreciacionTotal:C2}\n" +
                               $"Período: {dtDepreciaciones.Rows.Count} años",
                               "Cálculo Completado",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR en cálculo desde interfaz: {ex.Message}");
                MessageBox.Show($"Error al calcular depreciación: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_guardar_calculo_Click(object sender, EventArgs e)
        {
            int idActivo = 0;

            // Usar la misma lógica de conversión que en los otros métodos
            if (Cbo_seleccion_activo.SelectedValue != null)
            {
                if (Cbo_seleccion_activo.SelectedValue is DataRowView rowView)
                {
                    idActivo = Convert.ToInt32(rowView["Pk_Activo_ID"]);
                }
                else if (Cbo_seleccion_activo.SelectedValue is int)
                {
                    idActivo = (int)Cbo_seleccion_activo.SelectedValue;
                }
                else if (int.TryParse(Cbo_seleccion_activo.SelectedValue.ToString(), out int tempId))
                {
                    idActivo = tempId;
                }
            }

            if (idActivo == 0)
            {
                MessageBox.Show("No hay activo seleccionado.", "Advertencia",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Console.WriteLine($"=== INICIANDO GUARDADO DESDE INTERFAZ ===");

                // Verificar que hay datos calculados
                if (Dgv_depreciacion_lineal.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos de depreciación calculados. Por favor, calcule primero.", "Advertencia",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Preguntar confirmación
                DialogResult resultado = MessageBox.Show(
                    $"¿Está seguro de guardar el cálculo de depreciación para '{Cbo_seleccion_activo.Text}'?\n\n" +
                    "Esto reemplazará cualquier cálculo anterior para este activo.",
                    "Confirmar Guardado",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resultado != DialogResult.Yes)
                {
                    Console.WriteLine("Guardado cancelado por el usuario");
                    return;
                }

                // Guardar el cálculo
                bool exito = controlador.GuardarCalculoDepreciacion(idActivo);

                if (exito)
                {
                    MessageBox.Show("Cálculo de depreciación guardado correctamente en la base de datos.", "Éxito",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Recargar las depreciaciones existentes para mostrar los datos guardados
                    CargarDepreciacionesExistentes(idActivo);

                    Console.WriteLine("Datos recargados después del guardado");
                }
                else
                {
                    MessageBox.Show("No se pudo guardar el cálculo.", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR al guardar desde interfaz: {ex.Message}");
                MessageBox.Show($"Error al guardar cálculo: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_limpial_calculo_Click(object sender, EventArgs e)
        {
            LimpiarCamposDepreciacion();
            Cbo_seleccion_activo.SelectedIndex = 0;
        }

        // MÉTODOS ORIGINALES DE LA PESTAÑA DE REGISTRO
        private void CargarGruposActivos()
        {
            try
            {
                string[] grupos = {
                    "Mobiliario", "Equipo de Cómputo", "Vehículos", "Maquinaria",
                    "Equipo de Comunicación", "Herramientas", "Instalaciones",
                    "Software", "Equipo Médico", "Otros"
                };

                Cbo_grupo.Items.Clear();
                Cbo_grupo.Items.AddRange(grupos);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar grupos: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarCuentasContables()
        {
            try
            {
                // Limpiar combobox
                Cbo_cuenta_activo.Items.Clear();
                Cbo_cuenta_depreciacion.Items.Clear();
                Cbo_gastos_depreciacoin.Items.Clear();

                // Obtener cuentas a través del controlador
                var cuentasActivo = controlador.ObtenerCuentasActivo();
                var cuentasDepreciacion = controlador.ObtenerCuentasDepreciacion();
                var cuentasGasto = controlador.ObtenerCuentasGastoDepreciacion();

                // Cargar cuentas
                Cbo_cuenta_activo.Items.AddRange(cuentasActivo.ToArray());
                Cbo_cuenta_depreciacion.Items.AddRange(cuentasDepreciacion.ToArray());
                Cbo_gastos_depreciacoin.Items.AddRange(cuentasGasto.ToArray());

                // Seleccionar primeras opciones
                if (Cbo_cuenta_activo.Items.Count > 0) Cbo_cuenta_activo.SelectedIndex = 0;
                if (Cbo_cuenta_depreciacion.Items.Count > 0) Cbo_cuenta_depreciacion.SelectedIndex = 0;
                if (Cbo_gastos_depreciacoin.Items.Count > 0) Cbo_gastos_depreciacoin.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar cuentas contables: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarCampos()
        {
            // Validar nombre del activo
            if (string.IsNullOrEmpty(Txt_activo_fijo.Text.Trim()))
            {
                MessageBox.Show("El nombre del activo fijo es requerido", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                Txt_activo_fijo.Focus();
                return false;
            }

            // Validar grupo
            if (Cbo_grupo.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un grupo", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cbo_grupo.Focus();
                return false;
            }

            // Validar fecha
            if (string.IsNullOrEmpty(Txt_fecha_adquisicion.Text.Trim()))
            {
                MessageBox.Show("La fecha de adquisición es requerida", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                Txt_fecha_adquisicion.Focus();
                return false;
            }

            // Validar costo de adquisición
            if (string.IsNullOrEmpty(Txt_costo_adquisicion.Text.Trim()) ||
                Txt_costo_adquisicion.Text == "0.00" ||
                Txt_costo_adquisicion.Text == "0")
            {
                MessageBox.Show("El costo de adquisición es requerido y debe ser mayor a cero", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                Txt_costo_adquisicion.Focus();
                return false;
            }

            // Validar valor residual
            if (string.IsNullOrEmpty(Txt_adquisicion.Text.Trim()))
            {
                MessageBox.Show("El valor residual es requerido", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                Txt_adquisicion.Focus();
                return false;
            }

            // Validar vida útil
            if (string.IsNullOrEmpty(Txt_vida_util.Text.Trim()))
            {
                MessageBox.Show("La vida útil es requerida", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                Txt_vida_util.Focus();
                return false;
            }

            // Validar que sea un número entero mayor a 0
            if (!int.TryParse(Txt_vida_util.Text, out int vidaUtil) || vidaUtil <= 0)
            {
                MessageBox.Show("La vida útil debe ser un número entero mayor a 0", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                Txt_vida_util.Focus();
                Txt_vida_util.SelectAll();
                return false;
            }

            // Validar cuentas contables
            if (Cbo_cuenta_activo.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar una cuenta de activo", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cbo_cuenta_activo.Focus();
                return false;
            }

            if (Cbo_cuenta_depreciacion.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar una cuenta de depreciación", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cbo_cuenta_depreciacion.Focus();
                return false;
            }

            if (Cbo_gastos_depreciacoin.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar una cuenta de gasto", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cbo_gastos_depreciacoin.Focus();
                return false;
            }

            return true;
        }

        private void LimpiarCampos()
        {
            Txt_activo_fijo.Clear();
            Txt_descripcion.Clear();
            Txt_costo_adquisicion.Text = "0.00";
            Txt_adquisicion.Text = "0.00";
            Txt_vida_util.Clear();
            Cbo_grupo.SelectedIndex = -1;

            // Mantener las selecciones de cuentas (ya que vienen de BD)
            if (Cbo_cuenta_activo.Items.Count > 0) Cbo_cuenta_activo.SelectedIndex = 0;
            if (Cbo_cuenta_depreciacion.Items.Count > 0) Cbo_cuenta_depreciacion.SelectedIndex = 0;
            if (Cbo_gastos_depreciacoin.Items.Count > 0) Cbo_gastos_depreciacoin.SelectedIndex = 0;

            Txt_fecha_adquisicion.Text = DateTime.Now.ToString("yyyy-MM-dd");
            Rdb_activo.Checked = true;
            Txt_activo_fijo.Focus();
        }

        private void Btn_limpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        // VERSIÓN SIMPLIFICADA PARA INGRESO DE MONTOS
        private void Txt_costo_adquisicion_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números, punto decimal y teclas de control
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
                return;
            }

            // Validar que solo haya un punto decimal
            if (e.KeyChar == '.' && ((TextBox)sender).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void Txt_adquisicion_KeyPress(object sender, KeyPressEventArgs e)
        {
            Txt_costo_adquisicion_KeyPress(sender, e);
        }

        private void Txt_vida_util_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir teclas de control (backspace, delete, etc.)
            if (char.IsControl(e.KeyChar))
            {
                return;
            }

            // Solo permitir dígitos (números enteros)
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten números enteros en la vida útil.", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void Txt_vida_util_Leave(object sender, EventArgs e)
        {
            // Validar que no esté vacío y sea un número válido
            if (string.IsNullOrEmpty(Txt_vida_util.Text.Trim()))
            {
                MessageBox.Show("La vida útil es requerida.", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Txt_vida_util.Focus();
                return;
            }

            // Validar que sea un número mayor a 0
            if (int.TryParse(Txt_vida_util.Text, out int vidaUtil))
            {
                if (vidaUtil <= 0)
                {
                    MessageBox.Show("La vida útil debe ser mayor a 0.", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Txt_vida_util.Focus();
                    Txt_vida_util.SelectAll();
                }
            }
            else
            {
                MessageBox.Show("La vida útil debe ser un número entero válido.", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Txt_vida_util.Focus();
                Txt_vida_util.SelectAll();
            }
        }

        private void Frm_registro_activo_Load(object sender, EventArgs e)
        {
            Txt_activo_fijo.Focus();
            tabPage1.Text = "Datos del Activo";
            tabPage2.Text = "Calcular Depreciacion";
            tabPage3.Text = "Envio poliza";
        }

        private void Btn_guardar_Click_1(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            // Extraer códigos de cuenta
            string cuentaActivo = "";
            string cuentaDepreciacion = "";
            string cuentaGasto = "";

            try
            {
                // Para cuenta activo
                if (Cbo_cuenta_activo.SelectedItem != null)
                {
                    string cuentaCompleta = Cbo_cuenta_activo.SelectedItem.ToString();
                    string[] partes = cuentaCompleta.Split('-');
                    cuentaActivo = partes.Length > 0 ? partes[0].Trim() : cuentaCompleta.Trim();
                }

                // Para cuenta depreciación
                if (Cbo_cuenta_depreciacion.SelectedItem != null)
                {
                    string cuentaCompleta = Cbo_cuenta_depreciacion.SelectedItem.ToString();
                    string[] partes = cuentaCompleta.Split('-');
                    cuentaDepreciacion = partes.Length > 0 ? partes[0].Trim() : cuentaCompleta.Trim();
                }

                // Para cuenta gasto
                if (Cbo_gastos_depreciacoin.SelectedItem != null)
                {
                    string cuentaCompleta = Cbo_gastos_depreciacoin.SelectedItem.ToString();
                    string[] partes = cuentaCompleta.Split('-');
                    cuentaGasto = partes.Length > 0 ? partes[0].Trim() : cuentaCompleta.Trim();
                }

                // Validar que tenemos todas las cuentas
                if (string.IsNullOrEmpty(cuentaActivo) || string.IsNullOrEmpty(cuentaDepreciacion) || string.IsNullOrEmpty(cuentaGasto))
                {
                    MessageBox.Show("Error: No se pudieron extraer los códigos de cuenta contable", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar cuentas contables: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime fecha;
            try
            {
                fecha = DateTime.ParseExact(Txt_fecha_adquisicion.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            }
            catch (FormatException)
            {
                MessageBox.Show("Formato de fecha inválido. Use el formato AAAA-MM-DD.", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                Txt_fecha_adquisicion.Focus();
                return;
            }

            // Convertir valores a decimal - CON CÁLCULO DE IVA
            decimal costoAdquisicion, valorResidual;
            try
            {
                // CALCULAR COSTO SIN IVA AUTOMÁTICAMENTE
                decimal costoConIVA = Convert.ToDecimal(Txt_costo_adquisicion.Text);
                costoAdquisicion = costoConIVA / 1.12m; // Quitar el 12% de IVA

                valorResidual = Convert.ToDecimal(Txt_adquisicion.Text);

                // Validaciones adicionales
                if (costoAdquisicion <= 0)
                {
                    MessageBox.Show("El costo de adquisición debe ser mayor a cero.", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Txt_costo_adquisicion.Focus();
                    return;
                }

                if (valorResidual < 0)
                {
                    MessageBox.Show("El valor residual no puede ser negativo.", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Txt_adquisicion.Focus();
                    return;
                }

                if (valorResidual >= costoAdquisicion)
                {
                    MessageBox.Show("El valor residual no puede ser mayor o igual al costo de adquisición.", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Txt_adquisicion.Focus();
                    return;
                }

                if (!int.TryParse(Txt_vida_util.Text, out int vidaUtil) || vidaUtil <= 0)
                {
                    MessageBox.Show("La vida útil debe ser un número entero mayor a 0.", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Txt_vida_util.Focus();
                    Txt_vida_util.SelectAll();
                    return;
                }

                // Mostrar confirmación del cálculo del IVA
                decimal ivaCalculado = costoConIVA - costoAdquisicion;
                string mensajeConfirmacion = $"Resumen del cálculo:\n\n" +
                                           $"Costo ingresado (con IVA): {costoConIVA:C2}\n" +
                                           $"IVA quitado (12%): {ivaCalculado:C2}\n" +
                                           $"Costo a guardar (sin IVA): {costoAdquisicion:C2}\n\n" +
                                           $"¿Desea continuar con el guardado?";

                DialogResult confirmacion = MessageBox.Show(mensajeConfirmacion, "Confirmar Cálculo de IVA",
                                                           MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmacion != DialogResult.Yes)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en los valores numéricos: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool resultado = controlador.GuardarNuevoActivo(
                Txt_activo_fijo.Text.Trim(),
                Txt_descripcion.Text.Trim(),
                Cbo_grupo.SelectedItem?.ToString() ?? "",
                fecha,
                costoAdquisicion, // Este ya es el valor sin IVA
                valorResidual,
                int.Parse(Txt_vida_util.Text),
                cuentaActivo,
                cuentaDepreciacion,
                cuentaGasto,
                Rdb_activo.Checked
            );

            if (resultado)
            {
                MessageBox.Show("Activo guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();

                // ACTUALIZAR LISTAS DE ACTIVOS DESPUÉS DE GUARDAR
                ActualizarListasActivos();

                // Opcional: Cambiar a la pestaña de depreciación para ver el nuevo activo
                Tbc_calculo_activo_fijo.SelectedTab = tabPage2;
            }
            else
            {
                MessageBox.Show("Error al guardar el activo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Txt_fecha_adquisicion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }

        private void Txt_fecha_adquisicion_TextChanged(object sender, EventArgs e)
        {
            string text = Txt_fecha_adquisicion.Text.Replace("-", "");

            if (text.Length >= 4)
            {
                string formatted = text.Substring(0, 4);
                if (text.Length > 4)
                {
                    formatted += "-" + text.Substring(4, Math.Min(2, text.Length - 4));
                }
                if (text.Length > 6)
                {
                    formatted += "-" + text.Substring(6, Math.Min(2, text.Length - 6));
                }

                if (Txt_fecha_adquisicion.Text != formatted)
                {
                    Txt_fecha_adquisicion.Text = formatted;
                    Txt_fecha_adquisicion.SelectionStart = Txt_fecha_adquisicion.Text.Length;
                }
            }
        }

        private void Btn_buscar_activo_Click(object sender, EventArgs e)
        {
            // Simplemente actualiza la lista de activos en el ComboBox
            ActualizarListasActivos();
            MessageBox.Show("Lista de activos actualizada", "Información",
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BuscarActivos()
        {

        }

        private void ActualizarListasActivos()
        {
            try
            {
                // Solo actualizar el ComboBox de selección
                CargarActivosEnComboBox();

                Console.WriteLine("Lista de activos actualizada correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar lista de activos: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Tbc_calculo_activo_fijo.SelectedTab == tabPage2)
            {
                // Actualizar listas cuando se cambie a la pestaña de depreciación
                ActualizarListasActivos();
            }
        }

        private void Btn_actualizar_Click(object sender, EventArgs e)
        {
            ActualizarListasActivos();
            MessageBox.Show("Listas de activos actualizadas correctamente", "Actualización",
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Btn_prueba_Click(object sender, EventArgs e)
        {
            Console.WriteLine("=== PRUEBA MANUAL ===");

            if (Cbo_seleccion_activo.SelectedValue != null)
            {
                int idActivo = Convert.ToInt32(Cbo_seleccion_activo.SelectedValue);
                Console.WriteLine($"Probando con activo ID: {idActivo}");
                MostrarDatosActivo(idActivo);
            }
            else
            {
                Console.WriteLine("No hay activo seleccionado");
            }
        }

        private int ObtenerIdActivoSeleccionado()
        {
            int idActivo = 0;

            if (Cbo_seleccion_activo.SelectedValue != null)
            {
                if (Cbo_seleccion_activo.SelectedValue is DataRowView rowView)
                {
                    idActivo = Convert.ToInt32(rowView["Pk_Activo_ID"]);
                }
                else if (Cbo_seleccion_activo.SelectedValue is int)
                {
                    idActivo = (int)Cbo_seleccion_activo.SelectedValue;
                }
                else if (int.TryParse(Cbo_seleccion_activo.SelectedValue.ToString(), out int tempId))
                {
                    idActivo = tempId;
                }
            }

            return idActivo;
        }

        private void ConfigurarTabPolizas()
        {
            ConfigurarGridPolizas();
            // Configurar fecha por defecto
            Dtp_fecha_poliza.Value = DateTime.Now;
            Console.WriteLine("Tab de pólizas configurada correctamente");
        }

        private void ConfigurarGridPolizas()
        {
            try
            {
                Dgv_polizas_depreciacion.Columns.Clear();

                // Agregar columnas
                Dgv_polizas_depreciacion.Columns.Add("Año", "Año");
                Dgv_polizas_depreciacion.Columns.Add("DepreciacionAnual", "Depreciación Anual");
                Dgv_polizas_depreciacion.Columns.Add("CuentaGasto", "Cuenta Gasto");
                Dgv_polizas_depreciacion.Columns.Add("CuentaDepreciacion", "Cuenta Depreciación");
                Dgv_polizas_depreciacion.Columns.Add("Concepto", "Concepto");
                Dgv_polizas_depreciacion.Columns.Add("Estado", "Estado");

                // Configurar anchos
                Dgv_polizas_depreciacion.Columns["Año"].Width = 80;
                Dgv_polizas_depreciacion.Columns["DepreciacionAnual"].Width = 150;
                Dgv_polizas_depreciacion.Columns["CuentaGasto"].Width = 120;
                Dgv_polizas_depreciacion.Columns["CuentaDepreciacion"].Width = 120;
                Dgv_polizas_depreciacion.Columns["Concepto"].Width = 200;
                Dgv_polizas_depreciacion.Columns["Estado"].Width = 100;

                Console.WriteLine("Grid de pólizas configurado correctamente");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error configurando grid de pólizas: {ex.Message}");
            }
        }

        private void Btn_actualiazr_poliza_depre_Click(object sender, EventArgs e)
        {
            int idActivo = ObtenerIdActivoSeleccionado();
            if (idActivo > 0)
            {
                CargarDatosParaPolizas(idActivo);
                MessageBox.Show("Datos de pólizas actualizados", "Actualización",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Seleccione un activo primero", "Advertencia",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Tbc_calculo_activo_fijo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Tbc_calculo_activo_fijo.SelectedTab == tabPage3) // Pestaña de pólizas
            {
                int idActivo = ObtenerIdActivoSeleccionado();
                if (idActivo > 0)
                {
                    CargarDatosParaPolizas(idActivo);
                }
                else
                {
                    MessageBox.Show("Seleccione un activo primero.", "Advertencia",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (Tbc_calculo_activo_fijo.SelectedTab == tabPage2)
            {
                ActualizarListasActivos();
            }
        }

        private void Btn_enviar_poliza_Click(object sender, EventArgs e)
        {
            try
            {
                if (Dgv_polizas_depreciacion.CurrentRow == null)
                {
                    MessageBox.Show("Seleccione un año de depreciación para enviar la póliza.", "Advertencia",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idActivo = ObtenerIdActivoSeleccionado();
                if (idActivo == 0)
                {
                    MessageBox.Show("No hay activo seleccionado.", "Advertencia",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtener datos de la fila seleccionada
                int año = Convert.ToInt32(Dgv_polizas_depreciacion.CurrentRow.Cells["Año"].Value);
                string depreciacionAnualStr = Dgv_polizas_depreciacion.CurrentRow.Cells["DepreciacionAnual"].Value.ToString()
                    .Replace("Q", "").Replace("$", "").Replace(",", "").Trim();

                decimal depreciacionAnual = decimal.Parse(depreciacionAnualStr);

                // Obtener datos del activo a través del controlador
                string[] datosActivo = controlador.ObtenerDatosActivo(idActivo);

                if (datosActivo == null || datosActivo.Length < 1)
                {
                    MessageBox.Show("No se pudo obtener información del activo.", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string nombreActivo = datosActivo[0];

                // Obtener fecha desde el DateTimePicker
                DateTime fechaPoliza = Dtp_fecha_poliza.Value;

                // Mostrar confirmación con la fecha seleccionada
                DialogResult confirmacion = MessageBox.Show(
                    $"¿Enviar póliza de depreciación anual?\n\n" +
                    $"Activo: {nombreActivo}\n" +
                    $"Año de depreciación: {año}\n" +
                    $"Fecha de póliza: {fechaPoliza:dd/MM/yyyy}\n" +
                    $"Depreciación Anual: {depreciacionAnual:C}\n\n" +
                    $"Esta póliza se registrará en el sistema contable.",
                    "Confirmar Envío de Póliza",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmacion != DialogResult.Yes) return;

                // Enviar póliza usando el método del controlador
                bool resultado = controlador.EnviarPolizaDepreciacion(idActivo, fechaPoliza, depreciacionAnual);

                if (resultado)
                {
                    // Actualizar estado en el grid
                    Dgv_polizas_depreciacion.CurrentRow.Cells["Estado"].Value = "Enviada";
                    MessageBox.Show($"Póliza de depreciación enviada correctamente.\nFecha: {fechaPoliza:dd/MM/yyyy}", "Éxito",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al enviar la póliza.", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al enviar póliza: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatosParaPolizas(int idActivo)
        {
            try
            {
                Console.WriteLine($"Cargando datos para pólizas - Activo ID: {idActivo}");

                // Obtener datos del activo a través del controlador
                string[] datosActivo = controlador.ObtenerDatosActivo(idActivo);

                if (datosActivo == null || datosActivo.Length < 5)
                {
                    MessageBox.Show("No se pudo obtener información completa del activo seleccionado.", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string nombreActivo = datosActivo[0];
                string grupoActivo = datosActivo[1];
                string costoAdquisicion = datosActivo[2];
                string valorResidual = datosActivo[3];
                string vidaUtil = datosActivo[4];

                Console.WriteLine($"Datos obtenidos del activo:");
                Console.WriteLine($"  Nombre: {nombreActivo}");
                Console.WriteLine($"  Grupo: {grupoActivo}");
                Console.WriteLine($"  Costo: {costoAdquisicion}");
                Console.WriteLine($"  Valor Residual: {valorResidual}");
                Console.WriteLine($"  Vida Útil: {vidaUtil}");

                // Obtener depreciaciones calculadas
                DataTable dtDepreciaciones = controlador.ObtenerDepreciacionesExistentes(idActivo);

                if (dtDepreciaciones.Rows.Count == 0)
                {
                    MessageBox.Show("No hay depreciaciones calculadas para este activo.", "Información",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Limpiar labels si no hay datos
                    LimpiarLabelsPoliza();
                    return;
                }

                // Obtener cuentas contables del activo
                var cuentas = controlador.ObtenerCuentasContablesActivo(idActivo);
                string cuentaGasto = cuentas.cuentaGasto;
                string cuentaDepreciacion = cuentas.cuentaDepreciacion;

                // Limpiar datos anteriores
                Dgv_polizas_depreciacion.Rows.Clear();

                // Usar los nombres correctos de las columnas
                string columnaAnio = "Cmp_Anio";
                string columnaDepreciacionAnual = "Cmp_Depreciacion_Anual";

                // Preparar datos para pólizas
                foreach (DataRow row in dtDepreciaciones.Rows)
                {
                    try
                    {
                        // Obtener año usando el nombre correcto
                        int año = 0;
                        if (row[columnaAnio] != DBNull.Value)
                        {
                            año = Convert.ToInt32(row[columnaAnio]);
                        }

                        // Obtener depreciación anual usando el nombre correcto
                        decimal depreciacionAnual = 0;
                        if (row[columnaDepreciacionAnual] != DBNull.Value)
                        {
                            string depAnualStr = row[columnaDepreciacionAnual].ToString()
                                .Replace("Q", "").Replace("$", "").Replace(",", "").Trim();

                            if (decimal.TryParse(depAnualStr, out decimal temp))
                            {
                                depreciacionAnual = temp;
                            }
                        }

                        if (año > 0 && depreciacionAnual > 0)
                        {
                            string concepto = $"Depreciación Anual - {nombreActivo} - Año {año}";

                            // Agregar al grid
                            int index = Dgv_polizas_depreciacion.Rows.Add();
                            Dgv_polizas_depreciacion.Rows[index].Cells["Año"].Value = año;
                            Dgv_polizas_depreciacion.Rows[index].Cells["DepreciacionAnual"].Value = depreciacionAnual.ToString("C2");
                            Dgv_polizas_depreciacion.Rows[index].Cells["CuentaGasto"].Value = cuentaGasto;
                            Dgv_polizas_depreciacion.Rows[index].Cells["CuentaDepreciacion"].Value = cuentaDepreciacion;
                            Dgv_polizas_depreciacion.Rows[index].Cells["Concepto"].Value = concepto;
                            Dgv_polizas_depreciacion.Rows[index].Cells["Estado"].Value = "Pendiente";
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error procesando fila: {ex.Message}");
                        continue;
                    }
                }

                // Asignar valores correctos a los labels
                Lbl_activo_poliza.Text = nombreActivo;
                Lbl_total_polizas.Text = dtDepreciaciones.Rows.Count.ToString();
                Lbl_info_total.Text = costoAdquisicion;
                Lbl_vida_util_poliza.Text = vidaUtil + " años";

                Console.WriteLine($"Labels actualizados:");
                Console.WriteLine($"  Activo: {Lbl_activo_poliza.Text}");
                Console.WriteLine($"  Total pólizas: {Lbl_total_polizas.Text}");
                Console.WriteLine($"  Costo: {Lbl_info_total.Text}");
                Console.WriteLine($"  Vida útil: {Lbl_vida_util_poliza.Text}");

                Console.WriteLine($"Datos cargados: {dtDepreciaciones.Rows.Count} años preparados para pólizas");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos para pólizas: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Error detallado: {ex.ToString()}");
                LimpiarLabelsPoliza();
            }
        }

        private void LimpiarLabelsPoliza()
        {
            Lbl_activo_poliza.Text = "---";
            Lbl_total_polizas.Text = "---";
            Lbl_info_total.Text = "---";
            Lbl_vida_util_poliza.Text = "---";
        }

        private void Btn_enviar_poliza_todo_Click(object sender, EventArgs e)
        {
            try
            {
                int idActivo = ObtenerIdActivoSeleccionado();
                if (idActivo == 0)
                {
                    MessageBox.Show("No hay activo seleccionado.", "Advertencia",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DateTime fechaPoliza = Dtp_fecha_poliza.Value;

                DialogResult confirmacion = MessageBox.Show(
                    $"¿Enviar TODAS las pólizas de depreciación?\n\n" +
                    $"Fecha de póliza: {fechaPoliza:dd/MM/yyyy}\n" +
                    $"Total de pólizas: {Dgv_polizas_depreciacion.Rows.Count}\n\n" +
                    $"Esta acción enviará todas las pólizas pendientes.",
                    "Confirmar Envío Masivo",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmacion != DialogResult.Yes) return;

                int pólizasEnviadas = 0;
                int pólizasConError = 0;

                foreach (DataGridViewRow row in Dgv_polizas_depreciacion.Rows)
                {
                    if (row.Cells["Estado"].Value?.ToString() == "Pendiente")
                    {
                        try
                        {
                            int año = Convert.ToInt32(row.Cells["Año"].Value);
                            string depreciacionAnualStr = row.Cells["DepreciacionAnual"].Value.ToString()
                                .Replace("Q", "").Replace("$", "").Replace(",", "").Trim();

                            decimal depreciacionAnual = decimal.Parse(depreciacionAnualStr);

                            bool resultado = controlador.EnviarPolizaDepreciacion(idActivo, fechaPoliza, depreciacionAnual);

                            if (resultado)
                            {
                                row.Cells["Estado"].Value = "Enviada";
                                pólizasEnviadas++;
                            }
                            else
                            {
                                pólizasConError++;
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error enviando póliza para año {row.Cells["Año"].Value}: {ex.Message}");
                            pólizasConError++;
                        }
                    }
                }

                MessageBox.Show(
                    $"Proceso de envío masivo completado:\n\n" +
                    $"Pólizas enviadas: {pólizasEnviadas}\n" +
                    $"Pólizas con error: {pólizasConError}\n" +
                    $"Fecha utilizada: {fechaPoliza:dd/MM/yyyy}",
                    "Envío Masivo Completado",
                    MessageBoxButtons.OK,
                    pólizasConError > 0 ? MessageBoxIcon.Warning : MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en envío masivo: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Tbc_calculo_activo_fijo_DrawItem(object sender, DrawItemEventArgs e)
        {
            // Método existente
        }
        private void Txt_activo_fijo_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir teclas de control (backspace, delete, etc.)
            if (char.IsControl(e.KeyChar))
            {
                return;
            }

            // Permitir letras, espacios, acentos y caracteres especiales comunes
            if (char.IsLetter(e.KeyChar) ||
                e.KeyChar == ' ' ||
                e.KeyChar == '.' ||
                e.KeyChar == ',' ||
                e.KeyChar == '-' ||
                e.KeyChar == '_' ||
                e.KeyChar == 'á' || e.KeyChar == 'é' || e.KeyChar == 'í' || e.KeyChar == 'ó' || e.KeyChar == 'ú' ||
                e.KeyChar == 'Á' || e.KeyChar == 'É' || e.KeyChar == 'Í' || e.KeyChar == 'Ó' || e.KeyChar == 'Ú' ||
                e.KeyChar == 'ñ' || e.KeyChar == 'Ñ')
            {
                return;
            }

            // No permitir números ni otros caracteres
            e.Handled = true;
        }
        private void Txt_descripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir teclas de control (backspace, delete, etc.)
            if (char.IsControl(e.KeyChar))
            {
                return;
            }

            // Permitir letras, números, espacios y caracteres especiales comunes en descripciones
            if (char.IsLetterOrDigit(e.KeyChar) ||
                e.KeyChar == ' ' ||
                e.KeyChar == '.' ||
                e.KeyChar == ',' ||
                e.KeyChar == '-' ||
                e.KeyChar == '_' ||
                e.KeyChar == ':' ||
                e.KeyChar == ';' ||
                e.KeyChar == '(' ||
                e.KeyChar == ')' ||
                e.KeyChar == 'á' || e.KeyChar == 'é' || e.KeyChar == 'í' || e.KeyChar == 'ó' || e.KeyChar == 'ú' ||
                e.KeyChar == 'Á' || e.KeyChar == 'É' || e.KeyChar == 'Í' || e.KeyChar == 'Ó' || e.KeyChar == 'Ú' ||
                e.KeyChar == 'ñ' || e.KeyChar == 'Ñ')
            {
                return;
            }

            // No permitir otros caracteres especiales
            e.Handled = true;
        }
        private void Txt_activo_fijo_Leave(object sender, EventArgs e)
        {
            LimpiarTextoNoPermitido(Txt_activo_fijo, false);
        }

        private void Txt_descripcion_Leave(object sender, EventArgs e)
        {
            LimpiarTextoNoPermitido(Txt_descripcion, true);
        }

        private void LimpiarTextoNoPermitido(TextBox textBox, bool permitirNumeros)
        {
            if (string.IsNullOrEmpty(textBox.Text))
                return;

            string textoLimpio = "";
            foreach (char c in textBox.Text)
            {
                if (char.IsLetter(c) ||
                    c == ' ' ||
                    c == '.' ||
                    c == ',' ||
                    c == '-' ||
                    c == '_' ||
                    c == ':' ||
                    c == ';' ||
                    c == '(' ||
                    c == ')' ||
                    c == 'á' || c == 'é' || c == 'í' || c == 'ó' || c == 'ú' ||
                    c == 'Á' || c == 'É' || c == 'Í' || c == 'Ó' || c == 'Ú' ||
                    c == 'ñ' || c == 'Ñ' ||
                    (permitirNumeros && char.IsDigit(c)))
                {
                    textoLimpio += c;
                }
            }

            if (textBox.Text != textoLimpio)
            {
                textBox.Text = textoLimpio;
                MessageBox.Show("Se han removido caracteres no permitidos", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Btn_limpiar_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Limpiar campos de texto
                Txt_activo_fijo.Clear();
                Txt_descripcion.Clear();
                Txt_costo_adquisicion.Text = "0.00";
                Txt_adquisicion.Text = "0.00";
                Txt_vida_util.Clear();
                Txt_fecha_adquisicion.Text = DateTime.Now.ToString("yyyy-MM-dd");

                // Limpiar ComboBoxes
                Cbo_grupo.SelectedIndex = -1;

                // Restablecer cuentas contables a sus valores por defecto
                if (Cbo_cuenta_activo.Items.Count > 0)
                    Cbo_cuenta_activo.SelectedIndex = 0;
                if (Cbo_cuenta_depreciacion.Items.Count > 0)
                    Cbo_cuenta_depreciacion.SelectedIndex = 0;
                if (Cbo_gastos_depreciacoin.Items.Count > 0)
                    Cbo_gastos_depreciacoin.SelectedIndex = 0;

                // Restablecer RadioButtons
                Rdb_activo.Checked = true;

                // Limpiar pestaña de depreciación
                LimpiarCamposDepreciacion();

                // Limpiar pestaña de pólizas
                LimpiarPestaniaPolizas();

                // Enfocar el primer campo
                Txt_activo_fijo.Focus();

                MessageBox.Show("Todos los campos han sido limpiados correctamente.", "Limpieza Exitosa",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al limpiar los campos: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LimpiarPestaniaPolizas()
        {
            try
            {
                Dgv_polizas_depreciacion.Rows.Clear();
                Lbl_activo_poliza.Text = "---";
                Lbl_total_polizas.Text = "---";
                Lbl_info_total.Text = "---";
                Lbl_vida_util_poliza.Text = "---";
                Dtp_fecha_poliza.Value = DateTime.Now;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al limpiar pestaña de pólizas: {ex.Message}");
            }
        }

        private void btn_ayudas_Click(object sender, EventArgs e)
        {
            try
            {
                const string subRutaAyuda = @"ayuda\modulos\contabilidad\Ayudas\Ayuda_Activo_Fijo.chm";

                string rutaEncontrada = null;
                System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(Application.StartupPath);

                for (int i = 0; i < 10 && dir != null; i++, dir = dir.Parent)
                {
                    string candidata = System.IO.Path.Combine(dir.FullName, subRutaAyuda);
                    if (System.IO.File.Exists(candidata))
                    {
                        rutaEncontrada = candidata;
                        break;
                    }
                }

                string rutaAbsolutaRespaldo =
                    @"C:\Users\cesar\OneDrive\Escritorio\asis2k25p2_Contabilidad\ayuda\modulos\contabilidad\Ayudas\Ayuda_Activo_Fijo.chm";

                if (rutaEncontrada == null && System.IO.File.Exists(rutaAbsolutaRespaldo))
                    rutaEncontrada = rutaAbsolutaRespaldo;

                if (rutaEncontrada != null)
                {


                    Help.ShowHelp(this, rutaEncontrada, HelpNavigator.Topic, "ayuda_activos_fijos.html");
                }
                else
                {
                    string intento = System.IO.Path.Combine(Application.StartupPath, subRutaAyuda);
                    MessageBox.Show(
                        "No se encontró el archivo de ayuda.\n\nProbé desde:\n" + intento +
                        "\n\nVerifica que exista esta ruta relativa dentro del proyecto:\n" + subRutaAyuda,
                        "Archivo de ayuda no encontrado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al abrir la ayuda:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

        }

        private void Btn_reportes_activos_Click(object sender, EventArgs e)
        {

        }
    }

}