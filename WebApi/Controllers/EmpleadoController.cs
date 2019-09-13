using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocio.Logica;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {

        [HttpGet]
        public ActionResult<IEnumerable<object>> Get()
        {
            return GestorProfesionales.ObtenerProfesionales().ToArray();
        }

        /*[HttpGet("{id}", Name = "ObtenerAutor")]
        public ActionResult<Empleado> Get(int id)
        {
            Empleado result = MockUsers.Empleados.FirstOrDefault(x => x.Id == id);
            if(result == null)
            {
                return NotFound();
            }
            return result;
        }*/

        /*[HttpPost]
        public ActionResult Post([FromBody] Empleado empl)
        {
            if(MockUsers.Empleados.Any(x => x.Id == empl.Id))
            {
                throw new Exception("usuario con id duplicado");
            }
            MockUsers.Empleados.Add(empl);
            return new CreatedAtRouteResult("ObtenerAutor", new { id = empl.Id });
        }*/
    }
}