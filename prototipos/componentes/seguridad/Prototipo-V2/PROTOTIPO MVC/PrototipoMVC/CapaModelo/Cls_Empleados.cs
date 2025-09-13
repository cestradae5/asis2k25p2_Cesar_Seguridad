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
        public int PkIdEmpleado { get; set; }
        public string NombresEmpleado { get; set; }
        public string ApellidosEmpleado { get; set; }
        public long DpiEmpleado { get; set; }
        public long NitEmpleado { get; set; }
        public string CorreoEmpleado { get; set; }
        public string TelefonoEmpleado { get; set; }
        public bool GeneroEmpleado { get; set; }
        public DateTime FechaNacimientoEmpleado { get; set; }
        public DateTime FechaContratacionEmpleado { get; set; }

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
            this.PkIdEmpleado = pkIdEmpleado;
            this.NombresEmpleado = nombresEmpleado;
            this.ApellidosEmpleado = apellidosEmpleado;
            this.DpiEmpleado = dpiEmpleado;
            this.NitEmpleado = nitEmpleado;
            this.CorreoEmpleado = correoEmpleado;
            this.TelefonoEmpleado = telefonoEmpleado;
            this.GeneroEmpleado = generoEmpleado;
            this.FechaNacimientoEmpleado = fechaNacimientoEmpleado;
            this.FechaContratacionEmpleado = fechaContratacionEmpleado;
        }
    }
}


