using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentPoint.Admin.Domain.DTOModel
{
    public class PlanDTO
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public string TypeOfInvest { get; set; }
        public string AccountNo { get; set; }
    }
}
