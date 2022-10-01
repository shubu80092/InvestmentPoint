using InvestmentPoint.Admin.Domain.Common;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentPoint.Admin.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
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
        public IActionResult Login(AccountModel model)
        {
            try
            {
                return RedirectToAction("Dashboard", "Admin");
            }
            catch (Exception ex)
            {

                throw new Exception("Server Error" + ex.Message);
            }
        }
    }
}
