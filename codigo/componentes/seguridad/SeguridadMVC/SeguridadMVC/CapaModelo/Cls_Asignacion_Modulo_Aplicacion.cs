//Cesar Armando Estrtada Elias 0901-22-10153
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Modelo_Seguridad
{
    public class AsignacionModuloAplicacion
    {
        public int FkIdModulo { get; set; }
        public int FkIdAplicacion { get; set; }
        public AsignacionModuloAplicacion() { }
        public AsignacionModuloAplicacion(int iFkIdModulo, int iFkIdAplicacion)
        {
            FkIdModulo = iFkIdModulo;
            FkIdAplicacion = iFkIdAplicacion;
        }
    }
}
