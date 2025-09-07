// 0901-22-13036 Arón Ricardo Esquit Silva
using System;
using System.Windows.Forms;
using System.Drawing.Printing;      // para imprimir
using CapaControlador;              // puente hacia el DAO

namespace CapaVista
{
    public partial class frmBitacora : Form
    {
        private readonly BitacoraControlador _svc = new BitacoraControlador();

        public frmBitacora()
        {
            InitializeComponent();

          
            Dgv_Bitacora.AutoGenerateColumns = true;

            this.Load += frmBitacora_Load;
        }

        private void frmBitacora_Load(object sender, EventArgs e)
        {
            try
            {
                Dgv_Bitacora.DataSource = _svc.ObtenerBitacora();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar bitácora:\n" + ex.Message,
                                "Bitácora", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Métodos públicos por compatibilidad con otros formularios
        public void ExportarCSV()
        {
            using (var sfd = new SaveFileDialog { Title = "Exportar bitácora a CSV", Filter = "CSV (*.csv)|*.csv", FileName = "bitacora.csv" })
            {
                if (sfd.ShowDialog(this) == DialogResult.OK)
                {
                    _svc.ExportarCsv(sfd.FileName);
                    MessageBox.Show("CSV exportado con éxito.", "Bitácora", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public void Imprimir()
        {
            var doc = _svc.CrearDocumentoImpresion();
            using (var pd = new PrintDialog { Document = doc })
            {
                if (pd.ShowDialog(this) == DialogResult.OK)
                    doc.Print();
            }
        }
    }
}
