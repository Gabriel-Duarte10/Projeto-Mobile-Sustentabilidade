using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Projeto_Mobile_Sustentabilidade.Data.Dto;
using Projeto_Mobile_Sustentabilidade.Data.Models;
using Projeto_Mobile_Sustentabilidade.Data.Request;

namespace Projeto_Mobile_Sustentabilidade.Helpers
{
    public class FuncionarioPostoMapping: Profile
    {
        public FuncionarioPostoMapping()
        {
            MapFuncionarioPosto();
        }

        public void MapFuncionarioPosto()
        {
            //FuncionarioPosto -> FuncionarioPostoDto
            CreateMap<FuncionarioPosto, FuncionarioPostoDto>();

            //FuncionarioPostoRequest -> FuncionarioPosto
            CreateMap<FuncionarioPostoRequest, FuncionarioPosto>();
        }
        
    }
}