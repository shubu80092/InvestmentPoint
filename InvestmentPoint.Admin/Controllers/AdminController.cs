using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentPoint.Admin.Controllers
{
    //[Route("")]
    [Authorize]
    public class AdminController : Controller
    {
        //[Route("")]
        //[Route("Admin/Dashboard")]
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
