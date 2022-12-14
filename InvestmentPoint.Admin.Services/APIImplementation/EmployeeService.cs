using InvestmentPoint.Admin.Domain.DTOModel;
using InvestmentPoint.Admin.Domain.Entites;
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
    public class EmployeeService : IEmployeeService
    {
			private readonly ApplicationDbContext _context;
		public EmployeeService(ApplicationDbContext context)
		{
			this._context = context;
		}

		public async Task<List<CustomerDTO>> CurrentDateCustomer()
		{
			try
			{
				var status = await _context.CustomersEMIs.Where(x => x.TypeOfInvest == 1).FirstOrDefaultAsync(x =>x.DateOfEMI.Month == DateTime.Now.Month);
				if(status != null)
				{
					CustomersEMI custm = new();
					{
						status.EMIDate = DateTime.Now.Date;
					}
					_context.SaveChanges();
				}
				var result = await (from cus in _context.Customers
									join cusemi in _context.CustomersEMIs on cus.Id equals cusemi.CustomerID
									join sta in _context.Status on cusemi.status equals sta.Id
									where cusemi.DateOfEMI == DateTime.Now.Date || cusemi.EMIDate == DateTime.Now.Date
                                    select new CustomerDTO
									{
										Id = cus.Id,
										Name = cus.Name,
										MobileNo = cus.MobileNo,
										Email = cus.Email,
										Address = cus.Address,
										CollectionAmount = cus.CollectionAmount,
										BalanceAmc = cus.BalanceAmc,
										Advance = cus.Advance,
										status = sta.StatusName
                                    }).ToListAsync();
				return result;
			}
			catch (Exception ex)
			{

				throw new Exception("Server Error" + ex.Message);
			}
		}

		public Task CustomerEMISave(CustomerDTO model)
		{
			throw new NotImplementedException();
		}

		//public async Task<bool> CustomerEMISave(CustomerDTO model)
		//{
		//	try
		//	{
		//		return 
		//	}
		//	catch (Exception ex)
		//	{

		//		throw new Exception("Server Error" + ex.Message);
		//	}
		//}

		//public async Task<List<CustomerDTO>> CurrentDateCustomer()
		//{
		//	try
		//	{
		//		var data1 = await _context.Customers.Where(x => x.TypeOfInvestment == 1).ToListAsync();
		//		var data2 = await _context.Customers.Where(x => x.TypeOfInvestment == 2).ToListAsync();
		//		var data3 = await _context.Customers.Where(x => x.TypeOfInvestment == 3).ToListAsync();
		//		if (data2 != null)
		//		{
		//			foreach (var item in data2)
		//			{
		//				Customer customer = new()
		//				{
		//					EMIDate = item.CreateDate.AddDays(7)
		//				};
		//				await _context.SaveChangesAsync();
		//			}
		//		}
		//		if (data3 != null)
		//		{
		//			foreach (var item in data3)
		//			{
		//				Customer customer = new()
		//				{
		//					EMIDate = item.CreateDate.AddDays(30)
		//				};
		//				await _context.SaveChangesAsync();
		//			}
		//		}
		//		var list = await (from customer in _context.Customers
		//						  join s in _context.Status on customer.status equals s.Id
		//						  join employee in _context.Employees on customer.Area equals employee.AreaId
		//						  where customer.EMIDate == DateTime.Now.Date && customer.Area == employee.AreaId
		//						  select new CustomerDTO
		//						  {
		//							  Id = customer.Id,
		//							  Name = customer.Name,
		//							  MobileNo = customer.MobileNo,
		//							  Email = customer.Email,
		//							  Address = customer.Address,
		//							  status = s.StatusName,
		//							  CollectionAmount = customer.CollectionAmount
		//						  }).ToListAsync();
		//		return list;
		//	}
		//	catch (Exception ex)
		//	{

		//		throw new Exception("Server Error" + ex.Message);
		//	}
		//}

		public async Task<List<EmployeeDTO1>> EmployeeProfile(int id)
		{
			try
			{
				var result = await (from emp in _context.Employees
									where emp.Id == id
									select new EmployeeDTO1
									{
										Id = emp.Id,
										Name = emp.Name,
										Email = emp.Email,
										MobileNo = emp.MobileNo,
										AadharNo = emp.AadharNo
									}).ToListAsync();
				return result;
			}
			catch (Exception ex)
			{

				throw new Exception("Server Error" + ex.Message);
			}
		}

		public async Task<List<CustomerDTO>> ListCustomer()
		{
			try
			{
				var list = await (from customer in _context.Customers
								  join s in _context.Status on customer.status equals s.Id
								  join employee in _context.Employees on customer.Area equals employee.AreaId
								  where employee.AreaId == customer.Area
								  select new CustomerDTO
								  {
									  Id = customer.Id,
									  Name = customer.Name,
									  Email = customer.Email,
									  MobileNo = customer.MobileNo,
									  Address = customer.Address,
									  CollectionAmount = customer.CollectionAmount,
									  status = s.StatusName
								  }).ToListAsync();
				return list;
			}
			catch (Exception ex)
			{

				throw new Exception("Server Error" + ex.Message);
			}
		}
	}
}
