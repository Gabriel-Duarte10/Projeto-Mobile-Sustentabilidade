using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Projeto_Mobile_Sustentabilidade.Data.Context;
using Projeto_Mobile_Sustentabilidade.Data.Dto;
using Projeto_Mobile_Sustentabilidade.Data.Interface;
using Projeto_Mobile_Sustentabilidade.Data.Models.Enuns;
using Projeto_Mobile_Sustentabilidade.Data.Request;

namespace Projeto_Mobile_Sustentabilidade.Data.Repositorio
{
    public class ManterContaRep: IManterConta
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public ManterContaRep(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<LoginDto> Login(LoginRequest model)
        {
            var user = await _context.Usuarios.FirstOrDefaultAsync(x => x.Login.ToLower() == model.Login.ToLower());

            if (user == null)
                throw new Exception("Usuário não encontrado");

            if (!BCrypt.Net.BCrypt.Verify(model.Senha, user.Senha))
                throw new Exception("Senha inválida");

            var response = new LoginDto();

            switch (model.PerfilEnum)
            {
                case PerfilEnum.Administrador:
                    var admin = await _context.Administradores
                        .Include(x => x.Usuario)
                        .FirstOrDefaultAsync(x => x.IdUsuario == user.Id);
                    response.Administrador = _mapper.Map<AdministradorDto>(admin);
                    break;
                case PerfilEnum.Cliente:
                    var cliente = await _context.Clientes
                        .Include(x => x.Usuario)
                        .FirstOrDefaultAsync(x => x.IdUsuario == user.Id);
                    response.Cliente = _mapper.Map<ClienteDto>(cliente);
                    break;
                case PerfilEnum.FuncionarioPosto:
                    var funcionarioPosto = await _context.FuncionariosPosto
                        .Include(x => x.Usuario)
                        .FirstOrDefaultAsync(x => x.IdUsuario == user.Id);
                    response.FuncionarioPosto = _mapper.Map<FuncionarioPostoDto>(funcionarioPosto);
                    break;
                case PerfilEnum.DonoPosto:
                    var donoPosto = await _context.Postos
                        .Include(x => x.DonoPosto)
                            .ThenInclude(y => y.Usuario)
                        .FirstOrDefaultAsync(x => x.DonoPosto.IdUsuario == user.Id);
                    response.DonoPosto = _mapper.Map<DonoPostoDto>(donoPosto.DonoPosto);
                    break;
                default:
                    throw new Exception("Perfil não suportado");
            }

            return response;
        }

    }
}