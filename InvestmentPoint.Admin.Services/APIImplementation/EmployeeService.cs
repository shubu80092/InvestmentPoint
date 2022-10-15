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
				//var data1 = await _context.Customers.Where(x => x.TypeOfInvestment == 1).ToListAsync();
				var data2 = await _context.Customers.Where(x => x.TypeOfInvestment == 2).ToListAsync();
				var data3 = await _context.Customers.Where(x => x.TypeOfInvestment == 3).ToListAsync();
				if (data2 != null)
				{
					foreach(var item in data2)
					{
                        Customer customer = new()
                        {
                            EMIDate = item.CreateDate.AddDays(7)
                        };
						await _context.SaveChangesAsync();
                    }		
                }
				if(data3 != null)
				{
					foreach( var item in data3)
					{
                        Customer customer = new()
                        {
                            EMIDate = item.CreateDate.AddDays(30)
                        };
                        await _context.SaveChangesAsync();
                    }
                }
				var list = await (from customer in _context.Customers
							join s in _context.Status on customer.status equals s.Id
							join employee in _context.Employees on customer.Area equals employee.AreaId
							where customer.EMIDate == DateTime.Now.Date && customer.Area == employee.AreaId
                            select new CustomerDTO
							{
								Id = customer.Id,
								Name = customer.Name,
								MobileNo = customer.MobileNo,
								Email = customer.Email,
								Address = customer.Address,
								status = s.StatusName,
								CollectionAmount = customer.CollectionAmount
							}).ToListAsync();
				return list;
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
