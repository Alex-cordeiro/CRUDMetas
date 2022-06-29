using Telemetrix.API.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Telemetrix.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class EmpresaController : ControllerBase
    {
        private readonly EmpresaService _empresaService;

        public EmpresaController(EmpresaService empresaService)
        {
            _empresaService = empresaService;
        }

        // GET: api/<EmpresaController>
        [HttpGet]
        public IActionResult RetornaEmpresas()
        {
            var empresasRetornadas = _empresaService.FindAll();
            if (empresasRetornadas != null)
                return Ok(empresasRetornadas);
            return NotFound("Não foram encontradas Empresas cadastradas");
        }
    }
}
