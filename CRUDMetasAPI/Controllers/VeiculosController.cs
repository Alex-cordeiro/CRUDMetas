using CRUDMetasAPI.Model;
using CRUDMetasAPI.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDMetasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Bearer")]
    public class VeiculosController : ControllerBase
    {
        private readonly VeiculosService _veiculosService;

        public VeiculosController(VeiculosService veiculosService)
        {
            _veiculosService = veiculosService;
        }

        // GET: api/<VeiculosController>
        [HttpGet]
        public IActionResult RetornaVeiculos()
        {
            var veiculosRetornadosService = _veiculosService.FindAll();
            if (veiculosRetornadosService == null)
                return NotFound();
            return Ok(veiculosRetornadosService);
        }

        // GET api/<VeiculosController>/5
        [HttpGet("{idveiculo}")]
        public IActionResult RetornaVeiculoPorId(int id)
        {
            var veiculoRetornadoPorId = _veiculosService.FindById(id);
            if (veiculoRetornadoPorId == null)
                return BadRequest("Não foi possivel encontrar o produto");
            return Ok(veiculoRetornadoPorId);
        }

        // POST api/<VeiculosController>
        [HttpPost]
        public IActionResult InsereNovoVeiculo([FromBody] Veiculo veiculo)
        {
            var retornoInsert = _veiculosService.Insert(veiculo);
            if (retornoInsert == false)
                return BadRequest("Não possivel inserir o registro!");
            return Ok("Registro inserido com sucesso!");
        }

        // PUT api/<VeiculosController>/5
        [HttpPut]
        public IActionResult AlteraRegistro([FromBody] Veiculo novoveiculo)
        {
            var veiculo = novoveiculo;
            if (_veiculosService.Update(veiculo))
                return Ok("Registro Alterado!");
            return BadRequest("Não foi possivel alterar o produto selecionado!");
        }
    }
}
