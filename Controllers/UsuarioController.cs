using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Projeto_Mobile_Sustentabilidade.Data.Interface;
using Projeto_Mobile_Sustentabilidade.Data.Models.Enuns;
using Projeto_Mobile_Sustentabilidade.Data.Request;

namespace Projeto_Mobile_Sustentabilidade.Controllers
{
    [ApiController]
    [Route("api/usuario")]
    public class UsuarioController: ControllerBase
    {
        private readonly IUsuario _rep;
        public UsuarioController(IUsuario rep)
        {
            _rep = rep;
        }
        [HttpPost]
        public async Task<IActionResult> Post(UsuarioRequest model)
        {
            try
            {
                var result = await _rep.Post(model.Dados, model.Conta);
                return Ok(result);
            }
            catch (System.Exception error)
            {
                return BadRequest(error.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(PerfilEnum? perfil)
        {
            try
            {
                var result = await _rep.GetAll(perfil);
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
        [HttpPut]
        public async Task<IActionResult> Put(UsuarioDadosRequest model)
        {
            try
            {
                await _rep.Put(model);
                return Ok();
            }
            catch (System.Exception error)
            {
                return BadRequest(error.Message);
            }
        }
        [HttpPut("redefinir-senha")]	
        public async Task<IActionResult> RedefinirSenha(UsuarioRedefinirSenhaRequest model)
        {
            try
            {
                await _rep.RedefinirSenha(model);
                return Ok();
            }
            catch (System.Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}