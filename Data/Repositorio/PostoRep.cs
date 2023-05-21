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
    public class PostoRep: IPosto
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public PostoRep(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task Post(PostoRequest model)
        {
            try
            {
                var T = await _context.Database.BeginTransactionAsync();
            
                var posto = _mapper.Map<Posto>(model);

                var postoBd = await _context.Postos.AddAsync(posto);

                await _context.SaveChangesAsync();

                var PostoAceitaLiquido = _mapper.Map<List<PostoAceitaLiquido>>(model.LiquidosAceitos);
                
                PostoAceitaLiquido.ForEach(x => x.IdPosto = postoBd.Entity.Id);

                await _context.PostosAceitamLiquido.AddRangeAsync(PostoAceitaLiquido);

                await _context.SaveChangesAsync();

                await T.CommitAsync(); 
            }
            catch (System.Exception error)
            {
                
                throw;
            }
        }
        public async Task Put(PostoRequest model)
        {
            try
            {
                var T = await _context.Database.BeginTransactionAsync();

                var PostoBd = await _context.Postos.FindAsync(model.Id);

                var Postos = _mapper.Map<Posto>(model);
               
                _context.Entry(PostoBd).CurrentValues.SetValues(Postos);
                
                await _context.SaveChangesAsync();

                //remove todos os postos aceitam liquidos do banco de dados
                var PostoAceitaLiquidoBd = await _context.PostosAceitamLiquido.Where(x => x.IdPosto == model.Id).ToListAsync();
                 
                _context.PostosAceitamLiquido.RemoveRange(PostoAceitaLiquidoBd);

                await _context.SaveChangesAsync();
                //adiciona os novos liquidos
                var PostoAceitaLiquido = _mapper.Map<List<PostoAceitaLiquido>>(model.LiquidosAceitos);
                
                PostoAceitaLiquido.ForEach(x => x.IdPosto = PostoBd.Id);

                await _context.PostosAceitamLiquido.AddRangeAsync(PostoAceitaLiquido);

                await _context.SaveChangesAsync();

                await T.CommitAsync(); 

            }
            catch (System.Exception error)
            {
                
                throw;
            }
        }
        public async Task<List<PostoDto>> GetAll()
        {
            try
            {
                var Postos = await _context.Postos
                    .Include(x => x.DonoPosto)
                        .ThenInclude(a => a.Usuario)
                    .ToListAsync();

                var PostosDto = _mapper.Map<List<PostoDto>>(Postos);

                foreach (var i in PostosDto)
                {
                    var PostoAceitaLiquido = await _context.PostosAceitamLiquido.Include(x => x.Liquido).Where(x => x.IdPosto == i.Id).ToListAsync();
                    i.LiquidosAceitos = _mapper.Map<List<PostoAceitaLiquidoDto>>(PostoAceitaLiquido);
                }

                return PostosDto;
            }
            catch (System.Exception error)
            {
                
                throw;
            }
        }
        public async Task<PostoDto> GetById(int id)
        {
            try
            {
                var Posto = await _context.Postos
                .Include(x => x.DonoPosto)
                        .ThenInclude(a => a.Usuario)
                .FirstOrDefaultAsync(x => x.Id == id);

                var PostoDto = _mapper.Map<PostoDto>(Posto);

                var PostoAceitaLiquido = await _context.PostosAceitamLiquido.Include(x => x.Liquido).Where(x => x.IdPosto == id).ToListAsync();
                PostoDto.LiquidosAceitos = _mapper.Map<List<PostoAceitaLiquidoDto>>(PostoAceitaLiquido);
                return PostoDto;

            }
            catch (System.Exception error)
            {
                
                throw;
            }
        }
        public async Task PostoStatus(PostoStatusRequest model)
        {
            try
            {
                var T = await _context.Database.BeginTransactionAsync();

                var PostoBd = await _context.Postos
                    .Include(x => x.DonoPosto)
                        .ThenInclude(a => a.Usuario)
                    .FirstOrDefaultAsync(x => x.Id == model.PostoId);

                PostoBd.DonoPosto.Usuario.StatusEnum = model.Status;

                _context.Entry(PostoBd).CurrentValues.SetValues(PostoBd);

                await _context.SaveChangesAsync();

                await T.CommitAsync(); 
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
    }
}