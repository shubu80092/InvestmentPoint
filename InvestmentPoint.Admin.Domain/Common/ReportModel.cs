using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentPoint.Admin.Domain.Common
{
    public class ReportModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MobileNo { get; set; }
        public string Address { get; set; }
        public int CodeNo { get; set; }
        public string CardNo { get; set; }
        public string AccountNo { get; set; }
        public DateTime OpenDate { get; set; }
        public double Ammount { get; set; }
        public double Balance { get; set; }
    }
}
