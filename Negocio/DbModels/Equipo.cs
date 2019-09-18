using System;
using System.Collections.Generic;

namespace Negocio.DbModels
{
    public partial class Equipo
    {
        public int Id { get; set; }
        public int? Idprofesional { get; set; }
        public int? IdProyecto { get; set; }

        public virtual Proyecto IdProyectoNavigation { get; set; }
        public virtual Profesional IdprofesionalNavigation { get; set; }
    }
}
