using InvestmentPoint.Admin.Domain.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentPoint.Admin.Services.Contract
{
    public interface IEmployeeService
    {
        public Task<bool> AddEmployee(EmployeeModel model);

        public Task<bool> EditEmployee(int id,EmployeeModel model);
        public Task<IEnumerable> ListEmployee();
        public Task<bool> DeleteEmployee(int id);
    }
}
