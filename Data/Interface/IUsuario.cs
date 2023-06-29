using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto_Mobile_Sustentabilidade.Data.Dto;
using Projeto_Mobile_Sustentabilidade.Data.Models.Enuns;
using Projeto_Mobile_Sustentabilidade.Data.Request;

namespace Projeto_Mobile_Sustentabilidade.Data.Interface
{
    public interface IUsuario
    {
        Task<UsuarioPerfil> Post(UsuarioDadosRequest model, UsuarioContaRequest conta);
        Task<List<UsuarioDto>> GetAll(PerfilEnum? perfil);
        Task<UsuarioDto> GetById(int id);
        Task Put(UsuarioDadosRequest model);
        Task RedefinirSenha(UsuarioRedefinirSenhaRequest model);
    }
}