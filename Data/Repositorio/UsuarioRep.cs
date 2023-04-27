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
    public class UsuarioRep: IUsuario
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public UsuarioRep(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task Post(UsuarioDadosRequest model, UsuarioContaRequest conta)
        {
            try
            {
                var T = await _context.Database.BeginTransactionAsync();

                // var usuario = new Usuario(){
                //     Login = conta.Login,
                //     Senha = BCrypt.Net.BCrypt.HashPassword(conta.Senha),
                //     Nome = model.Nome,
                //     Email = model.Email,
                //     ...
                // };

                var usuario = _mapper.Map<Usuario>(model);

                usuario.Login = conta.Login;
                usuario.Senha = BCrypt.Net.BCrypt.HashPassword(conta.Senha);

                await _context.Usuarios.AddAsync(usuario);

                await _context.SaveChangesAsync();

                await T.CommitAsync(); 
            }
            catch (System.Exception error)
            {
                
                throw;
            }
        }
        public async Task Put(UsuarioDadosRequest model)
        {
            try
            {
                var T = await _context.Database.BeginTransactionAsync();

                var usuarioBd = await _context.Usuarios.FindAsync(model.Id);

                var usuario = _mapper.Map<Usuario>(model);
                
                usuario.Login = usuarioBd.Login;
                usuario.Senha = usuarioBd.Senha;

                _context.Entry(usuarioBd).CurrentValues.SetValues(usuario);
                
                await _context.SaveChangesAsync();

                await T.CommitAsync();

            }
            catch (System.Exception error)
            {
                
                throw;
            }
        }
        public async Task<List<UsuarioDto>> GetAll()
        {
            try
            {
                var usuarios = await _context.Usuarios.ToListAsync();

                var usuariosDto = _mapper.Map<List<UsuarioDto>>(usuarios);

                return usuariosDto;
            }
            catch (System.Exception error)
            {
                
                throw;
            }
        }
        public async Task<UsuarioDto> GetById(int id)
        {
            try
            {
                var usuario = await _context.Usuarios.FindAsync(id);

                var usuarioDto = _mapper.Map<UsuarioDto>(usuario);

                return usuarioDto;

            }
            catch (System.Exception error)
            {
                
                throw;
            }
        }
    }
}