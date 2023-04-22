using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Projeto_Mobile_Sustentabilidade.Data.Models.Enuns;

namespace Projeto_Mobile_Sustentabilidade.Data.Models
{
    public class Usuario : BaseEntity
    {

        public string Login { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public string CPFouCNPJ { get; set; }
        public PerfilEnum PerfilEnum { get; set; }
        public string CEP { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string UF { get; set; }
        public string Cidade { get; set; }
        public StatusEnum StatusEnum { get; set; }
    }
}
