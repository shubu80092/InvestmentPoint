using InvestmentPoint.Admin.Domain.DTOModel;
using InvestmentPoint.Admin.Services.APIContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentPoint.Admin.Services.APIImplementation
{
    public class EmployeeService : IEmployeeService
    {
        public Task<List<EmployeeDTO>> CustomerList()
        {
            throw new NotImplementedException();
        }
    }
}
