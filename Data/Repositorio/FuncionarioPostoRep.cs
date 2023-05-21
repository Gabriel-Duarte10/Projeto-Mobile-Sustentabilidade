using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Projeto_Mobile_Sustentabilidade.Data.Context;
using Projeto_Mobile_Sustentabilidade.Data.Dto;
using Projeto_Mobile_Sustentabilidade.Data.Interface;
using Projeto_Mobile_Sustentabilidade.Data.Models;
using Projeto_Mobile_Sustentabilidade.Data.Request;
using Projeto_Mobile_Sustentabilidade.Services;

namespace Projeto_Mobile_Sustentabilidade.Data.Repositorio
{
    public class FuncionarioPostoRep: IFuncionarioPosto
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly SendEmailService _email;
        public FuncionarioPostoRep(DataContext context, IMapper mapper, SendEmailService email)
        {
            _mapper = mapper;
            _context = context;
            _email = email;
        }

        public async Task FuncionarioPostoStatus(FuncionarioPostoStatusRequest model)
        {
            try
            {
                var T = await _context.Database.BeginTransactionAsync();

                var funcionarioPostoBd = await _context.FuncionariosPosto.Include(x => x.Usuario).FirstOrDefaultAsync(x => x.Id == model.FuncionarioPostoId);

                funcionarioPostoBd.Usuario.StatusEnum = model.Status;

                _context.Entry(funcionarioPostoBd).CurrentValues.SetValues(funcionarioPostoBd);

                await _context.SaveChangesAsync();

                await T.CommitAsync(); 
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
        public async Task<List<FuncionarioPostoDto>> GetAll()
        {
            try
            {
                var funcionarioPostos = await _context.FuncionariosPosto.Include(x => x.Posto).Include(x => x.Usuario).ToListAsync();

                var funcionarioPostosDto = _mapper.Map<List<FuncionarioPostoDto>>(funcionarioPostos);

                return funcionarioPostosDto;
            }
            catch (System.Exception error)
            {
                
                throw;
            }
        }
        public async Task<FuncionarioPostoDto> GetById(int id)
        {
            try
            {
                var funcionarioPosto = await _context.FuncionariosPosto.Include(x => x.Posto).Include(x => x.Usuario).FirstOrDefaultAsync(x => x.Id == id);

                var funcionarioPostoDto = _mapper.Map<FuncionarioPostoDto>(funcionarioPosto);

                return funcionarioPostoDto;

            }
            catch (System.Exception error)
            {
                
                throw;
            }
        }


        public async Task<List<TransacaoFuncionarioPostoDto>> TransacaoFuncionarioPostoGetAll(int idPosto)
        {
            var Transacaos = await _context.TransacoesPosto
            .Include(x => x.Posto)
            .Where(x => x.IdPosto == idPosto)
            .ToListAsync();

            var TransacaoFuncionarioPostoDto = _mapper.Map<List<TransacaoFuncionarioPostoDto>>(Transacaos);
            foreach (var item in TransacaoFuncionarioPostoDto)
            {
                var transacaoItem = await _context.TransacaoItens
                    .Include(x => x.Liquido)
                    .Where(x => x.IdTransacaoPosto == item.Id)
                    .ToListAsync();

                item.TransacaoItem = _mapper.Map<List<TransacaoItemDto>>(transacaoItem);
            }
            return TransacaoFuncionarioPostoDto;
        }
        public async Task<TransacaoFuncionarioPostoDto> TransacaoFuncionarioPostoGetById(int id)
        {
            var Transacaos = await _context.TransacoesPosto
            .Include(x => x.Posto)
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync();

            var TransacaoFuncionarioPostoDto = _mapper.Map<TransacaoFuncionarioPostoDto>(Transacaos);
            
            var transacaoItem = await _context.TransacaoItens
                .Include(x => x.Liquido)
                .Where(x => x.IdTransacaoPosto == Transacaos.Id)
                .ToListAsync();

            TransacaoFuncionarioPostoDto.TransacaoItem = _mapper.Map<List<TransacaoItemDto>>(transacaoItem);
            
            return TransacaoFuncionarioPostoDto;
        }
        public async Task TransacaoFuncionarioPostoPut(TransacaoFuncionarioPostoRequest model)
        {
            try
            {
                var T = await _context.Database.BeginTransactionAsync();

                var TransacaoPostoDb = await _context.TransacoesPosto.FirstOrDefaultAsync(x => x.Id == model.Id);
                if(TransacaoPostoDb == null)
                    throw new Exception("Transação não encontrada");

                if(TransacaoPostoDb.CodigoTransacao != model.CodigoTransacao)
                    throw new Exception("Código de transação inválido");

                TransacaoPostoDb.DataConfirmada = DateTime.Now;
                TransacaoPostoDb.Status = Models.Enuns.StatusEnum.Aprovado;
                TransacaoPostoDb.IdFuncionarioPosto = model.FuncionarioPostoId;
                TransacaoPostoDb.Valor = 0;

                foreach (var i in model.transacaoFuncionarioPostoItensRequests)
                {
                    var liquido = await _context.Liquidos.FirstOrDefaultAsync(x => x.Id == i.IdLiquido);

                    if(liquido == null)
                        throw new Exception("Liquido não encontrado");

                    TransacaoPostoDb.Valor += liquido.ValorUnitario * i.QtdConfirmada; 
                }
  
                _context.Entry(TransacaoPostoDb).CurrentValues.SetValues(TransacaoPostoDb);

                await _context.SaveChangesAsync();

                var TransacaoItens = await _context.TransacaoItens.Where(x => x.IdTransacaoPosto == model.Id).ToListAsync();
                
                foreach (var item in TransacaoItens)
                {
                    item.QtdConfirmada = model.transacaoFuncionarioPostoItensRequests
                        .First(x => x.IdLiquido == item.IdLiquido)
                        .QtdConfirmada;

                    await _context.SaveChangesAsync();

                    var postoLiquidoCapacidade = await _context.PostosAceitamLiquido
                        .Where(x => x.IdPosto == TransacaoPostoDb.IdPosto && x.IdLiquido == item.IdLiquido)
                        .FirstOrDefaultAsync();
                    
                    if(postoLiquidoCapacidade == null)
                        throw new Exception("Posto não aceita esse liquido");

                    postoLiquidoCapacidade.CapacidadeOcupada += model.transacaoFuncionarioPostoItensRequests
                        .First(x => x.IdLiquido == item.IdLiquido)
                        .QtdConfirmada;                  
                    
                    if(postoLiquidoCapacidade.CapacidadeOcupada > postoLiquidoCapacidade.CapacidadeTotal)
                        throw new Exception("Capacidade do posto excedida");

                    await _context.SaveChangesAsync();
                }

                var cliente = await _context.Clientes.FirstOrDefaultAsync(x => x.Id == TransacaoPostoDb.IdCliente);
                if(cliente == null)
                    throw new Exception("Cliente não encontrado");

                cliente.Saldo += TransacaoPostoDb.Valor;
                await _context.SaveChangesAsync();

                await T.CommitAsync();
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
        public async Task TransacaoFuncionarioPostoDelete(int id)
        {
            try
            {
                var T = await _context.Database.BeginTransactionAsync();

                var TransacaoPosto = await _context.TransacoesPosto
                    .Include(x => x.Cliente)
                        .ThenInclude(x => x.Usuario)
                    .FirstOrDefaultAsync(x => x.Id == id);
                
                if(TransacaoPosto == null)
                    throw new Exception("Transação não encontrada");

                TransacaoPosto.DeleteAt = DateTime.Now;

                await _context.SaveChangesAsync();

                await _email.EnvioEmailCancelamentoAgendamento(TransacaoPosto.Cliente.Usuario.Email);

                await T.CommitAsync();
            }
            catch (System.Exception error)
            {
                
                throw;
            }
        }

        public async Task TransacaoUsinaPost(TransacaoUsinaRequest model)
        {
            try
            {
                var T = await _context.Database.BeginTransactionAsync();

                var transacaoUsina = _mapper.Map<TransacaoUsina>(model);

                var transacaoUsinaBd = await _context.TransacoesUsina.AddAsync(transacaoUsina);

                await _context.SaveChangesAsync();

                foreach (var item in model.TransacaoUsinaItensRequest)
                {
                    var transacaoItemUsina = _mapper.Map<TransacaoItensUsina>(item);
                    transacaoItemUsina.IdTransacaoUsina = transacaoUsinaBd.Entity.Id;

                    await _context.TransacoesItensUsina.AddAsync(transacaoItemUsina);
                    await _context.SaveChangesAsync();

                    var funcionarioPosto = await _context.FuncionariosPosto
                        .Include(x => x.Posto)
                        .FirstOrDefaultAsync(x => x.Id == transacaoUsina.IdFuncionarioPosto);
                    
                    if(funcionarioPosto == null)
                        throw new Exception("Funcionario não encontrado");

                    var postoLiquidoCapacidade = await _context.PostosAceitamLiquido
                        .Where(x => x.IdPosto == funcionarioPosto.Posto.Id && x.IdLiquido == item.IdLiquido)
                        .FirstOrDefaultAsync();

                    if(postoLiquidoCapacidade == null)
                        throw new Exception("Posto não aceita esse liquido");

                    if(postoLiquidoCapacidade.CapacidadeTotal - item.Qtd < 0)
                        throw new Exception("Enviando mais liquido do que o posto armazena");
                    
                    if(postoLiquidoCapacidade.CapacidadeOcupada - item.Qtd < 0)
                        throw new Exception("Enviando mais liquido do que o posto tem armazenado");

                    postoLiquidoCapacidade.CapacidadeOcupada -= item.Qtd; 

                    await _context.SaveChangesAsync();
                }
                await T.CommitAsync();
            }
            catch (System.Exception error)
            {
                
                throw;
            }
        
        }
    }
}