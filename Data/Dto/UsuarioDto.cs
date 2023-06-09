using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto_Mobile_Sustentabilidade.Data.Models.Enuns;

namespace Projeto_Mobile_Sustentabilidade.Data.Dto
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPFouCNPJ { get; set; }
        public string Email { get; set; }
        public PerfilEnum PerfilEnum { get; set; }
        public string CEP { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string UF { get; set; }
        public string Cidade { get; set; }
        public StatusEnum StatusEnum { get; set; }
         public virtual DateTime? CreatedAt { get; set; }
        public virtual DateTime? UpdatedAt { get; set; }
    }
    public class UsuarioPerfil
    {
        public int UsuarioId { get; set; }
        public int PerfilUsuarioId { get; set; }
        public PerfilEnum PerfilEnum { get; set; }
    }
}