using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto_Mobile_Sustentabilidade.Data.Dto;
using Projeto_Mobile_Sustentabilidade.Data.Request;

namespace Projeto_Mobile_Sustentabilidade.Data.Interface
{
    public interface ILiquido
    {
        Task Post(LiquidoRequest model);
        Task<List<LiquidoDto>> GetAll();
        Task<LiquidoDto> GetById(int id);
        Task Put(LiquidoRequest model);
        Task Delete(int id);
    }
}