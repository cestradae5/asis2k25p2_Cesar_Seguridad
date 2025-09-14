using System;
/* Brandon Alexander Hernandez Salguero
 * 0901-22-9663
 */

namespace CapaModelo
{
    public class Cls_asignacion_perfil_usuario
    {
        public int fk_id_usuario { get; set; }
        public int fk_id_perfil { get; set; }

        public Cls_asignacion_perfil_usuario() { }

        public Cls_asignacion_perfil_usuario(int fk_id_usuario, int fk_id_perfil)
        {
            this.fk_id_usuario = fk_id_usuario;
            this.fk_id_perfil = fk_id_perfil;
        }
    }
}
