using System;
using System.Data;
using System.Data.Odbc;
using System.Collections.Generic;



namespace Capa_Modelo_Seguridad
{
    /* Brandon Alexander Hernandez Salguero
     * 0901-22-9663
     * Adaptado a los campos de la nueva tabla (ver imagen1)
     */
    public class Cls_Perfiles
    {
        public int Pk_Id_Perfil { get; set; }
        public string Cmp_Puesto_Perfil { get; set; }
        public string Cmp_Descripcion_Perfil { get; set; }
        public bool Cmp_Estado_Perfil { get; set; }
        public int Cmp_Tipo_Perfil { get; set; }

        public Cls_Perfiles() { }

        public Cls_Perfiles(int pkIdPerfil, string cmpPuestoPerfil, string cmpDescripcionPerfil, bool cmpEstadoPerfil, int cmpTipoPerfil)
        {
            this.Pk_Id_Perfil = pkIdPerfil;
            this.Cmp_Puesto_Perfil = cmpPuestoPerfil;
            this.Cmp_Descripcion_Perfil = cmpDescripcionPerfil;
            this.Cmp_Estado_Perfil = cmpEstadoPerfil;
            this.Cmp_Tipo_Perfil = cmpTipoPerfil;
        }
    }
}