using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityExtension.Models
{
    public class EquipmentProcurement
    {

        [Key]
        public int id { get; set; }

        [Display(Name = "Item")]
        public string item { get; set; }

        [Display(Name = "File Reference")]
        public string fileRef { get; set; }

        [Display(Name = "Product Distribution")]
        public string proDistribution { get; set; }

        [Display(Name = "Procurement Id")]
        public int procuId { get; set; }
        public Procurement Procurement { get; set; } 
    }
}
