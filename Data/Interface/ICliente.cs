using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto_Mobile_Sustentabilidade.Data.Dto;
using Projeto_Mobile_Sustentabilidade.Data.Request;

namespace Projeto_Mobile_Sustentabilidade.Data.Interface
{
    public interface ICliente
    {
        Task<List<ClienteDto>> GetAll();
        Task<ClienteDto> GetById(int id);
        Task ClienteStatus(ClienteStatusRequest model);
        Task<List<TransacaoClienteDto>>  TransacaoClienteGetAll(int idCliente);
        Task<TransacaoClienteDto> TransacaoClienteGetById(int id);
        Task TransacaoClientePost(TransacaoClienteRequest model);
        Task TransacaoClientePut(TransacaoClienteRequest model);
        Task TransacaoClienteDelete(int id);
    }
}