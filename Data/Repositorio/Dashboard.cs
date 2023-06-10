using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Projeto_Mobile_Sustentabilidade.Data.Context;
using Projeto_Mobile_Sustentabilidade.Data.Dto;
using Projeto_Mobile_Sustentabilidade.Data.Interface;

namespace Projeto_Mobile_Sustentabilidade.Data.Repositorio
{
    public class Dashboard : IDashboard
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public Dashboard(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<List<DashboardClienteDto>> GetClienteAdm()
        {
            var DashboardClienteDto = await _context.TransacoesPosto
                .Include(x => x.Cliente)
                    .ThenInclude(x => x.Usuario)
                .Where(x => x.Status == Models.Enuns.StatusEnum.Aprovado)
                .GroupBy(x => x.Cliente)
                .Select(g => new { Cliente = g.Key, Contagem = g.Count() })
                .OrderByDescending(g => g.Contagem)
                .Select(x => 
                    new DashboardClienteDto {Cliente = _mapper.Map<ClienteDto>(x.Cliente), QtdTransacoes = x.Contagem})
                .ToListAsync();
            
            if(DashboardClienteDto == null)
            {
                throw new Exception("Nenhum cliente encontrado");
            }

            foreach (var i in DashboardClienteDto)
            {
                i.Cliente.Usuario = _mapper
                    .Map<UsuarioDto>(await 
                        _context
                        .Clientes
                        .Include(x => x.Usuario)
                        .Where(x => x.Id == i.Cliente.Id)
                        .Select(x => x.Usuario)
                        .FirstOrDefaultAsync());
            }
            
            return DashboardClienteDto;
        }
        public async Task<List<DashboardLiquidoDto>> GetLiquidoAdm()
        {
            var liquido = await _context.TransacaoItens
                .Include(x => x.Liquido)
                .Include(x => x.TransacaoPosto)
                .Where(x => x.TransacaoPosto.Status == Models.Enuns.StatusEnum.Aprovado)
                .GroupBy(x => x.Liquido)
                .Select(g => new { Liquido = g.Key, Contagem = g.Count() })
                .OrderByDescending(g => g.Contagem)
                .Select(x => 
                    new DashboardLiquidoDto {Liquido = _mapper.Map<LiquidoDto>(x.Liquido), QtdTransacoes = x.Contagem})
                .ToListAsync();
            
            if(liquido == null)
            {
                throw new Exception("Nenhum liquido encontrado");
            }
            
            return liquido;
        }

        public async Task<List<DashboardPostoDto>> GetPostoAdm()
        {
            var Posto = await _context.TransacoesPosto
                .Include(x => x.Posto)
                    .ThenInclude(x => x.DonoPosto)
                    .ThenInclude(x => x.Usuario)
                .Where(x => x.Status == Models.Enuns.StatusEnum.Aprovado)
                .GroupBy(x => x.Posto)
                .Select(g => new { Posto = g.Key, Contagem = g.Count() })
                .OrderByDescending(g => g.Contagem)
                .Select(x => 
                    new DashboardPostoDto {Posto = _mapper.Map<PostoDto>(x.Posto), QtdTransacoes = x.Contagem})
                .ToListAsync();

            if(Posto == null)
            {
                throw new Exception("Nenhum posto encontrado");
            }
            
            return Posto;
        }

        public async Task<List<DashboardUsinaDto>> GetUsinaAdm()
        {
            var Usina = await _context.TransacoesUsina
                .Include(x => x.Usina)
                .GroupBy(x => x.Usina)
                .Select(g => new { Usina = g.Key, Contagem = g.Count() })
                .OrderByDescending(g => g.Contagem)
                .Select(x => 
                    new DashboardUsinaDto {Usina = _mapper.Map<UsinaDto>(x.Usina), QtdTransacoes = x.Contagem})
                .ToListAsync();

            if(Usina == null)
            {
                throw new Exception("Nenhuma usina encontrada");
            }
            
            return Usina;
        }
        public async Task<List<DashboardLiquidoDto>> GetLiquidoPosto(int idPosto)
        {
            var liquido = await _context.TransacaoItens
                .Include(x => x.Liquido)
                .Include(x => x.TransacaoPosto)
                .Where(x => x.TransacaoPosto.Status == Models.Enuns.StatusEnum.Aprovado)
                .Where(x => x.TransacaoPosto.IdPosto == idPosto)
                .GroupBy(x => x.Liquido)
                .Select(g => new { Liquido = g.Key, Contagem = g.Count() })
                .OrderByDescending(g => g.Contagem)
                .Select(x => 
                    new DashboardLiquidoDto {Liquido = _mapper.Map<LiquidoDto>(x.Liquido), QtdTransacoes = x.Contagem})
                .ToListAsync();

            if(liquido == null)
            {
                throw new Exception("Nenhum liquido encontrado");
            }
            
            return liquido;
        }
        public async Task<List<DashboardClienteDto>> GetClientePosto(int idPosto)
        {
            var clientes = await _context.TransacoesPosto
                .Include(x => x.Cliente)
                    .ThenInclude(x => x.Usuario)
                .Where(x => x.Status == Models.Enuns.StatusEnum.Aprovado)
                .Where(x => x.IdPosto == idPosto)
                .GroupBy(x => x.Cliente)
                .Select(g => new { Cliente = g.Key, Contagem = g.Count() })
                .OrderByDescending(g => g.Contagem)
                .Select(x => 
                    new DashboardClienteDto {Cliente = _mapper.Map<ClienteDto>(x.Cliente), QtdTransacoes = x.Contagem})
                .ToListAsync();

            if(clientes == null)
            {
                throw new Exception("Nenhum cliente encontrado");
            }
            foreach (var i in clientes)
            {
                i.Cliente.Usuario = _mapper
                    .Map<UsuarioDto>(await 
                        _context
                        .Clientes
                        .Include(x => x.Usuario)
                        .Where(x => x.Id == i.Cliente.Id)
                        .Select(x => x.Usuario)
                        .FirstOrDefaultAsync());
            }
            
            return clientes;
        }

        public async Task<List<DashboardFuncionarioPostoDto>> GetFuncionarioPosto(int idPosto)
        {
            var Funcionario = await _context.TransacoesPosto
                .Include(x => x.FuncionarioPosto)
                    .ThenInclude(x => x.Usuario)
                .Where(x => x.Status == Models.Enuns.StatusEnum.Aprovado)
                .Where(x => x.IdPosto == idPosto)
                .GroupBy(x => x.FuncionarioPosto)
                .Select(g => new { FuncionarioPosto = g.Key, Contagem = g.Count() })
                .OrderByDescending(g => g.Contagem)
                .Select(x => 
                    new DashboardFuncionarioPostoDto {FuncionarioPosto = _mapper.Map<FuncionarioPostoDto>(x.FuncionarioPosto), QtdTransacoes = x.Contagem})
                .ToListAsync();

            if(Funcionario == null)
            {
                throw new Exception("Nenhum funcionario encontrado");
            }
            foreach (var i in Funcionario)
            {
                i.FuncionarioPosto.Usuario = _mapper
                    .Map<UsuarioDto>(await 
                        _context
                        .FuncionariosPosto
                        .Include(x => x.Usuario)
                        .Where(x => x.Id == i.FuncionarioPosto.Id)
                        .Select(x => x.Usuario)
                        .FirstOrDefaultAsync());
            }
            
            return Funcionario;
        }
    }
}