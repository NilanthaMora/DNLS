using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityExtension.Models
{
    public class CanonType
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "Canon Type")]
        public string description { get; set; }

        public List<Weapon> Weapon { get; set; }
    }
}
