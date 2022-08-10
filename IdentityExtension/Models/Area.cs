using IdentityExtension.Models.Bill;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityExtension.Models
{
    public class Area
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "Area Code")]
        public int code { get; set; }

        [Display(Name = "Area")]
        public string description { get; set; }

        public IList<Base> Bases { get; set; }

        public IList<FuelBillAccount> FuelBillAccounts { get; set; } 

    }
}
