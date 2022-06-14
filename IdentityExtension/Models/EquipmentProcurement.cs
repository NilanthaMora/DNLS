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

        public string item { get; set; }

        public string fileRef { get; set; }

        public string proDistribution { get; set; }

        public int procuId { get; set; }
        public Procurement Procurement { get; set; } 
    }
}
