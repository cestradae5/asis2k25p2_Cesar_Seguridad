//Cesar Armando Estrada Elias 0901-22-10153
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Data;

namespace Capa_Modelo_Seguridad
{
    public class Cls_AplicacionDAO
    {
        private Cls_Conexion conexion = new Cls_Conexion();

        private static readonly string SQL_SELECT = @"
            SELECT Pk_Id_Aplicacion, Fk_Id_Reporte_Aplicacion, Cmp_Nombre_Aplicacion, 
                   Cmp_Descripcion_Aplicacion, Cmp_Estado_Aplicacion
            FROM Tbl_Aplicacion";

        private static readonly string SQL_INSERT = @"
            INSERT INTO Tbl_Aplicacion 
                (Pk_Id_Aplicacion, Fk_Id_Reporte_Aplicacion, Cmp_Nombre_Aplicacion, Cmp_Descripcion_Aplicacion, Cmp_Estado_Aplicacion)
            VALUES (?, ?, ?, ?, ?)";

        private static readonly string SQL_UPDATE = @"
            UPDATE Tbl_Aplicacion SET
                Fk_Id_Reporte_Aplicacion = ?, 
                Cmp_Nombre_Aplicacion = ?, 
                Cmp_Descripcion_Aplicacion = ?, 
                Cmp_Estado_Aplicacion = ?
            WHERE Pk_Id_Aplicacion = ?";

        private static readonly string SQL_DELETE = "DELETE FROM Tbl_Aplicacion WHERE Pk_Id_Aplicacion = ?";

        private static readonly string SQL_QUERY = @"
            SELECT Pk_Id_Aplicacion, Fk_Id_Reporte_Aplicacion, Cmp_Nombre_Aplicacion, 
                   Cmp_Descripcion_Aplicacion, Cmp_Estado_Aplicacion
            FROM Tbl_Aplicacion 
            WHERE Pk_Id_Aplicacion = ?";

        // ===============================================================
        // FUNCIÓN: fun_obtener_aplicaciones
        // Descripción: Retorna una lista con todas las aplicaciones registradas.
        // ===============================================================
        public List<Cls_Aplicacion> fun_ObtenerAplicaciones()
        {
            List<Cls_Aplicacion> lista = new List<Cls_Aplicacion>();
            using (OdbcConnection conn = conexion.conexion())
            {
                OdbcCommand cmd = new OdbcCommand(SQL_SELECT, conn);
                OdbcDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Cls_Aplicacion app = new Cls_Aplicacion
                    {
                        iPkIdAplicacion = reader.GetInt32(0),
                        iFkIdReporte = reader.IsDBNull(1) ? (int?)null : reader.GetInt32(1),
                        sNombreAplicacion = reader.GetString(2),
                        sDescripcionAplicacion = reader.GetString(3),
                        bEstadoAplicacion = reader.GetBoolean(4)
                    };
                    lista.Add(app);
                }
            }
            return lista;
        }

        // ===============================================================
        // PROCEDIMIENTO: pro_insertar_aplicacion
        // Descripción: Inserta una nueva aplicación en la tabla Tbl_Aplicacion.
        // ===============================================================
        public int pro_InsertarAplicacion(Cls_Aplicacion app)
        {
            using (OdbcConnection conn = conexion.conexion())
            {
                OdbcCommand cmd = new OdbcCommand(SQL_INSERT, conn);

                // VERIFICA EL ORDEN DE LOS PARÁMETROS
                cmd.Parameters.AddWithValue("@Pk_Id_Aplicacion", app.iPkIdAplicacion);
                cmd.Parameters.AddWithValue("@Fk_Id_Reporte_Aplicacion",
                    app.iFkIdReporte.HasValue ? (object)app.iFkIdReporte.Value : DBNull.Value); // Este es importante
                cmd.Parameters.AddWithValue("@Cmp_Nombre_Aplicacion", app.sNombreAplicacion);
                cmd.Parameters.AddWithValue("@Cmp_Descripcion_Aplicacion", app.sDescripcionAplicacion);
                cmd.Parameters.AddWithValue("@Cmp_Estado_Aplicacion", app.bEstadoAplicacion);

                // Agrega depuración
                Console.WriteLine($"DEBUG DAO: Insertando aplicación - ID: {app.iPkIdAplicacion}, Reporte: {app.iFkIdReporte}");

                return cmd.ExecuteNonQuery();
            }
        }

        // ===============================================================
        // PROCEDIMIENTO: pro_actualizar_aplicacion
        // Descripción: Actualiza una aplicación existente en la base de datos.
        // ===============================================================
        public int pro_ActualizarAplicacion(Cls_Aplicacion app)
        {
            using (OdbcConnection conn = conexion.conexion())
            {
                OdbcCommand cmd = new OdbcCommand(SQL_UPDATE, conn);

                cmd.Parameters.AddWithValue("@Fk_Id_Reporte_Aplicacion", app.iFkIdReporte.HasValue ? (object)app.iFkIdReporte.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@Cmp_Nombre_Aplicacion", app.sNombreAplicacion);
                cmd.Parameters.AddWithValue("@Cmp_Descripcion_Aplicacion", app.sDescripcionAplicacion);
                cmd.Parameters.AddWithValue("@Cmp_Estado_Aplicacion", app.bEstadoAplicacion);
                cmd.Parameters.AddWithValue("@Pk_Id_Aplicacion", app.iPkIdAplicacion);

                return cmd.ExecuteNonQuery();
            }
        }

        // ===============================================================
        // PROCEDIMIENTO: pro_borrar_aplicacion
        // Descripción: Elimina una aplicación y sus dependencias en Tbl_Asignacion_Modulo_Aplicacion.
        // ===============================================================
        public int pro_BorrarAplicacion(int idAplicacion)
        {
            using (OdbcConnection conn = conexion.conexion())
            {
                // NO USAMOS TRANSACCIÓN NI BORRAMOS DEPENDENCIAS AQUÍ,
                // ya que la verificación se hace en la capa superior (Vista).
                using (OdbcCommand cmd = new OdbcCommand(SQL_DELETE, conn)) // Solo borra la aplicación
                {
                    cmd.Parameters.AddWithValue("@Pk_Id_Aplicacion", idAplicacion);
                    int result = cmd.ExecuteNonQuery();
                    return result;
                }
            }
        }

        // ===============================================================
        // FUNCIÓN: fun_buscar_aplicacion
        // Descripción: Devuelve una aplicación específica por su ID.
        // ===============================================================
        public Cls_Aplicacion fun_buscar_aplicacion(int idAplicacion)
        {
            Cls_Aplicacion app = null;
            using (OdbcConnection conn = conexion.conexion())
            {
                OdbcCommand cmd = new OdbcCommand(SQL_QUERY, conn);
                cmd.Parameters.AddWithValue("@Pk_Id_Aplicacion", idAplicacion);

                OdbcDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    app = new Cls_Aplicacion
                    {
                        iPkIdAplicacion = reader.GetInt32(0),
                        iFkIdReporte = reader.IsDBNull(1) ? (int?)null : reader.GetInt32(1),
                        sNombreAplicacion = reader.GetString(2),
                        sDescripcionAplicacion = reader.GetString(3),
                        bEstadoAplicacion = reader.GetBoolean(4)
                    };
                }
            }
            return app;
        }
        // ===============================================================
        // FUNCIÓN: fun_VerificarRelaciones
        // Descripción: Verifica si la aplicación tiene asignaciones activas (llaves foráneas).
        // ===============================================================
        public bool fun_VerificarRelaciones(int idAplicacion)
        {
            // Consulta para contar cuántos registros existen en la tabla de asignaciones 
            // donde la aplicación sea una llave foránea.
            string SQL_CHECK_RELATIONS = "SELECT COUNT(*) FROM Tbl_Asignacion_Modulo_Aplicacion WHERE Fk_Id_Aplicacion = ?";

            using (OdbcConnection conn = conexion.conexion())
            {
                OdbcCommand cmd = new OdbcCommand(SQL_CHECK_RELATIONS, conn);
                cmd.Parameters.AddWithValue("@Fk_Id_Aplicacion", idAplicacion);

                try
                {
                    // Ejecuta la consulta y obtiene el resultado
                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    // Si el conteo es mayor que 0, significa que existen relaciones.
                    return count > 0;
                }
                catch (Exception ex)
                {
                    // En caso de error (ej. conexión), asumimos que hay riesgo
                    // y lanzamos para manejo superior o retornamos true para bloquear.
                    Console.WriteLine("Error al verificar relaciones: " + ex.Message);
                    return true;
                }
            }
        }
        // ===============================================================
        // FUNCIÓN: obtenerreportes
        // Descripción: verifica la tabla de reportes
        // ===============================================================
        public DataTable ObtenerReportes()
        {
            string SQL_SELECT_REPORTES = @"SELECT Pk_Id_Reporte 
                                 FROM Tbl_Reportes 
                                 ORDER BY Pk_Id_Reporte";

            DataTable dt = new DataTable();

            using (OdbcConnection conn = conexion.conexion())
            {
                OdbcDataAdapter da = new OdbcDataAdapter(SQL_SELECT_REPORTES, conn);
                da.Fill(dt);
            }

            return dt;
        }
    }
}