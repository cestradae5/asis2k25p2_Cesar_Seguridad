//Cesar Armando Estrtada Elias 0901-22-10153
using System;
using System.Collections.Generic;
using System.Data.Odbc;

namespace CapaModelo
{
    public class Cls_AplicacionDAO
    {
        private Conexion conexion = new Conexion();

        private static readonly string SQL_SELECT = @"
            SELECT pk_id_aplicacion, fk_id_reporte, nombre_aplicacion, 
                   descripcion_aplicacion, habilitado_aplicacion, desabilitado_aplicacion
            FROM tbl_APLICACION";

        private static readonly string SQL_INSERT = @"
            INSERT INTO tbl_aplicacion 
                (pk_id_aplicacion, fk_id_reporte, nombre_aplicacion, descripcion_aplicacion,
                 habilitado_aplicacion, desabilitado_aplicacion)
            VALUES (?, ?, ?, ?, ?, ?)";

        private static readonly string SQL_UPDATE = @"
            UPDATE tbl_APLICACION SET
                fk_id_reporte = ?, 
                nombre_aplicacion = ?, 
                descripcion_aplicacion = ?, 
                habilitado_aplicacion = ?, 
                desabilitado_aplicacion = ?
            WHERE pk_id_aplicacion = ?";

        private static readonly string SQL_DELETE = "DELETE FROM tbl_APLICACION WHERE pk_id_aplicacion = ?";

        private static readonly string SQL_QUERY = @"
            SELECT pk_id_aplicacion, fk_id_reporte, nombre_aplicacion, 
                   descripcion_aplicacion, habilitado_aplicacion, desabilitado_aplicacion
            FROM tbl_APLICACION 
            WHERE pk_id_aplicacion = ?";

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
                        HabilitadoAplicacion = reader.GetBoolean(4),
                        DeshabilitadoAplicacion = reader.GetBoolean(5)
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

                // ID manual
                cmd.Parameters.AddWithValue("@pk_id_aplicacion", app.PkIdAplicacion);

                // fk_id_reporte opcional
                if (app.FkIdReporte.HasValue)
                    cmd.Parameters.AddWithValue("@fk_id_reporte", app.FkIdReporte.Value);
                else
                    cmd.Parameters.AddWithValue("@fk_id_reporte", DBNull.Value);

                cmd.Parameters.AddWithValue("@nombre_aplicacion", app.NombreAplicacion);
                cmd.Parameters.AddWithValue("@descripcion_aplicacion", app.DescripcionAplicacion);
                cmd.Parameters.AddWithValue("@habilitado_aplicacion", app.HabilitadoAplicacion);
                cmd.Parameters.AddWithValue("@desabilitado_aplicacion", app.DeshabilitadoAplicacion);

                return cmd.ExecuteNonQuery();
            }
        }

        // Actualizar aplicación
        public int ActualizarAplicacion(Cls_Aplicacion app)
        {
            using (OdbcConnection conn = conexion.conexion())
            {
                OdbcCommand cmd = new OdbcCommand(SQL_UPDATE, conn);

                cmd.Parameters.AddWithValue("@fk_id_reporte", app.FkIdReporte.HasValue ? (object)app.FkIdReporte.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@nombre_aplicacion", app.NombreAplicacion);
                cmd.Parameters.AddWithValue("@descripcion_aplicacion", app.DescripcionAplicacion);
                cmd.Parameters.AddWithValue("@habilitado_aplicacion", app.HabilitadoAplicacion);
                cmd.Parameters.AddWithValue("@desabilitado_aplicacion", app.DeshabilitadoAplicacion);
                cmd.Parameters.AddWithValue("@pk_id_aplicacion", app.PkIdAplicacion);

                return cmd.ExecuteNonQuery();
            }
        }

        // Borrar aplicación
        public int BorrarAplicacion(int idAplicacion)
        {
            using (OdbcConnection conn = conexion.conexion())
            {
                OdbcCommand cmd = new OdbcCommand(SQL_DELETE, conn);
                cmd.Parameters.AddWithValue("@pk_id_aplicacion", idAplicacion);
                return cmd.ExecuteNonQuery();
            }
        }

        // Buscar una aplicación por ID
        public Cls_Aplicacion Query(int idAplicacion)
        {
            Cls_Aplicacion app = null;
            using (OdbcConnection conn = conexion.conexion())
            {
                OdbcCommand cmd = new OdbcCommand(SQL_QUERY, conn);
                cmd.Parameters.AddWithValue("@pk_id_aplicacion", idAplicacion);

                OdbcDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    app = new Cls_Aplicacion
                    {
                        PkIdAplicacion = reader.GetInt32(0),
                        FkIdReporte = reader.IsDBNull(1) ? (int?)null : reader.GetInt32(1),
                        NombreAplicacion = reader.GetString(2),
                        DescripcionAplicacion = reader.GetString(3),
                        HabilitadoAplicacion = reader.GetBoolean(4),
                        DeshabilitadoAplicacion = reader.GetBoolean(5)
                    };
                }
            }
            return app;
        }

    }
}
