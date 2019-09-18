using System;
using System.Collections.Generic;

namespace Negocio.DbModels
{
    public partial class Proyecto
    {
        public Proyecto()
        {
            Equipo = new HashSet<Equipo>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Equipo> Equipo { get; set; }
    }
}
