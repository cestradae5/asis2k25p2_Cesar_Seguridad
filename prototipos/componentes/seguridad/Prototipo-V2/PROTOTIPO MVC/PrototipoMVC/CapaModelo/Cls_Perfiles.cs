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
        public int iPk_Id_Perfil { get; set; }
        public string sCmp_Puesto_Perfil { get; set; }
        public string sCmp_Descripcion_Perfil { get; set; }
        public bool bCmp_Estado_Perfil { get; set; }
        public int iCmp_Tipo_Perfil { get; set; }

        public Cls_Perfiles() { }

        public Cls_Perfiles(int iPkIdPerfil, string sCmpPuestoPerfil, string sCmpDescripcionPerfil, bool bCmpEstadoPerfil, int iCmpTipoPerfil)
        {
            this.iPk_Id_Perfil = iPkIdPerfil;
            this.sCmp_Puesto_Perfil = sCmpPuestoPerfil;
            this.sCmp_Descripcion_Perfil = sCmpDescripcionPerfil;
            this.bCmp_Estado_Perfil = bCmpEstadoPerfil;
            this.iCmp_Tipo_Perfil = iCmpTipoPerfil;
        }
    }
}