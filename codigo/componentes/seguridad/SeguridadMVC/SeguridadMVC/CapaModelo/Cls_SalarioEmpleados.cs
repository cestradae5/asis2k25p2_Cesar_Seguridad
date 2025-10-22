// Ernesto David Samayoa Jocol - Generado en base a tbl_SALARIO_EMPLEADOS
using System;

namespace CapaModelo
{
    public class Cls_SalarioEmpleados
    {
        public int PkIdSalario { get; set; }
        public int FkIdEmpleado { get; set; }
        public string NombresEmpleado { get; set; }
        public string ApellidosEmpleado { get; set; }
        public float MontoSalario { get; set; }
        public DateTime FechaInicioSalario { get; set; }
        public DateTime FechaFinSalario { get; set; }
        public bool EstadoSalario { get; set; }

        public Cls_SalarioEmpleados() { }

        public Cls_SalarioEmpleados(
            int pkIdSalario,
            int fkIdEmpleado,
            string nombresEmpleado,
            string apellidosEmpleado,
            float montoSalario,
            DateTime fechaInicioSalario,
            DateTime fechaFinSalario,
            bool estadoSalario
        )
        {
            PkIdSalario = pkIdSalario;
            FkIdEmpleado = fkIdEmpleado;
            NombresEmpleado = nombresEmpleado;
            ApellidosEmpleado = apellidosEmpleado;
            MontoSalario = montoSalario;
            FechaInicioSalario = fechaInicioSalario;
            FechaFinSalario = fechaFinSalario;
            EstadoSalario = estadoSalario;
        }
    }
}
