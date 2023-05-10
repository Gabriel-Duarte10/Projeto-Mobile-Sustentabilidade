using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Projeto_Mobile_Sustentabilidade.Data.Context;
using Projeto_Mobile_Sustentabilidade.Data.Dto;
using Projeto_Mobile_Sustentabilidade.Data.Interface;
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