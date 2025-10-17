using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Modelo_Componente_Consultas;
// CARLO ANDREE BARQUERO BOCHE 0901-22-601 15/10/2025
// Diego André Monterroso Rabarique 0901-22-1369

namespace Capa_Controlador_Componente_Consultas
{
    public class Controlador
    {
        //  Inicializa sentencia 
        Sentencias sentencias = new Sentencias();


        // Funcion para Obtencion De Tablas
        public DataTable fun_ObtenerTablas()
        {
            return sentencias.fun_ObtenerTablas();
        }

        // Funcion para poder ejecutar la consulta 
        public DataTable fun_EjecutarConsulta(string stabla, string sorden)
        {
            return sentencias.fun_EjecutarConsulta(stabla, sorden);
        }

        // Jose Pablo Medina 0901-22-22592 15/10/2025
        // Ejecuta consulta con filtro (busca en todas las columnas)
        public DataTable fun_EjecutarConsultaConFiltro(string stabla, string sfiltro, string sorden)
        {
            return sentencias.fun_EjecutarConsultaConFiltro(stabla, sfiltro, sorden);
        }

        // Jose Pablo Medina 0901-22-22592 15/10/2025
        // Funcion para poder ejecutar la consulta Filtrada
        public DataTable fun_ConsultaFiltrada(string tabla, string campo, string operador, string valor, string sorden)
        {
            return sentencias.fun_EjecutarConsultaCondicional(tabla, campo, operador, valor, sorden);
        }


        // RICHARD ANTONY DE LEON 0901 - 22 - 10265 13/10/2025
        // Funcion para poder ejecutar la consulta po orden
        public DataTable fun_ConsultaOrdenada(string tabla, bool asc)
        {
            return sentencias.fun_ConsultaOrdenada(tabla, asc);
        }

    }

}

