using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Negocio.DbModels;

namespace Negocio.Logica
{
    public class GestorProfesionales
    {
        private MockGestionContext _context { get; set; }

        public GestorProfesionales(MockGestionContext context)
        {
            if (context != null) _context = context;
            else _context = new MockGestionContext();
        }

        public IQueryable<object> ObtenerProfesionales(int? id)
        {
            var query =
                from p in _context.Profesional
                join tp in _context.TipoProfesional on p.TipoId equals tp.Id
                where id == null || p.Id == id.Value 
                select new { p.NombreApelldo, tp.Descripcion, tp.Señority };
            return query;

        }
    }
}
