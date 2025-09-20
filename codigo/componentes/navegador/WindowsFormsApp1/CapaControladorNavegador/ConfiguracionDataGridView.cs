using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace CapaControladorNavegador
{
    public class ConfiguracionDataGridView
    {
        // Configuración básica
        public string Nombre { get; set; }
        public int Ancho { get; set; }
        public int Alto { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }

        // Colores y estilos
        public Color ColorFondo { get; set; }                // Áreas vacías
        public Color ColorFilas { get; set; }                // Color de las filas
        public Color ColorTextoFilas { get; set; }           // Color del texto
        public Color ColorFilasAlternas { get; set; }        // Filas alternadas
        public Color ColorEncabezado { get; set; }           // Fondo encabezado
        public Color ColorTextoEncabezado { get; set; }      // Texto encabezado
        public Font FuenteEncabezado { get; set; }

        // ScrollBars
        public ScrollBars TipoScrollBars { get; set; }

        public ConfiguracionDataGridView()
        {
            // Valores por defecto
            Nombre = "Dgv_Datos";
            Ancho = 1100;
            Alto = 200;
            PosX = 10;
            PosY = 250;

            // Estilos por defecto
            ColorFondo = Color.White;
            ColorFilas = Color.White;
            ColorTextoFilas = Color.Black;
            ColorFilasAlternas = Color.LightGray;
            ColorEncabezado = Color.White;
            ColorTextoEncabezado = Color.Black;
            FuenteEncabezado = new Font("Microsoft Sans Serif", 9, FontStyle.Bold);

            // Scrollbar por defecto
            TipoScrollBars = ScrollBars.Both;
        }
    }
}
