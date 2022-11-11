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
            var response = new Response<List<CustomerDTO>>();
            try
            {
                
                var status = new Status();
                var data = await _employee.CurrentDateCustomer();
                    if (data != null)
                    {

                    response.Succeeded = true;
                    response.StatusCode = StatusCodes.Status200OK;
                    response.Status = "Success";
                    response.Message = "Current Date All Customer Here";
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
        [HttpGet]
        [Route("EmployeeProfile/{id}")]
        public async Task<IActionResult> EmployeeProfile(int id)
        {
            var response = new Response<List<EmployeeDTO1>>(); 
            try
            {
                var data = await _employee.EmployeeProfile(id);
                if(data != null)
                {
                    response.Succeeded = true;
                    response.StatusCode = StatusCodes.Status200OK;
                    response.Status = "Success";
                    response.Message = "Employee Profile data Here.";
                    response.Data = data;
                    return Ok(response);
                }
                else
                {
                    response.Succeeded = false;
                    response.StatusCode = StatusCodes.Status404NotFound;
                    response.Status = "Faild";
                    response.Message = "Employee Data Not Found";
                    return Ok(response);
                }
            }
            catch
            {
                response.StatusCode = StatusCodes.Status500InternalServerError;
                response.Error = "Server Error";
                return Ok(response);
                
            }
        }
        //[HttpPost]
        //[Route("EmployeeEMIPost")]
        //public async Task<IActionResult> EmployeeEMIPost(CustomerDTO model)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            bool check = _employee.CustomerEMISave(model);
        //        } 
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}
    }
}
