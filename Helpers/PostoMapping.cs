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
    public class PostoMapping: Profile
    {
        public PostoMapping()
        {
            MapPosto();
        }

        public void MapPosto()
        {
            //Posto -> PostoDto
            CreateMap<Posto, PostoDto>();

            //PostoRequest -> Posto
            CreateMap<PostoRequest, Posto>();

            //PostoAceitaLiquidoRequest -> PostoAceitaLiquido  
            CreateMap<PostoAceitaLiquidoRequest, PostoAceitaLiquido>();

            //PostoAceitaLiquido -> PostoAceitaLiquidoDto
            CreateMap<PostoAceitaLiquido, PostoAceitaLiquidoDto>();

        }
    }
}