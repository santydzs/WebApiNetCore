using System;
using System.Collections.Generic;

namespace Negocio.DbModels
{
    public partial class Profesional
    {
        public int Id { get; set; }
        public string NombreApelldo { get; set; }
        public int? TipoId { get; set; }

        public virtual TipoProfesional Tipo { get; set; }
    }
}
