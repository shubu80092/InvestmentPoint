﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentPoint.Admin.Domain.DTOModel
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string AadharNo { get; set; }
        public string PanNo { get; set; }
        public int Area { get; set; }
        public string Address { get; set; }
        public int TypeOfInvestment { get; set; }
        public string Amount { get; set; }
        public string CollectionAmount { get; set; }
        public string AccountNumber { get; set; }
        public string Password { get; set; }
        public string status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime EMIDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}