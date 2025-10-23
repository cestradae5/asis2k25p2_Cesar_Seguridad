//Cesar Armando Estrada Elias 0901-22-10153 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;
using System.Data;

namespace Capa_Modelo_Seguridad
{
    public class Cls_Asignacion_Modulo_AplicacionDAO
    {
        private Cls_Conexion conexion = new Cls_Conexion();

        private static readonly string SQL_INSERT =
            "INSERT INTO Tbl_Asignacion_Modulo_Aplicacion (Fk_Id_Modulo, Fk_Id_Aplicacion) VALUES (?, ?)";

        private static readonly string SQL_EXISTE =
            "SELECT COUNT(*) FROM Tbl_Asignacion_Modulo_Aplicacion WHERE Fk_Id_Modulo = ? AND Fk_Id_Aplicacion = ?";

        private static readonly string SQL_SELECT = @"
            SELECT a.Fk_Id_Aplicacion, app.Cmp_Nombre_Aplicacion,
                   a.Fk_Id_Modulo, m.Cmp_Nombre_Modulo
            FROM Tbl_Asignacion_Modulo_Aplicacion a
            INNER JOIN Tbl_Aplicacion app ON a.Fk_Id_Aplicacion = app.Pk_Id_Aplicacion
            INNER JOIN Tbl_Modulo m ON a.Fk_Id_Modulo = m.Pk_Id_Modulo";

        // Insertar nueva asignación
        public int InsertarAsignacion(int iIdModulo, int iIdAplicacion)
        {
            using (OdbcConnection conn = conexion.conexion())
            {
                using (OdbcCommand cmd = new OdbcCommand(SQL_INSERT, conn))
                {
                    // ODBC usa parámetros en orden
                    cmd.Parameters.AddWithValue("?", iIdModulo);
                    cmd.Parameters.AddWithValue("?", iIdAplicacion);

                    int filas = cmd.ExecuteNonQuery();
                    conexion.desconexion(conn); // cerramos la conexión
                    return filas;
                }
            }
        }

        // Verificar si ya existe la asignación
        public bool ExisteAsignacion(int iIdModulo, int iIdAplicacion)
        {
            using (OdbcConnection conn = conexion.conexion())
            {
                using (OdbcCommand cmd = new OdbcCommand(SQL_EXISTE, conn))
                {
                    cmd.Parameters.AddWithValue("?", iIdModulo);
                    cmd.Parameters.AddWithValue("?", iIdAplicacion);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    conexion.desconexion(conn); // cerramos la conexión
                    return count > 0;
                }
            }
        }

        // Obtener todas las asignaciones con JOIN
        public DataTable ObtenerAsignaciones()
        {
            using (OdbcConnection conn = conexion.conexion())
            {
                using (OdbcDataAdapter da = new OdbcDataAdapter(SQL_SELECT, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    conexion.desconexion(conn); // cerramos la conexión
                    return dt;
                }
            }
        }
    }
}
