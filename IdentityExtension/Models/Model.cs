using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityExtension.Models
{
    public class Model
    {
        [Key]
        public int modelId { get; set; } 

        [Display(Name = "Model")]
        public string description { get; set; }
    }
}
