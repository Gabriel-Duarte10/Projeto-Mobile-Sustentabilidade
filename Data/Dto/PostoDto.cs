using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Mobile_Sustentabilidade.Data.Dto
{
    public class PostoDto
    {
        public int Id { get; set; }
        public string CEP { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string UF { get; set; }
        public string Cidade { get; set; }
        public List<PostoAceitaLiquidoDto> LiquidosAceitos { get; set; }
    }
    public class PostoAceitaLiquidoDto
    {
        public LiquidoDto Liquido { get; set; }
        public int CapacidadeTotal { get; set; }
        public int CapacidadeOcupada { get; set; }
    }
}