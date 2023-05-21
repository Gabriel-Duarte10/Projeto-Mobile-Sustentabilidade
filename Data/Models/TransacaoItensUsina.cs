using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Mobile_Sustentabilidade.Data.Models
{
    public class TransacaoItensUsina: BaseEntity
    {
        public int IdTransacaoUsina { get; set; }
        public virtual TransacaoUsina TransacaoUsina { get; set; }
        public int Qtd { get; set; }
        public int IdLiquido { get; set; }
        public virtual Liquido Liquido { get; set; }
    }
}