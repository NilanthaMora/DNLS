using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityExtension.Models
{
    public class EquipmentTable
    {
        [Key]
        public int id { get; set; }

        [Required]
        public int equipmentCode { get; set; }

        [Required]
        public string equipment { get; set; }

        public string equipmentSellCode { get; set; }

        public string imageUrl { get; set; }

        public string equipmentGeneralInq { get; set; }
    }
}
