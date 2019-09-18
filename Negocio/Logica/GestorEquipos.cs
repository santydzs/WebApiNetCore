using Microsoft.EntityFrameworkCore;
using Negocio.DbModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Logica
{
    public class GestorEquipos
    {
        private MockGestionContext Context { get; set; }

        public GestorEquipos(MockGestionContext con)
        {
            if (Context != null) Context = con;
            else Context = new MockGestionContext();
        }

        //ejecucion asincrona
        public async Task<Equipo> ObtenerEquipo(int idProyecto)
        {
            var query = await Context.Equipo.FirstOrDefaultAsync(x => x.IdProyecto == idProyecto);
            return query;
        }
    }
}
