using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Mobile_Sustentabilidade.Data.Dto
{
    public class ManterContaDto
    {
        
    }
    public class LoginDto
{
    public AdministradorDto Administrador { get; set; }
    public ClienteDto Cliente { get; set; }
    public FuncionarioPostoDto FuncionarioPosto { get; set; }
    public DonoPostoDto DonoPosto { get; set; }
}
}