using System;
using Projeto_Mobile_Sustentabilidade.Data.Models.Enuns;

namespace Projeto_Mobile_Sustentabilidade.Data.Models
{
    public class Liquido : BaseEntity
    {
        public string Nome { get; set; }
        public double ValorUnitario { get; set; }

        public int IdAdministrador { get; set; }
        public virtual Administrador Administrador { get; set; }
    }
}
