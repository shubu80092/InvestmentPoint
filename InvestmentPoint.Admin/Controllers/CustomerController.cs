using InvestmentPoint.Admin.Domain.Common;
using InvestmentPoint.Admin.Persistence;
using InvestmentPoint.Admin.Services.Contract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace InvestmentPoint.Admin.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ICustomerService _customer;
        public CustomerController(ICustomerService customer, ApplicationDbContext context)
        {
            _customer = customer;
            _context = context;
        }

        public async Task<IActionResult> ListCustomer(int Id)
        {
			try
			{
                ViewBag.Employees = new SelectList(await _context.Employees.ToListAsync(), "Id", "Name");
                if(Id > 0)
                {
                     return View(await _customer.ListCustomer(Id));
                }
                else
                {
                    return View(await _customer.ListCustomer(Id));
                }
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
                ViewBag.Area = new SelectList(_context.Areas.ToList(), "Id", "AreaName");
                ViewBag.Investment = new SelectList(_context.TypeofInvestments.ToList(), "Id", "InvestmentName");
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
                ViewBag.Area = new SelectList(_context.Areas.ToList(), "Id", "AreaName");
                ViewBag.Investment = new SelectList(_context.TypeofInvestments.ToList(), "Id", "InvestmentName");
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

        public async Task<IActionResult> Report()
        {
            try
            {
                return View(await _customer.CustomerReport());
               
            }
            catch (Exception ex)
            {

                throw new Exception("Server Error" + ex.Message);
            }
        }
    }
}
