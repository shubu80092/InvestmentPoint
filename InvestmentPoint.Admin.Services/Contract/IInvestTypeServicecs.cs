using InvestmentPoint.Admin.Domain.Common;
using InvestmentPoint.Admin.Domain.Entites;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentPoint.Admin.Services.Contract
{
    public interface IInvestTypeServicecs
    {
        public Task<IEnumerable> ListImvestType();
        public Task<TypeOfInvestment> ImvestTypeById(int id);
        public Task<bool> AddImvestType(InvestTypeModel model);
        public Task<bool> EditImvestType(int id, InvestTypeModel model);
        public Task<bool> DeleteInvestType(int id);
    }
}
