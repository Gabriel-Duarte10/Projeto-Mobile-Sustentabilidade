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
    public class UsinaMapping: Profile
    {
        public UsinaMapping()
        {
            MapUsina();
        }

        public void MapUsina()
        {
            //Usina -> UsinaDto
            CreateMap<Usina, UsinaDto>();

            //UsinaRequest -> Usina
            CreateMap<UsinaRequest, Usina>();
        }
    }
}