using InvestmentPoint.Admin.Domain.Common;
using InvestmentPoint.Admin.Domain.Entites;
using InvestmentPoint.Admin.Persistence;
using InvestmentPoint.Admin.Services.Contract;
using Microsoft.AspNetCore.Http.Features;
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
                    Customer customer = new();
                    {
                        customer.Name = model.Name;
                        customer.Email = model.Email;
                        customer.MobileNo = model.MobileNo;
                        customer.AadharNo = model.AadharNo;
                        customer.PanNo = model.PanNo;
                        customer.Area = model.Area;
                        customer.Address = model.Address;
                        customer.TypeOfInvestment = model.TypeOfInvestment;
                        customer.Amount = model.Amount;
                        customer.CollectionAmount = model.CollectionAmount;
                        customer.AccountNumber = model.AccountNumber;
                        customer.Password = model.Password;
                        customer.status = 1;
                        customer.CreateDate = model.OpenDate;
                        customer.CardNo = model.CardNo;
                        customer.CodeNo = model.CodeNo;
                        if (model.TypeOfInvestment == 1)
                        {
                            customer.StartDate = customer.CreateDate.Date.AddDays(1);
                            customer.EndDate = customer.StartDate.Date.AddYears(1);
                        }
                        if (model.TypeOfInvestment == 2)
                        {
                            customer.StartDate = customer.CreateDate.Date.AddDays(7);
                            customer.EndDate = customer.StartDate.Date.AddYears(1);
                        }
                        if (model.TypeOfInvestment == 3)
                        {
                            customer.StartDate = customer.CreateDate.Date.AddMonths(1);
                            customer.EndDate = customer.StartDate.Date.AddYears(1);
                        }
                        if (model.TypeOfInvestment == 4)
                        {
                            customer.StartDate = customer.CreateDate.Date;
                            customer.EndDate = customer.StartDate.Date.AddYears(1);
                        }
                        if (model.TypeOfInvestment == 5)
                        {
                            customer.StartDate = customer.CreateDate.Date;
                            customer.EndDate = customer.StartDate.Date.AddMonths(6);
                        }
                    };
                    await _context.Customers.AddAsync(customer);
                    await _context.SaveChangesAsync();
                    if (customer.TypeOfInvestment == 1)
                    {
                        for (var i = customer.CreateDate.Date.AddDays(1); i <= customer.CreateDate.Date.AddMonths(12); i = i.AddMonths(1))
                        {
                            CustomersEMI customeremi = new()
                            {
                                Name = customer.Name,
                                TypeOfInvest = customer.TypeOfInvestment,
                                EMIAmc = customer.CollectionAmount,
                                DateOfEMI = i,
                                CustomerID = customer.Id,
                                status = customer.status,
                                Ammount = customer.Amount,
                                MonthlyNoOfEMIs = 30
                            };
                            await _context.CustomersEMIs.AddAsync(customeremi);
                            await _context.SaveChangesAsync();
                        }
                    }
                    if (model.TypeOfInvestment == 2)
                    {
                        for (var i = customer.CreateDate.Date.AddDays(7); i<= customer.CreateDate.Date.AddMonths(12); i = i.AddMonths(1))
                        {
                            CustomersEMI custemi = new();
                            {
                                custemi.Name = customer.Name;
                                custemi.TypeOfInvest = customer.TypeOfInvestment;
                                custemi.EMIAmc = customer.CollectionAmount;
                                custemi.DateOfEMI = i;
                                custemi.CustomerID = customer.Id;
                                custemi.status = customer.status;
                                custemi.Ammount = customer.Amount;
                                custemi.MonthlyNoOfEMIs = 4;
                            }
                            await _context.CustomersEMIs.AddAsync(custemi);
                            await _context.SaveChangesAsync();
                        }
                    }
                    if (model.TypeOfInvestment == 3)
                    {
                        for (var i = customer.CreateDate.Date.AddMonths(1); i <= customer.CreateDate.Date.AddMonths(12); i = i.AddMonths(1))
                        {
                            CustomersEMI customeremi = new()
                            {
                                Name = customer.Name,
                                TypeOfInvest = customer.TypeOfInvestment,
                                EMIAmc = customer.CollectionAmount,
                                DateOfEMI = i,
                                CustomerID = customer.Id,
                                status = customer.status,
                                Ammount = customer.Amount,
                                MonthlyNoOfEMIs = 1,
                            };
                            await _context.CustomersEMIs.AddAsync(customeremi);
                            await _context.SaveChangesAsync();
                        }
                    }
                    if (model.TypeOfInvestment == 4)
                    {
                        for (var i = customer.CreateDate.Date; i <= customer.CreateDate.Date.AddYears(1); i = i.AddYears(1))
                        {
                            CustomersEMI customeremi = new()
                            {
                                Name = customer.Name,
                                TypeOfInvest = customer.TypeOfInvestment,
                                EMIAmc = customer.CollectionAmount,
                                DateOfEMI = i,
                                CustomerID = customer.Id,
                                status = customer.status,
                                MonthlyNoOfEMIs = 1
                            };
                            await _context.CustomersEMIs.AddAsync(customeremi);
                            await _context.SaveChangesAsync();
                        }
                    }
                    if (model.TypeOfInvestment == 5)
                    {
                        for (var i = customer.CreateDate.Date; i <= customer.CreateDate.Date.AddMonths(12); i = i.AddMonths(6))
                        {
                            CustomersEMI customeremi = new()
                            {
                                Name = customer.Name,
                                TypeOfInvest = customer.TypeOfInvestment,
                                EMIAmc = customer.CollectionAmount,
                                DateOfEMI = i,
                                CustomerID = customer.Id,
                                status = customer.status,
                                MonthlyNoOfEMIs=2
                            };
                            await _context.CustomersEMIs.AddAsync(customeremi);
                            await _context.SaveChangesAsync();
                        }
                    }
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

        public async Task<List<ReportModel>> CustomerReport()
        {
            try
            {
                var result = await (from cus in _context.Customers
                                    select new ReportModel
                                    {
                                        Id = cus.Id,
                                        Name = cus.Name,
                                        MobileNo = cus.MobileNo,
                                        Address = cus.Address,
                                        CodeNo = cus.CodeNo,
                                        CardNo = cus.CardNo,
                                        AccountNo = cus.AccountNumber,
                                        OpenDate = cus.CreateDate,
                                        Ammount = cus.Amount,
                                        Balance = cus.BalanceAmc,
                                    }).ToListAsync();
                return result;
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
