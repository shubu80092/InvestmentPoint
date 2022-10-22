using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentPoint.Admin.Domain.Common
{
    public class CustomerEMIModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TypeOfInvest { get; set; }
        public int EMIAmc { get; set; }
        public int BalanceAmc { get; set; }
        public DateTime DateOfEMI { get; set; }
        public int CustomerID { get; set; }
    }
}
