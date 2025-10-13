using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebaEjecucionNavegador
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //parametros para navegador
            Capa_Controlador_Navegador.Cls_ConfiguracionDataGridView config = new Capa_Controlador_Navegador.Cls_ConfiguracionDataGridView
            {
                Ancho = 1100,
                Alto = 200,
                PosX = 10,
                PosY = 300,
                ColorFondo = Color.AliceBlue,
                TipoScrollBars = ScrollBars.Both,
                Nombre = "dgv_empleados"
            };

            string[] columnas = {
                    "tbl_cliente",
                    "Pk_Id_Cliente",
                    "Cmp_Nombres_Cliente",
                    "Cmp_Apellidos_Cliente",
                    "Cmp_Dni_Cliente",
                    "Cmp_Fecha_Registro_Cliente",
                    "Cmp_Estado_Cliente",
                    "Cmp_Nacionalidad_Cliente"

            };

            string[] sEtiquetas = {
                "Codigo Cliente",
                "Nombres",
                "Apellidos",
                "DPI",
                "Fecha de Registro",
                "Estado del Cliente",
                "Nacionalidad",
               
            };



            int id_aplicacion = 100;
            navegador1.IPkId_Aplicacion = id_aplicacion;
            navegador1.configurarDataGridView(config);
            navegador1.SNombreTabla = columnas[0];
            navegador1.SAlias = columnas;
            navegador1.SEtiquetas = sEtiquetas;
            navegador1.mostrarDatos();
        }

    }
}