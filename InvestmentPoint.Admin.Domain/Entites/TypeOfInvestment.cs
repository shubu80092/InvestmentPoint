using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentPoint.Admin.Domain.Entites
{
    public class TypeOfInvestment
    {
        [Key]
        public int Id { get; set; }
        public string InvestmentName { get; set; }
    }
}
