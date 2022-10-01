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
    public interface IAreaService
    {
       public  Task<IEnumerable> ListArea();
        public Task<Area> ListAreaById(int id);
        public Task<bool> AddArea(AreaModel model);
        public Task<bool> EditArea(int id,AreaModel model);
        public Task<bool> DeleteArea(int id);
    }
}
