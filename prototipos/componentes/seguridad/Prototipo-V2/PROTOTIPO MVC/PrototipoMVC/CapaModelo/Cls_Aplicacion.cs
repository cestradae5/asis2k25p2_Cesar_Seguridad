//Cesar Armando Estrtada Elias 0901-22-10153
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CapaModelo
{
    public class Cls_Aplicacion
    {
        public int PkIdAplicacion { get; set; }
        public int? FkIdReporte { get; set; }
        public string NombreAplicacion { get; set; }
        public string DescripcionAplicacion { get; set; }
        public bool HabilitadoAplicacion { get; set; }
        public bool DeshabilitadoAplicacion { get; set; }
        public Cls_Aplicacion() { }
            public Cls_Aplicacion(int pkIdAplicacion, int? fkIdReporte, string nombreAplicacion, string descripcionAplicacion, bool habilitadoAplicacion, bool deshabilitadoAplicacion)
            {
                PkIdAplicacion = pkIdAplicacion;
                FkIdReporte = fkIdReporte;
                NombreAplicacion = nombreAplicacion;
                DescripcionAplicacion = descripcionAplicacion;
                HabilitadoAplicacion = habilitadoAplicacion;
                DeshabilitadoAplicacion = deshabilitadoAplicacion;
            }

        }
    }

