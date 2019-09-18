using System;
using System.Collections.Generic;

namespace Negocio.DbModels
{
    public partial class Profesional
    {
        public Profesional()
        {
            Equipo = new HashSet<Equipo>();
        }

        public int Id { get; set; }
        public string NombreApelldo { get; set; }
        public int? TipoId { get; set; }

        public virtual TipoProfesional Tipo { get; set; }
        public virtual ICollection<Equipo> Equipo { get; set; }
    }
}
