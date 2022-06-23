using Telemetrix.API.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Telemetrix.API.Model.DTOs;
using System;

namespace Telemetrix.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Bearer")]
    public class PecaController : ControllerBase
    {
        private readonly PecaService _pecasService;

        public PecaController(PecaService pecaService)
        {
            _pecasService = pecaService;
        }

        // GET: api/<PecaController>
        [HttpGet]
        public IActionResult RetornaPecas()
        {
            var pecasRetornadas = _pecasService.FindAll();
            if (pecasRetornadas == null)
                return NotFound();
            return Ok(pecasRetornadas);
        }

        // GET api/<PecaController>/5
        [HttpGet("{idPeca}")]
        public IActionResult RetornaPecasPorId(int id)
        {
            var pecasRetornadaPorId = _pecasService.FindById(id);
            if (pecasRetornadaPorId == null)
                return BadRequest("Não foi possivel encontrar o registro");
            return Ok(pecasRetornadaPorId);
        }

        // POST api/<PecaController>
        [HttpPost]
        public IActionResult InserePeca([FromBody] PecaDTO pecasDto)
        {
            var retornoInsert = _pecasService.Insert(pecasDto);
            if (retornoInsert == false)
                return BadRequest("Não possivel inserir o registro!");
            return Ok("Registro inserido com sucesso!");
        }

        // PUT api/<PecaController>/5
        [HttpPut]
        public IActionResult AlteraRegistro([FromBody] PecaDTO pecasDto)
        {
            if (pecasDto != null)
                _pecasService.Update(pecasDto);
                return Ok("Registro Alterado!");

            return BadRequest("Não foi possivel alterar o registro selecionado! Verifique as informações e tente novamente");
        }
    }
}
