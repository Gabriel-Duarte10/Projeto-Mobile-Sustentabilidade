using System;
using Projeto_Mobile_Sustentabilidade.Data.Models.Enuns;

namespace Projeto_Mobile_Sustentabilidade.Data.Models
{
    public class TransacaoUsina : BaseEntity
    {
        public int IdUsina { get; set; }
        public virtual Usina Usina { get; set; }

        public int IdFuncionarioPosto { get; set; }
        public virtual FuncionarioPosto FuncionarioPosto { get; set; }

    }
}
