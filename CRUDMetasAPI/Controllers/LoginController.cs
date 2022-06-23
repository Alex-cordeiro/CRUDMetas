using Telemetrix.API.Model.DTOs;
using Telemetrix.API.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Telemetrix.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly LoginService _loginService;

        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        // POST api login/<LoginController>
        [HttpPost]
        public IActionResult Login([FromBody] UsuarioDTO usuarioDTO)
        {
            if (usuarioDTO == null) return BadRequest("usuário inválido!!");

            var token = _loginService.ValidarCredenciais(usuarioDTO);
            if (token == null) return Unauthorized();

            return Ok(token);
        }

        // POST api refresh token/<LoginController>
        [HttpPost]
        [Route("refresh-token")]
        public IActionResult RefreshToken([FromBody] TokenDTO tokendto)
        {
            if (tokendto == null) return BadRequest("credenciais inválidas!");

            var token = _loginService.ValidarCredenciais(tokendto);
            if (token == null) return BadRequest("credenciais inválidas!");
            return Ok(token);
        }
    }
}
