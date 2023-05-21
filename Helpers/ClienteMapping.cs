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
    public class ClienteMapping: Profile
    {
        public ClienteMapping()
        {
            MapCliente();
        }

        public void MapCliente()
        {
            //Cliente -> ClienteDto
            CreateMap<Cliente, ClienteDto>();

            //ClienteRequest -> Cliente
            CreateMap<ClienteRequest, Cliente>();

            //TransacaoPosto -> TransacaoClienteDto
            CreateMap<TransacaoPosto, TransacaoClienteDto>();

            //TransacaoClienteRequest -> TransacaoPosto
            CreateMap<TransacaoClienteRequest, TransacaoPosto>();

            //TransacaoItens -> TransacaoItensDto
            CreateMap<TransacaoItens, TransacaoItemDto>();

            //TransacaoItensRequest -> TransacaoItens
            CreateMap<TransacaoItensRequest, TransacaoItens>();
        }
    }
}