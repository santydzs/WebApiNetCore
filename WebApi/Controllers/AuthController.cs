using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Auth.Logic;
using Microsoft.AspNetCore.Authorization;
using Auth.Models;

namespace WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private UserService Service { get; set; }

        public AuthController(UserService service)
        {
            Service = service;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Authenticate([FromBody]UserRequest input)
        {
            var user = Service.Authenticate(input.email, input.pass);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost("create")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDTO input)
        {
            int id = await Service.CreateUser(input);

            return Ok(id);
        }
    }
}