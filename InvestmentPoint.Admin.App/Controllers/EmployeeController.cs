using InvestmentPoint.Admin.Domain.Common;
using InvestmentPoint.Admin.Services.APIContract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentPoint.Admin.App.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employee;
        public EmployeeController(IEmployeeService employee)
        {
            this._employee = employee;
        }

        
        [HttpGet]
        [Route("CurrentDateCustomer")]
        public async Task<IActionResult> CurrentDateCustomer()
        {
            try
            {
                var status = new Status();
                var result = await _employee.CurrentDateCustomer();
                    if (result != null)
                    {
                        
                        status.StatusCode = StatusCodes.Status200OK;
                        status.Message = "Success";
                        return Ok(new { result, status });
                    }
                    else
                    {
                        status.StatusCode=StatusCodes.Status404NotFound;
                         status.Message = "Data Does't Exists";
                        return Ok(status);
                    }
                
            }
            catch
            {

                return BadRequest(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet]
        [Route("ListCustomer")]
        public async Task<IActionResult> ListCustomer()
        {
            try
            {
                var status = new Status();
                var result = await _employee.ListCustomer();
                if(result != null)
                {
                    status.StatusCode = StatusCodes.Status200OK;
                    status.Message = "Success";
                    return Ok(new { result, status });
                }
                else
                {
                    status.StatusCode = StatusCodes.Status404NotFound;
                    status.Message = "Data Does't Exists";
                    return Ok(status);
                }
            }
            catch
            {

                return BadRequest(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
