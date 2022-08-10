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
        [Display(Name ="Equipment Code")]
        public int equipmentCode { get; set; }

        [Required]
        [Display(Name = "Equipment")]
        public string equipment { get; set; }

        [Required]
        [Display(Name = "Equipment Variable Name")]
        public string varName { get; set; }

        [Display(Name = "Equipment Sell Code")]
        public string equipmentSellCode { get; set; }

        [Display(Name = "Image Url")]
        public string imageUrl { get; set; }

        [Display(Name = "Equipment General Inquery")]
        public string equipmentGeneralInq { get; set; }

        public List<Equipment> Equipment { get; set; }
        public List<Procurement> Procurements { get; set; }
        public List<MakeModel> MakeModels { get; set; } 
    }
}


