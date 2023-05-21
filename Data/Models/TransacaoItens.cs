using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Mobile_Sustentabilidade.Data.Models
{
    public class TransacaoItens: BaseEntity
    {
        public int IdTransacaoPosto { get; set; }
        public virtual TransacaoPosto TransacaoPosto { get; set; }
        public int QtdAgendada { get; set; }
        public int? QtdConfirmada { get; set; }

        public int IdLiquido { get; set; }
        public virtual Liquido Liquido { get; set; }
        
    }
}