using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_modelo
{
    public class Cls_Activo_Fijo
    {
        public int iPkActivoId { get; set; }
        public string sNombreActivo { get; set; }
        public string sDescripcion { get; set; }
        public string sGrupoActivo { get; set; }
        public DateTime dFechaAdquisicion { get; set; }
        public decimal dCostoAdquisicion { get; set; }
        public decimal dValorResidual { get; set; }
        public int iVidaUtil { get; set; }
        public bool bEstadoActivo { get; set; }
        public string sCuentaActivo { get; set; }
        public string sCuentaDepreciacionAcumulada { get; set; }
        public string sCuentaGastoDepreciacion { get; set; }

        public Cls_Activo_Fijo() { }

        public Cls_Activo_Fijo(int iId, string sNombre, string sDescripcion, string sGrupo, DateTime dFecha, decimal deCosto, decimal deResidual, int iVida, bool bEstado, string sCtaActivo, string sCtaDepAcum, string sCtaGastoDep)
        {
            iPkActivoId = iId;
            sNombreActivo = sNombre;
            this.sDescripcion = sDescripcion;
            sGrupoActivo = sGrupo;
            dFechaAdquisicion = dFecha;
            dCostoAdquisicion = deCosto;
            dValorResidual = deResidual;
            iVidaUtil = iVida;
            bEstadoActivo = bEstado;
            sCuentaActivo = sCtaActivo;
            sCuentaDepreciacionAcumulada = sCtaDepAcum;
            sCuentaGastoDepreciacion = sCtaGastoDep;
        }
    }
}