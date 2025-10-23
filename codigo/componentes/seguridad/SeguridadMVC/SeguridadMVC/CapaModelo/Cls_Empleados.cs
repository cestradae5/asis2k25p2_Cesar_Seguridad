// Ernesto David Samayoa Jocol - Generado en base a tbl_EMPLEADO
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Capa_Modelo_Seguridad
{
    public class Cls_Empleado
    {
        public int iPkIdEmpleado { get; set; }
        public string sNombresEmpleado { get; set; }
        public string sApellidosEmpleado { get; set; }
        public long lDpiEmpleado { get; set; }
        public long lNitEmpleado { get; set; }
        public string sCorreoEmpleado { get; set; }
        public string sTelefonoEmpleado { get; set; }
        public bool bGeneroEmpleado { get; set; }
        public DateTime dFechaNacimientoEmpleado { get; set; }
        public DateTime dFechaContratacionEmpleado { get; set; }

        public Cls_Empleado() { }

        public Cls_Empleado(
            int iPkIdEmpleado,
            string sNombresEmpleado,
            string sApellidosEmpleado,
            long lDpiEmpleado,
            long lNitEmpleado,
            string sCorreoEmpleado,
            string sTelefonoEmpleado,
            bool bGeneroEmpleado,
            DateTime dFechaNacimientoEmpleado,
            DateTime dFechaContratacionEmpleado
        )
        {
            this.iPkIdEmpleado = iPkIdEmpleado;
            this.sNombresEmpleado = sNombresEmpleado;
            this.sApellidosEmpleado = sApellidosEmpleado;
            this.lDpiEmpleado = lDpiEmpleado;
            this.lNitEmpleado = lNitEmpleado;
            this.sCorreoEmpleado = sCorreoEmpleado;
            this.sTelefonoEmpleado = sTelefonoEmpleado;
            this.bGeneroEmpleado = bGeneroEmpleado;
            this.dFechaNacimientoEmpleado = dFechaNacimientoEmpleado;
            this.dFechaContratacionEmpleado = dFechaContratacionEmpleado;
        }
    }
}
