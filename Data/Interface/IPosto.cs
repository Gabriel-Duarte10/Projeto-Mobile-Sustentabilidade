using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto_Mobile_Sustentabilidade.Data.Dto;
using Projeto_Mobile_Sustentabilidade.Data.Request;

namespace Projeto_Mobile_Sustentabilidade.Data.Interface
{
    public interface IPosto
    {
        Task Post(PostoRequest model);
        Task<List<PostoDto>> GetAll();
        Task<PostoDto> GetById(int id);
        Task Put(PostoRequest model);
    }
}