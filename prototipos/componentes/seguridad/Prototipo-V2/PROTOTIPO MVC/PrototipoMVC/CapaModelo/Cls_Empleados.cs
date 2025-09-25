// Ernesto David Samayoa Jocol - Generado en base a tbl_EMPLEADO
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CapaModelo
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
            int pkIdEmpleado,
            string nombresEmpleado,
            string apellidosEmpleado,
            long dpiEmpleado,
            long nitEmpleado,
            string correoEmpleado,
            string telefonoEmpleado,
            bool generoEmpleado,
            DateTime fechaNacimientoEmpleado,
            DateTime fechaContratacionEmpleado
        )
        {
            iPkIdEmpleado = pkIdEmpleado;
            sNombresEmpleado = nombresEmpleado;
            sApellidosEmpleado = apellidosEmpleado;
            lDpiEmpleado = dpiEmpleado;
            lNitEmpleado = nitEmpleado;
            sCorreoEmpleado = correoEmpleado;
            sTelefonoEmpleado = telefonoEmpleado;
            bGeneroEmpleado = generoEmpleado;
            dFechaNacimientoEmpleado = fechaNacimientoEmpleado;
            dFechaContratacionEmpleado = fechaContratacionEmpleado;
        }
    }
}
