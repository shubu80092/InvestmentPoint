using Microsoft.AspNetCore.Mvc;

namespace InvestmentPoint.Admin.Controllers
{
    //[Route("")]
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
