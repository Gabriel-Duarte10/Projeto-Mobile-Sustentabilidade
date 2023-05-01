using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Mobile_Sustentabilidade.Data.Request
{
    public class LiquidoRequest
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public double ValorUnitario { get; set; }
        public int IdAdministrador { get; set; }
    }
}