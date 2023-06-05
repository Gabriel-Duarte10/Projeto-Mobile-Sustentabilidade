using System;
using Projeto_Mobile_Sustentabilidade.Data.Models.Enuns;

namespace Projeto_Mobile_Sustentabilidade.Data.Models
{
    public class Posto : BaseEntity
    {
        public int? IdAdministrador { get; set; }
        public virtual Administrador Administrador { get; set; }

        public int IdDonoPosto { get; set; }
        public virtual DonoPosto DonoPosto { get; set; }

        public string Nome { get; set; }
        public string CEP { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string UF { get; set; }
        public string Cidade { get; set; }
    }
}
