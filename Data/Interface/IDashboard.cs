using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto_Mobile_Sustentabilidade.Data.Dto;

namespace Projeto_Mobile_Sustentabilidade.Data.Interface
{
    public interface IDashboard
    {
        Task<List<DashboardPostoDto>> GetPostoAdm();
        Task<List<DashboardLiquidoDto>> GetLiquidoAdm();
        Task<List<DashboardUsinaDto>> GetUsinaAdm();
        Task<List<DashboardClienteDto>> GetClienteAdm();
        Task<List<DashboardLiquidoDto>> GetLiquidoPosto(int idPosto);
        Task<List<DashboardClienteDto>> GetClientePosto(int idPosto);
        Task<List<DashboardFuncionarioPostoDto>> GetFuncionarioPosto(int idPosto);
    }
}