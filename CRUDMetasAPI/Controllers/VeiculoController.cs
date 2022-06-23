using Telemetrix.API.Model;
using Telemetrix.API.Model.DTOs;
using Telemetrix.API.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Telemetrix.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Bearer")]
    public class VeiculoController : ControllerBase
    {
        private readonly VeiculoService _veiculosService;

        public VeiculoController(VeiculoService veiculosService)
        {
            _veiculosService = veiculosService;
        }

        // GET: api/<VeiculoController>
        [HttpGet]
        public IActionResult RetornaVeiculos()
        {
            var veiculosRetornadosService = _veiculosService.FindAll();
            if (veiculosRetornadosService == null)
                return NotFound();
            return Ok(veiculosRetornadosService);
        }

        // GET api/<VeiculoController>/5
        [HttpGet("{idveiculo}")]
        public IActionResult RetornaVeiculoPorId(int id)
        {
            var veiculoRetornadoPorId = _veiculosService.FindById(id);
            if (veiculoRetornadoPorId == null)
                return BadRequest("Não foi possivel encontrar o produto");
            return Ok(veiculoRetornadoPorId);
        }

        // POST api/<VeiculoController>
        [HttpPost]
        public IActionResult InsereNovoVeiculo([FromBody] VeiculoDTO veiculodto)
        {
            var retornoInsert = _veiculosService.Insert(veiculodto);
            if (retornoInsert == false)
                return BadRequest("Não possivel inserir o registro!");
            return Ok("Registro inserido com sucesso!");
        }

        // PUT api/<VeiculoController>/5
        [HttpPut]
        public IActionResult AlteraRegistro([FromBody] VeiculoDTO novoveiculoDTO)
        {
            if (_veiculosService.Update(novoveiculoDTO))
                return Ok("Registro Alterado!");
            return BadRequest("Não foi possivel alterar o produto selecionado!");
        }
    }
}
