using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Modelo_Contabilidad
{
    public class Cls_Activo_Fijo
    {
        public int iPkActivoId { get; set; }
        public string sNombreActivo { get; set; }
        public string sDescripcion { get; set; }
        public DateTime dFechaAdquisicion { get; set; }
        public decimal dCostoAdquisicion { get; set; }
        public decimal dValorResidual { get; set; }
        public int iVidaUtil { get; set; }
        public bool bEstadoActivo { get; set; } // true = activo, false = dado de baja
        public string sCuentaActivo { get; set; }
        public string sCuentaDepreciacion { get; set; }

        public Cls_Activo_Fijo() { }

        public Cls_Activo_Fijo(int iId, string sNombre, string sDescripcion, DateTime dFecha, decimal deCosto, decimal deResidual, int iVida, bool bEstado, string sCtaActivo, string sCtaDep)
        {
            iPkActivoId = iId;
            sNombreActivo = sNombre;
            this.sDescripcion = sDescripcion;
            dFechaAdquisicion = dFecha;
            dCostoAdquisicion = deCosto;
            dValorResidual = deResidual;
            iVidaUtil = iVida;
            bEstadoActivo = bEstado;
            sCuentaActivo = sCtaActivo;
            sCuentaDepreciacion = sCtaDep;
        }
    }
}
