using InvestmentPoint.Admin.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentPoint.Admin.Services.Contract
{
    public interface IAccountService
    {
        Task<Status> LoginAsync(AccountModel model);
        Task<Status> RegistrationAsync(RegistrationModel model);
        Task LogoutAsync();
    }
}
