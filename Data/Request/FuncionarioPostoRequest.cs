using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto_Mobile_Sustentabilidade.Data.Models.Enuns;

namespace Projeto_Mobile_Sustentabilidade.Data.Request
{
    public class FuncionarioPostoRequest
    {
    }
    public class FuncionarioPostoStatusRequest
    {
        public int FuncionarioPostoId { get; set; }
        public StatusEnum Status { get; set; }
    }
}