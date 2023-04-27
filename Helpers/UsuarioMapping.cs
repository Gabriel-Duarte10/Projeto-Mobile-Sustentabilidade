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
    public class UsuarioMapping: Profile
    {
        public UsuarioMapping()
        {
            MapUsuario();
        }

        public void MapUsuario()
        {
            //Usuario -> UsuarioDto
            CreateMap<Usuario, UsuarioDto>();

            //UsuarioRequest -> Usuario
            CreateMap<UsuarioDadosRequest, Usuario>();
        }
    }
}