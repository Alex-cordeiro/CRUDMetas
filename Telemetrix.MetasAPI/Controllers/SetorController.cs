using Telemetrix.API.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Telemetrix.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Bearer")]
    public class SetorController : ControllerBase
    {
        private readonly SetorService _setorService;

        public SetorController(SetorService setorService)
        {
            _setorService = setorService;
        }

        // GET: api/<FilialController>/1
        [HttpGet("{idEmpresa}")]
        public IActionResult RetornaSetoresPorIdEmpresa(int idEmpresa)
        {
            var setores = _setorService.FindByIdEmpresa(idEmpresa);
            if (setores != null)
                return Ok(setores);
            return NotFound("Não foram encontrados os setores cadastradas");
        }
    }
}
