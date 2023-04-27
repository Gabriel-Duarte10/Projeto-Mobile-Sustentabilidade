using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto_Mobile_Sustentabilidade.Data.Dto;
using Projeto_Mobile_Sustentabilidade.Data.Request;

namespace Projeto_Mobile_Sustentabilidade.Data.Interface
{
    public interface IUsuario
    {
        Task Post(UsuarioDadosRequest model, UsuarioContaRequest conta);
        Task<List<UsuarioDto>> GetAll();
        Task<UsuarioDto> GetById(int id);
        Task Put(UsuarioDadosRequest model);
    }
}