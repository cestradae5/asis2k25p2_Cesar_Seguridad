//Registrar en Bitácora - Arón Ricardo Esquit Silva - 0901-22-13036 - 12/09/2025
using System;
using System.Data;
using System.IO;
using System.Text;
using System.Drawing;
using System.Drawing.Printing;
using Capa_Modelo_Seguridad;

namespace Capa_Controlador_Seguridad
{
    public class Cls_BitacoraControlador
    {
        private readonly Cls_SentenciasBitacora ctrlSentencias = new Cls_SentenciasBitacora();

        // Consultas

        //Mostar tabla
        public DataTable MostrarBitacora() => ctrlSentencias.Listar();
        //Busca por fecha
        public DataTable BuscarPorFecha(DateTime fecha) => ctrlSentencias.ConsultarPorFecha(fecha);
        //Busca por rango de fechas
        public DataTable BuscarPorRango(DateTime inicio, DateTime fin) => ctrlSentencias.ConsultarPorRango(inicio, fin);
        //Busca por usuario
        public DataTable BuscarPorUsuario(int iIdUsuario) => ctrlSentencias.ConsultarPorUsuario(iIdUsuario);

        //Registrar acciones
        public void RegistrarAccion(int iIdUsuario, int iIdAplicacion, string sAccion, bool bEstado)
        {
            ctrlSentencias.InsertarBitacora(iIdUsuario, iIdAplicacion, sAccion, bEstado);
        }

        //Registrar Inicio de sesión
        public void RegistrarInicioSesion(int iIdUsuario)
        {
            ctrlSentencias.RegistrarInicioSesion(iIdUsuario, 0);
        }

        //Registrar cierre de sesión
        public void RegistrarCierreSesion(int iIdUsuario)
        {
            ctrlSentencias.RegistrarCierreSesion(iIdUsuario, 0);
        }



        // Exportar a CSV
        public void ExportarCsv(string path)
        {
            var dt = MostrarBitacora();
            if (dt == null || dt.Rows.Count == 0)
                throw new InvalidOperationException("No hay datos de bitácora para exportar.");

            var sb = new StringBuilder();

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                if (i > 0) sb.Append(',');
                sb.Append(CsvCell(dt.Columns[i].ColumnName));
            }
            sb.AppendLine();

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
        private DataTable dtImpresion;
        private int filaActual;
        private readonly Font fontHeader = new Font("Segoe UI", 10, FontStyle.Bold);
        private readonly Font fontCell = new Font("Segoe UI", 9, FontStyle.Regular);

        public PrintDocument CrearDocumentoImpresion()
        {
            dtImpresion = MostrarBitacora();
            if (dtImpresion == null || dtImpresion.Rows.Count == 0)
                throw new InvalidOperationException("No hay datos de bitácora para imprimir.");

            filaActual = 0;

            var doc = new PrintDocument();
            doc.DocumentName = "Bitácora";
            doc.PrintPage += OnPrintPage;
            return doc;
        }

        //Alistar el documento
        private void OnPrintPage(object sender, PrintPageEventArgs e)
        {
            if (dtImpresion == null) return;

            Graphics g = e.Graphics;
            Rectangle area = e.MarginBounds;

            using (Font fontTitulo = new Font("Segoe UI", 12, FontStyle.Bold))
            {
                g.DrawString("Bitácora", fontTitulo, Brushes.Black, area.Left, area.Top - 30);
                g.DrawString(DateTime.Now.ToString("yyyy-MM-dd HH:mm"),
                             fontCell, Brushes.Black, area.Right - 160, area.Top - 24);
            }

            string[] cols = { "id", "usuario", "aplicacion", "fecha", "accion", "ip", "equipo", "estado" };
            int[] colW = { 50, 120, 120, 130, 160, 110, 100, 100 };

            int x = area.Left;
            int y = area.Top;
            int rowH = (int)fontCell.GetHeight(g) + 8;

            for (int i = 0; i < cols.Length; i++)
            {
                var rect = new Rectangle(x, y, colW[i], rowH);
                g.FillRectangle(Brushes.Gainsboro, rect);
                g.DrawRectangle(Pens.Black, rect);
                g.DrawString(cols[i].ToUpperInvariant(), fontHeader, Brushes.Black, rect.Left + 4, rect.Top + 4);
                x += colW[i];
            }
            y += rowH;

            int linesPerPage = (area.Bottom - y) / rowH;
            int printed = 0;

            while (filaActual < dtImpresion.Rows.Count && printed < linesPerPage)
            {
                x = area.Left;
                var row = dtImpresion.Rows[filaActual];

                for (int i = 0; i < cols.Length; i++)
                {
                    var rect = new Rectangle(x, y, colW[i], rowH);
                    g.DrawRectangle(Pens.Black, rect);

                    object val = dtImpresion.Columns.Contains(cols[i]) ? row[cols[i]] : null;
                    string text = (val == null || val == DBNull.Value) ? "" : val.ToString();

                    if (cols[i] == "fecha" && DateTime.TryParse(text, out var dt))
                        text = dt.ToString("yyyy-MM-dd HH:mm");

                    g.DrawString(text, fontCell, Brushes.Black, rect.Left + 4, rect.Top + 4);
                    x += colW[i];
                }

                y += rowH;
                filaActual++;
                printed++;
            }

            e.HasMorePages = (filaActual < dtImpresion.Rows.Count);
        }

        // Obtener usuarios
        public DataTable ObtenerUsuarios()
        {
            var dao = new Cls_BitacoraDao();
            string sql = @"
                SELECT Pk_Id_Usuario AS id, 
                Cmp_Nombre_Usuario AS usuario
                FROM Tbl_Usuario
                WHERE Cmp_Estado_Usuario = 1
                ORDER BY Cmp_Nombre_Usuario;";
            return dao.EjecutarConsulta(sql);
        }

    }
}
