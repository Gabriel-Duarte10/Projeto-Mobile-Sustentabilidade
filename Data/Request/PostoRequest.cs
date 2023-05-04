using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Mobile_Sustentabilidade.Data.Request
{
    public class PostoRequest
    {
        public int? Id { get; set; }
        public int IdDonoPosto { get; set; }
        public string CEP { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string UF { get; set; }
        public string Cidade { get; set; }
        public List<PostoAceitaLiquidoRequest> LiquidosAceitos { get; set; }
    }
    public class PostoAceitaLiquidoRequest
    {
        public int IdLiquido { get; set; }
        public int CapacidadeTotal { get; set; }
    }
}