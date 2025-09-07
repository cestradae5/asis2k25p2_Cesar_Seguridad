using System;
using System.Data;
using System.IO;
using System.Text;
using System.Drawing;
using System.Drawing.Printing;
using CapaModelo;

//0901-22-13036 Arón Ricardo Esquit Silva
namespace CapaControlador
{
    // Puente entre la Vista y el DAO
    public class BitacoraControlador
    {
        private readonly BitacoraDao _dao = new BitacoraDao();

        //  Consultar bitácora 
        public DataTable ObtenerBitacora()
        {
            return _dao.Listar();
        }

        //  Exportar CSV 
        public void ExportarCsv(string path)
        {
            var dt = ObtenerBitacora();
            if (dt == null || dt.Rows.Count == 0)
                throw new InvalidOperationException("No hay datos de bitácora para exportar.");

            var sb = new StringBuilder();

            // Encabezados
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                if (i > 0) sb.Append(',');
                sb.Append(CsvCell(dt.Columns[i].ColumnName));
            }
            sb.AppendLine();

            // Filas
            foreach (DataRow row in dt.Rows)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    if (i > 0) sb.Append(',');
                    sb.Append(CsvCell(row[i]));
                }
                sb.AppendLine();
            }

            File.WriteAllText(path, sb.ToString(), new UTF8Encoding(true));
        }

        private static string CsvCell(object value)
        {
            string s = (value == null || value == DBNull.Value) ? "" : value.ToString();
            s = s.Replace("\"", "\"\"");
            if (s.Contains(",") || s.Contains("\"") || s.Contains("\n") || s.Contains("\r"))
                s = "\"" + s + "\"";
            return s;
        }

        // Imprimir 
        private DataTable _printData;
        private int _printRowIndex;
        private readonly Font _fontHeader = new Font("Segoe UI", 10, FontStyle.Bold);
        private readonly Font _fontCell = new Font("Segoe UI", 9, FontStyle.Regular);

        public PrintDocument CrearDocumentoImpresion()
        {
            _printData = ObtenerBitacora();
            if (_printData == null || _printData.Rows.Count == 0)
                throw new InvalidOperationException("No hay datos de bitácora para imprimir.");

            _printRowIndex = 0;

            var doc = new PrintDocument();
            doc.DocumentName = "Bitacora";
            doc.PrintPage += OnPrintPage;
            return doc;
        }

        private void OnPrintPage(object sender, PrintPageEventArgs e)
        {
            if (_printData == null) return;

            Graphics g = e.Graphics;
            Rectangle area = e.MarginBounds;

            using (Font fontTitulo = new Font("Segoe UI", 12, FontStyle.Bold))
            {
                g.DrawString("Bitácora", fontTitulo, Brushes.Black, area.Left, area.Top - 30);
                g.DrawString(DateTime.Now.ToString("yyyy-MM-dd HH:mm"),
                             _fontCell, Brushes.Black, area.Right - 160, area.Top - 24);
            }

            string[] cols = { "id", "usuario", "aplicacion", "fecha", "accion", "ip", "equipo", "login" };
            int[] colW = { 50, 120, 120, 130, 160, 110, 100, 60 };

            int x = area.Left;
            int y = area.Top;
            int rowH = (int)_fontCell.GetHeight(g) + 8;

            // Encabezado
            for (int i = 0; i < cols.Length; i++)
            {
                var rect = new Rectangle(x, y, colW[i], rowH);
                g.FillRectangle(Brushes.Gainsboro, rect);
                g.DrawRectangle(Pens.Black, rect);
                g.DrawString(cols[i].ToUpperInvariant(), _fontHeader, Brushes.Black, rect.Left + 4, rect.Top + 4);
                x += colW[i];
            }
            y += rowH;

            // Filas por página
            int linesPerPage = (area.Bottom - y) / rowH;
            int printed = 0;

            while (_printRowIndex < _printData.Rows.Count && printed < linesPerPage)
            {
                x = area.Left;
                var row = _printData.Rows[_printRowIndex];

                for (int i = 0; i < cols.Length; i++)
                {
                    var rect = new Rectangle(x, y, colW[i], rowH);
                    g.DrawRectangle(Pens.Black, rect);

                    object val = _printData.Columns.Contains(cols[i]) ? row[cols[i]] : null;
                    string text = (val == null || val == DBNull.Value) ? "" : val.ToString();

                    if (cols[i] == "fecha" && DateTime.TryParse(text, out var dt))
                        text = dt.ToString("yyyy-MM-dd HH:mm");
                    if (cols[i] == "login" && int.TryParse(text, out var v))
                        text = (v != 0) ? "Sí" : "No";

                    g.DrawString(text, _fontCell, Brushes.Black, rect.Left + 4, rect.Top + 4);
                    x += colW[i];
                }

                y += rowH;
                _printRowIndex++;
                printed++;
            }

            e.HasMorePages = (_printRowIndex < _printData.Rows.Count);
        }
    }
}
