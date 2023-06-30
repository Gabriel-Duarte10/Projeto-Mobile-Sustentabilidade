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
    public class UsinaRep: IUsina
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public UsinaRep(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task Post(UsinaRequest model)
        {
            try
            {
                var T = await _context.Database.BeginTransactionAsync();
            
                var usina = _mapper.Map<Usina>(model);

                await _context.Usinas.AddAsync(usina);

                await _context.SaveChangesAsync();

                await T.CommitAsync(); 
            }
            catch (System.Exception error)
            {
                
                throw;
            }
        }
        public async Task Put(UsinaRequest model)
        {
            try
            {
                var T = await _context.Database.BeginTransactionAsync();

                var UsinaBd = await _context.Usinas.FindAsync(model.Id);

                var usina = _mapper.Map<Usina>(model);
               
                _context.Entry(UsinaBd).CurrentValues.SetValues(usina);
                
                await _context.SaveChangesAsync();

                await T.CommitAsync();

            }
            catch (System.Exception error)
            {
                
                throw;
            }
        }
        public async Task<List<UsinaDto>> GetAll()
        {
            try
            {
                var Usinas = await _context.Usinas.ToListAsync();

                var UsinasDto = _mapper.Map<List<UsinaDto>>(Usinas);

                return UsinasDto;
            }
            catch (System.Exception error)
            {
                
                throw;
            }
        }
        public async Task<UsinaDto> GetById(int id)
        {
            try
            {
                var Usina = await _context.Usinas.FindAsync(id);

                var UsinaDto = _mapper.Map<UsinaDto>(Usina);

                return UsinaDto;

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

                var Usina = await _context.Usinas.FindAsync(id);

                if(Usina == null)
                    throw new Exception("Usina não encontrada");
                
                Usina.DeleteAt = DateTime.Now;

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