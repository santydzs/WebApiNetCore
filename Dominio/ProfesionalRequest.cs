using System;
using System.ComponentModel.DataAnnotations;

namespace Dominio.RequestEndpoint
{
    public class ProfesionalRequest
    {
        [Required]
        public string NombreApellido { get; set; }

        [Required]
        public int IdTipoProfesion { get; set; }
    }
}
