using InvestmentPoint.Admin.Domain.DTOModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentPoint.Admin.Services.APIContract
{
    public interface ICustomerService
    {
        Task<List<PlanDTO>> PlanDetails(int id);

        Task<List<CustomerDTO1>> CustomerDetails(int id);
    }
}
