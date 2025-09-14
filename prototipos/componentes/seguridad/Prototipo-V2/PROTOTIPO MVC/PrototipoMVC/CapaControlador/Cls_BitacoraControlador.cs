using System;
using System.Data;
using System.IO;
using System.Text;
using System.Drawing;
using System.Drawing.Printing;
using CapaModelo;

namespace CapaControlador
{
    public class Cls_BitacoraControlador
    {
        private readonly Cls_SentenciasBitacora sentencias = new Cls_SentenciasBitacora();

        //Método de consultas

        public DataTable MostrarBitacora()
        {
            return sentencias.Listar();
        }

        public DataTable BuscarPorFecha(DateTime fecha)
        {
            return sentencias.ConsultarPorFecha(fecha);
        }

        public DataTable BuscarPorRango(DateTime inicio, DateTime fin)
        {
            return sentencias.ConsultarPorRango(inicio, fin);
        }

        public DataTable BuscarPorUsuario(int idUsuario)
        {
            return sentencias.ConsultarPorUsuario(idUsuario);
        }

        // Método de registros


        public void RegistrarAccion(int idUsuario, int idAplicacion, string accion, bool estadoLogin)
        {
            sentencias.InsertarBitacora(idUsuario, idAplicacion, accion, estadoLogin);
        }

        public void RegistrarInicioSesion(int idUsuario, int idAplicacion)
        {
            sentencias.RegistrarInicioSesion(idUsuario, idAplicacion);
        }

        public void RegistrarCierreSesion(int idUsuario, int idAplicacion)
        {
            sentencias.RegistrarCierreSesion(idUsuario, idAplicacion);
        }

        // Exportar
        public void ExportarCsv(string path)
        {
            var dt = MostrarBitacora();
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

        // Imprimir Bitacora

        private DataTable _printData;
        private int _printRowIndex;
        private readonly Font _fontHeader = new Font("Segoe UI", 10, FontStyle.Bold);
        private readonly Font _fontCell = new Font("Segoe UI", 9, FontStyle.Regular);

        public PrintDocument CrearDocumentoImpresion()
        {
            _printData = MostrarBitacora();
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

            string[] cols = { "id", "usuario", "aplicacion", "fecha", "accion", "ip", "equipo", "estado" };
            int[] colW = { 50, 120, 120, 130, 160, 110, 100, 100 };

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

                    g.DrawString(text, _fontCell, Brushes.Black, rect.Left + 4, rect.Top + 4);
                    x += colW[i];
                }

                y += rowH;
                _printRowIndex++;
                printed++;
            }

            e.HasMorePages = (_printRowIndex < _printData.Rows.Count);
        }
        public DataTable ObtenerUsuarios()
        {
            var dao = new Cls_BitacoraDao(); // DAO que se ejecuta en SQL
            string sql = "SELECT pk_id_usuario AS id, nombre_usuario AS usuario FROM tbl_USUARIO ORDER BY nombre_usuario;";
            return dao.EjecutarConsulta(sql);
        }

    }
}
