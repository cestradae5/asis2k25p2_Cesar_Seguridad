using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Capa_Controlador_Consultas;
using Microsoft.VisualBasic;


namespace Capa_Vista_Componente_Consultas
{
    public partial class Frm_Consulta_Compleja : Form
    {
        private const string sDsn = "Consultas";
        public const string sDB = "consultas";

        private Controlador oControlador;
        private string sTablaActual = null;
        //Se estandarizó variables realizado por Nelson Godínez 0901-22-3550 07/10/2025
        private readonly List<string> lstPartesWhere = new List<string>();
        private readonly List<string> lstPartesGroupOrder = new List<string>();
        // Rellena los dos bloques visibles de UI a partir de las condiciones parseadas Nelson Jose Godinez Mendez 0901-22-3550 09/26/2025
        private bool bCargandoDesdeSql = false;
        private string sSqlActual = string.Empty;
        // Mapeo de qué condición del WHERE se pintó en cada bloque de UI
        private int _idxComp = -1;   // índice en _partesWhere de la condición usada en "Comparación"
        private int _idxLogic = -1;  // índice en _partesWhere de la condición usada en "Lógica"
                                     // Señaliza que se está editando una consulta cargada desde SQL
        private bool _editandoConsulta = false;

        // Si el usuario cambió algo en la UI y debe presionar "Agregar" de nuevo
        private bool _requiereAgregar = false;


        // BETWEEN dinámico
        private TextBox Txt_ValorCompMin;
        private TextBox Txt_ValorCompMax;
        private Label Lbl_ValorCompMin;
        private Label Lbl_ValorCompMax;

        public Frm_Consulta_Compleja()
        {
            InitializeComponent();

            KeyPreview = true;
            KeyDown += delegate (object s, KeyEventArgs e)
            {
                if (e.Control && e.KeyCode == Keys.L) { LimpiarTodo(); e.Handled = true; }
            };

            // Oculta la caja de SQL generada en UI
            Txt_CadenaGenerada.Visible = false;
            Txt_CadenaGenerada.TabStop = false;

            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
            CargarEventos();
        }

        private void CargarEventos()
        {
            Load += Frm_Consulta_Compleja_Load;

            // Cambio de tabla
            Cbo_Tabla.SelectedIndexChanged += delegate
            {
                sTablaActual = Cbo_Tabla.SelectedItem == null ? null : Cbo_Tabla.SelectedItem.ToString();
                CargarColumnas(sTablaActual);

                if (!bCargandoDesdeSql)
                {
                    LimpiarCondiciones();
                    Txt_CadenaGenerada.Clear();
                }
                PrevisualizarTabla(sTablaActual);
            };

            // Buscar/Refrescar preview
            {
                var t = Cbo_Tabla.SelectedItem == null ? null : Cbo_Tabla.SelectedItem.ToString();
                PrevisualizarTabla(t);
            };

            // Radios ASC/DES  actualizan dirección y la pieza ORDER BY
            Rdb_Asc.CheckedChanged += delegate { if (Rdb_Asc.Checked) SincronizarOrdenConRadios(); };
            Rdb_Des.CheckedChanged += delegate { if (Rdb_Des.Checked) SincronizarOrdenConRadios(); };

            // Cualquier cambio en estos controles marcará que hay que re-agregar:
            Txt_ValorCond.TextChanged += MarcarRequiereAgregar;
            Txt_ValorComp.TextChanged += MarcarRequiereAgregar;

            // Si usas BETWEEN dinámico, suscríbelo tras EnsureBetweenControls()
            EnsureBetweenControls();
            if (Txt_ValorCompMin != null) Txt_ValorCompMin.TextChanged += MarcarRequiereAgregar;
            if (Txt_ValorCompMax != null) Txt_ValorCompMax.TextChanged += MarcarRequiereAgregar;

            Cbo_OperadorLogico.SelectedIndexChanged += MarcarRequiereAgregar;
            Cbo_CampoCond.SelectedIndexChanged += MarcarRequiereAgregar;
            Cbo_TipoComparador.SelectedIndexChanged += MarcarRequiereAgregar;
            Cbo_CampoComp.SelectedIndexChanged += MarcarRequiereAgregar;

            // También si cambia el agrupado/orden (opcional)
            Cbo_AgruparOrdenar.SelectedIndexChanged += MarcarRequiereAgregar;
            Cbo_CampoOrdenar.SelectedIndexChanged += MarcarRequiereAgregar;
            Cbo_Ordenamiento.SelectedIndexChanged += MarcarRequiereAgregar;


            // Si el usuario cambia el combo de dirección, sincronizamos radios y pieza
            Cbo_Ordenamiento.SelectedIndexChanged += delegate
            {
                if (Cbo_Ordenamiento.SelectedItem == null) return;
                string v = Cbo_Ordenamiento.SelectedItem.ToString();
                if (string.Equals(v, "ASC", StringComparison.OrdinalIgnoreCase)) Rdb_Asc.Checked = true;
                else if (string.Equals(v, "DESC", StringComparison.OrdinalIgnoreCase)) Rdb_Des.Checked = true;
                SincronizarOrdenConRadios();
            };


            // // ---- Lógica EDITADA DE NUEVO Nelson Jose Godínez Méndez 0901-22-3550 26/09/2025 y 11/10/2025
            Btn_AgregarCond.Click += (s, e) =>
            {
                if (!Chk_AgregarCondiciones.Checked) return;
                if (Cbo_CampoCond.SelectedItem == null) { MessageBox.Show("Selecciona un campo."); return; }

                var val = Txt_ValorCond.Text.Trim();
                if (val.Length == 0) { MessageBox.Show("Ingresa un valor."); return; }

                var operador = lstPartesWhere.Count == 0 ? null
                               : (GetComboValor(Cbo_OperadorLogico) ?? "AND");

                var campo = Cbo_CampoCond.SelectedItem.ToString();
                string rhs = decimal.TryParse(val, NumberStyles.Any, CultureInfo.InvariantCulture, out var num)
                             ? num.ToString(CultureInfo.InvariantCulture)
                             : $"'{Esc(val)}'";

                var pieza = $"`{campo}` = {rhs}";
                AgregarWhere(pieza, operador);

                _requiereAgregar = false;
                _editandoConsulta = false;

                //  Mensaje de éxito
                MostrarOk("Se agregó la condición correctamente.");
            };

            // ---- Comparación
            Cbo_TipoComparador.SelectedIndexChanged += delegate { ToggleBetweenControls(); };

            Btn_AgregarComp.Click += (s, e) =>
            {
                if (!Chk_AgregarCondiciones.Checked) return;
                if (Cbo_CampoComp.SelectedItem == null || Cbo_TipoComparador.SelectedItem == null)
                { MessageBox.Show("Selecciona campo y comparador."); return; }

                var campo = Cbo_CampoComp.SelectedItem.ToString();
                var sel = GetComboValor(Cbo_TipoComparador) ?? "=";

                string pieza;

                switch (sel)
                {
                    case "BETWEEN":
                        EnsureBetweenControls();
                        var minRaw = (Txt_ValorCompMin.Text ?? "").Trim();
                        var maxRaw = (Txt_ValorCompMax.Text ?? "").Trim();
                        if (minRaw.Length == 0 || maxRaw.Length == 0)
                        { MessageBox.Show("Completa Mín. y Máx."); return; }

                        string left = TryNumOrQuoted(minRaw);
                        string right = TryNumOrQuoted(maxRaw);
                        pieza = $"`{campo}` BETWEEN {left} AND {right}";
                        break;

                    case "LIKE":
                        if (Txt_ValorComp.TextLength == 0) { MessageBox.Show("Ingresa un valor."); return; }
                        pieza = $"`{campo}` LIKE '%{Esc(Txt_ValorComp.Text)}%'";
                        break;

                    case "LIKE_START":
                        if (Txt_ValorComp.TextLength == 0) { MessageBox.Show("Ingresa un valor."); return; }
                        pieza = $"`{campo}` LIKE '{Esc(Txt_ValorComp.Text)}%'";
                        break;

                    case "LIKE_END":
                        if (Txt_ValorComp.TextLength == 0) { MessageBox.Show("Ingresa un valor."); return; }
                        pieza = $"`{campo}` LIKE '%{Esc(Txt_ValorComp.Text)}'";
                        break;

                    case "IS NULL":
                    case "IS NOT NULL":
                        pieza = $"`{campo}` {sel}";
                        break;

                    default:
                        if (Txt_ValorComp.TextLength == 0) { MessageBox.Show("Ingresa un valor."); return; }
                        pieza = $"`{campo}` {sel} {TryNumOrQuoted(Txt_ValorComp.Text)}";
                        break;
                }

                string conector = lstPartesWhere.Count == 0
                    ? null
                    : (GetComboValor(Cbo_OperadorLogico) ?? "AND");

                AgregarWhere(pieza, conector);

                _requiereAgregar = false;
                _editandoConsulta = false;

                //  Mensaje de éxito
                MostrarOk("Se agregó la comparación correctamente.");
            };



            // ---- Agrupar/Ordenar Bryan Raul Ramirez Lopez 0901-21-8202 26/09/2025 y 11/10/2025
            Btn_AgregarOrden.Click += (s, e) =>
            {
                if (Cbo_AgruparOrdenar.SelectedItem == null || Cbo_CampoOrdenar.SelectedItem == null)
                { MessageBox.Show("Selecciona modo y campo."); return; }

                string modo = Cbo_AgruparOrdenar.SelectedItem.ToString();
                string campo = Cbo_CampoOrdenar.SelectedItem.ToString();

                if (modo == "GROUP BY")
                {
                    lstPartesGroupOrder.Add($"GROUP BY `{campo}`");
                    MostrarOk("Se agregó el agrupamiento correctamente.");
                }
                else
                {
                    string ord = Cbo_Ordenamiento.SelectedItem == null
                        ? (Rdb_Asc.Checked ? "ASC" : "DESC")
                        : Cbo_Ordenamiento.SelectedItem.ToString();

                    lstPartesGroupOrder.Add($"ORDER BY `{campo}` {ord}");
                    MostrarOk("Se agregó el ordenamiento correctamente.");
                }

                _requiereAgregar = false;
                _editandoConsulta = false;
            };



            // ---- Ejecutar  Juan Carlos Sandoval Quej 0901-22-4170 26/09/2025 y 11/10/2025
            Btn_Ejecutar.Click += (s, e) =>
            {
                string sMsg; Control oFoco;
                if (!ValidarParaGenerarEjecutar(out sMsg, out oFoco))
                { MostrarError(sMsg, oFoco); return; }
                if (_requiereAgregar)
                {
                    MessageBox.Show(
                        "Has editado la consulta cargada.\n\n" +
                        "Para aplicar los cambios, pulsa:\n" +
                        "  1) «Agregar valor» (o «Agregar»),\n" +
                        "  2) «Generar», y luego\n" +
                        "  3) «Ejecutar».",
                        "Cambios sin agregar",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                // <<<<<< APLICAR CAMBIOS DE LA UI A LAS LISTAS >>>>>>
                AplicarEdicionEnListasDesdeUI();

                string sSql = string.IsNullOrWhiteSpace(sSqlActual)
                    ? oControlador.ConstruirSql(sTablaActual, Chk_AgregarCondiciones.Checked, lstPartesWhere, lstPartesGroupOrder)
                    : sSqlActual;

                sSql = oControlador.ReescribirSelectSeguroSiHayTime(sDB, sTablaActual, sSql);

                try
                {
                    var dt = oControlador.EjecutarConsulta(sSql);
                    Dgv_Preview.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MostrarError("Error al ejecutar:\n" + ex.Message, null);
                }
            };


            // ---- Limpiar
            Btn_Limpiar.Click += delegate { LimpiarTodo(); };

            // ---- Consultas guardadas Diego Fernando Saquil Gramajo 0901-22-4103 26/09/2025 y 11/10/2025
            Btn_AgregarConsulta.Click += (s, e) =>
            {
                string sMsg; Control oFoco;
                if (!ValidarParaGuardarEditar(out sMsg, out oFoco))
                { MostrarError(sMsg, oFoco); return; }

                GuardarConsultaAuto(); 
            };


            Btn_EditarConsulta.Click += (s, e) =>
            {
                if (Lst_ConsultasGuardadas.SelectedItem == null)
                { MostrarError("Selecciona una consulta para editar.", Lst_ConsultasGuardadas); return; }

                var sSql = Lst_ConsultasGuardadas.SelectedValue as string ?? "";
                if (string.IsNullOrWhiteSpace(sSql))
                { MostrarError("La consulta seleccionada no tiene SQL asociado.", Lst_ConsultasGuardadas); return; }

                // Si quieres bloquear edición si hay campos incompletos actualmente en la UI:
                string sMsg; Control oFoco;
                if (!ValidarParaGuardarEditar(out sMsg, out oFoco))
                { MostrarError("Completa o limpia los campos antes de editar otra consulta.\n\n" + sMsg, oFoco); return; }

                CargarConsultaDesdeSql(sSql);
            };


            Btn_EliminarConsulta.Click += delegate
            {
                if (Lst_ConsultasGuardadas.SelectedItem == null) { MessageBox.Show("Selecciona una consulta."); return; }
                string nombre = Lst_ConsultasGuardadas.GetItemText(Lst_ConsultasGuardadas.SelectedItem);

                if (MessageBox.Show("¿Eliminar \"" + nombre + "\"?", "Confirmación",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (oControlador.EliminarConsulta(nombre))
                    {
                        CargarConsultasGuardadas();
                        Txt_CadenaGenerada.Clear();
                        MessageBox.Show("Consulta eliminada.");
                    }
                    else MessageBox.Show("No se pudo eliminar.");
                }
            };

            // Seleccionar consulta -> mostrar SQL (solo interno; la caja está oculta)
            Lst_ConsultasGuardadas.SelectedIndexChanged += delegate
            {
                var sql = Lst_ConsultasGuardadas.SelectedValue as string;
                if (sql != null) Txt_CadenaGenerada.Text = sql;
            };

            // Doble click: cargar y ejecutar
            Lst_ConsultasGuardadas.DoubleClick += delegate
            {
                var sql = Lst_ConsultasGuardadas.SelectedValue as string;
                if (!string.IsNullOrEmpty(sql))
                {
                    Txt_CadenaGenerada.Text = sql;
                    Btn_Ejecutar.PerformClick();
                }
            };

            Btn_Generar.Click += (s, e) =>
            {
                string sMsg; Control oFoco;
                if (!ValidarParaGenerarEjecutar(out sMsg, out oFoco))
                { MostrarError(sMsg, oFoco); return; }
                if (_requiereAgregar)
                {
                    MessageBox.Show(
                        "Has editado la consulta cargada.\n\n" +
                        "Para aplicar los cambios, pulsa:\n" +
                        "  1) «Agregar valor» (o «Agregar»),\n" +
                        "  2) «Generar», y luego\n" +
                        "  3) «Ejecutar».",
                        "Cambios sin agregar",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //  APLICAR CAMBIOS DE LA UI A LAS LISTAS 
                AplicarEdicionEnListasDesdeUI();

                string sSql = oControlador.ConstruirSql(
                    sTablaActual,
                    Chk_AgregarCondiciones.Checked,
                    lstPartesWhere,
                    lstPartesGroupOrder);

                sSqlActual = sSql;
                MessageBox.Show("Consulta generada.", "OK",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            };

        }

        private void Frm_Consulta_Compleja_Load(object sender, EventArgs e)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;

            oControlador = new Controlador(sDsn, sDB);

            CargarTablas();

            // Combos fijos
            if (Cbo_OperadorLogico.DataSource == null)
            {
                Cbo_OperadorLogico.DataSource = new List<ComboItem> {
                    new ComboItem("Y (AND)","AND"),
                    new ComboItem("O (OR)","OR")
                };
            }
            Cbo_OperadorLogico.DisplayMember = "Texto";
            Cbo_OperadorLogico.ValueMember = "Valor";

            if (Cbo_TipoComparador.DataSource == null)
            {
                Cbo_TipoComparador.DataSource = new List<ComboItem> {
                    new ComboItem("Igual (=)","="),
                    new ComboItem("Distinto (≠)","<>"),
                    new ComboItem("Mayor (>)",">"),
                    new ComboItem("Menor (<)","<"),
                    new ComboItem("Mayor o igual (≥)",">="),
                    new ComboItem("Menor o igual (≤)","<="),
                    new ComboItem("Contiene","LIKE"),
                    new ComboItem("Comienza con","LIKE_START"),
                    new ComboItem("Termina con","LIKE_END"),
                    new ComboItem("Entre","BETWEEN"),
                    new ComboItem("Es nulo","IS NULL"),
                    new ComboItem("No es nulo","IS NOT NULL")
                };
            }
            Cbo_TipoComparador.DisplayMember = "Texto";
            Cbo_TipoComparador.ValueMember = "Valor";

            if (Cbo_AgruparOrdenar.Items.Count == 0)
                Cbo_AgruparOrdenar.Items.AddRange(new object[] { "GROUP BY", "ORDER BY" });
            if (Cbo_Ordenamiento.Items.Count == 0)
                Cbo_Ordenamiento.Items.AddRange(new object[] { "ASC", "DESC" });

            Rdb_Asc.Checked = true;
            LimpiarCondiciones();
            CargarConsultasGuardadas();

            EnsureBetweenControls();
            ToggleBetweenControls();
        }

        // ----------------- Datos: Juan Carlos Sandoval Quej 0901-22-4170 26/09/2025
        private void CargarTablas()
        {
            try
            {
                // Limpia el combo de tablas antes de volver a llenarlo
                Cbo_Tabla.Items.Clear();
                var tabs = oControlador.ObtenerTablas();
                foreach (var t in tabs) Cbo_Tabla.Items.Add(t);

                // Si hay al menos una tabla, selecciona la primera por defecto
                if (Cbo_Tabla.Items.Count > 0) Cbo_Tabla.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                // Si falla (por ejemplo, no hay conexión), muestra el error
                MessageBox.Show("No se pudieron obtener las tablas.\n" + ex.Message);
            }
        }
        private void MostrarOk(string texto)
        {
            MessageBox.Show(texto, "Agregado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SincronizarOrdenConRadios()
        {
            // Lee qué radiobutton está marcado: si es ASC lo usa, si no, utiliza DESC
            string dir = Rdb_Asc.Checked ? "ASC" : "DESC";

            // Asegura que el combo de orden contenga las dos opciones
            if (Cbo_Ordenamiento.Items.Count == 0)
                Cbo_Ordenamiento.Items.AddRange(new object[] { "ASC", "DESC" });

            // Refleja en el combo la dirección elegida en los radios
            Cbo_Ordenamiento.SelectedItem = dir;

            // Busca, de atrás hacia adelante, si ya existe una pieza "ORDER BY" en la lista
            int idx = -1;
            for (int i = lstPartesGroupOrder.Count - 1; i >= 0; i--)
            {
                if (lstPartesGroupOrder[i].StartsWith("ORDER BY ", StringComparison.OrdinalIgnoreCase))
                { idx = i; break; }
            }

            if (idx >= 0)
            {
                string pieza = lstPartesGroupOrder[idx]; // "ORDER BY `col` DIR"
                string col = null;
                var m = Regex.Match(pieza, @"ORDER\s+BY\s+`?(?<c>[^`\s]+)`?", RegexOptions.IgnoreCase);
                if (m.Success) col = m.Groups["c"].Value;

                // Si no se pudo leer la columna, intenta usar la elegida en el combo de campo a ordenar
                if (string.IsNullOrEmpty(col) && Cbo_CampoOrdenar.SelectedItem != null)
                    col = Cbo_CampoOrdenar.SelectedItem.ToString();

                // Si tenemos columna, reconstruye la pieza con la nueva dirección.
                if (!string.IsNullOrEmpty(col))
                    lstPartesGroupOrder[idx] = "ORDER BY `" + NormalizeCol(col) + "` " + dir;
            }
            else
            {
                // No existe ORDER BY aún.
                // Si el usuario está en modo "ORDER BY" y ya eligió un campo, creamos la pieza desde cero.
                if (Cbo_AgruparOrdenar.SelectedItem != null &&
                    string.Equals(Cbo_AgruparOrdenar.SelectedItem.ToString(), "ORDER BY", StringComparison.OrdinalIgnoreCase) &&
                    Cbo_CampoOrdenar.SelectedItem != null)
                {
                    string col2 = Cbo_CampoOrdenar.SelectedItem.ToString();
                    lstPartesGroupOrder.Add("ORDER BY `" + NormalizeCol(col2) + "` " + dir);
                }
            }
        }
        private void MarcarRequiereAgregar(object sender, EventArgs e)
        {
            if (_editandoConsulta) _requiereAgregar = true;
        }

        //Ayudas  o HELPERS Nelson Jose Godinez Mendez 0901-22-3550 26/09/2025
        private void CargarColumnas(string tabla)
        {
            Cbo_CampoCond.Items.Clear();
            Cbo_CampoComp.Items.Clear();
            Cbo_CampoOrdenar.Items.Clear();

            if (string.IsNullOrEmpty(tabla)) return;

            var cols = oControlador.ObtenerColumnas(tabla);
            foreach (var c in cols)
            {
                Cbo_CampoCond.Items.Add(c);
                Cbo_CampoComp.Items.Add(c);
                Cbo_CampoOrdenar.Items.Add(c);
            }
        }

        private static string NormalizeCol(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return s;
            s = s.Trim().Trim('`', '"');
            int lastDot = s.LastIndexOf('.');
            if (lastDot >= 0) s = s.Substring(lastDot + 1);
            return s;
        }

        // Selección tolerante con reintentos si aún no hay Items/DataSource cargado
        private void SetComboSelectedItemLoose(ComboBox cb, string value)
        {
            value = NormalizeCol(value);
            if (string.IsNullOrEmpty(value)) { cb.SelectedIndex = -1; return; }

            Func<bool> trySelect = delegate ()
            {
                // Sin DataSource
                if (cb.DataSource == null)
                {
                    for (int i = 0; i < cb.Items.Count; i++)
                    {
                        var txt = NormalizeCol(cb.Items[i]?.ToString());
                        if (string.Equals(txt, value, StringComparison.OrdinalIgnoreCase))
                        { cb.SelectedIndex = i; return true; }
                    }
                    if (cb.Items.Count == 0) return false; // nada aún: reintenta
                                                           // fallback
                    cb.Items.Add(value);
                    cb.SelectedItem = value;
                    return true;
                }

                // Con DataSource
                var enumerable = cb.DataSource as System.Collections.IEnumerable;
                if (enumerable != null)
                {
                    int idx = 0;
                    foreach (var it in enumerable)
                    {
                        string txt = it?.ToString();
                        if (!string.IsNullOrEmpty(cb.DisplayMember))
                        {
                            var p = it?.GetType().GetProperty(cb.DisplayMember);
                            var v = p?.GetValue(it, null);
                            txt = v?.ToString();
                        }
                        txt = NormalizeCol(txt);
                        if (string.Equals(txt, value, StringComparison.OrdinalIgnoreCase))
                        { cb.SelectedIndex = idx; return true; }
                        idx++;
                    }
                    // intenta por SelectedValue
                    try { cb.SelectedValue = value; return true; } catch { /*ignore*/ }
                    return false;
                }
                return false;
            };

            if (trySelect()) return;

            // Reintenta algunas veces (p.ej., cada 25ms hasta 20 intentos)
            int intentos = 0;
            var t = new Timer();
            t.Interval = 25;
            t.Tick += (s, e) =>
            {
                intentos++;
                if (trySelect() || intentos >= 20)
                {
                    var tt = (Timer)s;
                    tt.Stop();
                    tt.Dispose();
                }
            };
            t.Start();
        }
        private void SafeSelectColumn(ComboBox cb, string col)
        {
            if ((cb.Items.Count == 0) && cb.DataSource == null)
                cb.Items.Add(NormalizeCol(col));
            SetComboSelectedItemLoose(cb, col);
        }

        private void PrevisualizarTabla(string tabla)
        {
            if (string.IsNullOrEmpty(tabla)) { Dgv_Preview.DataSource = null; return; }
            try
            {
                var sql = "SELECT * FROM `" + tabla + "` LIMIT 50;";
                sql = oControlador.ReescribirSelectSeguroSiHayTime(sDB, tabla, sql);
                var dt = oControlador.EjecutarConsulta(sql);
                Dgv_Preview.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar la tabla.\n" + ex.Message);
            }
        }
        // Crea la pieza SIN conector: `campo` OP valor  (o BETWEEN / LIKE / IS NULL)
        private string BuildPieza(string campo, string op, string v1, string v2)
        {
            if (string.IsNullOrEmpty(campo)) return null;
            campo = NormalizeCol(campo);

            if (string.Equals(op, "BETWEEN", StringComparison.OrdinalIgnoreCase))
                return "`" + campo + "` BETWEEN " + TryNumOrQuoted(v1) + " AND " + TryNumOrQuoted(v2);

            if (string.Equals(op, "IS NULL", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(op, "IS NOT NULL", StringComparison.OrdinalIgnoreCase))
                return "`" + campo + "` " + op;

            if (string.Equals(op, "LIKE", StringComparison.OrdinalIgnoreCase))
                return "`" + campo + "` LIKE '%" + Esc(v1 ?? "") + "%'";

            if (string.Equals(op, "LIKE_START", StringComparison.OrdinalIgnoreCase))
                return "`" + campo + "` LIKE '" + Esc(v1 ?? "") + "%'";

            if (string.Equals(op, "LIKE_END", StringComparison.OrdinalIgnoreCase))
                return "`" + campo + "` LIKE '%" + Esc(v1 ?? "") + "'";

            // comparadores normales (=, <>, >, <, >=, <=)
            return "`" + campo + "` " + op + " " + TryNumOrQuoted(v1);
        }

        // Convierte una condición parseada a PIEZA (sin conector)
        private string BuildPiezaFromCond(string campo, string op, string v1, string v2)
        {
            return BuildPieza(campo, op, Unquote(v1), Unquote(v2));
        }

        // Reemplaza (o inserta) en _partesWhere un elemento aplicando conector si corresponde
        private void SetWhereAt(int index, string pieza, string conector)
        {
            if (pieza == null) return;

            string full = (index == 0 || string.IsNullOrEmpty(conector))
                ? pieza
                : (conector + " " + pieza);

            if (index >= 0 && index < lstPartesWhere.Count)
                lstPartesWhere[index] = full;
            else if (index == lstPartesWhere.Count)
                lstPartesWhere.Add(full);
        }


        // ----------------- Estado/Limpieza Bryan Raul Ramirez Lopez 0901-21-8202
        private void LimpiarCondiciones()
        {
            lstPartesWhere.Clear();
            lstPartesGroupOrder.Clear();

            Cbo_OperadorLogico.SelectedItem = null;
            Cbo_CampoCond.SelectedItem = null;
            Txt_ValorCond.Clear();

            Cbo_TipoComparador.SelectedItem = null;
            Cbo_CampoComp.SelectedItem = null;
            Txt_ValorComp.Clear();

            if (Txt_ValorCompMin != null) Txt_ValorCompMin.Clear();
            if (Txt_ValorCompMax != null) Txt_ValorCompMax.Clear();

            Cbo_AgruparOrdenar.SelectedItem = null;
            Cbo_CampoOrdenar.SelectedItem = null;
            Cbo_Ordenamiento.SelectedItem = Rdb_Asc.Checked ? "ASC" : "DESC";

            ToggleBetweenControls();
        }

        private void LimpiarTodo()
        {
            LimpiarCondiciones();
            Txt_CadenaGenerada.Clear();
            Rdb_Asc.Checked = true;

            if (!string.IsNullOrEmpty(sTablaActual))
                PrevisualizarTabla(sTablaActual);
        }

        // ----------------- WHERE building / BETWEEN UI ----------------- Diego Fernando Saquil Gramajo 0901-22-4103 editado 11/10/2025
        private void AgregarWhere(string pieza, string operador)
        {
            if (lstPartesWhere.Count == 0 || string.IsNullOrEmpty(operador)) lstPartesWhere.Add(pieza);
            else lstPartesWhere.Add(operador + " " + pieza);
        }

        private void EnsureBetweenControls()
        {
            if (Txt_ValorCompMin != null) return;

            var parent = Txt_ValorComp.Parent;

            int left = Txt_ValorComp.Left;
            int top = Txt_ValorComp.Top;
            int w = Txt_ValorComp.Width;
            int h = Txt_ValorComp.Height;
            int sep = 6;
            int half = (w - sep) / 2;

            Lbl_ValorCompMin = new Label { Text = "Mín.", AutoSize = true };
            Lbl_ValorCompMax = new Label { Text = "Máx.", AutoSize = true };

            Txt_ValorCompMin = new TextBox();
            Txt_ValorCompMax = new TextBox();

            Lbl_ValorCompMin.SetBounds(left - 35, top + 4, 30, 13);
            Txt_ValorCompMin.SetBounds(left, top, half, h);

            Lbl_ValorCompMax.SetBounds(left + half + sep - 35, top + 4, 30, 13);
            Txt_ValorCompMax.SetBounds(left + half + sep, top, half, h);

            Lbl_ValorCompMin.Visible = Lbl_ValorCompMax.Visible =
                Txt_ValorCompMin.Visible = Txt_ValorCompMax.Visible = false;

            parent.Controls.Add(Lbl_ValorCompMin);
            parent.Controls.Add(Txt_ValorCompMin);
            parent.Controls.Add(Lbl_ValorCompMax);
            parent.Controls.Add(Txt_ValorCompMax);
        }

        public void ToggleBetweenControls()
        {
            EnsureBetweenControls();

            var v = GetComboValor(Cbo_TipoComparador) ?? "";

            bool noValue = v == "IS NULL" || v == "IS NOT NULL";
            bool isBetween = v == "BETWEEN";

            Txt_ValorComp.Visible = !noValue && !isBetween;
            Lbl_ValorCompMin.Visible = (isBetween);
            Lbl_ValorCompMax.Visible = (isBetween);
            Txt_ValorCompMin.Visible = (isBetween);
            Txt_ValorCompMax.Visible = (isBetween);

            if (noValue)
            {
                Txt_ValorComp.Clear();
                if (Txt_ValorCompMin != null) Txt_ValorCompMin.Clear();
                if (Txt_ValorCompMax != null) Txt_ValorCompMax.Clear();
            }
        }
        // ----------------- Guardar/Listar consultas ------------------
        // CAMBIO Nelson Godínez 0901-22-3550 (10/10/2025)
        // - Se obliga a ingresar un nombre no vacío para guardar.
        // - Si está vacío, se muestra alerta y NO se guarda.
        // - Si el usuario cancela el cuadro, se aborta el guardado.
        private void GuardarConsultaAuto()
        {
            string sql = string.IsNullOrWhiteSpace(sSqlActual)
                ? oControlador.ConstruirSql(sTablaActual, Chk_AgregarCondiciones.Checked, lstPartesWhere, lstPartesGroupOrder)
                : sSqlActual;

            if (string.IsNullOrWhiteSpace(sql))
            {
                MessageBox.Show("Genera la consulta primero.");
                return;
            }
            sSqlActual = sql;

            // ---------- Solicitar nombre obligatorio ----------
            string inputNombre = null;

            while (true)
            {
                inputNombre = ShowInputBox(
                    "Guardar consulta personalizada",
                    "Ingresa el nombre con el que deseas guardar la consulta:"
                );

                // Si el usuario presiona Cancelar -> se canela el guardado
                if (inputNombre == null)
                    return;

                // Limpia caracteres inválidos para nombres de archivo/clave
                char[] invalid = System.IO.Path.GetInvalidFileNameChars();
                inputNombre = new string(inputNombre.Where(ch => !invalid.Contains(ch)).ToArray()).Trim();

                if (string.IsNullOrWhiteSpace(inputNombre))
                {
                    // Nombre vacío -> avisar y volver a pedir
                    MessageBox.Show("Debes ingresar un nombre para la consulta.", "Nombre requerido",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    continue;
                }

                // Nombre válido
                break;
            }

            try
            {
                // Si el nombre ya existe, se desambigua con _1, _2
                var existentes = new HashSet<string>(
                    oControlador.ListarConsultasPlano().Select(kv => kv.Key),
                    StringComparer.OrdinalIgnoreCase);

                string unique = inputNombre;
                int i = 1;
                while (existentes.Contains(unique))
                    unique = inputNombre + "_" + (i++).ToString();

                oControlador.GuardarConsulta(unique, sql);
                CargarConsultasGuardadas();

                var lista = Lst_ConsultasGuardadas.DataSource as List<KeyValuePair<string, string>>;
                if (lista != null)
                {
                    int idx = lista.FindIndex(kv => string.Equals(kv.Key, unique, StringComparison.OrdinalIgnoreCase));
                    if (idx >= 0) Lst_ConsultasGuardadas.SelectedIndex = idx;
                }

                MessageBox.Show("Consulta guardada como: " + unique, "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar la consulta.\n" + ex.Message);
            }

            // Validación adicional existente
            string sMsg; Control oFoco;
            if (!ValidarParaGenerarEjecutar(out sMsg, out oFoco))
            {
                MostrarError("No se puede guardar: " + sMsg, oFoco);
                return;
            }
        }
        // Realizado por: Nelson Godínez 0901-22-3550 (10/10/2025)
        // Devuelve el texto ingresado o null si el usuario cancela.
        private static string ShowInputBox(string titulo, string mensaje)
        {
            using (Form form = new Form())
            {
                form.Text = titulo;
                form.StartPosition = FormStartPosition.CenterParent;
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.MinimizeBox = false;
                form.MaximizeBox = false;
                form.ClientSize = new System.Drawing.Size(400, 140);
                form.ShowInTaskbar = false;

                Label label = new Label() { AutoSize = true, Text = mensaje };
                label.SetBounds(10, 10, 380, 20);

                TextBox textBox = new TextBox();
                textBox.SetBounds(10, 35, 380, 25);

                Button buttonOk = new Button() { Text = "Aceptar", DialogResult = DialogResult.OK };
                buttonOk.SetBounds(210, 75, 80, 30);

                Button buttonCancel = new Button() { Text = "Cancelar", DialogResult = DialogResult.Cancel };
                buttonCancel.SetBounds(300, 75, 80, 30);

                form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
                form.AcceptButton = buttonOk;
                form.CancelButton = buttonCancel;

                return form.ShowDialog() == DialogResult.OK ? textBox.Text : null;
            }
        }
        private void CargarConsultasGuardadas()
        {
            try
            {
                var items = oControlador.ListarConsultasPlano();
                Lst_ConsultasGuardadas.DataSource = null;
                Lst_ConsultasGuardadas.DisplayMember = "Key";   // Lo que se muestra (nombre de la consulta)
                Lst_ConsultasGuardadas.ValueMember = "Value";   // Lo que devuelva
                Lst_ConsultasGuardadas.DataSource = items;
            }
            catch { /* Si algo falla, simplemente lo ignora */ }
        }

        // ----------------- Editar: SQL -> UI Bryan Raul Ramirez Lopez 0901-21-8202 + Nelson Godínez 0901-22-3550 editado 11/10/2025
        private void CargarConsultaDesdeSql(string sql)
        {
            _editandoConsulta = true;
            _requiereAgregar = false;
            bCargandoDesdeSql = true;

            try
            {
                LimpiarCondiciones();
                Chk_AgregarCondiciones.Checked = false;

                // ---------------- Tabla ----------------
                var mTable = Regex.Match(sql, @"FROM\s+`?(?<t>[^`\s]+)`?", RegexOptions.IgnoreCase);
                if (mTable.Success)
                {
                    var t = mTable.Groups["t"].Value;
                    SetComboSelectedItem(Cbo_Tabla, t);
                    CargarColumnas(t);
                    sTablaActual = t;
                }

                // ---------------- WHERE ----------------
                // --- WHERE parseado ---
                var conds = oControlador.ParsearWhere(sql).ToList();

                // Limpia y reconstruye _partesWhere COMPLETA según lo parseado
                lstPartesWhere.Clear();
                for (int i = 0; i < conds.Count; i++)
                {
                    var c = conds[i];
                    string pieza = BuildPiezaFromCond(c.Campo, c.Operador, c.Valor1, c.Valor2);
                    string con = (i == 0) ? null : (string.IsNullOrEmpty(c.Conector) ? "AND" : c.Conector);
                    AgregarWhere(pieza, con); 
                }


                lstPartesWhere.Clear();
                bool first = true;
                foreach (var c in conds)
                {
                    string campo = NormalizeCol(c.Campo);
                    string op = c.Operador?.ToUpperInvariant() ?? "=";

                    string pieza;
                    if (op == "BETWEEN")
                    {
                        string left = TryNumOrQuoted(Unquote(c.Valor1));
                        string right = TryNumOrQuoted(Unquote(c.Valor2));
                        pieza = $"`{campo}` BETWEEN {left} AND {right}";
                    }
                    else if (op == "IS NULL" || op == "IS NOT NULL")
                    {
                        pieza = $"`{campo}` {op}";
                    }
                    else if (op == "LIKE")
                    {
                        pieza = $"`{campo}` LIKE {TryNumOrQuoted(Unquote(c.Valor1))}";
                    }
                    else
                    {
                        pieza = $"`{campo}` {op} {TryNumOrQuoted(Unquote(c.Valor1))}";
                    }

                    string con = first ? null : (string.IsNullOrEmpty(c.Conector) ? "AND" : c.Conector.ToUpperInvariant());
                    AgregarWhere(pieza, con);
                    first = false;
                }

                if (lstPartesWhere.Count > 0)
                    Chk_AgregarCondiciones.Checked = true;

                // --------------- GROUP BY ---------------
                var mGroup = Regex.Match(sql, @"GROUP\s+BY\s+`?(?<g>[^`\s]+)`?", RegexOptions.IgnoreCase);
                if (mGroup.Success)
                {
                    var col = NormalizeCol(mGroup.Groups["g"].Value);
                    SetComboSelectedItem(Cbo_AgruparOrdenar, "GROUP BY");
                    SafeSelectColumn(Cbo_CampoOrdenar, col);
                    lstPartesGroupOrder.Add($"GROUP BY `{col}`");
                }

                // --------------- ORDER BY ---------------
                var mOrder = Regex.Match(sql, @"ORDER\s+BY\s+`?(?<c>[^`\s]+)`?(?:\s+(?<dir>ASC|DESC))?", RegexOptions.IgnoreCase);
                if (mOrder.Success)
                {
                    var col = NormalizeCol(mOrder.Groups["c"].Value);
                    var dir = mOrder.Groups["dir"].Success ? mOrder.Groups["dir"].Value.ToUpperInvariant() : "ASC";

                    SetComboSelectedItem(Cbo_AgruparOrdenar, "ORDER BY");
                    SafeSelectColumn(Cbo_CampoOrdenar, col);
                    SetComboSelectedItem(Cbo_Ordenamiento, dir);

                    lstPartesGroupOrder.Add($"ORDER BY `{col}` {dir}");
                    if (dir == "ASC") Rdb_Asc.Checked = true; else Rdb_Des.Checked = true;
                }

                sSqlActual = oControlador.ConstruirSql(
                    sTablaActual,
                    Chk_AgregarCondiciones.Checked,
                    lstPartesWhere,
                    lstPartesGroupOrder
                );
                // Espera a que todo haya enlazado y pinta UI
                this.BeginInvoke(new Action(() => RellenarUIDesdeConds(conds)));
                RellenarUIDesdeConds(conds);
                ToggleBetweenControls();
            }
            finally
            {
                bCargandoDesdeSql = false;
            }
        }

        // Rellena UI a partir de condiciones parseadas (máx 2)
        // Rellena los dos bloques visibles de UI a partir de las condiciones parseadas
        // conds: IEnumerable<(Conector, Campo, Operador, Valor1, Valor2)>
        private void RellenarUIDesdeConds(
    IEnumerable<(string Conector, string Campo, string Operador, string Valor1, string Valor2)> eConds)
        {
            var arr = eConds.ToList();
            _idxComp = -1; _idxLogic = -1;

            if (arr.Count == 0)
            {
                Chk_AgregarCondiciones.Checked = false;
                ToggleBetweenControls();
                return;
            }

            // Elegimos COMPARACIÓN: primera que NO sea "=" (si no hay, la primera)
            int iComp = arr.FindIndex(c => !string.Equals(c.Operador, "=", StringComparison.OrdinalIgnoreCase));
            if (iComp < 0) iComp = 0;
            var comp = arr[iComp];

            // Elegimos LÓGICA: primera "=" distinta de comp (si existe)
            int iLogic = arr.FindIndex(c => string.Equals(c.Operador, "=", StringComparison.OrdinalIgnoreCase));
            if (iLogic == iComp) iLogic = arr.FindIndex(iLogic + 1, c => string.Equals(c.Operador, "=", StringComparison.OrdinalIgnoreCase));

            // --- COMPARACIÓN a UI ---
            SafeSelectColumn(Cbo_CampoComp, NormalizeCol(comp.Campo));
            SetComboSelectedItem(Cbo_TipoComparador, comp.Operador);

            if (string.Equals(comp.Operador, "BETWEEN", StringComparison.OrdinalIgnoreCase))
            {
                EnsureBetweenControls();
                Txt_ValorComp.Visible = false;
                Lbl_ValorCompMin.Visible = Txt_ValorCompMin.Visible = true;
                Lbl_ValorCompMax.Visible = Txt_ValorCompMax.Visible = true;
                Txt_ValorCompMin.Text = Unquote(comp.Valor1);
                Txt_ValorCompMax.Text = Unquote(comp.Valor2);
            }
            else if (string.Equals(comp.Operador, "IS NULL", StringComparison.OrdinalIgnoreCase) ||
                     string.Equals(comp.Operador, "IS NOT NULL", StringComparison.OrdinalIgnoreCase))
            {
                Txt_ValorComp.Clear();
            }
            else if (string.Equals(comp.Operador, "LIKE", StringComparison.OrdinalIgnoreCase) ||
                     string.Equals(comp.Operador, "LIKE_START", StringComparison.OrdinalIgnoreCase) ||
                     string.Equals(comp.Operador, "LIKE_END", StringComparison.OrdinalIgnoreCase))
            {
                var v = Unquote(comp.Valor1);
                if (comp.Operador == "LIKE") v = v.Trim('%');
                else if (comp.Operador == "LIKE_START") v = v.TrimEnd('%');
                else if (comp.Operador == "LIKE_END") v = v.TrimStart('%');
                Txt_ValorComp.Text = v;
            }
            else
            {
                Txt_ValorComp.Text = Unquote(comp.Valor1);
            }

            // Conector por defecto si no viene en la SQL
            SetComboSelectedItem(Cbo_OperadorLogico, string.IsNullOrEmpty(comp.Conector) ? "AND" : comp.Conector);
            _idxComp = iComp;

            // --- LÓGICA a UI (si existe) ---
            if (iLogic >= 0 && iLogic < arr.Count && iLogic != iComp)
            {
                var lg = arr[iLogic];
                SafeSelectColumn(Cbo_CampoCond, NormalizeCol(lg.Campo));
                Txt_ValorCond.Text = Unquote(lg.Valor1);
                // El operador lógico ya está puesto; si no, AND por defecto
                if (Cbo_OperadorLogico.SelectedItem == null)
                    SetComboSelectedItem(Cbo_OperadorLogico, "AND");
                _idxLogic = iLogic;
            }

            Chk_AgregarCondiciones.Checked = true;
            ToggleBetweenControls();
        }
        // ----------------- Utils Diego Fernando Saquil Gramajo 0901-22-4103
        private class ComboItem
        {
            public string Texto { get; set; }
            public string Valor { get; set; }
            public ComboItem(string texto, string valor) { Texto = texto; Valor = valor; }
            public override string ToString() { return Texto; }
        }
        private static string Esc(string s)
        {
            return (s ?? string.Empty).Replace("'", "''");
        }

        private static string TryNumOrQuoted(string raw)
        {
            raw = (raw ?? "").Trim();
            decimal num;
            if (decimal.TryParse(raw, NumberStyles.Any, CultureInfo.InvariantCulture, out num))
                return num.ToString(CultureInfo.InvariantCulture);
            return "'" + Esc(raw) + "'";
        }

        private static string Unquote(string s)
        {
            if (string.IsNullOrEmpty(s)) return s;
            s = s.Trim();
            if (s.StartsWith("'") && s.EndsWith("'") && s.Length >= 2)
                return s.Substring(1, s.Length - 2).Replace("''", "'");
            return s;
        }

        private static string GetComboValor(ComboBox cb)
        {
            if (cb == null || cb.SelectedItem == null) return null;
            var ci = cb.SelectedItem as ComboItem;
            if (ci != null) return ci.Valor;
            return cb.SelectedItem.ToString();
        }

        private static string GetPropText(object obj, string propName)
        {
            if (obj == null) return null;
            if (string.IsNullOrEmpty(propName)) return obj.ToString();
            var p = obj.GetType().GetProperty(propName);
            var v = p == null ? null : p.GetValue(obj, null);
            return v == null ? null : v.ToString();
        }

        private void SetComboSelectedItem(ComboBox cb, string value)
        {
            if (value == null) { cb.SelectedIndex = -1; return; }

            if (cb.DataSource != null)
            {
                var enumerable = cb.DataSource as System.Collections.IEnumerable;
                if (enumerable != null)
                {
                    int i = 0;
                    foreach (var it in enumerable)
                    {
                        var ci = it as ComboItem;
                        if (ci != null)
                        {
                            if (string.Equals(ci.Valor, value, StringComparison.OrdinalIgnoreCase) ||
                                string.Equals(ci.Texto, value, StringComparison.OrdinalIgnoreCase))
                            { cb.SelectedIndex = i; return; }
                        }
                        else
                        {
                            var txt = GetPropText(it, cb.DisplayMember);
                            if (string.Equals(txt, value, StringComparison.OrdinalIgnoreCase) ||
                                string.Equals(it.ToString(), value, StringComparison.OrdinalIgnoreCase))
                            { cb.SelectedIndex = i; return; }
                        }
                        i++;
                    }
                }
                try { cb.SelectedValue = value; } catch { }
                return;
            }

            for (int i = 0; i < cb.Items.Count; i++)
                if (string.Equals(cb.Items[i].ToString(), value, StringComparison.OrdinalIgnoreCase))
                { cb.SelectedIndex = i; return; }

            cb.Items.Add(value);
            cb.SelectedItem = value;
            Rdb_Asc.Checked = true;
            SincronizarOrdenConRadios();
        }

        // ---------- VALIDACIONES ----------
        private void MostrarError(string sMsg, Control oFoco)
        {
            MessageBox.Show(sMsg, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (oFoco != null) oFoco.Focus();
        }

        // Para valores BETWEEN: ambas cajas visibles -> ambas deben tener texto
        // ----------------- Validación BETWEEN (corregido por Nelson Godínez 10/10/2025)
        private bool ValidarBetweenVisibleYCompleto(out string sMsg, out Control oFoco)
        {
            sMsg = null; oFoco = null;

            if (Txt_ValorCompMin != null && Txt_ValorCompMax != null &&
                Txt_ValorCompMin.Visible && Txt_ValorCompMax.Visible)
            {
                if (Txt_ValorCompMin.TextLength == 0)
                { sMsg = "Ingresa el valor mínimo."; oFoco = Txt_ValorCompMin; return false; }

                if (Txt_ValorCompMax.TextLength == 0)
                { sMsg = "Ingresa el valor máximo."; oFoco = Txt_ValorCompMax; return false; }
            }
            return true;
        }
        // Valida antes de AGREGAR la condición LÓGICA (= operador fijo '=').
        private bool ValidarLogicaParaAgregar(out string sMsg, out Control oFoco)
        {
            sMsg = null; oFoco = null;

            if (!Chk_AgregarCondiciones.Checked)
            { sMsg = "Activa 'Agregar condiciones'."; oFoco = Chk_AgregarCondiciones; return false; }

            if (Cbo_CampoCond.SelectedItem == null)
            { sMsg = "Selecciona el campo en Lógica."; oFoco = Cbo_CampoCond; return false; }

            if (Txt_ValorCond.TextLength == 0)
            { sMsg = "Ingresa el valor en Lógica."; oFoco = Txt_ValorCond; return false; }

            // Si ya hay piezas where, debe existir conector (AND/OR)
            if (lstPartesWhere.Count > 0 && Cbo_OperadorLogico.SelectedItem == null)
            { sMsg = "Selecciona el Operador Lógico (AND/OR)."; oFoco = Cbo_OperadorLogico; return false; }

            return true;
        }
        /// Valida antes de AGREGAR la COMPARACIÓN (operador elegido).
        private bool ValidarComparacionParaAgregar(out string sMsg, out Control oFoco)
        {
            sMsg = null; oFoco = null;

            if (!Chk_AgregarCondiciones.Checked)
            { sMsg = "Activa 'Agregar condiciones'."; oFoco = Chk_AgregarCondiciones; return false; }

            if (Cbo_CampoComp.SelectedItem == null)
            { sMsg = "Selecciona el campo en Comparación."; oFoco = Cbo_CampoComp; return false; }

            if (Cbo_TipoComparador.SelectedItem == null)
            { sMsg = "Selecciona el Tipo Comparador."; oFoco = Cbo_TipoComparador; return false; }

            string sOp = GetComboValor(Cbo_TipoComparador) ?? "=";

            if (sOp == "BETWEEN")
            {
                if (!ValidarBetweenVisibleYCompleto(out sMsg, out oFoco)) return false;
            }
            else if (sOp == "IS NULL" || sOp == "IS NOT NULL")
            {
                // no requiere valor
            }
            else
            {
                // LIKE / LIKE_START / LIKE_END / = <> > < >= <= requieren valor
                if (Txt_ValorComp.Visible && Txt_ValorComp.TextLength == 0)
                { sMsg = "Ingresa el valor para la comparación."; oFoco = Txt_ValorComp; return false; }
            }

            if (lstPartesWhere.Count > 0 && Cbo_OperadorLogico.SelectedItem == null)
            { sMsg = "Selecciona el Operador Lógico (AND/OR)."; oFoco = Cbo_OperadorLogico; return false; }

            return true;
        }
        /// Valida antes de AGREGAR agrupar/ordenar.
        private bool ValidarOrdenParaAgregar(out string sMsg, out Control oFoco)
        {
            sMsg = null; oFoco = null;

            if (Cbo_AgruparOrdenar.SelectedItem == null)
            { sMsg = "Selecciona si deseas 'GROUP BY' u 'ORDER BY'."; oFoco = Cbo_AgruparOrdenar; return false; }

            if (Cbo_CampoOrdenar.SelectedItem == null)
            { sMsg = "Selecciona el campo para agrupar/ordenar."; oFoco = Cbo_CampoOrdenar; return false; }

            if (string.Equals(Cbo_AgruparOrdenar.SelectedItem.ToString(), "ORDER BY", StringComparison.OrdinalIgnoreCase))
            {
                if (Cbo_Ordenamiento.SelectedItem == null)
                { sMsg = "Selecciona el sentido de ordenamiento (ASC/DESC)."; oFoco = Cbo_Ordenamiento; return false; }
            }
            return true;
        }
        /// Valida el formulario para GUARDAR/EDITAR consulta.
        private bool ValidarParaGuardarEditar(out string sMsg, out Control oFoco)
        {
            sMsg = null; oFoco = null;

            if (Cbo_Tabla.SelectedItem == null)
            { sMsg = "Selecciona una tabla."; oFoco = Cbo_Tabla; return false; }

            if (Chk_AgregarCondiciones.Checked)
            {
                // Si no hay nada agregado y el usuario empezó a escribir, bloqueamos si está incompleto…
                bool bHayAlgoEscritoLogica = (Cbo_CampoCond.SelectedItem != null || Txt_ValorCond.TextLength > 0);
                bool bHayAlgoEscritoComp =
                    (Cbo_CampoComp.SelectedItem != null || Cbo_TipoComparador.SelectedItem != null ||
                     (Txt_ValorComp.Visible && Txt_ValorComp.TextLength > 0) ||
                     (Txt_ValorCompMin != null && Txt_ValorCompMin.Visible && Txt_ValorCompMin.TextLength > 0) ||
                     (Txt_ValorCompMax != null && Txt_ValorCompMax.Visible && Txt_ValorCompMax.TextLength > 0));

                if (lstPartesWhere.Count == 0 && (bHayAlgoEscritoLogica || bHayAlgoEscritoComp))
                {
                    // Valida ambos bloques según corresponda
                    string sTmp; Control oTmp;

                    // Si hay algo en lógica -> validar lógica
                    if (bHayAlgoEscritoLogica && !ValidarLogicaParaAgregar(out sTmp, out oTmp))
                    { sMsg = sTmp; oFoco = oTmp; return false; }

                    // Si hay algo en comp -> validar comp
                    if (bHayAlgoEscritoComp && !ValidarComparacionParaAgregar(out sTmp, out oTmp))
                    { sMsg = sTmp; oFoco = oTmp; return false; }
                }
            }

            if (Cbo_AgruparOrdenar.SelectedItem != null)
            {
                string sTmp; Control oTmp;
                if (!ValidarOrdenParaAgregar(out sTmp, out oTmp))
                { sMsg = sTmp; oFoco = oTmp; return false; }
            }

            return true;
        }

        // La SQL resultante es un SELECT * FROM `tabla`; sin filtros ni group/order
        private bool EsSelectVacio(string sSql, string sTabla)
        {
            if (string.IsNullOrEmpty(sSql) || string.IsNullOrEmpty(sTabla)) return true;

            string sPat = @"^\s*SELECT\s+\*\s+FROM\s+`?" + Regex.Escape(sTabla) + @"`?\s*;\s*$";
            return Regex.IsMatch(sSql, sPat, RegexOptions.IgnoreCase);
        }

        // Valida todo lo necesario para GENERAR/EJECUTAR evita "select vacío"
        private bool ValidarParaGenerarEjecutar(out string sMsg, out Control oFoco)
        {
            sMsg = null; oFoco = null;

            // Reutiliza la validación general (tabla, bloques incompletos, order incompleto…)
            if (!ValidarParaGuardarEditar(out sMsg, out oFoco))
                return false;

            // Construimos lo que se generaría
            string sSqlPreview = oControlador.ConstruirSql(
                sTablaActual,
                Chk_AgregarCondiciones.Checked,
                lstPartesWhere,
                lstPartesGroupOrder);

            if (EsSelectVacio(sSqlPreview, sTablaActual))
            {
                sMsg = "No hay nada que generar/ejecutar.\n" +
                       "Añade condiciones, agrupamiento u ordenamiento.";
                oFoco = Chk_AgregarCondiciones;
                return false;
            }

            return true;
        }

        // Sincroniza los dos bloques visibles (Lógica y Comparación) con lstPartesWhere
        private void AplicarEdicionEnListasDesdeUI()
        {
            if (!Chk_AgregarCondiciones.Checked) return;

            string conector = GetComboValor(Cbo_OperadorLogico) ?? "AND";

            // --- COMPARACIÓN ---
            if (_idxComp >= 0 && _idxComp < lstPartesWhere.Count && Cbo_CampoComp.SelectedItem != null && Cbo_TipoComparador.SelectedItem != null)
            {
                string campo = Cbo_CampoComp.SelectedItem.ToString();
                string op = GetComboValor(Cbo_TipoComparador) ?? "=";

                string v1 = null, v2 = null;
                if (string.Equals(op, "BETWEEN", StringComparison.OrdinalIgnoreCase))
                {
                    EnsureBetweenControls();
                    v1 = Txt_ValorCompMin == null ? null : Txt_ValorCompMin.Text;
                    v2 = Txt_ValorCompMax == null ? null : Txt_ValorCompMax.Text;
                }
                else
                {
                    v1 = Txt_ValorComp.Text;
                }

                string pieza = BuildPieza(campo, op, v1, v2);
                SetWhereAt(_idxComp, pieza, (_idxComp == 0) ? null : conector);
            }

            // --- LÓGICA ---
            if (_idxLogic >= 0 && _idxLogic < lstPartesWhere.Count && Cbo_CampoCond.SelectedItem != null)
            {
                string campo = Cbo_CampoCond.SelectedItem.ToString();
                string pieza = BuildPieza(campo, "=", Txt_ValorCond.Text, null);
                SetWhereAt(_idxLogic, pieza, (_idxLogic == 0) ? null : conector);
            }
        }

        //Diego Fernando Saquil Gramajo 0901 - 22 -4103 26/09/2025
        private void Btn_Regreso_Click(object sender, EventArgs e)
        {
            Frm_Principal inicio = new Frm_Principal();
            this.Hide();
        }
    }
}
