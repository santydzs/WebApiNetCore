using System;
using System.Collections.Generic;

namespace Negocio.DbModels
{
    public partial class TipoProfesional
    {
        public TipoProfesional()
        {
            Profesional = new HashSet<Profesional>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Señority { get; set; }

        public virtual ICollection<Profesional> Profesional { get; set; }
    }
}
