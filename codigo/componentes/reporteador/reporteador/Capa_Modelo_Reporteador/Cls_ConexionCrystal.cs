using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrystalDecisions.Shared;

namespace Capa_Modelo_Reporteador
{
    public class Cls_ConexionCrystal
    {
        public ConnectionInfo ObtenerConexionCrystal()
        {
            // Retorna un objeto ConnectionInfo configurado
            return new ConnectionInfo
            {
                ServerName = "bd_hoteleria", // DSN
                IntegratedSecurity = true
            };
        }
    }
}
