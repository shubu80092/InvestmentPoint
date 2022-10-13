using InvestmentPoint.Admin.Domain.Common;
using InvestmentPoint.Admin.Domain.Entites;
using InvestmentPoint.Admin.Persistence;
using InvestmentPoint.Admin.Services.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentPoint.Admin.Services.Implementation
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext _context;
        public CustomerService(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// this method is Add to the customer details.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> AddCustomer(CustomerModel model)
        {
            try
            {
                if (!string.IsNullOrEmpty(model.Email))
                {
                    Customer customer = new()
                    {
                        Name = model.Name,
                        Email = model.Email,
                        MobileNo = model.MobileNo,
                        AadharNo = model.AadharNo,
                        PanNo = model.PanNo,
                        Area = model.Area,
                        Address =model.Address,
                        TypeOfInvestment = model.TypeOfInvestment,
                        Amount = model.Amount,
                        CollectionAmount = model.CollectionAmount,
                        AccountNumber = model.AccountNumber,
                        Password = model.Password,
                    };
                    await _context.Customers.AddAsync(customer);
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Server Error" + ex.Message);
            }
        }

        /// <summary>
        /// this method is Display the All Customer Details.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<List<CustomerModel>> ListCustomer(int Id)
        {
            try
            {
                if(Id > 0)
                {
                    var data = await _context.Employees.FirstOrDefaultAsync(x => x.Id == Id);
                    int id = data.AreaId;

                    var list = await (from c in _context.Customers
                                      join a in _context.Areas on c.Area equals a.Id
                                      join ty in _context.TypeofInvestments on c.TypeOfInvestment equals ty.Id
                                      where id == c.Area
                            select new CustomerModel
                            {
                                Id = c.Id,
                                Name = c.Name,
                                MobileNo = c.MobileNo,
                                AadharNo = c.AadharNo,
                                Email = c.Email,
                                PanNo = c.PanNo,
                                AreaName = a.AreaName,
                                Address = c.Address,
                                InvestmentName = ty.InvestmentName,
                                Amount = c.Amount,
                                CollectionAmount = c.CollectionAmount,
                                AccountNumber = c.AccountNumber,
                                Password = c.Password
                            }).ToListAsync();
                    return list;
                }
                else
                {
                    var list = await (from c in _context.Customers
                                      join a in _context.Areas on c.Area equals a.Id
                                      join ty in _context.TypeofInvestments on c.TypeOfInvestment equals ty.Id
                            select new CustomerModel
                            {
                                Id = c.Id,
                                Name = c.Name,
                                MobileNo = c.MobileNo,
                                AadharNo = c.AadharNo,
                                Email = c.Email,
                                PanNo = c.PanNo,
                                AreaName = a.AreaName,
                                Address = c.Address,
                                InvestmentName = ty.InvestmentName,
                                Amount = c.Amount,
                                CollectionAmount = c.CollectionAmount,
                                AccountNumber = c.AccountNumber,
                                Password = c.Password
                            }).ToListAsync();
                    return list;
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Server Error" + ex.Message);
            }
        }
    }
}
