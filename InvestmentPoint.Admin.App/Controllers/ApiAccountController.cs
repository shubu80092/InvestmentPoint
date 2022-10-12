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
    public class ApiAccountController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IJwtToken _jwtToken;
        public ApiAccountController(IJwtToken jwtToken,ApplicationDbContext context)
        {
            this._jwtToken = jwtToken;
            this._context = context;
        }
        [AllowAnonymous]
        [HttpPost]
        //[Route("~/")]
        [Route("EmployeeLogin")]
        public IActionResult EmployeeLogin(AccountModelDTO model)
        {
            try
            {
                var status = new Status();
                var user = _context.Employees.Where(x => x.Email == model.Email && x.Password == model.Password).FirstOrDefault();
                if(user != null)
                {
                    var Token = _jwtToken.token(model);
                    if (Token == null)
                    {
                        status.StatusCode = StatusCodes.Status401Unauthorized;
                        status.Message = "Token is Not Generated";
                        return Ok(status);
                    }
                    else
                    {
                        status.StatusCode = StatusCodes.Status200OK;
                        status.Message = "Login Successfully";
                        return Ok(new { user.Id, user.Name, user.Email, user.AadharNo, Token,status });
                    }
                }
                else
                {
                    status.StatusCode = StatusCodes.Status404NotFound;
                    status.Message = "Email and Password is Invalid";
                    return Ok(status);
                }
            }
            catch
            {

                return Ok(StatusCodes.Status400BadRequest);
            }
        }
        [AllowAnonymous]
        [HttpPost]
        //[Route("~/")]
        [Route("CustomerLogin")]
        public IActionResult CustomerLogin(AccountModelDTO model)
        {
            try
            {
                var status = new Status();
                var user = _context.Customers.Where(x => x.Email == model.Email && x.Password == model.Password).FirstOrDefault();
                if (user != null)
                {
                    var Token = _jwtToken.token(model);
                    if (Token == null)
                    {
                        status.StatusCode = StatusCodes.Status401Unauthorized;
                        status.Message = "Token is Not Generated";
                        return Ok(status);
                    }
                    else
                    {
                        status.StatusCode = StatusCodes.Status200OK;
                        status.Message = "Login Successfully";
                        return Ok(new { user.Id, user.Name, user.Email, user.AadharNo, Token, status });
                    }
                }
                else
                {
                    status.StatusCode = StatusCodes.Status404NotFound;
                    status.Message = "Email and Password is Invalid";
                    return Ok(status);
                }
            }
            catch
            {
                return Ok(StatusCodes.Status400BadRequest);   
            }
        }
    }
}
