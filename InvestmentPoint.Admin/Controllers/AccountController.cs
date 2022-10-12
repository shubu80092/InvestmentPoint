using InvestmentPoint.Admin.Domain.Common;
using InvestmentPoint.Admin.Services.Contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentPoint.Admin.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _account;
        public AccountController(IAccountService account)
        {
            this._account = account;
        }

        public IActionResult Registration()
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
        public async Task<IActionResult> Registration(RegistrationModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                model.Role = "Admin";
                var result = await _account.RegistrationAsync(model);
                TempData["msg"] = result.Message;
                return RedirectToAction(nameof(Registration));
            }
            catch (Exception ex)
            {

                throw new Exception("Server Error" + ex.Message);
            }
        }

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
        public async Task<IActionResult> Login(AccountModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var result = await _account.LoginAsync(model);
                if(result.StatusCode == 1)
                {
                    return RedirectToAction("Dashboard", "Admin");
                }
                else
                {
                    TempData["msg"] = result.Message;
                    return RedirectToAction(nameof(Login));
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Server Error" + ex.Message);
            }
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _account.LogoutAsync();
            return RedirectToAction(nameof(Login));
        }

        //public async Task<IActionResult> reg()
        //{
        //    var model = new RegistrationModel
        //    {
        //        Username = "admin",
        //        Name = "shubu",
        //        Email = "vishwakarma80092@gmail.com",
        //        Password = "Admin@12345#"
        //    };
        //    model.Role = "admin";
        //    var result = await _account.RegistrationAsync(model);
        //    return Ok(result);
        //}
    }
}
