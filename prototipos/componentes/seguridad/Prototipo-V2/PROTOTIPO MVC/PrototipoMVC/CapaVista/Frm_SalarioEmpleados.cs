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
    public partial class Frm_SalarioEmpleados : Form { 

        



    
        public Frm_SalarioEmpleados()
        {
            InitializeComponent();
            /*ConfigurarIdsDinamicamenteYAplicarPermisos();*/
            
        }

        //Marcos Andres Velásquez Alcántara
        //Carnet: 0901-21-1115
        /*
        private Cls_PermisoUsuario gPermisoUsuario = new Cls_PermisoUsuario();

        private List<(int moduloId, int aplicacionId)> gParesModuloAplicacion = new List<(int, int)>();

        private Dictionary<(int moduloId, int aplicacionId), (bool bIngresar, bool bConsultar, bool bModificar, bool bEliminar, bool bImprimir)> gPermisosPorModuloApp
            = new Dictionary<(int, int), (bool, bool, bool, bool, bool)>();


        private void ConfigurarIdsDinamicamenteYAplicarPermisos()
        {
            int usuarioId = Capa_Controlador_Seguridad.Cls_UsuarioConectado.iIdUsuario;

            var sParesNombres = new List<(string sModulo, string sAplicacion)>
    {
        ("Empleado", "Empleado"),
        ("Empleado", "Empleados"),
        ("RHM", "Gestion de empleado"),
        ("RHM", "Gestion De Empleados"),
        ("Recursos", "Gestion de empleado"),
        ("Seguridad", "Gestion de empleado"),
        ("Seguridad", "Administracion"),
    };

            foreach (var (sNombreModulo, sNombreAplicacion) in sParesNombres)
            {
                int idModulo = gPermisoUsuario.ObtenerIdModuloPorNombre(sNombreModulo);
                int idAplicacion = gPermisoUsuario.ObtenerIdAplicacionPorNombre(sNombreAplicacion);

                if (idModulo != -1 && idAplicacion != -1)
                {
                    gParesModuloAplicacion.Add((idModulo, idAplicacion));
                }
            }

            AplicarPermisosUsuario(usuarioId);
        }

        private void AplicarPermisosUsuario(int usuarioId)
        {
            foreach (var (moduloId, aplicacionId) in gParesModuloAplicacion)
            {
                var bPermisos = gPermisoUsuario.ConsultarPermisos(usuarioId, aplicacionId, moduloId);

                if (bPermisos != null)
                {
                    gPermisosPorModuloApp[(moduloId, aplicacionId)] = bPermisos.Value;
                }
            }

            CombinarPermisosYActualizarBotones();
        }

        private void CombinarPermisosYActualizarBotones()
        {
            bool bIngresar = false, bConsultar = false, bModificar = false, bEliminar = false;

            foreach (var bPermiso in gPermisosPorModuloApp.Values)
            {
                bIngresar |= bPermiso.bIngresar;
                bConsultar |= bPermiso.bConsultar;
                bModificar |= bPermiso.bModificar;
                bEliminar |= bPermiso.bEliminar;
            }

            Btn_nuevo_salario.Enabled = bIngresar;
            Btn_guardar_salario.Enabled = bIngresar;
            Btn_modificar_salario.Enabled = bModificar;
            Btn_eliminar_salario.Enabled = bEliminar;
        }*/


    }
}
