using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentPoint.Admin.Domain.Entites
{
    public class transaction
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int InvestType { get; set; }
        public double DepositeAmc { get; set; }
        public double Advance { get; set; }
        public double BalanceAmc { get; set; }
        public DateTime DepositeDate { get; set; }
        public int CustomerId { get; set; }
    }
}
