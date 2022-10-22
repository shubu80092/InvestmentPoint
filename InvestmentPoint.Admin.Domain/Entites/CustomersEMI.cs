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
        public int EMIAmc { get; set; }
        public int BalanceAmc { get; set; }
        public DateTime DateOfEMI { get; set; }
        public int CustomerID { get; set; }
    }
}
