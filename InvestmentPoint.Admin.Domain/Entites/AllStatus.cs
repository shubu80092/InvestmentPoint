using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentPoint.Admin.Domain.Entites
{
    public class AllStatus
    {
        [Key]
        public int Id { get; set; }
        public string StatusName { get; set; }
    }
}
