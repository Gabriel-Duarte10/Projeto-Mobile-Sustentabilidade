using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Projeto_Mobile_Sustentabilidade.Data.Interface;

namespace Projeto_Mobile_Sustentabilidade.Controllers
{
    [ApiController]
    [Route("api/dashboard")]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboard _rep;
        public DashboardController(IDashboard rep)
        {
            _rep = rep;
        }
        [HttpGet("cliente-adm")]
        public async Task<IActionResult> GetClienteAdm()
        {
            try
            {
                var result = await _rep.GetClienteAdm();
                return Ok(result);
            }
            catch (System.Exception error)
            {
                return Problem(error.Message);
            }
        }
        [HttpGet("liquido-adm")]
        public async Task<IActionResult> GetLiquidoAdm()
        {
            try
            {
                var result = await _rep.GetLiquidoAdm();
                return Ok(result);
            }
            catch (System.Exception error)
            {
                return Problem(error.Message);
            }
        }
        [HttpGet("usina-adm")]
        public async Task<IActionResult> GetUsinaAdm()
        {
            try
            {
                var result = await _rep.GetUsinaAdm();
                return Ok(result);
            }
            catch (System.Exception error)
            {
                return Problem(error.Message);
            }
        }
        [HttpGet("posto-adm")]
        public async Task<IActionResult> GetPostoAdm()
        {
            try
            {
                var result = await _rep.GetPostoAdm();
                return Ok(result);
            }
            catch (System.Exception error)
            {
                return Problem(error.Message);
            }
        }
        [HttpGet("cliente-dono")]
        public async Task<IActionResult> GetClienteDono(int idPosto)
        {
            try
            {
                var result = await _rep.GetClientePosto(idPosto);
                return Ok(result);
            }
            catch (System.Exception error)
            {
                return Problem(error.Message);
            }
        }
        [HttpGet("liquido-dono")]
        public async Task<IActionResult> GetLiquidoDono(int idPosto)
        {
            try
            {
                var result = await _rep.GetLiquidoPosto(idPosto);
                return Ok(result);
            }
            catch (System.Exception error)
            {
                return Problem(error.Message);
            }
        }
        [HttpGet("funcionario-dono")]
        public async Task<IActionResult> GetFuncionarioDono(int idPosto)
        {
            try
            {
                var result = await _rep.GetFuncionarioPosto(idPosto);
                return Ok(result);
            }
            catch (System.Exception error)
            {
                return Problem(error.Message);
            }
        }

    }
}