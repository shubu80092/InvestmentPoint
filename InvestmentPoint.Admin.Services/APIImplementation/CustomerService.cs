using InvestmentPoint.Admin.Domain.DTOModel;
using InvestmentPoint.Admin.Persistence;
using InvestmentPoint.Admin.Services.APIContract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentPoint.Admin.Services.APIImplementation
{
    public class CustomerService : ICustomerService
    {
		private readonly ApplicationDbContext _context;
		public CustomerService(ApplicationDbContext context)
		{
			this._context = context;
		}
        public async Task<List<PlanDTO>> PlanDetails(int id)
        {
			try
			{
				var result = await (from cus in _context.Customers
									join invst in _context.TypeofInvestments on cus.TypeOfInvestment equals invst.Id
									where cus.Id == id
									select new PlanDTO
									{
										Id = cus.Id,
										Amount = cus.Amount,
										TypeOfInvest = invst.InvestmentName,
										AccountNo = cus.AccountNumber
									}).ToListAsync();
				return result;
			}
			catch (Exception ex)
			{

				throw new Exception("Server Error" + ex.Message);
			}
        }

		public async Task<List<CustomerDTO1>> CustomerDetails(int id)
		{
			try
			{
				var result = await (from cus in _context.Customers
									join ar in _context.Areas on cus.Area equals ar.Id
									join typeofinvest in _context.TypeofInvestments on cus.TypeOfInvestment equals typeofinvest.Id
									where cus.Id == id
									select new CustomerDTO1
									{
										Id = cus.Id,
										Name = cus.Name,
										Email = cus.Email,
										MobileNo = cus.MobileNo,
										AadharNo = cus.AadharNo,
										PanNo = cus.PanNo,
										AreaName = ar.AreaName,
										Address = cus.Address,
										Amount = cus.Amount,
										TypeOfInvestmentName = typeofinvest.InvestmentName,
										CollectionAmount = cus.CollectionAmount,
										AccountNumber = cus.AccountNumber,
									}).ToListAsync();
				return result;
			}
			catch (Exception ex)
			{

				throw new Exception("Server Error" + ex.Message);
			}
		}
	}
}
