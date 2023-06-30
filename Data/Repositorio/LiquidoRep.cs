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

namespace Projeto_Mobile_Sustentabilidade.Data.Repositorio
{
    public class LiquidoRep: ILiquido
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public LiquidoRep(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task Post(LiquidoRequest model)
        {
            try
            {
                var T = await _context.Database.BeginTransactionAsync();
            
                var liquido = _mapper.Map<Liquido>(model);

                await _context.Liquidos.AddAsync(liquido);

                await _context.SaveChangesAsync();

                await T.CommitAsync(); 
            }
            catch (System.Exception error)
            {
                
                throw;
            }
        }
        public async Task Put(LiquidoRequest model)
        {
            try
            {
                var T = await _context.Database.BeginTransactionAsync();

                var liquidoBd = await _context.Liquidos.FindAsync(model.Id);

                var liquidos = _mapper.Map<Liquido>(model);
               
                _context.Entry(liquidoBd).CurrentValues.SetValues(liquidos);
                
                await _context.SaveChangesAsync();

                await T.CommitAsync();

            }
            catch (System.Exception error)
            {
                
                throw;
            }
        }
        public async Task<List<LiquidoDto>> GetAll()
        {
            try
            {
                var liquidos = await _context.Liquidos.ToListAsync();

                var liquidosDto = _mapper.Map<List<LiquidoDto>>(liquidos);

                return liquidosDto;
            }
            catch (System.Exception error)
            {
                
                throw;
            }
        }
        public async Task<LiquidoDto> GetById(int id)
        {
            try
            {
                var liquido = await _context.Liquidos.FindAsync(id);

                var LiquidoDto = _mapper.Map<LiquidoDto>(liquido);

                return LiquidoDto;

            }
            catch (System.Exception error)
            {
                
                throw;
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                var T = await _context.Database.BeginTransactionAsync();

                var liquido = await _context.Liquidos.FindAsync(id);
                if(liquido == null)
                    throw new Exception("Liquido não encontrado");
                    
                liquido.DeleteAt  = DateTime.Now;

                await _context.SaveChangesAsync();

                await T.CommitAsync();
            }
            catch (System.Exception error)
            {
                
                throw;
            }
            
        }
    }
}