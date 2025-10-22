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
        //cambios por cesar estrada
        public List<EmpleadoComboBoxData> fun_ObtenerEmpleadosParaComboBox()
        {
            // Esto SÍ es correcto: el Controlador usa el Modelo
            var empleados = daoEmpleado.fun_ObtenerEmpleados();
            var resultado = new List<EmpleadoComboBoxData>();

            foreach (var emp in empleados) // emp es Cls_Empleado (Modelo)
            {
                resultado.Add(new EmpleadoComboBoxData
                {
                    Id = emp.iPkIdEmpleado,
                    Display = $"{emp.iPkIdEmpleado} - {emp.sNombresEmpleado} {emp.sApellidosEmpleado}"
                });
            }

            return resultado;
        }
        // Clase auxiliar para transferencia de datos Vista-Controlador
        public class EmpleadoComboBoxData
        {
            public int Id { get; set; }
            public string Display { get; set; }
        }

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

        // --- Métodos para evitar que la vista tenga referencia al modelo ---
        public Dictionary<string, object> fun_ObtenerEmpleadoComoDiccionario(int id)
        {
            var emp = daoEmpleado.Query(id);
            if (emp == null) return null;

            return new Dictionary<string, object>
            {
                { "Id", emp.iPkIdEmpleado },
                { "Nombre", emp.sNombresEmpleado },
                { "Apellido", emp.sApellidosEmpleado },
                { "Dpi", emp.lDpiEmpleado },
                { "Nit", emp.lNitEmpleado },
                { "Correo", emp.sCorreoEmpleado },
                { "Telefono", emp.sTelefonoEmpleado },
                { "Genero", emp.bGeneroEmpleado },
                { "FechaNacimiento", emp.dFechaNacimientoEmpleado },
                { "FechaContratacion", emp.dFechaContratacionEmpleado }
            };
        }

        public List<Dictionary<string, object>> fun_ObtenerEmpleadosComoDiccionarios()
        {
            var lista = daoEmpleado.fun_ObtenerEmpleados();
            var resultado = new List<Dictionary<string, object>>();

            foreach (var emp in lista)
            {
                resultado.Add(new Dictionary<string, object>
                {
                    { "Id", emp.iPkIdEmpleado },
                    { "Nombre", emp.sNombresEmpleado },
                    { "Apellido", emp.sApellidosEmpleado },
                    { "Display", $"{emp.iPkIdEmpleado} - {emp.sNombresEmpleado} {emp.sApellidosEmpleado}" }
                });
            }

            return resultado;
        }

        public Dictionary<string, object> fun_BuscarEmpleado(string busqueda)
        {
            var listaEmpleados = daoEmpleado.fun_ObtenerEmpleados();
            Cls_Empleado empEncontrado = null;

            // Buscar por ID
            if (int.TryParse(busqueda.Split('-')[0].Trim(), out int id))
            {
                empEncontrado = listaEmpleados.FirstOrDefault(a => a.iPkIdEmpleado == id);
            }

            // Si no se encuentra, buscar por nombre
            if (empEncontrado == null)
            {
                empEncontrado = listaEmpleados.FirstOrDefault(a =>
                    a.sNombresEmpleado.Equals(busqueda, StringComparison.OrdinalIgnoreCase));
            }

            if (empEncontrado == null) return null;

            return new Dictionary<string, object>
            {
                { "Id", empEncontrado.iPkIdEmpleado },
                { "Nombre", empEncontrado.sNombresEmpleado },
                { "Apellido", empEncontrado.sApellidosEmpleado },
                { "Dpi", empEncontrado.lDpiEmpleado },
                { "Nit", empEncontrado.lNitEmpleado },
                { "Correo", empEncontrado.sCorreoEmpleado },
                { "Telefono", empEncontrado.sTelefonoEmpleado },
                { "Genero", empEncontrado.bGeneroEmpleado },
                { "FechaNacimiento", empEncontrado.dFechaNacimientoEmpleado },
                { "FechaContratacion", empEncontrado.dFechaContratacionEmpleado }
            };
        }

        // --- Métodos de validación y lógica de negocio extraídos de la vista ---
        public bool ValidarNombreOApellido(char keyChar)
        {
            return char.IsLetter(keyChar) || char.IsControl(keyChar) || keyChar == ' ';
        }

        // --- Métodos para sistema de permisos (sin exponer el modelo a la vista) ---
        public int ObtenerIdUsuarioConectado()
        {
            return Cls_Usuario_Conectado.iIdUsuario;
        }

        public class PermisosEmpleado
        {
            public bool ingresar { get; set; }
            public bool consultar { get; set; }
            public bool modificar { get; set; }
            public bool eliminar { get; set; }
            public bool imprimir { get; set; }
        }

        public PermisosEmpleado ObtenerPermisos()
        {
            int idUsuario = Cls_Usuario_Conectado.iIdUsuario;
            var usuarioCtrl = new Cls_Usuario_Controlador();
            var permisoUsuario = new Cls_Permiso_Usuario();

            int idAplicacion = permisoUsuario.ObtenerIdAplicacionPorNombre("Empleados");
            if (idAplicacion <= 0) idAplicacion = 301;
            int idModulo = permisoUsuario.ObtenerIdModuloPorNombre("Seguridad");
            int idPerfil = usuarioCtrl.ObtenerIdPerfilDeUsuario(idUsuario);

            var permisos = Cls_Aplicacion_Permisos.ObtenerPermisosCombinados(idUsuario, idAplicacion, idModulo, idPerfil);

            return new PermisosEmpleado
            {
                ingresar = permisos.ingresar,
                consultar = permisos.consultar,
                modificar = permisos.modificar,
                eliminar = permisos.eliminar,
                imprimir = permisos.imprimir
            };
        }

        // --- Métodos de validación y lógica de negocio ---

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
            // Permitir control y dígitos siempre
            if (!(char.IsDigit(keyChar) || char.IsControl(keyChar) || keyChar == '-'))
                return false;

            // Si se intenta escribir un guion, solo permitirlo si es la posición 5 (índice 4)
            if (keyChar == '-')
            {
                // Si ya existe un guion no permitir otro
                if (textoActual.Contains("-")) return false;
                // Permitir guion solo si se está escribiendo en la 5ª posición (textoActual length == 4)
                if (textoActual.Length != 4) return false;
                return true;
            }

            // Para dígitos, permitir máximo 8 dígitos (sin contar guion)
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
            // Validar teléfono: aceptar 8 dígitos seguidos (12345678) o con un guion en medio (1234-5678)
            if (!System.Text.RegularExpressions.Regex.IsMatch(telefono, @"^(\d{8}|\d{4}-\d{4})$"))
            {
                mensajeError = "El teléfono debe tener el formato 12345678 o 1234-5678.";
                return false;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(correo, @"^[a-z0-9@.]+$"))
            {
                mensajeError = "El correo solo puede contener letras minúsculas, números, '@' y '.'.";
                return false;
            }
            // Verificar dominios permitidos
            string correoLower = correo?.ToLowerInvariant() ?? string.Empty;
            if (!(correoLower.EndsWith("@gmail.com") || correoLower.EndsWith("@miumg.edu.gt")))
            {
                mensajeError = "El correo debe terminar en @gmail.com o @miumg.edu.gt.";
                return false;
            }
            return true;
        }
    }
}
