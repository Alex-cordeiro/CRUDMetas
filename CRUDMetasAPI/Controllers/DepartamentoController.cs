using Telemetrix.API.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Telemetrix.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Bearer")]
    public class DepartamentoController : ControllerBase
    {
        private readonly DepartamentoService _departamentoService;

        public DepartamentoController(DepartamentoService departamentoService)
        {
            _departamentoService = departamentoService;
        }

        // GET: api/<DepartamentoController>/1
        [HttpGet("{idEmpresa}")]
        public IActionResult RetornaDepartamentoPorIdEmpresa(int idEmpresa)
        {
            var departamentos = _departamentoService.FindByIdEmpresa(idEmpresa);
            if (departamentos != null)
                return Ok(departamentos);
            return NotFound("Não foram encontrados departamentos cadastrados para essa empresa");
        }
    }
}
