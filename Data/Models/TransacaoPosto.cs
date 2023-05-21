using System;
using Projeto_Mobile_Sustentabilidade.Data.Models.Enuns;

namespace Projeto_Mobile_Sustentabilidade.Data.Models
{
    public class TransacaoPosto : BaseEntity
    {
        public DateTime DataAgendada { get; set; }
        public DateTime? DataConfirmada { get; set; }
        public double? Valor { get; set; }
        public StatusEnum Status { get; set; }
        public String CodigoTransacao { get; set; }

        public int? IdFuncionarioPosto { get; set; }
        public virtual FuncionarioPosto FuncionarioPosto { get; set; }

        public int IdCliente { get; set; }
        public virtual Cliente Cliente { get; set; }

        public int IdPosto { get; set; }
        public virtual Posto Posto { get; set; }
    }
}
