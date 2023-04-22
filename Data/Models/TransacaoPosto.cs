using System;
using Projeto_Mobile_Sustentabilidade.Data.Models.Enuns;

namespace Projeto_Mobile_Sustentabilidade.Data.Models
{
    public class TransacaoPosto : BaseEntity
    {
        public int QtdAgendada { get; set; }
        public int? QtdConfirmada { get; set; }
        public DateTime DataAgendada { get; set; }
        public double? Valor { get; set; }
        public StatusEnum Status { get; set; }

        public int? IdFuncionarioPosto { get; set; }
        public virtual FuncionarioPosto FuncionarioPosto { get; set; }

        public int IdLiquido { get; set; }
        public virtual Liquido Liquido { get; set; }

        public int IdCliente { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}
