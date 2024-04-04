using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Users
{
    public class JWTGeneratorService
    {
        private readonly IConfiguration _builder;

        public JWTGeneratorService(IConfiguration builder)
        {
            _builder = builder;
        }
        public string GenerateJwtToken(User user)
        {
            List<Claim> claims = new()
        {
            new (JwtRegisteredClaimNames.Sid, user.UserID.ToString()),
            new (JwtRegisteredClaimNames.Name, user.Name)
        };

            var token = new JwtSecurityToken(
                issuer: _builder.GetSection("Jwt:Issuer").Value,
                audience: _builder.GetSection("Jwt:Audience").Value,
                claims: claims,
                expires: DateTime.Now.AddDays(7),
                notBefore: DateTime.Now,
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_builder.GetSection("Jwt:Key").Value)),
                    SecurityAlgorithms.HmacSha256)
            );

            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

            return jwtToken;
        }
    }
}
