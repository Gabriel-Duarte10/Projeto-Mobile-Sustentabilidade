using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto_Mobile_Sustentabilidade.Data.Models.Enuns;

namespace Projeto_Mobile_Sustentabilidade.Data.Dto
{
    public class ClienteDto
    {
        public int Id { get; set; }
        public double Saldo { get; set; }
        public UsuarioDto Usuario { get; set; }
    }
    public class TransacaoClienteDto
    {
        public int Id { get; set; }
        public PostoDto Posto { get; set; }
        public StatusEnum Status { get; set; }
        public DateTime dataAgendada { get; set; }
        public String CodigoTransacao { get; set; }
        public List<TransacaoItemDto> TransacaoItem { get; set; }
    }
    public class TransacaoItemDto
    {
        public int QtdAgendada { get; set; }
        public LiquidoDto Liquido { get; set; }
    }
}