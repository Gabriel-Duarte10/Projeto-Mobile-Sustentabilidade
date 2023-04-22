using System;
using Projeto_Mobile_Sustentabilidade.Data.Models.Enuns;

namespace Projeto_Mobile_Sustentabilidade.Data.Models
{
    public class Administrador: BaseEntity
    {
        public int IdUsuario { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
