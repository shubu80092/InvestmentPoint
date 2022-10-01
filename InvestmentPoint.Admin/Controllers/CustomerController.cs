using InvestmentPoint.Admin.Domain.Common;
using InvestmentPoint.Admin.Services.Contract;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentPoint.Admin.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customer;
        public CustomerController(ICustomerService customer)
        {
            _customer = customer;
        }

        public async Task<IActionResult> ListCustomer()
        {
			try
			{
                return View(await _customer.ListCustomer());
            }
			catch (Exception ex)
			{

				throw new Exception("Server Error" + ex.Message);
			}
        }

        public async Task<IActionResult> AddCustomer()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {

                throw new Exception("Server Error" + ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddCustomer(CustomerModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool check = await _customer.AddCustomer(model);
                    if (check)
                    {
                        TempData["msg"] = "Customer Add Successfully";
                        return RedirectToAction("ListCustomer");
                    }
                    else
                    {
                        TempData["msg"] = "Customer Not Add Successfully";
                    }
                }
                return View();
            }
            catch (Exception ex)
            {

                throw new Exception("Server Error" + ex.Message);
            }
        }
    }
}
