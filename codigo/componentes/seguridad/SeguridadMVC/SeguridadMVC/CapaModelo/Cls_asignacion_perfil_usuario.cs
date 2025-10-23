using System;
using System.Linq;
/* Brandon Alexander Hernandez Salguero
 * 0901-22-9663
 */

namespace Capa_Modelo_Seguridad
{
    public class Cls_asignacion_perfil_usuario
    {
        public int Fk_Id_Usuario { get; set; }
        public int Fk_Id_Perfil { get; set; }

        public Cls_asignacion_perfil_usuario() { }

        public Cls_asignacion_perfil_usuario(int iFk_Id_Usuario, int iFk_Id_Perfil)
        {
            this.Fk_Id_Usuario = iFk_Id_Usuario;
            this.Fk_Id_Perfil = iFk_Id_Perfil;
        }
    }
}