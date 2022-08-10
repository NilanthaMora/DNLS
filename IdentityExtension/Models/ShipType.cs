using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityExtension.Models
{
    public class ShipType
    {
        [Key]
        public int id { get; set; }
        [Display(Name = "Ship Code")]
        public int code { get; set; }

        [Display(Name = "Description")]
        public string description { get; set; }

        public List<Base> Base { get; set; }
    }
}
