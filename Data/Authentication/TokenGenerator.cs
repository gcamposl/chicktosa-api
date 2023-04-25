using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Domain.Authentication;
using Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace Data.Authentication
{
    public class TokenGenerator : ITokenGenerator
    {
        public dynamic Generator(User user)
        {
            var claims = new List<Claim>
            {
                new Claim("Email", user.Email),
                new Claim("Id", user.Id.ToString())
            };

            var expires = DateTime.Now.AddDays(1);
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("testePass"));
            var tokenData = new JwtSecurityToken(
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature),
                expires: expires,
                claims: claims
            );

            var token = new JwtSecurityTokenHandler().WriteToken(tokenData);

            return new
            {
                access_token = token,
                expirations = expires
            };
        }
    }
}