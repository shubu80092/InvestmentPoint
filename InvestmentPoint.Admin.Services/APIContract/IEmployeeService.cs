using InvestmentPoint.Admin.Domain.DTOModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentPoint.Admin.Services.APIContract
{
    public interface IEmployeeService
    {
        Task<List<CustomerDTO>> CurrentDateCustomer();
        Task<List<CustomerDTO>> ListCustomer();
    }
}
