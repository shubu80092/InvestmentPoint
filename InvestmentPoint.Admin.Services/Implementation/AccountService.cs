using InvestmentPoint.Admin.Domain.Common;
using InvestmentPoint.Admin.Domain.Entites;
using InvestmentPoint.Admin.Services.Contract;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentPoint.Admin.Services.Implementation
{
    public class AccountService : IAccountService
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        public AccountService(SignInManager<User> signInManager, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task<Status> LoginAsync(AccountModel model)
        {
            var status = new Status();
            var user = await userManager.FindByIdAsync(model.Username);
            if(user == null)
            {
                status.StatusCode = 0;
                status.Message = "Invalid username";
                return status;
            }
            ///we will match password
            if(!await userManager.CheckPasswordAsync(user, model.Password))
            {

                status.StatusCode = 0;
                status.Message = "Invalid username";
                return status;
            }
            var signInResult = await signInManager.PasswordSignInAsync(user, model.Password, false, true);
            if (signInResult.Succeeded)
            {
                var userRoles = await userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,user.UserName)
                };
                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                status.StatusCode = 1;
                status.Message = "Logged In Successfully";
                return status;
            }
            else if (signInResult.IsLockedOut)
            {

                status.StatusCode = 0;
                status.Message = "User locked out";
                return status;
            }
            else
            {

                status.StatusCode = 0;
                status.Message = "Error on loggin in";
                return status;
            }
        }

        public async Task LogoutAsync()
        {
            await signInManager.SignOutAsync();
        }

        public async Task<Status> RegistrationAsync(RegistrationModel model)
        {
           var status = new Status();
            var userExists = await userManager.FindByNameAsync(model.Username);
            if(userExists != null)
            {
                status.StatusCode = 0;
                status.Message = "User Already Exists";
                return status;
            }
            User user = new User
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                Name = model.Name,
                Email = model.Email,
                UserName = model.Username,
                EmailConfirmed = true
                
            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                status.StatusCode = 0;
                status.Message = "User creation faild";
                return status;
            }
            if (!await roleManager.RoleExistsAsync(model.Role))
                await roleManager.CreateAsync(new IdentityRole(model.Role));
            if(await roleManager.RoleExistsAsync(model.Role))
            {
                await userManager.AddToRoleAsync(user, model.Role);
            }
            status.StatusCode = 1;
            status.Message = "User has registered successfully";
            return status;
        }
    }
}
