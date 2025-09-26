using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Controlador_Seguridad;
using Capa_Modelo_Seguridad;
namespace Capa_Vista_Seguridad
{
    public partial class frmSalarioEmpleados : Form { 

         // permisos 0901-21-1115 Marcos Andres Velásquez Alcántara
    private Cls_PermisoUsuario permisoUsuario = new Cls_PermisoUsuario();

    private int moduloId = -1;
    private int aplicacionId = -1;

    // Tupla para los permisos actuales
    private (bool ingresar, bool consultar, bool modificar, bool eliminar, bool imprimir)? permisosActuales = null;



    
        public frmSalarioEmpleados()
        {
            InitializeComponent();
            ConfigurarIdsDinamicamenteYAplicarPermisos();
            
        }


        //0901-21-1115 Marcos Andres Velasquez Alcánatara

        private void ConfigurarIdsDinamicamenteYAplicarPermisos()
        {
           
           string nombreModulo = "RHM";
            string nombreAplicacion = "Empleados";
            aplicacionId = permisoUsuario.ObtenerIdAplicacionPorNombre(nombreAplicacion);
            moduloId = permisoUsuario.ObtenerIdModuloPorNombre(nombreModulo);
            AplicarPermisosUsuario();
        }

        private void AplicarPermisosUsuario()
        {
            int usuarioId = Cls_sesion.iUsuarioId; // Usuario logueado
            if (aplicacionId == -1 || moduloId == -1)
            {
                permisosActuales = null;
                ActualizarEstadoBotonesSegunPermisos();
                return;
            }
            var permisos = permisoUsuario.ConsultarPermisos(usuarioId, aplicacionId, moduloId);
            permisosActuales = permisos;
            ActualizarEstadoBotonesSegunPermisos();
        }

        // Centraliza el habilitado/deshabilitado de botones según permisos y estado de navegación
        private void ActualizarEstadoBotonesSegunPermisos(bool empleadoCargado = false)
        {
            if (!permisosActuales.HasValue)
            {
                Btn_nuevo_salario.Enabled = false;
                Btn_modificar_salario.Enabled = false;
                Btn_guardar_salario.Enabled = false;
                Btn_eliminar_salario.Enabled = false;


                return;
            }

            var p = permisosActuales.Value;


            Btn_nuevo_salario.Enabled = p.ingresar;
            Btn_modificar_salario.Enabled = p.modificar;
            Btn_guardar_salario.Enabled = p.ingresar;
            Btn_eliminar_salario.Enabled = p.eliminar;

        }

    }
}
