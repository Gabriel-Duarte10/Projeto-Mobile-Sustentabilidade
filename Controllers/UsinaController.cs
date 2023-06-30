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
    [Route("api/usina")]
    public class UsinaController : ControllerBase
    {
        private readonly IUsina _rep;
        public UsinaController(IUsina rep)
        {
            _rep = rep;
        }
        [HttpPost]
        public async Task<IActionResult> Post(UsinaRequest model)
        {
            try
            {
                await _rep.Post(model);
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
        [HttpPut]
        public async Task<IActionResult> Put(UsinaRequest model)
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
        [HttpDelete("{id}")]	
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _rep.Delete(id);
                return Ok();
            }
            catch (System.Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}