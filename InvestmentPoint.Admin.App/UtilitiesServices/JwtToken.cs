﻿using InvestmentPoint.Admin.App.DTO;
using InvestmentPoint.Admin.App.IUtilitiesServices;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace InvestmentPoint.Admin.App.UtilitiesServices
{
    public class JwtToken : IJwtToken
    {
        private IDictionary<string, string> users = new Dictionary<string, string>
        { {"test1","password1"},{ "test2","password2"} };
        private readonly string key;
        public JwtToken(string key)
        {
            this.key = key;
        }

        public string token(LoginDTO model)
        {
            if(!users.Any(u =>u.Key == model.Username && u.Value == model.Password))
            {
                return null;
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(key);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, model.Username)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey),
            SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
           return tokenHandler.WriteToken(token);
        }
    }
}