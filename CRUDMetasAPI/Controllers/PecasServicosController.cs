﻿using CRUDMetasAPI.Model;
using CRUDMetasAPI.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDMetasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Bearer")]
    public class PecasServicosController : ControllerBase
    {
        private readonly PecasServicosService _pecasService;

        public PecasServicosController(PecasServicosService pecasServicosService)
        {
            _pecasService = pecasServicosService;
        }

        // GET: api/<PecasServicosController>
        [HttpGet]
        public IActionResult RetornaPecasEServicos()
        {
            var pecasRetornadasService = _pecasService.FindAll();
            if (pecasRetornadasService == null)
                return NotFound();
            return Ok(pecasRetornadasService);
        }

        // GET api/<PecasServicosController>/5
        [HttpGet("{idPeca}")]
        public IActionResult RetornaPecasPorId(int id)
        {
            var pecasRetornadaPorId = _pecasService.FindById(id);
            if (pecasRetornadaPorId == null)
                return BadRequest("Não foi possivel encontrar o produto");
            return Ok(pecasRetornadaPorId);
        }

        // POST api/<PecasServicosController>
        [HttpPost]
        public IActionResult InsereNovaPecaServico([FromBody] PecasEServicos pecasEServicos)
        {
            var retornoInsert = _pecasService.Insert(pecasEServicos);
            if (retornoInsert == false)
                return BadRequest("Não possivel inserir o registro!");
            return Ok("Registro inserido com sucesso!");
        }

        // PUT api/<PecasServicosController>/5
        [HttpPut]
        public IActionResult AlteraRegistro([FromBody] PecasEServicos pecasEServicos)
        {
            var pecas = pecasEServicos;
            if (_pecasService.Update(pecas))
                return Ok("Registro Alterado!");
            return BadRequest("Não foi possivel alterar o produto selecionado!");
        }
    }
}