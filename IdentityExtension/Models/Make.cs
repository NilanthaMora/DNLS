using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityExtension.Models
{
    public class Make
    {
        [Key]
        public int makeId { get; set; } 

        [Display(Name ="Make")]
        public string description { get; set; }
    }
}
