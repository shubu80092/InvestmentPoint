using InvestmentPoint.Admin.App.DTO;
using InvestmentPoint.Admin.App.IUtilitiesServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace InvestmentPoint.Admin.App.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IJwtToken _jwtToken;
        public AccountController(IJwtToken jwtToken)
        {
            this._jwtToken = jwtToken;
        }
        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public IActionResult Authenticate([FromBody] LoginDTO model)
        {
            try
            {
                var token =  _jwtToken.token(model);
                if(token == null)
                {
                    return Unauthorized();
                }
                else
                {
                    return Ok(token);
                }
            }
            catch
            {

                return Ok(StatusCodes.Status400BadRequest);
            }
        }
    }
}
