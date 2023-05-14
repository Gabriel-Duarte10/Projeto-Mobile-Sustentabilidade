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
    public class FuncionarioPostoRep: IFuncionarioPosto
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public FuncionarioPostoRep(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
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
    }
}