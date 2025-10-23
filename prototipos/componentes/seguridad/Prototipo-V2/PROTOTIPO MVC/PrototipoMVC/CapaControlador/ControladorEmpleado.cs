using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaModelo;

namespace CapaControlador
{
    public class ControladorEmpleado
    {
        SentenciaEmpleado sentencia = new SentenciaEmpleado();

        public bool GuardarEmpleado(int id, string nombre, string apellido, string dpi, string nit,
                                    string genero, string telefono, string correo, string fechaNacimiento, string fechaContrato)
        {
            int filas = sentencia.GuardarEmpleado(id, nombre, apellido, dpi, nit, genero, telefono, correo, fechaNacimiento, fechaContrato);
            return filas > 0;
        }
    }
}

