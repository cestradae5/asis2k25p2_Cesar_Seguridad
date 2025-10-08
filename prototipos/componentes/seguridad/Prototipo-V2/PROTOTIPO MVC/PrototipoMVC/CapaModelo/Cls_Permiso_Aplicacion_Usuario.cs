using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Modelo_Seguridad
{
   public class Cls_Permiso_Aplicacion_Usuario
    {
        public int IdUsuario { get; set; }
        public int IdAplicacion { get; set; }
        public bool Ingresar { get; set; }
        public bool Consultar { get; set; }
        public bool Modificar { get; set; }
        public bool Eliminar { get; set; }
        public bool Imprimir { get; set; }
    }
}
