using System;
using Projeto_Mobile_Sustentabilidade.Data.Models.Enuns;

namespace Projeto_Mobile_Sustentabilidade.Data.Models
{
    public class Cliente : BaseEntity
    {
        public int IdUsuario { get; set; }
        public virtual Usuario Usuario { get; set; }
        public double Saldo { get; set; }
        public int? IdAdministrador { get; set; }
        public virtual Administrador Administrador { get; set; }
    }
}
