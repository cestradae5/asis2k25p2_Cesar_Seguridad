// Ernesto David Samayoa Jocol - Controlador para tbl_EMPLEADO NUEVO 2025
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

        // --- Métodos de validación y lógica para la vista
        public bool ValidarNombreOApellido(char keyChar)
        {
            return char.IsLetter(keyChar) || char.IsControl(keyChar) || keyChar == ' ';
        }

        public bool ValidarDpiKeyPress(char keyChar, string textoActual)
        {
            if (!char.IsControl(keyChar) && !char.IsDigit(keyChar))
                return false;
            if (char.IsDigit(keyChar) && textoActual.Length >= 13)
                return false;
            return true;
        }

        public bool ValidarNitKeyPress(char keyChar, string textoActual)
        {
            if (!char.IsControl(keyChar) && !char.IsDigit(keyChar))
                return false;
            if (char.IsDigit(keyChar) && textoActual.Length >= 9)
                return false;
            return true;
        }

        public bool ValidarTelefonoKeyPress(char keyChar, string textoActual)
        {
            if (!(char.IsDigit(keyChar) || char.IsControl(keyChar) || keyChar == '-'))
                return false;
            string textoSinGuiones = textoActual.Replace("-", "");
            if (char.IsDigit(keyChar) && textoSinGuiones.Length >= 8)
                return false;
            return true;
        }

        public bool ValidarCorreoKeyPress(char keyChar)
        {
            return char.IsLower(keyChar) || char.IsDigit(keyChar) || keyChar == '@' || keyChar == '.' || char.IsControl(keyChar);
        }

        public bool ValidarCampos(
            string id,
            string nombre,
            string apellido,
            string dpi,
            string nit,
            string correo,
            string telefono,
            string fechaNac,
            string fechaContra,
            bool generoMasc,
            bool generoFem,
            out string mensajeError)
        {
            mensajeError = string.Empty;
            if (string.IsNullOrWhiteSpace(id) ||
                string.IsNullOrWhiteSpace(nombre) ||
                string.IsNullOrWhiteSpace(apellido) ||
                string.IsNullOrWhiteSpace(dpi) ||
                string.IsNullOrWhiteSpace(nit) ||
                string.IsNullOrWhiteSpace(correo) ||
                string.IsNullOrWhiteSpace(telefono) ||
                string.IsNullOrWhiteSpace(fechaNac) ||
                string.IsNullOrWhiteSpace(fechaContra) ||
                (!generoMasc && !generoFem))
            {
                mensajeError = "Debe llenar todos los campos antes de guardar.";
                return false;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(nombre, @"^[a-zA-Z\s]+$") ||
                !System.Text.RegularExpressions.Regex.IsMatch(apellido, @"^[a-zA-Z\s]+$"))
            {
                mensajeError = "El nombre y apellido solo pueden contener letras y espacios.";
                return false;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(dpi, @"^\d{13}$"))
            {
                mensajeError = "El DPI debe contener exactamente 13 dígitos numéricos.";
                return false;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(nit, @"^\d{9}$"))
            {
                mensajeError = "El NIT debe contener exactamente 9 dígitos numéricos.";
                return false;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(telefono, @"^[0-9\-]{8,10}$"))
            {
                mensajeError = "El teléfono debe contener 8 dígitos y puede incluir guiones.";
                return false;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(correo, @"^[a-z0-9@.]+$"))
            {
                mensajeError = "El correo solo puede contener letras minúsculas, números, '@' y '.'.";
                return false;
            }
            return true;
        }
    }
}
