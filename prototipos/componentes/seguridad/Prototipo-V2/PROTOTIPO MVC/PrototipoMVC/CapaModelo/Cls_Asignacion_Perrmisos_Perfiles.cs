using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/* Brandon Alexander Hernandez Salguero
 * 0901-22-9663
 */

namespace CapaModelo
{
    public class Cls_Asignacion_Perrmisos_Perfiles
    {
        public int fk_id_modulo { get; set; }
        public int fk_id_perfil { get; set; }
        public int fk_id_aplicacion { get; set; }
        public bool ingresar_permiso_aplicacion_perfil { get; set; }
        public bool consultar_permiso_aplicacion_perfil { get; set; }
        public bool modificar_permiso_aplicacion_perfil { get; set; }
        public bool eliminar_permiso_aplicacion_perfil { get; set; }
        public bool imprimir_permiso_aplicacion_perfil { get; set; }

        public Cls_Asignacion_Perrmisos_Perfiles(){}

        public Cls_Asignacion_Perrmisos_Perfiles(
            int fk_id_modulo,
            int fk_id_perfil,
            int fk_id_aplicacion,
            bool ingresar_permiso_aplicacion_perfil,
            bool consultar_permiso_aplicacion_perfil,
            bool modificar_permiso_aplicacion_perfil,
            bool eliminar_permiso_aplicacion_perfil,
            bool imprimir_permiso_aplicacion_perfil)
        {
            this.fk_id_modulo = fk_id_modulo;
            this.fk_id_perfil = fk_id_perfil;
            this.ingresar_permiso_aplicacion_perfil = ingresar_permiso_aplicacion_perfil;
            this.consultar_permiso_aplicacion_perfil = consultar_permiso_aplicacion_perfil;
            this.modificar_permiso_aplicacion_perfil = modificar_permiso_aplicacion_perfil;
            this.eliminar_permiso_aplicacion_perfil = eliminar_permiso_aplicacion_perfil;
            this.imprimir_permiso_aplicacion_perfil = imprimir_permiso_aplicacion_perfil;
        }




    }
}
