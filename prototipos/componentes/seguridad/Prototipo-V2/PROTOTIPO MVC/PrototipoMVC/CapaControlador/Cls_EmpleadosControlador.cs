// Ernesto David Samayoa Jocol - Controlador para tbl_EMPLEADO
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Modelo_Seguridad;

namespace Capa_Controlador_Seguridad
{
    public class Cls_EmpleadoControlador
    {
        private Cls_EmpleadoDAO daoEmpleado = new Cls_EmpleadoDAO();

        // Obtener todos los empleados
        public List<Cls_Empleado> fun_ObtenerTodosLosEmpleados()
        {
            return daoEmpleado.fun_ObtenerEmpleados();
        }

        // Insertar un nuevo empleado
        public void fun_InsertarEmpleado(int idEmpleado, string nombres, string apellidos, long dpi, long nit,
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

            daoEmpleado.fun_InsertarEmpleado(nuevoEmpleado);
        }

        // Actualizar empleado existente
        public bool fun_ActualizarEmpleado(int idEmpleado, string nombres, string apellidos, long dpi, long nit,
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

            daoEmpleado.fun_ActualizarEmpleado(empleadoActualizado);
            return true;
        }

        // Eliminar empleado por ID
        public bool fun_BorrarEmpleado(int idEmpleado)
        {
            return daoEmpleado.fun_BorrarEmpleado(idEmpleado) > 0;
        }

        // Buscar empleado por ID
        public Cls_Empleado fun_BuscarEmpleadoPorId(int idEmpleado)
        {
            return daoEmpleado.Query(idEmpleado);
        }
    }
}
