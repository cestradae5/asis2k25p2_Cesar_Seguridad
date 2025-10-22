using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Modelo_Seguridad
{
   public class Cls_Permiso_Aplicacion_Usuario
    {
        public int Fk_Id_Usuario { get; set; }
        public int FK_Id_Aplicacion { get; set; }
        public bool Cmp_Ingresar_Permiso_Aplicacion_Usuario { get; set; }
        public bool Cmp_Consultar_Permiso_Aplicacion_Usuario { get; set; }
        public bool Cmp_Modificar_Permiso_Aplicacion_Usuario { get; set; }
        public bool Cmp_Eliminar_Permiso_Aplicacion_Usuario { get; set; }
        public bool Cmp_Imprimir_Permiso_Aplicacion_Usuario { get; set; }
    }
}
