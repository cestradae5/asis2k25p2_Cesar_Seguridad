// Ernesto David Samayoa Jocol - Controlador para tbl_EMPLEADO
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaModelo;

namespace CapaControlador
{
    public class Cls_EmpleadoControlador
    {
        private Cls_EmpleadoDAO daoEmpleado = new Cls_EmpleadoDAO();

        // Obtener todos los empleados
        public List<Cls_Empleado> ObtenerTodosLosEmpleados()
        {
            return daoEmpleado.ObtenerEmpleados();
        }

        // Insertar un nuevo empleado
        public void func_InsertarEmpleado(int idEmpleado, string nombres, string apellidos, long dpi, long nit,
                                     string correo, string telefono, bool genero, DateTime fechaNacimiento, DateTime fechaContratacion)
        {
            Cls_Empleado nuevoEmpleado = new Cls_Empleado
            {
                iPkIdEmpleado = idEmpleado,
                sNombresEmpleado = nombres,
                sApellidosEmpleado = apellidos,
                lDpiEmpleado = dpi,
                lNitEmpleado = nit,
                sCorreoEmpleado = correo,
                sTelefonoEmpleado = telefono,
                bGeneroEmpleado = genero,
                dFechaNacimientoEmpleado = fechaNacimiento,
                dFechaContratacionEmpleado = fechaContratacion
            };

            daoEmpleado.func_InsertarEmpleado(nuevoEmpleado);
        }

        // Actualizar empleado existente
        public bool func_ActualizarEmpleado(int idEmpleado, string nombres, string apellidos, long dpi, long nit,
                                       string correo, string telefono, bool genero, DateTime fechaNacimiento, DateTime fechaContratacion)
        {
            Cls_Empleado empleadoActualizado = new Cls_Empleado
            {
                iPkIdEmpleado = idEmpleado,
                sNombresEmpleado = nombres,
                sApellidosEmpleado = apellidos,
                lDpiEmpleado = dpi,
                lNitEmpleado = nit,
                sCorreoEmpleado = correo,
                sTelefonoEmpleado = telefono,
                bGeneroEmpleado = genero,
                dFechaNacimientoEmpleado = fechaNacimiento,
                dFechaContratacionEmpleado = fechaContratacion
            };

            daoEmpleado.func_ActualizarEmpleado(empleadoActualizado);
            return true;
        }

        // Eliminar empleado por ID
        public bool func_BorrarEmpleado(int idEmpleado)
        {
            return daoEmpleado.func_BorrarEmpleado(idEmpleado) > 0;
        }

        // Buscar empleado por ID
        public Cls_Empleado func_BuscarEmpleadoPorId(int idEmpleado)
        {
            return daoEmpleado.Query(idEmpleado);
        }
    }
}
