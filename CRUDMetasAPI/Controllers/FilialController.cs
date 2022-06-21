using CRUDMetasAPI.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDMetasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Bearer")]
    public class FilialController : ControllerBase
    {
        private readonly FilialService _filialService;

        public FilialController(FilialService filialService)
        {
            _filialService = filialService;
        }

        // GET: api/<FilialController>/1
        [HttpGet("{idEmpresa}")]
        public IActionResult RetornaFiliaisPorIdEmpresa(int idEmpresa)
        {
            var filiais = _filialService.FindByIdEmpresa(idEmpresa);
            if (filiais != null)
                return Ok(filiais);
            return NotFound("Não foram encontradas filiais cadastradas");
        }
    }
}
