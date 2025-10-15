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

        //Ernesto David SamayoaJocol 0901-22-3415 Verificar si un empleado tiene usuario asociado nueva funcion
        public bool fun_EmpleadoTieneUsuario(int iIdEmpleado)
        {
            return daoEmpleado.fun_EmpleadoTieneUsuario(iIdEmpleado);
        }

        // Obtener todos los empleados
        public List<Cls_Empleado> fun_ObtenerTodosLosEmpleados()
        {
            return daoEmpleado.fun_ObtenerEmpleados();
        }

        // Insertar un nuevo empleado
        public void fun_InsertarEmpleado(int iIdEmpleado, string sNombres, string sApellidos, long lDpi, long lNit,
                                     string sCorreo, string sTelefono, bool bGenero, DateTime dFechaNacimiento, DateTime dFechaContratacion)
        {
            Cls_Empleado nuevoEmpleado = new Cls_Empleado
            {
                iPkIdEmpleado = iIdEmpleado,
                sNombresEmpleado = sNombres,
                sApellidosEmpleado = sApellidos,
                lDpiEmpleado = lDpi,
                lNitEmpleado = lNit,
                sCorreoEmpleado = sCorreo,
                sTelefonoEmpleado = sTelefono,
                bGeneroEmpleado = bGenero,
                dFechaNacimientoEmpleado = dFechaNacimiento,
                dFechaContratacionEmpleado = dFechaContratacion
            };

            daoEmpleado.fun_InsertarEmpleado(nuevoEmpleado);
        }

        // Actualizar empleado existente
        public bool fun_ActualizarEmpleado(int iIdEmpleado, string sNombres, string sApellidos, long lDpi, long lNit,
                                       string sCorreo, string sTelefono, bool sGenero, DateTime dfFechaNacimiento, DateTime dFechaContratacion)
        {
            Cls_Empleado empleadoActualizado = new Cls_Empleado
            {
                iPkIdEmpleado = iIdEmpleado,
                sNombresEmpleado = sNombres,
                sApellidosEmpleado = sApellidos,
                lDpiEmpleado = lDpi,
                lNitEmpleado = lNit,
                sCorreoEmpleado = sCorreo,
                sTelefonoEmpleado = sTelefono,
                bGeneroEmpleado = sGenero,
                dFechaNacimientoEmpleado = dfFechaNacimiento,
                dFechaContratacionEmpleado = dFechaContratacion
            };

            daoEmpleado.fun_ActualizarEmpleado(empleadoActualizado);
            return true;
        }

        // Eliminar empleado por ID
        public bool fun_BorrarEmpleado(int iIdEmpleado)
        {
            return daoEmpleado.fun_BorrarEmpleado(iIdEmpleado) > 0;
        }

        // Buscar empleado por ID
        public Cls_Empleado fun_BuscarEmpleadoPorId(int iIdEmpleado)
        {
            return daoEmpleado.Query(iIdEmpleado);
        }
    }
}
