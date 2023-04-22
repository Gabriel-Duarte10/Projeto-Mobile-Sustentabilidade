using System;
using Projeto_Mobile_Sustentabilidade.Data.Models.Enuns;

namespace Projeto_Mobile_Sustentabilidade.Data.Models
{
    public class Usina : BaseEntity
    {
        public string Nome { get; set; }

        public int IdAdministrador { get; set; }
        public virtual Administrador Administrador { get; set; }

        public string CEP { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string UF { get; set; }
        public string Cidade { get; set; }
    }
}
