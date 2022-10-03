using InvestmentPoint.Admin.Domain.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentPoint.Admin.Services.Contract
{
    public interface ICustomerService
    {
       public  Task<List<CustomerModel>> ListCustomer();
        public Task<bool> AddCustomer(CustomerModel model);
    }
}
