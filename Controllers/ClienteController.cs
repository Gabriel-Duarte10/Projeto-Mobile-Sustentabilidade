using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Projeto_Mobile_Sustentabilidade.Data.Interface;
using Projeto_Mobile_Sustentabilidade.Data.Request;

namespace Projeto_Mobile_Sustentabilidade.Controllers
{
    [ApiController]
    [Route("api/cliente")]
    public class ClienteController : ControllerBase
    {

        private readonly ICliente _rep;
        public ClienteController(ICliente rep)
        {
            _rep = rep;
        }
        [HttpPut("alterar-status")]
        public async Task<IActionResult> Post(ClienteStatusRequest model)
        {
            try
            {
                await _rep.ClienteStatus(model);
                return Ok();
            }
            catch (System.Exception error)
            {
                return BadRequest(error.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _rep.GetAll();
                return Ok(result);
            }
            catch (System.Exception error)
            {
                return BadRequest(error.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _rep.GetById(id);
                return Ok(result);
            }
            catch (System.Exception error)
            {
                return BadRequest(error.Message);
            }
        }
        [HttpPost("agendamento")]
        public async Task<IActionResult> AgendamentoPost(TransacaoClienteRequest model)
        {
            try
            {
                await _rep.TransacaoClientePost(model);
                return Ok();
            }
            catch (System.Exception error)
            {
                return BadRequest(error.Message);
            }
        }
        [HttpPut("agendamento")]
        public async Task<IActionResult> AgendamentoPut(TransacaoClienteRequest model)
        {
            try
            {
                await _rep.TransacaoClientePut(model);
                return Ok();
            }
            catch (System.Exception error)
            {
                return BadRequest(error.Message);
            }
        }
        [HttpDelete("agendamento/{id}")]
        public async Task<IActionResult> AgendamentoDelete(int id)
        {
            try
            {
                await _rep.TransacaoClienteDelete(id);
                return Ok();
            }
            catch (System.Exception error)
            {
                return BadRequest(error.Message);
            }
        }
        [HttpGet("agendamento/{id}")]
        public async Task<IActionResult> AgendamentoGetById(int id)
        {
            try
            {
                var transacaoDto = await _rep.TransacaoClienteGetById(id);
                return Ok(transacaoDto);
            }
            catch (System.Exception error)
            {
                return BadRequest(error.Message);
            }
        }
        [HttpGet("agendamento")]
        public async Task<IActionResult> AgendamentoGetAll(int IdCliente)
        {
            try
            {
                var transacaoDto = await _rep.TransacaoClienteGetAll(IdCliente);
                return Ok(transacaoDto);
            }
            catch (System.Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}