using InvestmentPoint.Admin.Domain.Common;
using InvestmentPoint.Admin.Domain.Entites;
using InvestmentPoint.Admin.Persistence;
using InvestmentPoint.Admin.Services.Contract;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace InvestmentPoint.Admin.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;
        //public EmployeeController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}
        private readonly IEmployeeService _employee;
        public EmployeeController(IEmployeeService employee, ApplicationDbContext context)
        {
            _employee = employee;
            _context = context;
        }
        /// <summary>
        /// this Method is IActionResult is Get the List
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<IActionResult> ListEmployee()
        {
            try
            {
                 var list =  await _employee.ListEmployee();
                return View(list);
            }
            catch (Exception ex)
            {

                throw new Exception("Server Error" + ex.Message);
            }
        }
        /// <summary>
        /// this Method is IActionResult to add the Employee Details
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<IActionResult> AddEmployee()
        {
            try
            {
                ViewBag.Area = new SelectList(_context.Areas.ToList(), "Id", "AreaName");
                return View();
            }
            catch (Exception ex)
            {

                throw new Exception("Server Error" + ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee(EmployeeModel employee)
        {
            try
            {
                ViewBag.Area = new SelectList(_context.Areas.ToList(), "Id", "AreaName");
                if (ModelState.IsValid)
                {
                   bool check = await _employee.AddEmployee(employee);
                    if (check)
                    {
                        return RedirectToAction("ListEmployee");
                    }
                    else
                    {
                        return View();
                    }
                }
                return View();
            }
            catch (Exception ex)
            {

                throw new Exception("Server Error" + ex.Message);
            }
        }

        /// <summary>
        /// This Method is IActionResult to Edit Employee Details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<IActionResult> EditEmployee(int id)
        {
            try
            {
                var data = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);
                if(!string.IsNullOrEmpty(data.Email))
                {
                    return View(data);
                }
                return View();
            }
            catch (Exception ex)
            {

                throw new Exception("Server Error" + ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> EditEmployee(int id,EmployeeModel employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _employee.EditEmployee(id, employee);
                }
                return View();
            }
            catch (Exception ex)
            {

                throw new Exception("Server Error" + ex.Message);
            }
        }
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   bool check =  await _employee.DeleteEmployee(id);
                    if (check)
                    {
                        return RedirectToAction("ListEmployee");
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
