using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;


namespace InvestmentPoint.Admin.Domain.Entites
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string ProfilePicture { get; set; }
    }
}
