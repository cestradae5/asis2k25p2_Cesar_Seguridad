using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Printing;
using CapaVista;  // para abrir la grilla Consulta

namespace Bitacora_Menu
{
    public partial class Frm_Menu : Form
    {
        private readonly PrintDocument _printDoc = new PrintDocument();

        public Frm_Menu()
        {
            InitializeComponent();

            // Enlazar clics del menú (usa los nombres que definiste en el Diseñador)
            Mni_Bitacora_Consultar.Click += new EventHandler(Mni_Bitacora_Consultar_Click);
            Mni_ExportarCSV.Click += new EventHandler(Mni_ExportarCSV_Click);
            Mni_Imprimir.Click += new EventHandler(Mni_Imprimir_Click);
            Mni_Salir.Click += new EventHandler(Mni_Salir_Click);

            // Impresión
            _printDoc.PrintPage += new PrintPageEventHandler(PrintDoc_PrintPage);
        }

        // ===== Bitácora → Consultar =====
        private void Mni_Bitacora_Consultar_Click(object sender, EventArgs e)
        {
            var frm = new Consulta();
            frm.Show(); // no modal
        }

        // ===== (Menú) Salir =====
        private void Mni_Salir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // ===== (Menú) Exportar CSV =====
        private void Mni_ExportarCSV_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.Title = "Exportar bitácora a CSV";
                sfd.Filter = "CSV (*.csv)|*.csv";
                sfd.FileName = "bitacora.csv";

                if (sfd.ShowDialog(this) == DialogResult.OK)
                {
                    // Cabeceras (luego podemos llenar con datos reales)
                    string header = "ID,Usuario,Aplicacion,Fecha,Accion,IP,Equipo,Login";
                    File.WriteAllText(sfd.FileName, header + Environment.NewLine, new UTF8Encoding(true));

                    MessageBox.Show("CSV creado (solo cabeceras por ahora).",
                        "Exportar CSV", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        // ===== (Menú) Imprimir (demo) =====
        private void Mni_Imprimir_Click(object sender, EventArgs e)
        {
            using (var pd = new PrintDialog())
            {
                pd.Document = _printDoc;
                if (pd.ShowDialog(this) == DialogResult.OK)
                {
                    _printDoc.Print();
                }
            }
        }

        // Contenido de impresión (demo)
        private void PrintDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;

            using (Font fontTitulo = new Font("Segoe UI", 14, FontStyle.Bold))
            using (Font fontTexto = new Font("Segoe UI", 10, FontStyle.Regular))
            {
                float y = 80;
                g.DrawString("Reporte de Bitácora (demo)", fontTitulo, Brushes.Black, 80, y);
                y += 40;
                g.DrawString("Fecha: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm"),
                             fontTexto, Brushes.Black, 80, y);
                y += 30;
                g.DrawString("Contenido pendiente de integrar (demostración).",
                             fontTexto, Brushes.Black, 80, y);
            }
        }

        // Handlers generados por el diseñador (pueden quedar vacíos)
        private void Mnu_Principal_ItemClicked(object sender, ToolStripItemClickedEventArgs e) { }
        private void Frm_Menu_Load(object sender, EventArgs e) { }

        private void Mni_Bitacora_Click(object sender, EventArgs e)
        {

        }
    }
}
