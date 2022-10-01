using InvestmentPoint.Admin.Domain.Common;
using InvestmentPoint.Admin.Services.Contract;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentPoint.Admin.Controllers
{
    public class InvestmentTypeController : Controller
    {
        private readonly IInvestTypeServicecs _investType;
        public InvestmentTypeController(IInvestTypeServicecs investType)
        {
            _investType = investType;
        }
        public async Task<IActionResult> ListInvestType()
        {
			try
			{
                return View(await _investType.ListImvestType());
            }
			catch (Exception ex) 
			{
				throw new Exception("Server Error" + ex.Message);
			}
        }
        public async Task<IActionResult> AddInvestType()
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
        public async Task<IActionResult> AddInvestType(InvestTypeModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool check = await _investType.AddImvestType(model);
                    if (check)
                    {
                        TempData["msg"] = "Data Add Successfully";
                        return RedirectToAction("ListInvestType");
                    }
                    else
                    {
                        TempData["msg"] = "Data Not Add Successfully";
                    }
                }
                return View();
            }
            catch (Exception ex)
            {

                throw new Exception("Server Error" + ex.Message);
            }
        }
        public async Task<IActionResult> EditInvestType(int id)
        {
            try
            {
                return View(await _investType.ImvestTypeById(id));
            }
            catch (Exception ex)
            {

                throw new Exception("Server Error" + ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> EditInvestType(int id,InvestTypeModel model)
        {
            try
            {
                if(id > 0)
                {
                    bool check = await _investType.EditImvestType(id, model);
                    if (check)
                    {
                        return RedirectToAction("ListInvestType");
                    }
                }
                return View();
            }
            catch (Exception ex)
            {

                throw new Exception("Server Error" + ex.Message);
            }
        }
        public async Task<IActionResult> DeleteInvestType(int id)
        {
            try
            {
                if(id > 0)
                {
                    bool check = await _investType.DeleteInvestType(id);
                    if (check)
                    {
                        return RedirectToAction("ListInvestType");
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
