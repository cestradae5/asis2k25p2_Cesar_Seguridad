using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_modelo
{
    public class Cls_Depreciacion_Activo
    {
        public int iAnio { get; set; }
        public decimal dValorEnLibros { get; set; }
        public decimal dDepreciacionAnual { get; set; }
        public decimal dDepreciacionAcumulada { get; set; }

        public Cls_Depreciacion_Activo() { }

        public Cls_Depreciacion_Activo(int anio, decimal valor, decimal depAnual, decimal depAcumulada)
        {
            iAnio = anio;
            dValorEnLibros = valor;
            dDepreciacionAnual = depAnual;
            dDepreciacionAcumulada = depAcumulada;
        }
    }
}