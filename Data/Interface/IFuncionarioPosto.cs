using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto_Mobile_Sustentabilidade.Data.Dto;
using Projeto_Mobile_Sustentabilidade.Data.Request;

namespace Projeto_Mobile_Sustentabilidade.Data.Interface
{
    public interface IFuncionarioPosto
    {
        Task<List<FuncionarioPostoDto>> GetAll();
        Task<FuncionarioPostoDto> GetById(int id);
        Task FuncionarioPostoStatus(FuncionarioPostoStatusRequest model);

        Task<List<TransacaoFuncionarioPostoDto>>  TransacaoFuncionarioPostoGetAll(int idPosto);
        Task<TransacaoFuncionarioPostoDto> TransacaoFuncionarioPostoGetById(int id);
        Task TransacaoFuncionarioPostoPut(TransacaoFuncionarioPostoRequest model);
        Task TransacaoFuncionarioPostoDelete(int id);
    }
}