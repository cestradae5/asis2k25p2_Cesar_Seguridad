using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Odbc;

namespace CapaModelo
{
    public class SentenciaEmpleado
    {
        Conexion conexion = new Conexion();

        public int GuardarEmpleado(int id, string nombre, string apellido, string dpi, string nit,
                                   string genero, string telefono, string correo, string fechaNacimiento, string fechaContrato)
        {
            string sql = @"INSERT INTO tbl_EMPLEADO
                           (pk_id_empleado, nombre_empleado, apellido_empleado, dpi_empleado, nit_empleado,
                            genero_empleado, telefono_empleado, correo_empleado, fecha_nacimiento_empleado, fecha_contrato_empleado)
                           VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";

            OdbcCommand cmd = new OdbcCommand(sql, conexion.conexion());
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@apellido", apellido);
            cmd.Parameters.AddWithValue("@dpi", dpi);
            cmd.Parameters.AddWithValue("@nit", nit);
            cmd.Parameters.AddWithValue("@genero", genero);
            cmd.Parameters.AddWithValue("@telefono", telefono);
            cmd.Parameters.AddWithValue("@correo", correo);
            cmd.Parameters.AddWithValue("@fechaNacimiento", fechaNacimiento);
            cmd.Parameters.AddWithValue("@fechaContrato", fechaContrato);

            return cmd.ExecuteNonQuery();
        }
    }
}

