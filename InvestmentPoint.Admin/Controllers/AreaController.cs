using InvestmentPoint.Admin.Domain.Common;
using InvestmentPoint.Admin.Domain.Entites;
using InvestmentPoint.Admin.Services.Contract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace InvestmentPoint.Admin.Controllers
{
    public class AreaController : Controller
    {
        private readonly IAreaService _area;
        public AreaController(IAreaService area)
        {
            _area = area;
        }

        public async Task<IActionResult> ListArea()
        {
			try
			{
                return View(await _area.ListArea());
            }
			catch (Exception ex)
			{

				throw new Exception("Server Error" + ex.Message);
            }
        }
        public async Task<IActionResult> AddArea()
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
        public async Task<IActionResult> AddArea(AreaModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool check = await _area.AddArea(model);
                    if (check)
                    {
                        return RedirectToAction("ListArea");
                    }
                    else
                    {
                        TempData["msg"] = "Area Not Add Successfully";
                    }
                }
                return View();
            }
            catch (Exception ex)
            {

                throw new Exception("Server Error" + ex.Message);
            }
        }

        public async Task<IActionResult> EditArea(int id)
        {
            try
            {
                var data =  await _area.ListAreaById(id);
                if(data != null)
                {
                    return View(data);
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Server Error" + ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> EditArea(int id,AreaModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool check = await _area.EditArea(id,model);
                    if (check)
                    {
                        return RedirectToAction("ListArea");
                    }
                }
                return View();
            }
            catch (Exception ex)
            {

                throw new Exception("Server Error" + ex.Message);
            }
        }
        public async Task<IActionResult> DeleteArea(int id)
        {
            try
            {
                if(id > 0)
                {
                    bool check = await _area.DeleteArea(id);
                    if (check)
                    {
                        return RedirectToAction("ListArea");
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
