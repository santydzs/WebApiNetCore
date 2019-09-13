using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Negocio.DbModels;

namespace Negocio.Logica
{
    public static class GestorProfesionales
    {
        private static readonly MockGestionContext _context = new MockGestionContext();

        public static IQueryable<object> ObtenerProfesionales()
        {
            var query =
                from p in _context.Profesional
                join tp in _context.TipoProfesional on p.TipoId equals tp.Id
                select new { p.NombreApelldo, tp.Descripcion, tp.Señority };
            return query;
        }
    }
}
