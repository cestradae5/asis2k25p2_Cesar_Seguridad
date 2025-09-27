using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Capa_Controlador_Consultas;

namespace Capa_Vista_Componente_Consultas
{
    public partial class Frm_Consulta_Compleja : Form
    {
        private const string DSN = "Prueba1";
        public const string DB = "controlempleados";

        private Controlador _controlador;
        private string _tablaActual = null;


        private readonly List<string> _partesWhere = new List<string>();
        private readonly List<string> _partesGroupOrder = new List<string>();
        // Rellena los dos bloques visibles de UI a partir de las condiciones parseadas Nelson Jose Godinez Mendez 0901-22-3550 09/26/2025
        private void RellenarUIDesdeConds(
            IEnumerable<(string Conector, string Campo, string Operador, string Valor1, string Valor2)> conds)
        {
            int idx = 0;
            foreach (var c in conds)
            {
                var campo = NormalizeCol(c.Campo);

                if (idx == 0)
                {
                    SafeSelectColumn(Cbo_CampoCond, campo);
                    Txt_ValorCond.Text = c.Operador == "LIKE"
                        ? Unquote(c.Valor1).Trim('%')
                        : Unquote(c.Valor1);
                }
                else if (idx == 1)
                {
                    SafeSelectColumn(Cbo_CampoComp, campo);
                    SetComboSelectedItem(Cbo_TipoComparador, c.Operador);

                    if (c.Operador == "BETWEEN")
                    {
                        EnsureBetweenControls();
                        Txt_ValorComp.Visible = false;
                        Lbl_ValorCompMin.Visible = Txt_ValorCompMin.Visible = true;
                        Lbl_ValorCompMax.Visible = Txt_ValorCompMax.Visible = true;
                        Txt_ValorCompMin.Text = Unquote(c.Valor1);
                        Txt_ValorCompMax.Text = Unquote(c.Valor2);
                    }
                    else
                    {
                        Txt_ValorComp.Text = c.Operador == "LIKE"
                            ? Unquote(c.Valor1).Trim('%')
                            : Unquote(c.Valor1);
                    }

                    SetComboSelectedItem(Cbo_OperadorLogico,
                        string.IsNullOrEmpty(c.Conector) ? "AND" : c.Conector);
                }
                else break; // sólo mostramos 2 en UI
                idx++;
            }

            if (idx > 0) Chk_AgregarCondiciones.Checked = true;
            ToggleBetweenControls();
        }

        private bool _cargandoDesdeSql = false;
        // Guarda la última SQL generada, sin mostrarla en la UI
        private string _sqlActual = string.Empty;


        // BETWEEN dinámico
        private TextBox Txt_ValorCompMin;
        private TextBox Txt_ValorCompMax;
        private Label Lbl_ValorCompMin;
        private Label Lbl_ValorCompMax;

        public Frm_Consulta_Compleja()
        {
            InitializeComponent();

            this.KeyPreview = true;
            this.KeyDown += (s, e) => { if (e.Control && e.KeyCode == Keys.L) { LimpiarTodo(); e.Handled = true; } };
            Txt_CadenaGenerada.Visible = false;   // <- oculta la caja
            Txt_CadenaGenerada.TabStop = false;   // <- que no reciba foco con Tab
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
            CargarEventos();
        }

        private void CargarEventos()
        {
            this.Load += Frm_Consulta_Compleja_Load;

            // Tabla
            Cbo_Tabla.SelectedIndexChanged += (s, e) =>
            {
                _tablaActual = Cbo_Tabla.SelectedItem == null ? null : Cbo_Tabla.SelectedItem.ToString();
                CargarColumnas(_tablaActual);

                if (!_cargandoDesdeSql)
                {
                    LimpiarCondiciones();
                    Txt_CadenaGenerada.Clear();
                }

                PrevisualizarTabla(_tablaActual);
            };

            // Buscar (refresh preview)
            // Radios ASC/DES sincronizan combo
            Rdb_Asc.CheckedChanged += (s, e) => { if (Rdb_Asc.Checked) Cbo_Ordenamiento.SelectedItem = "ASC"; };
            Rdb_Des.CheckedChanged += (s, e) => { if (Rdb_Des.Checked) Cbo_Ordenamiento.SelectedItem = "DESC"; };

            // ---- Lógica Bryan Raul Ramirez Lopez 0901-21-8202 26/09/2025
            Btn_AgregarCond.Click += (s, e) =>
            {
                if (!Chk_AgregarCondiciones.Checked) return;
                if (Cbo_CampoCond.SelectedItem == null) { MessageBox.Show("Selecciona un campo."); return; }

                var val = Txt_ValorCond.Text.Trim();
                if (val.Length == 0) { MessageBox.Show("Ingresa un valor."); return; }

                var operador = _partesWhere.Count == 0 ? null
                               : (GetComboValor(Cbo_OperadorLogico) ?? "AND");

                var campo = Cbo_CampoCond.SelectedItem.ToString();
                string rhs = decimal.TryParse(val, NumberStyles.Any, CultureInfo.InvariantCulture, out var num)
                             ? num.ToString(CultureInfo.InvariantCulture)
                             : $"'{Esc(val)}'";

                var pieza = $"`{campo}` = {rhs}";
                AgregarWhere(pieza, operador);
            };

            // ---- Comparación Nelson Jose Godinez Mendez 0901-22-3550 26/09/2025
            Cbo_TipoComparador.SelectedIndexChanged += (s, e) => ToggleBetweenControls();

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
                        {
                            EnsureBetweenControls();
                            var minRaw = (Txt_ValorCompMin.Text ?? "").Trim();
                            var maxRaw = (Txt_ValorCompMax.Text ?? "").Trim();
                            if (minRaw.Length == 0 || maxRaw.Length == 0)
                            { MessageBox.Show("Completa Mín. y Máx."); return; }

                            string left = TryNumOrQuoted(minRaw);
                            string right = TryNumOrQuoted(maxRaw);
                            pieza = $"`{campo}` BETWEEN {left} AND {right}";
                            break;
                        }

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

                string conector = _partesWhere.Count == 0
                    ? null
                    : (GetComboValor(Cbo_OperadorLogico) ?? "AND");

                AgregarWhere(pieza, conector);
            };

            // ---- Agrupar / Ordenar Diego Fernando Saquil Gramajo 0901-22-4103 26/09/2025
            Btn_AgregarOrden.Click += (s, e) =>
            {
                if (Cbo_AgruparOrdenar.SelectedItem == null || Cbo_CampoOrdenar.SelectedItem == null)
                { MessageBox.Show("Selecciona modo y campo."); return; }

                string modo = Cbo_AgruparOrdenar.SelectedItem.ToString();
                string campo = Cbo_CampoOrdenar.SelectedItem.ToString();

                if (modo == "GROUP BY")
                    _partesGroupOrder.Add($"GROUP BY `{campo}`");
                else
                {
                    string ord = Cbo_Ordenamiento.SelectedItem == null
                        ? (Rdb_Asc.Checked ? "ASC" : "DESC")
                        : Cbo_Ordenamiento.SelectedItem.ToString();
                    _partesGroupOrder.Add($"ORDER BY `{campo}` {ord}");
                }
            };

            // ---- Ejecutar ---- Juan Carlos Sandoval Quej 0901-22-4170 26/09/2025
            Btn_Ejecutar.Click += (s, e) =>
            {
                var sql = string.IsNullOrWhiteSpace(_sqlActual)
                    ? _controlador.ConstruirSql(_tablaActual, Chk_AgregarCondiciones.Checked, _partesWhere, _partesGroupOrder)
                    : _sqlActual;

                _sqlActual = sql; // guardamos lo que se ejecuta

                sql = _controlador.ReescribirSelectSeguroSiHayTime(DB, _tablaActual, sql);

                try
                {
                    var dt = _controlador.EjecutarConsulta(sql);
                    Dgv_Preview.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al ejecutar:\n" + ex.Message);
                }
            };
            // ---- Limpiar ----
            Btn_Limpiar.Click += (s, e) => LimpiarTodo();

            // ---- Consultas guardadas ---- Juan Carlos Sandoval Quej 0901-22-4170 26/09/2025
            Btn_AgregarConsulta.Click += (s, e) => GuardarConsultaAuto();

            Btn_EditarConsulta.Click += (s, e) =>
            {
                if (Lst_ConsultasGuardadas.SelectedItem == null) { MessageBox.Show("Selecciona una consulta."); return; }
                var sql = Lst_ConsultasGuardadas.SelectedValue as string ?? "";
                if (string.IsNullOrWhiteSpace(sql)) return;
                CargarConsultaDesdeSql(sql);
            };

            Btn_EliminarConsulta.Click += (s, e) =>
            {
                if (Lst_ConsultasGuardadas.SelectedItem == null) { MessageBox.Show("Selecciona una consulta."); return; }
                string nombre = Lst_ConsultasGuardadas.GetItemText(Lst_ConsultasGuardadas.SelectedItem);

                if (MessageBox.Show($"¿Eliminar \"{nombre}\"?", "Confirmación",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (_controlador.EliminarConsulta(nombre))
                    {
                        CargarConsultasGuardadas();
                        Txt_CadenaGenerada.Clear();
                        MessageBox.Show("Consulta eliminada.");
                    }
                    else MessageBox.Show("No se pudo eliminar.");
                }
            };

            // Al seleccionar, mostrar SQL en la caja
            Lst_ConsultasGuardadas.SelectedIndexChanged += (s, e) =>
            {
                var sql = Lst_ConsultasGuardadas.SelectedValue as string;
                if (sql != null) Txt_CadenaGenerada.Text = sql;
            };

            // Doble click: cargar y ejecutar
            Lst_ConsultasGuardadas.DoubleClick += (s, e) =>
            {
                var sql = Lst_ConsultasGuardadas.SelectedValue as string;
                if (!string.IsNullOrEmpty(sql))
                {
                    Txt_CadenaGenerada.Text = sql;
                    Btn_Ejecutar.PerformClick();
                }
            };
        }

        private void Frm_Consulta_Compleja_Load(object sender, EventArgs e)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;

            _controlador = new Controlador(DSN, DB);

            CargarTablas();

            // Combos fijos Nelson Jose Godinez Mendez 0901-22-3550 26/09/2025
            if (Cbo_OperadorLogico.DataSource == null)
                Cbo_OperadorLogico.DataSource = new List<ComboItem> {
                    new ComboItem("Y (AND)", "AND"),
                    new ComboItem("O (OR)", "OR")
                };
            Cbo_OperadorLogico.DisplayMember = "Texto";
            Cbo_OperadorLogico.ValueMember = "Valor";

            if (Cbo_TipoComparador.DataSource == null)
                Cbo_TipoComparador.DataSource = new List<ComboItem> {
                    new ComboItem("Igual (=)",              "="),
                    new ComboItem("Distinto (≠)",           "<>"),
                    new ComboItem("Mayor (>)",              ">"),
                    new ComboItem("Menor (<)",              "<"),
                    new ComboItem("Mayor o igual (≥)",      ">="),
                    new ComboItem("Menor o igual (≤)",      "<="),
                    new ComboItem("Contiene",               "LIKE"),
                    new ComboItem("Comienza con",           "LIKE_START"),
                    new ComboItem("Termina con",            "LIKE_END"),
                    new ComboItem("Entre",                  "BETWEEN"),
                    new ComboItem("Es nulo",                "IS NULL"),
                    new ComboItem("No es nulo",             "IS NOT NULL")
                };
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

        // --------- Helpers de datos Nelson Jose Godinez Mendez 0901 - 22 -3550 26/09/2025
        private void CargarTablas()
        {
            try
            {
                Cbo_Tabla.Items.Clear();
                foreach (var t in _controlador.ObtenerTablas()) Cbo_Tabla.Items.Add(t);
                if (Cbo_Tabla.Items.Count > 0) Cbo_Tabla.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron obtener las tablas.\n" + ex.Message);
            }
        }

        private void CargarColumnas(string tabla)
        {
            Cbo_CampoCond.Items.Clear();
            Cbo_CampoComp.Items.Clear();
            Cbo_CampoOrdenar.Items.Clear();

            if (string.IsNullOrEmpty(tabla)) return;

            foreach (var c in _controlador.ObtenerColumnas(tabla))
            {
                Cbo_CampoCond.Items.Add(c);
                Cbo_CampoComp.Items.Add(c);
                Cbo_CampoOrdenar.Items.Add(c);
            }
        }
        // Quita backticks/comillas y prefijo (db.tbl.col o e.col -> col)
        private static string NormalizeCol(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return s;
            s = s.Trim().Trim('`', '"');
            int lastDot = s.LastIndexOf('.');
            if (lastDot >= 0) s = s.Substring(lastDot + 1);
            return s;
        }

        // Selección tolerante en combos de columnas
        private void SetComboSelectedItemLoose(ComboBox cb, string value)
        {
            value = NormalizeCol(value);
            if (string.IsNullOrEmpty(value)) { cb.SelectedIndex = -1; return; }

            // Sin DataSource
            if (cb.DataSource == null)
            {
                for (int i = 0; i < cb.Items.Count; i++)
                {
                    var txt = NormalizeCol(cb.Items[i]?.ToString());
                    if (string.Equals(txt, value, StringComparison.OrdinalIgnoreCase))
                    { cb.SelectedIndex = i; return; }
                }
                // fallback
                cb.Items.Add(value);
                cb.SelectedItem = value;
                return;
            }

            // Con DataSource
            var enumerable = cb.DataSource as System.Collections.IEnumerable;
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
                { cb.SelectedIndex = idx; return; }
                idx++;
            }

          
            try { cb.SelectedValue = value; } catch { /* ignore */ }
        }

        // Por si el combo aún no tiene items, fuerza agregar y luego selecciona
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
                var sql = $"SELECT * FROM `{tabla}` LIMIT 50;";
                sql = _controlador.ReescribirSelectSeguroSiHayTime(DB, tabla, sql);
                var dt = _controlador.EjecutarConsulta(sql);
                Dgv_Preview.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar la tabla.\n" + ex.Message);
            }
        }

        // --------- Estado y limpieza ---------- Bryan Raul Ramirez Lopez 0901-21-8202
        private void LimpiarCondiciones()
        {
            _partesWhere.Clear();
            _partesGroupOrder.Clear();

            Cbo_OperadorLogico.SelectedItem = null;
            Cbo_CampoCond.SelectedItem = null;
            Txt_ValorCond.Clear();

            Cbo_TipoComparador.SelectedItem = null;
            Cbo_CampoComp.SelectedItem = null;
            Txt_ValorComp.Clear();

            Txt_ValorCompMin?.Clear();
            Txt_ValorCompMax?.Clear();

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

            if (!string.IsNullOrEmpty(_tablaActual))
                PrevisualizarTabla(_tablaActual);
        }

        // --------- WHERE building / BETWEEN UI ---------- Diego Fernando Saquil Gramajo 0901-22-4103
        private void AgregarWhere(string pieza, string operador)
        {
            if (_partesWhere.Count == 0 || string.IsNullOrEmpty(operador)) _partesWhere.Add(pieza);
            else _partesWhere.Add(operador + " " + pieza);
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
            Lbl_ValorCompMin.Visible = Txt_ValorCompMin.Visible = isBetween;
            Lbl_ValorCompMax.Visible = Txt_ValorCompMax.Visible = isBetween;

            if (noValue)
            {
                Txt_ValorComp.Clear();
                Txt_ValorCompMin.Clear();
                Txt_ValorCompMax.Clear();
            }
        }

        // --------- Consultas guardadas ----------  Diego Fernando Saquil Gramajo 0901-22-4103 26/09/2025
        private void GuardarConsultaAuto()
        {
            // Usa la SQL en memoria o constrúyela si aún no existe
            string sql = string.IsNullOrWhiteSpace(_sqlActual)
                ? _controlador.ConstruirSql(_tablaActual, Chk_AgregarCondiciones.Checked, _partesWhere, _partesGroupOrder)
                : _sqlActual;

            if (string.IsNullOrWhiteSpace(sql))
            {
                MessageBox.Show("Genera la consulta primero.");
                return;
            }

            _sqlActual = sql; // persistimos lo que realmente vamos a guardar

            var baseName = string.IsNullOrEmpty(_tablaActual) ? "consulta" : _tablaActual;
            var name = $"{baseName}_{DateTime.Now:yyyyMMdd_HHmmss}";

            try
            {
                var existentes = _controlador.ListarConsultasPlano()
                                             .Select(kv => kv.Key)
                                             .ToHashSet(StringComparer.OrdinalIgnoreCase);
                var unique = name; int i = 1;
                while (existentes.Contains(unique)) unique = $"{name}_{i++}";

                _controlador.GuardarConsulta(unique, sql);
                CargarConsultasGuardadas();

                // Seleccionar la recién guardada
                if (Lst_ConsultasGuardadas.DataSource is List<KeyValuePair<string, string>> lista)
                {
                    int idx = lista.FindIndex(kv => string.Equals(kv.Key, unique, StringComparison.OrdinalIgnoreCase));
                    if (idx >= 0) Lst_ConsultasGuardadas.SelectedIndex = idx;
                }

                MessageBox.Show("Consulta guardada.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar la consulta.\n" + ex.Message);
            }
        }
        private void CargarConsultasGuardadas()
        {
            try
            {
                var items = _controlador.ListarConsultasPlano(); // List<KeyValuePair<string,string>>
                Lst_ConsultasGuardadas.DataSource = null;
                Lst_ConsultasGuardadas.DisplayMember = "Key";
                Lst_ConsultasGuardadas.ValueMember = "Value";
                Lst_ConsultasGuardadas.DataSource = items;
            }
            catch {  }
        }

        // --------- Editar: SQL -> UI ---------- Nelson Jose Godinez Mendez 0901-22-3550 26/09/2025
        private void CargarConsultaDesdeSql(string sql)
        {
            LimpiarCondiciones();
            Chk_AgregarCondiciones.Checked = false;

            // --- Tabla ---
            var mTable = Regex.Match(sql, @"FROM\s+`?(?<t>[^`\s]+)`?", RegexOptions.IgnoreCase);
            if (mTable.Success)
            {
                var t = mTable.Groups["t"].Value;
                _cargandoDesdeSql = true;

                // Selecciona la tabla (lanza SelectedIndexChanged)
                SetComboSelectedItem(Cbo_Tabla, t);

                // Asegura columnas ya mismo (por si el evento aún no corrió)
                CargarColumnas(t);

                _cargandoDesdeSql = false;
                _tablaActual = t;
            }

            // --- WHERE parseado (de tu Controlador) ---
            var conds = _controlador.ParsearWhere(sql);

            // --- GROUP BY ---
            var mGroup = Regex.Match(sql, @"GROUP\s+BY\s+`?(?<g>[^`\s]+)`?", RegexOptions.IgnoreCase);
            if (mGroup.Success)
            {
                var col = mGroup.Groups["g"].Value;
                SetComboSelectedItem(Cbo_AgruparOrdenar, "GROUP BY");
                // Selección tolerante
                this.BeginInvoke(new Action(() => SafeSelectColumn(Cbo_CampoOrdenar, col)));
                _partesGroupOrder.Add($"GROUP BY `{NormalizeCol(col)}`");
            }

            // --- ORDER BY ---
            var mOrder = Regex.Match(sql, @"ORDER\s+BY\s+`?(?<c>[^`\s]+)`?(?:\s+(?<dir>ASC|DESC))?", RegexOptions.IgnoreCase);
            if (mOrder.Success)
            {
                var col = mOrder.Groups["c"].Value;
                var dir = mOrder.Groups["dir"].Success ? mOrder.Groups["dir"].Value.ToUpperInvariant() : "ASC";
                SetComboSelectedItem(Cbo_AgruparOrdenar, "ORDER BY");

                this.BeginInvoke(new Action(() => SafeSelectColumn(Cbo_CampoOrdenar, col)));
                SetComboSelectedItem(Cbo_Ordenamiento, dir);

                _partesGroupOrder.Add($"ORDER BY `{NormalizeCol(col)}` {dir}");
                if (dir == "ASC") Rdb_Asc.Checked = true; else Rdb_Des.Checked = true;
            }

            // Refresca SQL en memoria
            _sqlActual = _controlador.ConstruirSql(
                _tablaActual,
                Chk_AgregarCondiciones.Checked,
                _partesWhere,
                _partesGroupOrder
            );

            // >>> Espera a que todos los combos hayan terminado de enlazar y PINTA UI
            this.BeginInvoke(new Action(() => RellenarUIDesdeConds(conds)));
        }

        // --------- Utils ---------- Bryan Raul Ramirez Lopez 0901-21-8202 26/09/2025
        private class ComboItem
        {
            public string Texto { get; set; }
            public string Valor { get; set; }
            public ComboItem(string texto, string valor) { Texto = texto; Valor = valor; }
            public override string ToString() => Texto;
        }

        private static string Esc(string s) => (s ?? string.Empty).Replace("'", "''");

        private static string TryNumOrQuoted(string raw)
        {
            raw = (raw ?? "").Trim();
            if (decimal.TryParse(raw, NumberStyles.Any, CultureInfo.InvariantCulture, out var num))
                return num.ToString(CultureInfo.InvariantCulture);
            return $"'{Esc(raw)}'";
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
            if (cb.SelectedItem is ComboItem ci) return ci.Valor;
            return cb.SelectedItem.ToString();
        }

        private static string GetPropText(object obj, string propName)
        {
            if (obj == null) return null;
            if (string.IsNullOrEmpty(propName)) return obj.ToString();
            var p = obj.GetType().GetProperty(propName);
            var v = p?.GetValue(obj, null);
            return v?.ToString();
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
                        if (it is ComboItem ci)
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
                try { cb.SelectedValue = value; } catch { /* ignore */ }
                return;
            }

            for (int i = 0; i < cb.Items.Count; i++)
                if (string.Equals(cb.Items[i].ToString(), value, StringComparison.OrdinalIgnoreCase))
                { cb.SelectedIndex = i; return; }

            cb.Items.Add(value);
            cb.SelectedItem = value;
        }
//Diego Fernando Saquil Gramajo 0901 - 22 -4103 26/09/2025
        private void Btn_Regreso_Click(object sender, EventArgs e)
        {
            Frm_Principal inicio = new Frm_Principal();
            this.Hide();
        }
    }
}
