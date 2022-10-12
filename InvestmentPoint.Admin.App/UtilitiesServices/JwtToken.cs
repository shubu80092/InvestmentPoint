using InvestmentPoint.Admin.App.IUtilitiesServices;
using InvestmentPoint.Admin.Domain.Common;
using InvestmentPoint.Admin.Domain.Entites;
using InvestmentPoint.Admin.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace InvestmentPoint.Admin.App.UtilitiesServices
{
    public class JwtToken : IJwtToken
    {
        //private IDictionary<string, string> users = new Dictionary<string, string>
        //{ {"test1","password1"},{ "test2","password2"} };
        //private readonly SignInManager<User> signInManager;
        //private readonly UserManager<User> userManager;
        //private readonly RoleManager<IdentityRole> roleManager;
        private readonly string key;
        public JwtToken(string key)
        {
            this.key = key;
        }
        //public JwtToken(ApplicationDbContext context,SignInManager<User> signInManager, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        //{
        //    this.signInManager = signInManager;
        //    this.userManager = userManager;
        //    this.roleManager = roleManager;
        //    this._context = context;
        //}

        public  string token(AccountModelDTO model)
        {
            
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.ASCII.GetBytes(key);
                var tokenDescriptor = new SecurityTokenDescriptor()
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Email, model.Email)
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
