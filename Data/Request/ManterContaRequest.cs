using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto_Mobile_Sustentabilidade.Data.Models.Enuns;

namespace Projeto_Mobile_Sustentabilidade.Data.Request
{
    public class ManterContaRequest
    {
        
    }
    public class LoginRequest
    {
        public string Login { get; set; }
        public string Senha { get; set; }
        public PerfilEnum PerfilEnum { get; set; }
    }
}