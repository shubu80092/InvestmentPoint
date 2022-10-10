using InvestmentPoint.Admin.App.IUtilitiesServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using InvestmentPoint.Admin.Domain.Common;
using InvestmentPoint.Admin.Persistence;
using Microsoft.EntityFrameworkCore;

namespace InvestmentPoint.Admin.App.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IJwtToken _jwtToken;
        public AccountController(IJwtToken jwtToken, ApplicationDbContext context)
        {
            this._jwtToken = jwtToken;
            this._context = context;
        }
        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public IActionResult Authenticate(AccountModel model)
        {
            try
            {
                var user = _context.Employees.Where(x => x.Name == model.Username && x.Password == model.Password).FirstOrDefault();
                if (!string.IsNullOrEmpty(user.Name))
                {
                    var Token = _jwtToken.token(model);
                    if (Token == null)
                    {
                        return Ok(StatusCodes.Status401Unauthorized);
                    }
                //else
                //{
                //    return Ok(new {model.Username,model.Password,Token});
                //}
                    else
                    {
                        return Ok(new { user.Id, user.Name, user.Email, user.AadharNo, Token });
                    }
                }
                else
                {
                    return Ok(StatusCodes.Status401Unauthorized);
                }
            }
            catch
            {

                return Ok(StatusCodes.Status400BadRequest);
            }
        }
    }
}
