using System;
using Projeto_Mobile_Sustentabilidade.Data.Models.Enuns;

namespace Projeto_Mobile_Sustentabilidade.Data.Models
{
    public class PostoAceitaLiquido : BaseEntity
    {
        public int IdPosto { get; set; }
        public virtual Posto Posto { get; set; }

        public int IdLiquido { get; set; }
        public virtual Liquido Liquido { get; set; }

        public int CapacidadeTotal { get; set; }
        public int CapacidadeOcupada { get; set; }
    }
}
