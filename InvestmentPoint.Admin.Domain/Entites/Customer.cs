using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentPoint.Admin.Domain.Entites
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string AadharNo { get; set; }
        public string PanNo { get; set; }
        public int Area { get; set; }
        public string Address { get; set; }
        public int TypeOfInvestment { get; set; }
        public double Amount { get; set; }
        public double CollectionAmount { get; set; }
        public string AccountNumber { get; set; }
        public string Password { get; set; }
        public int status { get; set; }
        public DateTime CreateDate { get; set; }
        public int CodeNo { get; set; }
        public string CardNo { get; set; }
        public double BalanceAmc { get; set; }
        public double Advance { get; set; }
        public double TotalDepositeAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
