using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Projeto_Mobile_Sustentabilidade.Data.Dto;
using Projeto_Mobile_Sustentabilidade.Data.Models;

namespace Projeto_Mobile_Sustentabilidade.Helpers
{
    public class AdministradorMapping: Profile
    {
        public AdministradorMapping()
        {
            MapAdministrador();
        }

        public void MapAdministrador()
        {
            //Administrador -> AdministradorDto
            CreateMap<Administrador, AdministradorDto>();
        }
        
    }
}