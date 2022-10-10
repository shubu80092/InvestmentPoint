using InvestmentPoint.Admin.Domain.Common;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentPoint.Admin.App.IUtilitiesServices
{
    public interface IJwtToken
    {
       string token(AccountModel model);
    }
}
