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
}