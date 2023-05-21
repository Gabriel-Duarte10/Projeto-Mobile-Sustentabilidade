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
    [Route("api/funcionario-posto")]
    public class FuncionarioPostoController : ControllerBase
    {
       private readonly IFuncionarioPosto _rep;
        public FuncionarioPostoController(IFuncionarioPosto rep)
        {
            _rep = rep;
        }
        [HttpPut("alterar-status")]
        public async Task<IActionResult> Post(FuncionarioPostoStatusRequest model)
        {
            try
            {
                await _rep.FuncionarioPostoStatus(model);
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
        [HttpPut("agendamento")]
        public async Task<IActionResult> AgendamentoPut(TransacaoFuncionarioPostoRequest model)
        {
            try
            {
                await _rep.TransacaoFuncionarioPostoPut(model);
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
                await _rep.TransacaoFuncionarioPostoDelete(id);
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
                var transacaoDto = await _rep.TransacaoFuncionarioPostoGetById(id);
                return Ok(transacaoDto);
            }
            catch (System.Exception error)
            {
                return BadRequest(error.Message);
            }
        }
        [HttpGet("agendamento")]
        public async Task<IActionResult> AgendamentoGetAll(int idPosto)
        {
            try
            {
                var transacaoDto = await _rep.TransacaoFuncionarioPostoGetAll(idPosto);
                return Ok(transacaoDto);
            }
            catch (System.Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}