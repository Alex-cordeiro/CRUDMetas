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

        // GET: api/<FilialController>
        [HttpGet]
        public IActionResult RetornaEmpresas(int idEmpresa)
        {
            var filiais = _filialService.FindById(idEmpresa);
            if (filiais != null)
                return Ok(filiais);
            return NotFound("Não foram encontradas filials cadastradas");
        }
    }
}
