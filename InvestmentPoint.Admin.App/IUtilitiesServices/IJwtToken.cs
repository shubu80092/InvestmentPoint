using InvestmentPoint.Admin.App.DTO;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;

namespace InvestmentPoint.Admin.App.IUtilitiesServices
{
    public interface IJwtToken
    {
        string token(LoginDTO model);
    }
}
