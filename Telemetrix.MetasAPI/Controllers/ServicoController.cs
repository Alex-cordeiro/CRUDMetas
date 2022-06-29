using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telemetrix.API.Model.DTOs;
using Telemetrix.API.Service;

namespace Telemetrix.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Bearer")]
    public class ServicoController : ControllerBase
    {

        private readonly ServicoService _servicoService;

        public ServicoController(ServicoService servicoService)
        {
            _servicoService = servicoService;
        }

        // GET: api/<ServicoController>
        [HttpGet]
        public IActionResult RetornaServicos()
        {
            var servicosRetornados = _servicoService.FindAll();
            if (servicosRetornados == null)
                return NotFound();
            return Ok(servicosRetornados);
        }

        // GET api/<ServicoController>/5
        [HttpGet("{idServico}")]
        public IActionResult RetornaServicosPorId(int idServico)
        {
            var servicosRetornadosPorId = _servicoService.FindById(idServico);
            if (servicosRetornadosPorId == null)
                return BadRequest("Não foi possivel encontrar o registro");
            return Ok(servicosRetornadosPorId);
        }

        // POST api/<ServicoController>
        [HttpPost]
        public IActionResult InserePeca([FromBody] ServicoDTO servicoDTO)
        {
            var retornoInsert = _servicoService.Insert(servicoDTO);
            if (retornoInsert == false)
                return BadRequest("Não possivel inserir o registro!");
            return Ok("Registro inserido com sucesso!");
        }

        // PUT api/<ServicoController>/5
        [HttpPut]
        [Route("EditaServico")]
        public IActionResult AlteraRegistro([FromBody] ServicoDTO servicoDto)
        {
            if (servicoDto != null)
                _servicoService.Update(servicoDto);
            return Ok("Registro Alterado!");

            return BadRequest("Não foi possivel alterar o registro selecionado! Verifique as informações e tente novamente");
        }
    }
}
