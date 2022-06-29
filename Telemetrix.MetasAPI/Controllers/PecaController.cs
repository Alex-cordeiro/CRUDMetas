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
        [Route("RetornaPorId")]
        public IActionResult RetornaPecasPorId([FromQuery] int idPeca)
        {
            var pecasRetornadaPorId = _pecasService.FindById(idPeca);
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

        // POST api/<PecaController>/5
        [Route("EditaPeca")]
        [HttpPost]
        public IActionResult AlteraRegistro([FromBody] PecaDTO pecasDto)
        {
            if (pecasDto != null)
                _pecasService.Atualizar(pecasDto);
                return Ok("Registro Alterado!");

            return BadRequest("Não foi possivel alterar o registro selecionado! Verifique as informações e tente novamente");
        }

        // DELETE api/<PecaController>/5
        [HttpDelete]
        public IActionResult DeletaRegistro([FromBody] PecaDTO pecasDto)
        {
            if (pecasDto != null)
                _pecasService.Delete(pecasDto.Id);
                return Ok("Registro Alterado!");

            return BadRequest("Não foi possivel alterar o registro selecionado! Verifique as informações e tente novamente");
        }


    }
}
