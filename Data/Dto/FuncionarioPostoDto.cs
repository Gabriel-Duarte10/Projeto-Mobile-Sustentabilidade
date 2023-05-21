using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto_Mobile_Sustentabilidade.Data.Models.Enuns;

namespace Projeto_Mobile_Sustentabilidade.Data.Dto
{
    public class FuncionarioPostoDto
    {
        public int Id { get; set; }
        public UsuarioDto Usuario { get; set; }
        public PostoDto Posto { get; set; }
    }
    public class TransacaoFuncionarioPostoDto
    {
        public int Id { get; set; }
        public StatusEnum Status { get; set; }
        public DateTime dataAgendada { get; set; }
        public List<TransacaoItemDto> TransacaoItem { get; set; }
    }
}