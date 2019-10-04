using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocio.Logica;
using Negocio.DbModels;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private GestorEquipos Gestor { get; set; }

        public TeamsController()
        {
            Gestor = new GestorEquipos(null);
        }

        [HttpGet("ObtenerTodosAsync/{id=1}")]
        public async Task<ActionResult<Equipo>> Get(int id)
        {
            Equipo equipo = await Gestor.ObtenerEquipo(id);

            if (equipo == null) return NotFound();

            return equipo;
        }
    }
}