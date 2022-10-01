using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentPoint.Admin.Domain.Common
{
    public class CustomerModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int MobileNo { get; set; }
        public int AadharNo { get; set; }
        public string PanNo { get; set; }
        public int Area { get; set; }
        public string Address { get; set; }
        public int TypeOfInvestment { get; set; }
        public string MonthlyAmount { get; set; }
        public string CollectionAmount { get; set; }
        public string AccountNumber { get; set; }
        public string Password { get; set; }
    }
}
