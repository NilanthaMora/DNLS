using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityExtension.Models
{
    public class MakeModel
    {
        [Key]
        public int id { get; set; }

        public int makeId { get; set; }
        public Make Make { get; set; } 

        public int modelId { get; set; }
        public Model Model { get; set; }

        [Display(Name = "System")]
        public string system { get; set; }

        [Display(Name = "Equipment Table Id")]
        [ForeignKey("EquipmentTable")]
        public int eqTId { get; set; }
        public EquipmentTable EquipmentTable { get; set; }
    }
}
