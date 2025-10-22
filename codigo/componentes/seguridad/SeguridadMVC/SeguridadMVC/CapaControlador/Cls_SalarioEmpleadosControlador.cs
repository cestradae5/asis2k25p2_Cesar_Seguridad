// Ernesto David Samayoa Jocol - Controlador para tbl_SALARIO_EMPLEADOS
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaModelo;

namespace CapaControlador
{
    public class Cls_SalarioEmpleadosControlador
    {
        private Cls_SalarioEmpleadosDAO daoSalario = new Cls_SalarioEmpleadosDAO();

        // Obtener todos los salarios de empleados
        public List<Cls_SalarioEmpleados> ObtenerTodosLosSalarios()
        {
            return daoSalario.ObtenerSalarios();
        }

        // Insertar un nuevo registro de salario
        public void InsertarSalarioEmpleado(int idSalario, int idEmpleado, float monto,
            DateTime fechaInicioSalario, DateTime fechaFinSalario, bool estado)
        {
            Cls_SalarioEmpleados nuevoSalario = new Cls_SalarioEmpleados
            {
                PkIdSalario = idSalario,
                FkIdEmpleado = idEmpleado,
                MontoSalario = monto,
                FechaInicioSalario = fechaInicioSalario,
                FechaFinSalario = fechaFinSalario,
                EstadoSalario = estado
            };

            daoSalario.InsertarSalario(nuevoSalario);
        }

        // Actualizar salario existente
        public bool ActualizarSalario(int idSalario, int idEmpleado, float monto,
            DateTime fechaInicioSalario, DateTime fechaFinSalario, bool estado)
        {
            Cls_SalarioEmpleados salarioActualizado = new Cls_SalarioEmpleados
            {
                PkIdSalario = idSalario,
                FkIdEmpleado = idEmpleado,
                MontoSalario = monto,
                FechaInicioSalario = fechaInicioSalario,
                FechaFinSalario = fechaFinSalario,
                EstadoSalario = estado
            };

            daoSalario.ActualizarSalario(salarioActualizado);
            return true;
        }

        // Eliminar salario por ID
        public bool BorrarSalario(int idSalario)
        {
            return daoSalario.BorrarSalario(idSalario) > 0;
        }

        // Buscar salario por ID
        public Cls_SalarioEmpleados BuscarSalarioPorId(int idSalario)
        {
            return daoSalario.Query(idSalario);
        }

        // Buscar salarios por empleado
        public List<Cls_SalarioEmpleados> BuscarSalariosPorEmpleado(int idEmpleado)
        {
            return daoSalario.BuscarPorEmpleado(idEmpleado);
        }
    }
}
