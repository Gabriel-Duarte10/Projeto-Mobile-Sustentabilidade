using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto_Mobile_Sustentabilidade.Data.Dto;
using Projeto_Mobile_Sustentabilidade.Data.Request;

namespace Projeto_Mobile_Sustentabilidade.Data.Interface
{
    public interface IUsina
    {
        Task Post(UsinaRequest model);
        Task<List<UsinaDto>> GetAll();
        Task<UsinaDto> GetById(int id);
        Task Put(UsinaRequest model);
        Task Delete(int id);
    }
}