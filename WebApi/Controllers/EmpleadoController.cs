using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocio.Logica;
using Negocio.DbModels;
using Dominio.RequestEndpoint;

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

        [HttpPost("AltaProfesional")]
        public ActionResult<int> Post([FromBody] ProfesionalRequest prof)
        {
            int nuevoid = GestorProfesionales.AgregarProfesional(prof);

            return Ok(nuevoid);
        }
    }
}