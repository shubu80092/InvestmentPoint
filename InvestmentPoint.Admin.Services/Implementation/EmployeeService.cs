using InvestmentPoint.Admin.Domain.Common;
using InvestmentPoint.Admin.Domain.Entites;
using InvestmentPoint.Admin.Persistence;
using InvestmentPoint.Admin.Services.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// This is implementation of IEmployeeService
/// </summary>
namespace InvestmentPoint.Admin.Services.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _context;
        public EmployeeService(ApplicationDbContext context)
        {
            _context = context;
        }

        #region Employee
        /// <summary>
        /// This service method is implemented to add employee.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> AddEmployee(EmployeeModel model)
        {
            try
            {
               if(!string.IsNullOrEmpty(model.Email))
                {
                    Employee employee = new()
                    {
                        Name = model.Name,
                        MobileNo = model.MobileNo,
                        Email = model.Email,
                        AadharNo = model.AadharNo,
                        AreaId = model.AreaId,
                        Password = model.Password,
                        CreateDate = DateTime.Now.Date
                    };
                    await _context.Employees.AddAsync(employee);
                    await _context.SaveChangesAsync();
                    return true;

                }
                return false;
            }
            catch (Exception ex)
            {

                throw new Exception("Server Error" + ex.Message);
            }
        }

        /// <summary>
        /// This service method is delete the employee.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> DeleteEmployee(int id)
        {
            try
            {
                var result = await _context.Employees.FirstOrDefaultAsync(x =>x.Id == id);
                if(!string.IsNullOrEmpty(result.Email))
                {
                    _context.Employees.Remove(result);
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
        /// This service method is Update the employee details.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> EditEmployee(int id, EmployeeModel model)
        {
            try
            {
                if (!string.IsNullOrEmpty(model.Email))
                {
                    var employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);
                    if (!string.IsNullOrEmpty(employee.Email))
                    {
                        employee.Name = model.Name;
                        employee.Email = model.Email;
                        employee.MobileNo = model.MobileNo;
                        employee.AadharNo = model.AadharNo;
                        employee.AreaId = model.AreaId;
                        employee.Password = model.Password;
                       
                    }
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {

                throw new Exception("Server Error" + ex.Message);
            }
        }


        /// <summary>
        /// This service method is display the employee details.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<List<EmployeeModel>> ListEmployee()
        {
            try
            {
                //var list = await _context.Employees.ToListAsync();
                var list = await (from e in _context.Employees
                                  join a in _context.Areas on e.AreaId equals a.Id
                                  select new EmployeeModel
                                  {
                                      Id = e.Id,
                                      Name = e.Name,
                                      Email = e.Email,
                                      MobileNo = e.MobileNo,
                                      AadharNo = e.AadharNo,
                                      AreaName = a.AreaName,
                                      Password = e.Password
                                  }).ToListAsync();
                return list;
            }
            catch (Exception ex)
            {

                throw new Exception("Server Error" + ex.Message);
            }
        }


        #endregion
    }
}
