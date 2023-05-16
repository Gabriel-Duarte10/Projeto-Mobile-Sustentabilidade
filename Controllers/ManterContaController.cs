using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Projeto_Mobile_Sustentabilidade.Data.Interface;
using Projeto_Mobile_Sustentabilidade.Data.Request;
using Projeto_Mobile_Sustentabilidade.Services;

namespace Projeto_Mobile_Sustentabilidade.Controllers
{
    [ApiController]
    [Route("api/manter-conta")]
    public class ManterContaController : ControllerBase
    {
        private readonly IManterConta _rep;
        private readonly SendEmailService _email;
        public ManterContaController(IManterConta rep, SendEmailService email)
        {
            _rep = rep;
            _email = email;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                var response = await _rep.Login(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPost("email")]
        public async Task<IActionResult> RedefinirSenha(string email)
        {
            try
            {
                await _email.EnvioEmailRedefinirSenha(email);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}