using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocio.Logica;
using Negocio.DbModels;
using Dominio.RequestEndpoint;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private GestorProfesionales GestorProfesionales { get; set; }

        public EmployeeController(GestorProfesionales gestor)
        {
            GestorProfesionales = gestor;
        }

        [Authorize]
        [HttpGet("all")]
        public ActionResult<object[]> Get()
        {
            return GestorProfesionales.ObtenerProfesionales(null).ToArray();
        }

        [HttpGet("{id}")]
        public ActionResult<object> Get(int id)
        {
            var result = GestorProfesionales.ObtenerProfesionales(id).FirstOrDefault();

            if (result == null) return NotFound();
            else return Ok(result);
        }

        [HttpPost("create")]
        public ActionResult<int> Post([FromBody] ProfesionalRequest prof)
        {
            int nuevoid = GestorProfesionales.AgregarProfesional(prof);

            return Ok(nuevoid);
        }

        [HttpPatch("{id}")]
        public ActionResult Patch(int id, [FromBody] JsonPatchDocument<Profesional> prof)
        {
            if(prof == null)
            {
                return BadRequest();
            }

            Profesional EntityDB = GestorProfesionales.ObtenerProfesionales(id).FirstOrDefault();

            if(EntityDB == null)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}