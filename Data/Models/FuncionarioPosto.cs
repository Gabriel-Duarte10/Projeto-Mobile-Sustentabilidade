using System;
using Projeto_Mobile_Sustentabilidade.Data.Models.Enuns;

namespace Projeto_Mobile_Sustentabilidade.Data.Models
{
    public class FuncionarioPosto : BaseEntity
    {
        public int IdUsuario { get; set; }
        public virtual Usuario Usuario { get; set; }

        public int IdPosto { get; set; }
        public virtual Posto Posto { get; set; }

        public int? IdDonoPosto { get; set; }
        public virtual DonoPosto DonoPosto { get; set; }
    }
}
