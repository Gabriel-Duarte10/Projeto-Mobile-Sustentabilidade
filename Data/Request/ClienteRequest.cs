using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto_Mobile_Sustentabilidade.Data.Models.Enuns;

namespace Projeto_Mobile_Sustentabilidade.Data.Request
{
    public class ClienteRequest
    {

    }
    public class ClienteStatusRequest
    {
        public int ClienteId { get; set; }
        public StatusEnum Status { get; set; }
    }
    public class TransacaoClienteRequest
    {
        public int? Id { get; set; }
        public DateTime DataAgendada { get; set; }
        public int IdCliente { get; set; }
        public int IdPosto { get; set; }
        public List<TransacaoItensRequest> TransacaoItens { get; set; }
    }
    public class TransacaoItensRequest
    {
        public int QtdAgendada { get; set; }
        public int IdLiquido { get; set; }
    }
}