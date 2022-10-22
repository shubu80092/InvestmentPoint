using InvestmentPoint.Admin.App.UtilitiesServices;
using InvestmentPoint.Admin.Domain.Common;
using InvestmentPoint.Admin.Domain.DTOModel;
using InvestmentPoint.Admin.Services.APIContract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentPoint.Admin.App.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customer;
        public CustomerController(ICustomerService customer)
        {
            this._customer = customer;
        }
        [HttpGet]
        [Route("CustomerProfile/{id}")]
        public async Task<IActionResult> CustomerProfile(int id)
        {
            var response = new Response<List<CustomerDTO1>>(); 
            try
            {
                var data = await _customer.CustomerDetails(id);
                if(data != null)
                {
                    response.Succeeded = true;
                    response.StatusCode = StatusCodes.Status200OK;
                    response.Status = "Success"; 
                    response.Message = "All About Customer Data Here";
                    response.Data = data;
                    return Ok(response);
                }
                else
                {
                    response.Succeeded = true;
                    response.StatusCode = StatusCodes.Status404NotFound;
                    response.Message = "Customer Data Not Found";
                    return Ok(response);
                }
            }
            catch
            {

                response.Error = "Server Error";
                return BadRequest(response);
            }
        }


        [HttpGet]
        [Route("CustomerPlan/{id}")]
        public async Task<IActionResult> CustomerPlan(int id)
        {
            var response = new Response<List<PlanDTO>>();
            try
            {
                var data = await _customer.PlanDetails(id);
                if(data != null)
                {
                    response.Succeeded = true;
                    response.StatusCode = StatusCodes.Status200OK;
                    response.Message = "All About this";
                    response.Status = "Success";
                    response.Data = data;
                    return Ok(response);
                }
                else
                {
                    response.StatusCode = StatusCodes.Status404NotFound;
                    response.Message = "Data Not Found";
                    response.Data = data;
                    return Ok(response);
                }      
            }
            catch
            {
                return BadRequest(StatusCodes.Status401Unauthorized);
            }
        }
    }
}
