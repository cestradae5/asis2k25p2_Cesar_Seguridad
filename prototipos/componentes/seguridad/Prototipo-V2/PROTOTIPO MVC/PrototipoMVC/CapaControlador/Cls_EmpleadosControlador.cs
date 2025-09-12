// Ernesto David Samayoa Jocol - Controlador para tbl_EMPLEADO
using System;
using System.Collections.Generic;
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
        public void InsertarEmpleado(int idEmpleado, string nombres, string apellidos, long dpi, long nit,
                                     string correo, string telefono, bool genero, DateTime fechaNacimiento, DateTime fechaContratacion)
        {
            Cls_Empleado nuevoEmpleado = new Cls_Empleado
            {
                PkIdEmpleado = idEmpleado,
                NombresEmpleado = nombres,
                ApellidosEmpleado = apellidos,
                DpiEmpleado = dpi,
                NitEmpleado = nit,
                CorreoEmpleado = correo,
                TelefonoEmpleado = telefono,
                GeneroEmpleado = genero,
                FechaNacimientoEmpleado = fechaNacimiento,
                FechaContratacionEmpleado = fechaContratacion
            };

            daoEmpleado.InsertarEmpleado(nuevoEmpleado);
        }

        // Actualizar empleado existente
        public bool ActualizarEmpleado(int idEmpleado, string nombres, string apellidos, long dpi, long nit,
                                       string correo, string telefono, bool genero, DateTime fechaNacimiento, DateTime fechaContratacion)
        {
            Cls_Empleado empleadoActualizado = new Cls_Empleado
            {
                PkIdEmpleado = idEmpleado,
                NombresEmpleado = nombres,
                ApellidosEmpleado = apellidos,
                DpiEmpleado = dpi,
                NitEmpleado = nit,
                CorreoEmpleado = correo,
                TelefonoEmpleado = telefono,
                GeneroEmpleado = genero,
                FechaNacimientoEmpleado = fechaNacimiento,
                FechaContratacionEmpleado = fechaContratacion
            };

            daoEmpleado.ActualizarEmpleado(empleadoActualizado);
            return true;
        }

        // Eliminar empleado por ID
        public bool BorrarEmpleado(int idEmpleado)
        {
            return daoEmpleado.BorrarEmpleado(idEmpleado) > 0;
        }

        // Buscar empleado por ID
        public Cls_Empleado BuscarEmpleadoPorId(int idEmpleado)
        {
            return daoEmpleado.Query(idEmpleado);
        }
    }
}
