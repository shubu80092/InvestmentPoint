using InvestmentPoint.Admin.Domain.Common;
using InvestmentPoint.Admin.Models;
using InvestmentPoint.Admin.Services.Contract;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace InvestmentPoint.Admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //EmployeeModel employee = new();
            //_employee.AddEmployee(employee);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}