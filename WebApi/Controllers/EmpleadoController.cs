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
    public class EmpleadoController : ControllerBase
    {
        private GestorProfesionales GestorProfesionales { get; set; }

        public EmpleadoController()
        {
            GestorProfesionales = new GestorProfesionales(null);
        }

        [HttpGet("ObtenerTodos")]
        public ActionResult<object[]> Get()
        {

            return GestorProfesionales.ObtenerProfesionales(null).ToArray();

            
        }

        [HttpGet("ObtenerAutor/{id}")]
        public ActionResult<object> Get(int id)
        {
            var result = GestorProfesionales.ObtenerProfesionales(id).FirstOrDefault();

            if (result == null) return NotFound();
            else return Ok(result);
        }

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