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
using Projeto_Mobile_Sustentabilidade.Data.Models.Enuns;
using Projeto_Mobile_Sustentabilidade.Data.Request;

namespace Projeto_Mobile_Sustentabilidade.Data.Repositorio
{
    public class ClienteRep: ICliente
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public ClienteRep(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task TransacaoClienteDelete(int id)
        {
            try
            {
                var T = await _context.Database.BeginTransactionAsync();

                var TransacaoPosto = await _context.TransacoesPosto.FirstOrDefaultAsync(x => x.Id == id);

                TransacaoPosto.DeleteAt = DateTime.Now;

                await _context.SaveChangesAsync();

                await T.CommitAsync();
            }
            catch (System.Exception error)
            {
                
                throw;
            }
        }

        public async Task<List<TransacaoClienteDto>> TransacaoClienteGetAll(int idCliente)
        {
            var Transacaos = await _context.TransacoesPosto
            .Include(x => x.Posto)
            .Where(x => x.IdCliente == idCliente)
            .ToListAsync();

            var TransacaoClienteDto = _mapper.Map<List<TransacaoClienteDto>>(Transacaos);
            foreach (var item in TransacaoClienteDto)
            {
                var transacaoItem = await _context.TransacaoItens
                    .Include(x => x.Liquido)
                    .Where(x => x.IdTransacaoPosto == item.Id)
                    .ToListAsync();

                item.TransacaoItem = _mapper.Map<List<TransacaoItemDto>>(transacaoItem);
            }
            return TransacaoClienteDto;
        }

        public async Task<TransacaoClienteDto> TransacaoClienteGetById(int id)
        {
            var TransacaoCliente = await _context.TransacoesPosto
                .Include(x => x.Posto)
                .FirstOrDefaultAsync(x => x.Id == id);
            
            var TransacaoClienteDto = _mapper.Map<TransacaoClienteDto>(TransacaoCliente);

            var transacaoItem = await _context.TransacaoItens
                .Include(x => x.Liquido)
                .Where(x => x.IdTransacaoPosto == TransacaoClienteDto.Id)
                .ToListAsync();
            TransacaoClienteDto.TransacaoItem = _mapper.Map<List<TransacaoItemDto>>(transacaoItem);

            return TransacaoClienteDto;
        }

        public async Task TransacaoClientePost(TransacaoClienteRequest model)
        {
            try
            {
                var T = await _context.Database.BeginTransactionAsync();

                var Transacao = _mapper.Map<TransacaoPosto>(model);
                Transacao.Status = StatusEnum.Pendente;
                
                var codigoTransacao = new Random().Next(100000, 999999).ToString();
                
                while (_context.TransacoesPosto.Where(x => x.CodigoTransacao == codigoTransacao).Any())
                {
                    codigoTransacao = new Random().Next(100000, 999999).ToString();
                }

                Transacao.CodigoTransacao = codigoTransacao;
                
                var TransacaoDb = await _context.TransacoesPosto.AddAsync(Transacao);

                 await _context.SaveChangesAsync();

                foreach (var item in model.TransacaoItens)
                {
                    var TransacaoItem = _mapper.Map<TransacaoItens>(item);                  
                    TransacaoItem.IdTransacaoPosto = TransacaoDb.Entity.Id;

                    await _context.TransacaoItens.AddAsync(TransacaoItem);
                    await _context.SaveChangesAsync();
                }

                await T.CommitAsync();
            }
            catch (System.Exception error)
            {
                
                throw;
            }
        }

        public async Task TransacaoClientePut(TransacaoClienteRequest model)
        {
            try
            {
                var T = await _context.Database.BeginTransactionAsync();

                var TransacaoPostoDb = await _context.TransacoesPosto.FirstOrDefaultAsync(x => x.Id == model.Id);

                var Transacao = _mapper.Map<TransacaoPosto>(model);
                Transacao.Status = StatusEnum.Pendente;
  
                _context.Entry(TransacaoPostoDb).CurrentValues.SetValues(Transacao);

                await _context.SaveChangesAsync();

                var TransacaoItens = await _context.TransacaoItens.Where(x => x.IdTransacaoPosto == model.Id).ToListAsync();

                foreach (var item in TransacaoItens)
                {
                    _context.TransacaoItens.Remove(item);
                    await _context.SaveChangesAsync();
                }

                foreach (var item in model.TransacaoItens)
                {
                    var TransacaoItem = _mapper.Map<TransacaoItens>(item);                  
                    TransacaoItem.IdTransacaoPosto = Transacao.Id;
                    await _context.TransacaoItens.AddAsync(TransacaoItem);
                    await _context.SaveChangesAsync();
                }

                await T.CommitAsync();
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        public async Task ClienteStatus(ClienteStatusRequest model)
        {
            try
            {
                var T = await _context.Database.BeginTransactionAsync();
            
                var ClienteDb = await _context.Clientes
                    .Include(x => x.Usuario)
                    .FirstOrDefaultAsync(x => x.Id == model.ClienteId);

                ClienteDb.Usuario.StatusEnum = model.Status;

                _context.Entry(ClienteDb).CurrentValues.SetValues(ClienteDb);

                await _context.SaveChangesAsync();

                await T.CommitAsync(); 
            }
            catch (System.Exception error)
            {
                
                throw;
            }
        }

        public async Task<List<ClienteDto>> GetAll()
        {
            try
            {
                var clientes = await _context.Clientes.Include(x => x.Usuario).ToListAsync();

                var clientesDto = _mapper.Map<List<ClienteDto>>(clientes);

                return clientesDto;
            }
            catch (System.Exception error)
            {
                
                throw;
            }
        }

        public async Task<ClienteDto> GetById(int id)
        {
            try
            {
                var cliente = await _context.Clientes.Include(x => x.Usuario).FirstOrDefaultAsync(x => x.Id == id);

                var clienteDto = _mapper.Map<ClienteDto>(cliente);

                return clienteDto;

            }
            catch (System.Exception error)
            {
                
                throw;
            }
        }

    }
}