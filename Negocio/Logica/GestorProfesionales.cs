using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Negocio.DbModels;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Dominio.RequestEndpoint;

namespace Negocio.Logica
{
    public class GestorProfesionales
    {
        private MockGestionContext Context { get; set; }

        public GestorProfesionales(MockGestionContext con)
        {
            if (Context != null) Context = con;
            else Context = new MockGestionContext();
        }

        public IQueryable<object> ObtenerProfesionales(int? id)
        {
            var query =
                from p in Context.Profesional
                join tp in Context.TipoProfesional on p.TipoId equals tp.Id
                where id == null || p.Id == id.Value 
                select new { p.NombreApelldo, tp.Descripcion, tp.Señority };
            return query;

        }

        public int AgregarProfesional(ProfesionalRequest request)
        {
            Context.Profesional.Add(new Profesional()
            {
                NombreApelldo = request.NombreApellido,
                TipoId = request.IdTipoProfesion
            });

            Context.SaveChanges();

            return 0;
        }
    }
}
