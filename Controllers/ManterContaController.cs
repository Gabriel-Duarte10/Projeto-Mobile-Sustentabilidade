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
    [Route("api/manter-conta")]
    public class ManterContaController : ControllerBase
    {
        private readonly IManterConta _rep;
        public ManterContaController(IManterConta rep)
        {
            _rep = rep;
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
    }
}