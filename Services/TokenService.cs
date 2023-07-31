using JucaSystem.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JucaSystem.Services
{
    public static class TokenService
    {

        public static string GerarTokenAcesso(Login login)
        {
            var tokenAssist = new JwtSecurityTokenHandler();
            var masterKey = Encoding.ASCII.GetBytes(Settings.Chave);
            var descritor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, login.DescricaoLogin.ToString()),
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(masterKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenAssist.CreateToken(descritor);
            return tokenAssist.WriteToken(token);
        }
    }
}

