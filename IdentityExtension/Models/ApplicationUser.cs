using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityExtension.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() : base() { }

        public string   Name    { get; set; }
        public string   UserRole      { get; set; }        
        public string   MobileContact { get; set; }

        public List<Procurement> Procurements { get; set; } 
    }
}
