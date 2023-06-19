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
        [HttpPut("agendamento/cliente")]
        public async Task<IActionResult> AgendamentoClientePut(TransacaoFuncionarioPostoRequest model)
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
        [HttpDelete("agendamento/cliente/{idAgendamento}")]
        public async Task<IActionResult> AgendamentoClienteDelete(int idAgendamento)
        {
            try
            {
                await _rep.TransacaoFuncionarioPostoDelete(idAgendamento);
                return Ok();
            }
            catch (System.Exception error)
            {
                return BadRequest(error.Message);
            }
        }
        
        [HttpGet("agendamento/cliente/{idPosto}")]
        public async Task<IActionResult> AgendamentoClienteGetAll(int idPosto)
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
        [HttpPost("agendamento/Usina")]
        public async Task<IActionResult> AgendamentoUsina(TransacaoUsinaRequest model)
        {
            try
            {
                await _rep.TransacaoUsinaPost(model);
                return Ok();
            }
            catch (System.Exception error)
            {
                return BadRequest(error.Message);
            }
        }

    }
}