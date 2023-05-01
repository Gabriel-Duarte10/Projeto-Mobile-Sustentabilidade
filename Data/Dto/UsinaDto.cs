using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Mobile_Sustentabilidade.Data.Dto
{
    public class UsinaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CEP { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string UF { get; set; }
        public string Cidade { get; set; }
    }
}