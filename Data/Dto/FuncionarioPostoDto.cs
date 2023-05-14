using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Mobile_Sustentabilidade.Data.Dto
{
    public class FuncionarioPostoDto
    {
        public int Id { get; set; }
        public UsuarioDto Usuario { get; set; }
        public PostoDto Posto { get; set; }
    }
}