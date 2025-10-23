using System;
using System.Collections.Generic;
using Capa_Modelo_Componente_Consultas;
// Juan Carlos Sandoval Quej 0901-22-4170 11/10/2025
namespace Capa_Controlador_Consultas
{
    /// <summary>
    /// Repositorio que persiste las consultas en la BD (tabla consultas_guardadas),
    /// delegando en Capa_Modelo_Componente_Consultas.Sentencias (métodos Db_*).
    /// </summary>
    public class DbConsultasRepo : IConsultasRepo
    {
        private readonly Sentencias _m;

        public DbConsultasRepo(Sentencias modelo)
        {
            if (modelo == null) throw new ArgumentNullException(nameof(modelo));
            _m = modelo;
        }

        public List<KeyValuePair<string, string>> Listar()
        {
            return _m.Db_ListarConsultasPlano();
        }

        public void Guardar(string sNombre, string sSql)
        {
            _m.Db_GuardarConsulta(sNombre, sSql, null, null);
        }

        public bool Eliminar(string sNombre)
        {
            return _m.Db_EliminarConsulta(sNombre);
        }

        // Overload opcional por si quieres pasar tabla/descripcion:
        public void Guardar(string sNombre, string sSql, string tabla, string descripcion)
        {
            _m.Db_GuardarConsulta(sNombre, sSql, tabla, descripcion);
        }
    }
}
