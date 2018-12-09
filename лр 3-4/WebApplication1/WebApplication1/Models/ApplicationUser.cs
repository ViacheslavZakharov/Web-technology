using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronomic { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", Name, Surname, Patronomic);
        }
    }
}
