//Cesar Armando Estrada Elias 0901-22-10153
using System;
using System.Collections.Generic;
using System.Data.Odbc;

namespace CapaModelo
{
    public class Cls_AplicacionDAO
    {
        private Conexion conexion = new Conexion();

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

        // Obtener todas las aplicaciones
        public List<Cls_Aplicacion> ObtenerAplicaciones()
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
                        PkIdAplicacion = reader.GetInt32(0),
                        FkIdReporte = reader.IsDBNull(1) ? (int?)null : reader.GetInt32(1),
                        NombreAplicacion = reader.GetString(2),
                        DescripcionAplicacion = reader.GetString(3),
                        EstadoAplicacion = reader.GetBoolean(4)
                    };
                    lista.Add(app);
                }
            }
            return lista;
        }

        // Insertar una nueva aplicación
        public int InsertarAplicacion(Cls_Aplicacion app)
        {
            using (OdbcConnection conn = conexion.conexion())
            {
                OdbcCommand cmd = new OdbcCommand(SQL_INSERT, conn);

                cmd.Parameters.AddWithValue("@Pk_Id_Aplicacion", app.PkIdAplicacion);
                cmd.Parameters.AddWithValue("@Fk_Id_Reporte_Aplicacion", app.FkIdReporte.HasValue ? (object)app.FkIdReporte.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@Cmp_Nombre_Aplicacion", app.NombreAplicacion);
                cmd.Parameters.AddWithValue("@Cmp_Descripcion_Aplicacion", app.DescripcionAplicacion);
                cmd.Parameters.AddWithValue("@Cmp_Estado_Aplicacion", app.EstadoAplicacion);

                return cmd.ExecuteNonQuery();
            }
        }

        // Actualizar aplicación
        public int ActualizarAplicacion(Cls_Aplicacion app)
        {
            using (OdbcConnection conn = conexion.conexion())
            {
                OdbcCommand cmd = new OdbcCommand(SQL_UPDATE, conn);

                cmd.Parameters.AddWithValue("@Fk_Id_Reporte_Aplicacion", app.FkIdReporte.HasValue ? (object)app.FkIdReporte.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@Cmp_Nombre_Aplicacion", app.NombreAplicacion);
                cmd.Parameters.AddWithValue("@Cmp_Descripcion_Aplicacion", app.DescripcionAplicacion);
                cmd.Parameters.AddWithValue("@Cmp_Estado_Aplicacion", app.EstadoAplicacion);
                cmd.Parameters.AddWithValue("@Pk_Id_Aplicacion", app.PkIdAplicacion);

                return cmd.ExecuteNonQuery();
            }
        }

        // Borrar aplicación y sus dependencias
        public int BorrarAplicacion(int idAplicacion)
        {
            using (OdbcConnection conn = conexion.conexion())
            {
                using (OdbcTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Eliminar registros dependientes en tbl_ASIGNACION_MODULO_APLICACION
                        string sqlDeleteDependientes = "DELETE FROM tbl_ASIGNACION_MODULO_APLICACION WHERE fk_id_aplicacion = ?";
                        using (OdbcCommand cmdDependientes = new OdbcCommand(sqlDeleteDependientes, conn, transaction))
                        {
                            cmdDependientes.Parameters.AddWithValue("@fk_id_aplicacion", idAplicacion);
                            cmdDependientes.ExecuteNonQuery();
                        }

                        // 2. Eliminar registro en Tbl_Aplicacion
                        using (OdbcCommand cmd = new OdbcCommand(SQL_DELETE, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@Pk_Id_Aplicacion", idAplicacion);
                            int result = cmd.ExecuteNonQuery();

                            // 3. Confirmar cambios
                            transaction.Commit();
                            return result;
                        }
                    }
                    catch
                    {
                        // Si algo falla, revertimos todo
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        // Buscar una aplicación por ID
        public Cls_Aplicacion Query(int idAplicacion)
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
                        PkIdAplicacion = reader.GetInt32(0),
                        FkIdReporte = reader.IsDBNull(1) ? (int?)null : reader.GetInt32(1),
                        NombreAplicacion = reader.GetString(2),
                        DescripcionAplicacion = reader.GetString(3),
                        EstadoAplicacion = reader.GetBoolean(4)
                    };
                }
            }
            return app;
        }
    }
}
