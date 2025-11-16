using Capa_Controlador_Polizas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa_Vista_Polizas
{
    public partial class Frm_DetallePolizas : Form
    {
        private Cls_PolizaControlador cControlador = new Cls_PolizaControlador();
        private List<(string sCodigoCuenta, bool bTipo, decimal dValor)> lDetalles = new List<(string, bool, decimal)>();

        private string sModo; // "insertar", "editar", "lectura"
        private int iIdPoliza;

        private DataTable dtDetalle = new DataTable();

        // variables de edición de filas del detalle
        private int iFilaSeleccionada = -1; 
        private bool bEditandoFila = false;  

        //variable para habilitar modo edicion
        private bool bModoEdicionGeneral = false; // si se está editando toda la póliza



        //constructor para abrir detalle ya existente
        public Frm_DetallePolizas(int idPoliza, string sModo)
        {
            InitializeComponent();
            iIdPoliza = idPoliza;
            this.sModo = sModo;

            InicializarFormulario();

            if (sModo != "insertar")
                Txt_IdPoliza.Text = idPoliza.ToString();
            else
                Dtp_Fecha.Value = DateTime.Now;
        }

        private void InicializarFormulario()
        {
            CargarComboCuentas();
            CargarComboTipo();

            dtDetalle.Columns.Add("CodigoCuenta", typeof(string));
            dtDetalle.Columns.Add("NombreCuenta", typeof(string));
            dtDetalle.Columns.Add("Tipo", typeof(string));
            dtDetalle.Columns.Add("Valor", typeof(decimal));
            Dgv_DetallePoliza.DataSource = dtDetalle;

            if (sModo == "insertar")
            {
                //genera el siguiente ID automáticamente con la fecha actual
                int isiguienteId = cControlador.ObtenerSiguienteIdEncabezado(DateTime.Now);
                iIdPoliza = isiguienteId;
                Txt_IdPoliza.Text = isiguienteId.ToString();
                Txt_IdPoliza.Enabled = false; // bloquear campo

                ModoInsercion();
            }
            else if (sModo == "editar")
            {
                Txt_IdPoliza.Enabled = false; // bloquear id
                CargarEncabezadoExistente();
                ModoEdicion();
                CargarDetallePolizaExistente();
            }
            else // lectura
            {
                Txt_IdPoliza.Enabled = false; // bloquear id
                CargarEncabezadoExistente();
                ModoLectura();
                CargarDetallePolizaExistente();
            }
        }

        private void CargarComboCuentas()
        {
            try
            {
                DataTable dt = cControlador.ObtenerCuentasContables();
                Cmb_CodigoCuenta.DataSource = dt;
                Cmb_CodigoCuenta.DisplayMember = "Cmp_CtaNombre";
                Cmb_CodigoCuenta.ValueMember = "Pk_Codigo_Cuenta";
                Cmb_CodigoCuenta.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar cuentas: " + ex.Message);
            }
        }

        private void CargarComboTipo()
        {
            Cmb_Tipo.Items.Clear();
            Cmb_Tipo.Items.Add("Cargo");
            Cmb_Tipo.Items.Add("Abono");
            Cmb_Tipo.SelectedIndex = -1;
        }

        private void ModoInsercion()
        {
            Btn_Ingresar.Enabled = false;
            Btn_Editar.Enabled = false;
            Btn_Grabar.Enabled = true;
            Btn_Cancelar.Enabled = true;
            Btn_Quitar.Enabled = true;
            Btn_Salir.Enabled = true;
        }

        private void ModoEdicion()
        {
            CargarEncabezadoExistente();
            

            // Bloquear campos
            Txt_IdPoliza.Enabled = false;
            Dtp_Fecha.Enabled = false;
            Txt_Concepto.Enabled = true;

            // Ajustar botones
            Btn_Ingresar.Enabled = false;
            Btn_Editar.Enabled = true;
            Btn_Quitar.Enabled = true;
            Btn_Cancelar.Enabled = true;
            Btn_Salir.Enabled = true;

            Btn_Grabar.Enabled = true;

            bModoEdicionGeneral = true;
            CargarDetallePolizaExistente();
        }


        private void ModoLectura()
        {
            CargarEncabezadoExistente();   
            CargarDetallePolizaExistente(); 
            DeshabilitarCampos();
            Btn_Ingresar.Enabled = false;
            Btn_Editar.Enabled = false;
            Btn_Grabar.Enabled = false;
            Btn_Cancelar.Enabled = false;
            Btn_Refrescar.Enabled = false; 
            Btn_Quitar.Enabled = false;
            Btn_Aceptar.Enabled = false;  
            Btn_Salir.Enabled = true;
        }

        private void DeshabilitarCampos()
        {
            foreach (Control ctrl in this.Controls)
                if (!(ctrl is Button))
                    ctrl.Enabled = false;
        }

        // Cargar encabezado
        private void CargarEncabezadoExistente()
        {
            try
            {
                DataTable dtEncabezado = cControlador.ObtenerEncabezados();
                DataRow[] fila = dtEncabezado.Select($"Codigo = {iIdPoliza}");

                if (fila.Length > 0)
                {
                    Dtp_Fecha.Value = Convert.ToDateTime(fila[0]["Fecha"]);
                    Txt_Concepto.Text = fila[0]["Concepto"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar encabezado: " + ex.Message);
            }
        }

        // Cargar detalles
        private void CargarDetallePolizaExistente()
        {
            try
            {
                // Ahora pasamos Id + Fecha (la fecha ya está en Dtp_Fecha porque antes cargamos encabezado)
                DataTable dtDB = cControlador.ObtenerDetalles(iIdPoliza, Dtp_Fecha.Value);

                dtDetalle.Rows.Clear();
                lDetalles.Clear();

                foreach (DataRow row in dtDB.Rows)
                {
                    string sCodigo = row["CodigoCuenta"].ToString();
                    string sNombre = row["NombreCuenta"].ToString();
                    bool bTipo = Convert.ToBoolean(row["Tipo"]); // 1 = Cargo, 0 = Abono
                    decimal dValor = Convert.ToDecimal(row["Valor"]);

                    dtDetalle.Rows.Add(sCodigo, sNombre, bTipo ? "Cargo" : "Abono", dValor);
                    lDetalles.Add((sCodigo, bTipo, dValor));
                }

                ActualizarTotales();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar detalle: " + ex.Message);
            }
        }

        private void ActualizarTotales()
        {
            decimal dCargo = 0m, dAbono = 0m;

            foreach (DataRow row in dtDetalle.Rows)
            {
                if (row["Valor"] == DBNull.Value) continue;

                decimal dValor;
                if (!decimal.TryParse(row["Valor"].ToString(), out dValor)) continue;

                var tipo = (row["Tipo"]?.ToString() ?? "").Trim();
                if (tipo.Equals("Cargo", StringComparison.OrdinalIgnoreCase))
                    dCargo += dValor;
                else
                    dAbono += dValor;
            }

            decimal dDif = dCargo - dAbono;

            Lbl_TotalCargo.Text = dCargo.ToString("N2");
            Lbl_TotalAbono.Text = dAbono.ToString("N2");
            Lbl_Diferencial.Text = dDif.ToString("N2");
            Lbl_Diferencial.ForeColor = dDif == 0 ? Color.DarkGreen : Color.Red;
        }


        private void Btn_Aceptar_Click(object sender, EventArgs e)
        {
            try
            {

                if (Cmb_CodigoCuenta.SelectedIndex == -1 ||Cmb_Tipo.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(Txt_Valor.Text))
                {
                    MessageBox.Show("Debe completar todos los campos antes de agregar un detalle.",
                                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(Txt_Valor.Text.Trim(), out decimal dValor) || dValor <= 0)
                {
                    MessageBox.Show("El valor debe ser numérico y mayor a cero.",
                                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string sCodigo = Cmb_CodigoCuenta.SelectedValue.ToString();
                string sNombre = Cmb_CodigoCuenta.Text;
                bool bTipo = Cmb_Tipo.SelectedItem.ToString() == "Cargo";
                string sTipo = bTipo ? "Cargo" : "Abono";

                bool existe = lDetalles.Any(x => x.sCodigoCuenta == sCodigo && x.bTipo == bTipo);
                if (existe)
                {
                    if (MessageBox.Show("Ya existe un renglón con esa cuenta y ese tipo.\n¿Desea agregar otro igualmente?",
                                        "Duplicado detectado", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        return;
                }

                // Agregar
                dtDetalle.Rows.Add(sCodigo, sNombre, sTipo, dValor);
                lDetalles.Add((sCodigo, bTipo, dValor));
                Txt_Valor.Clear();
                ActualizarTotales();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar detalle: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_Grabar_Click(object sender, EventArgs e)
        {
            try
            {
                // Evita doble clic durante el guardado
                Btn_Grabar.Enabled = false;

                //debe haber al menos una línea
                if (lDetalles.Count == 0)
                {
                    MessageBox.Show("Debe ingresar al menos una cuenta detalle antes de grabar.",
                                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("¿Desea guardar los cambios de esta póliza?",
                                    "Confirmar guardado",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question) == DialogResult.No)
                    return;

                //datos del encabezado
                DateTime dFecha = Dtp_Fecha.Value.Date;
                string sConcepto = Txt_Concepto.Text.Trim();

                //llamada al controlador según modo de la ventana
                bool exito = false;

                if (sModo == "insertar")
                {
                    // ID por mes y año 
                    iIdPoliza = cControlador.ObtenerSiguienteIdEncabezado(dFecha);
                    Txt_IdPoliza.Text = iIdPoliza.ToString();

                    exito = cControlador.InsertarPoliza(dFecha, sConcepto, lDetalles);
                }
                else if (sModo == "editar")
                {
                    // bloquea edición si el periodo está cerrado 
                    exito = cControlador.ActualizarPoliza(iIdPoliza, dFecha, sConcepto, lDetalles);
                }
                else
                {
                    MessageBox.Show("El formulario está en modo lectura. No puede grabar.",
                                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (exito)
                {
                    MessageBox.Show("Cambios guardados correctamente.",
                                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar póliza: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Btn_Grabar.Enabled = true;
            }
        }

        private void Btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_Quitar_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (Dgv_DetallePoliza.CurrentRow == null)
                {
                    MessageBox.Show("Seleccione una fila para quitar.", "Advertencia",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int indice = Dgv_DetallePoliza.CurrentRow.Index;

                if (MessageBox.Show("¿Desea quitar la línea seleccionada del detalle?",
                                    "Quitar detalle",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question) == DialogResult.No)
                    return;

                if (indice >= 0 && indice < dtDetalle.Rows.Count)
                {
                    dtDetalle.Rows.RemoveAt(indice);
                    lDetalles.RemoveAt(indice);
                    Dgv_DetallePoliza.ClearSelection();
                    ActualizarTotales();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al quitar detalle: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_Ingresar_Click(object sender, EventArgs e)
        {
            Btn_Editar.Enabled = true;
            Btn_Grabar.Enabled = true;
            Btn_Cancelar.Enabled = true;
            Btn_Ingresar.Enabled = false;
        }

        private void Btn_Editar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!bEditandoFila || iFilaSeleccionada < 0)
                {
                    MessageBox.Show("Seleccione primero una fila del detalle para editar.",
                                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validación de diseño
                if (Cmb_CodigoCuenta.SelectedIndex == -1 ||
                    Cmb_Tipo.SelectedIndex == -1 ||
                    string.IsNullOrWhiteSpace(Txt_Valor.Text))
                {
                    MessageBox.Show("Debe llenar Código de Cuenta, Tipo y Valor.", "Advertencia",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(Txt_Valor.Text.Trim(),
                                      NumberStyles.Number,
                                      CultureInfo.InvariantCulture,
                                      out decimal dValor) || dValor <= 0)
                {
                    MessageBox.Show("El valor debe ser numérico y mayor a cero.", "Advertencia",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // nuevos valores
                string sCodigo = Cmb_CodigoCuenta.SelectedValue?.ToString();
                if (string.IsNullOrWhiteSpace(sCodigo))
                {
                    MessageBox.Show("Debe seleccionar una cuenta válida.", "Advertencia",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string sNombre = Cmb_CodigoCuenta.Text;
                bool bTipo = Cmb_Tipo.SelectedItem.ToString() == "Cargo";
                string sTipo = bTipo ? "Cargo" : "Abono";

                // evitar duplicado exacto en otra fila
                bool yaExiste = lDetalles
                    .Where((x, idx) => idx != iFilaSeleccionada)
                    .Any(x => x.sCodigoCuenta == sCodigo && x.bTipo == bTipo);
                if (yaExiste)
                {
                    if (MessageBox.Show("Ya existe otra línea con esa cuenta y tipo.\n¿Desea continuar?",
                                        "Posible duplicado",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question) == DialogResult.No)
                        return;
                }

                // Actualizar DataTable
                dtDetalle.Rows[iFilaSeleccionada]["CodigoCuenta"] = sCodigo;
                dtDetalle.Rows[iFilaSeleccionada]["NombreCuenta"] = sNombre;
                dtDetalle.Rows[iFilaSeleccionada]["Tipo"] = sTipo;
                dtDetalle.Rows[iFilaSeleccionada]["Valor"] = dValor;

                // Actualizar lista para el controlador
                lDetalles[iFilaSeleccionada] = (sCodigo, bTipo, dValor);

                // Limpiar estado de edición
                Cmb_CodigoCuenta.SelectedIndex = -1;
                Cmb_Tipo.SelectedIndex = -1;
                Txt_Valor.Clear();
                bEditandoFila = false;
                iFilaSeleccionada = -1;

                Dgv_DetallePoliza.ClearSelection();
                ActualizarTotales();

                MessageBox.Show("Detalle actualizado correctamente.",
                                "Edición Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar detalle: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Dgv_DetallePoliza_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.RowIndex < Dgv_DetallePoliza.Rows.Count)
                {
                    DataGridViewRow row = Dgv_DetallePoliza.Rows[e.RowIndex];

                    iFilaSeleccionada = e.RowIndex;
                    Cmb_CodigoCuenta.SelectedValue = row.Cells["CodigoCuenta"].Value.ToString();
                    Cmb_Tipo.SelectedItem = row.Cells["Tipo"].Value.ToString();
                    Txt_Valor.Text = row.Cells["Valor"].Value.ToString();

                    bEditandoFila = true;
                    Btn_Editar.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar fila: " + ex.Message);
            }
        }

        private void Frm_DetallePolizas_Load(object sender, EventArgs e)
        {

        }

        private void Btn_Salir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_Refrescar_Click(object sender, EventArgs e)
        {
            CargarDetallePolizaExistente();
        }

        private void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            Btn_Ingresar.Enabled = true;
            Btn_Editar.Enabled = false;
            Btn_Grabar.Enabled = false;
            Btn_Cancelar.Enabled = false;
        }
    }
}
