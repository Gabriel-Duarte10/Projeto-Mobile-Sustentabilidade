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
    public class LiquidoMapping: Profile
    {
        public LiquidoMapping()
        {
            MapLiquido();
        }

        public void MapLiquido()
        {
            //Liquido -> LiquidoDto
            CreateMap<Liquido, LiquidoDto>();

            //LiquidoRequest -> Liquido
            CreateMap<LiquidoRequest, Liquido>();
        }
    }
}