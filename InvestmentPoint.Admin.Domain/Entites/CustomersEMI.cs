using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentPoint.Admin.Domain.Entites
{
    public class CustomersEMI
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int TypeOfInvest { get; set; }
        public double Ammount { get; set; }
        public double EMIAmc { get; set; }
        public double CurrentOutstanding { get; set; }
        public DateTime DateOfEMI { get; set; } 
        public DateTime DipositeDate { get; set; } 
        public int status { get; set; }
        public int CustomerID { get; set; }
        public DateTime EMIDate { get; set; }
        public int MonthlyNoOfEMIs { get; set; }
    }
}
