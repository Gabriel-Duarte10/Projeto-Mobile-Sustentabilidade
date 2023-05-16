using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using Projeto_Mobile_Sustentabilidade.Data.Context;
using Projeto_Mobile_Sustentabilidade.Data.Request;

namespace Projeto_Mobile_Sustentabilidade.Services
{
    public class SendEmailService
    {
        private readonly SendGridService SendGridService;
        private readonly IConfiguration Configuration;
        private readonly DataContext _context;
        private readonly int DelaySend = 1;
        private string caminhoEmail = "";
        private string tituleEmail = "";

        public SendEmailService(
            SendGridService sendGridService,
            IConfiguration configuration, 
            DataContext context
        )
        {
            SendGridService = sendGridService;
            _context = context;  
            Configuration = configuration;
        }
        public async Task EnvioEmailRedefinirSenha(String email)
        {
            var usuario = _context.Usuarios.Where(x => x.Email.ToLower() == email.ToLower()).First();
            if(usuario != null)
            {
                var token = GenerateToken(usuario.Id.ToString());
                await SendGridService.Send(email, $"Envio de Email - Redefinir de senha", $"Email/RedefinirSenha", token);
            }
        }
        public string GenerateToken(string userId)
        {
            var jwtConfig = Configuration.GetSection("JWT");
            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(jwtConfig.GetValue<string>("SecurityKey")));
            var createdDate = DateTime.Now;
            var expirationDate = createdDate.AddHours(jwtConfig.GetValue<double>("HoursExpire"));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("Id", userId),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: expirationDate,
                signingCredentials: signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }
    }
}