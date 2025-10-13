//Cesar Armando Estrtada Elias 0901-22-10153
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Capa_Modelo_Seguridad
{
    public class Cls_Aplicacion
    {
        public int iPkIdAplicacion { get; set; }
        public int? iFkIdReporte { get; set; }
        public string sNombreAplicacion { get; set; }
        public string sDescripcionAplicacion { get; set; }

        public bool bEstadoAplicacion { get; set; } // true = habilitado, false = deshabilitado

        public Cls_Aplicacion() { }

        public Cls_Aplicacion(int sPkIdAplicacion, int? iFkIdReporte, string sNombreAplicacion, string sDescripcionAplicacion, bool bEstadoAplicacion)
        {
            iPkIdAplicacion = sPkIdAplicacion;
            this.iFkIdReporte = iFkIdReporte;
            this.sNombreAplicacion = sNombreAplicacion;
            this.sDescripcionAplicacion = sDescripcionAplicacion;
            this.bEstadoAplicacion = bEstadoAplicacion;
        }
    }
}

