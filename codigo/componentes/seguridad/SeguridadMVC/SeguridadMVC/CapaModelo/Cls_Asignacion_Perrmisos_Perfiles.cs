using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/* Brandon Alexander Hernandez Salguero
 * 0901-22-9663
 */

namespace Capa_Modelo_Seguridad
{
    public class Cls_Asignacion_Perrmisos_Perfiles
    {
        public int iFk_id_modulo { get; set; }
        public int iFk_id_perfil { get; set; }
        public int iFk_id_aplicacion { get; set; }
        public bool bIngresar_permiso_aplicacion_perfil { get; set; }
        public bool bConsultar_permiso_aplicacion_perfil { get; set; }
        public bool bModificar_permiso_aplicacion_perfil { get; set; }
        public bool bEliminar_permiso_aplicacion_perfil { get; set; }
        public bool bImprimir_permiso_aplicacion_perfil { get; set; }

        public Cls_Asignacion_Perrmisos_Perfiles(){}

        public Cls_Asignacion_Perrmisos_Perfiles(
            int iFk_id_modulo,
            int iFk_id_perfil,
            int iFk_id_aplicacion,
            bool bIngresar_permiso_aplicacion_perfil,
            bool bConsultar_permiso_aplicacion_perfil,
            bool bModificar_permiso_aplicacion_perfil,
            bool bEliminar_permiso_aplicacion_perfil,
            bool bImprimir_permiso_aplicacion_perfil)
        {
            this.iFk_id_modulo = iFk_id_modulo;
            this.iFk_id_perfil = iFk_id_perfil;
            this.bIngresar_permiso_aplicacion_perfil = bIngresar_permiso_aplicacion_perfil;
            this.bConsultar_permiso_aplicacion_perfil = bConsultar_permiso_aplicacion_perfil;
            this.bModificar_permiso_aplicacion_perfil = bModificar_permiso_aplicacion_perfil;
            this.bEliminar_permiso_aplicacion_perfil = bEliminar_permiso_aplicacion_perfil;
            this.bImprimir_permiso_aplicacion_perfil = bImprimir_permiso_aplicacion_perfil;
        }




    }
}
