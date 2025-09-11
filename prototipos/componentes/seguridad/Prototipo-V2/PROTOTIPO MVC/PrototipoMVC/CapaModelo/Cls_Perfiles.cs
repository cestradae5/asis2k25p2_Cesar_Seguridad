using System;
using System.Data;
using System.Data.Odbc;
using System.Collections.Generic;

namespace CapaModelo
{
    /* Brandon Alexander Hernandez Salguero
     * 0901-22-9663
     */
    public class Cls_Perfiles
    {
        public int pk_id_perfil { get; set; }
        public string puesto_perfil { get; set; }
        public string descripcion_perfil { get; set; }
        public bool estado_perfil { get; set; }
        public int tipo_perfil { get; set; }

        public Cls_Perfiles() { }

        public Cls_Perfiles(int pk_id_perfil, string puesto_perfil, string descripcion_perfil, bool estado_perfil, int tipo_perfil)
        {
            this.pk_id_perfil = pk_id_perfil;
            this.puesto_perfil = puesto_perfil;
            this.descripcion_perfil = descripcion_perfil;
            this.estado_perfil = estado_perfil;
            this.tipo_perfil = tipo_perfil;
        }
    }
}