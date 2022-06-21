using CRUDMetasAPI.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDMetasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Bearer")]
    public class VendedorController : ControllerBase
    {
        private readonly VendedorService _vendedorService;

        public VendedorController(VendedorService vendedorService)
        {
            _vendedorService = vendedorService;
        }

        // GET: api/<VendedorController>/1
        [HttpGet("{idEmpresa}")]
        public IActionResult RetornaVendedoresPorEmpresa(int idEmpresa)
        {
            var vendedores = _vendedorService.FindByIdEmpresa(idEmpresa);
            if (vendedores != null)
                return Ok(vendedores);
            return NotFound("Não foram encontradas filials cadastradas");
        }

    }
}
