using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityExtension.Models
{
    public class EquipProcuView
    {
        [Key]
        public int id { get; set; }

        [Display(Name ="Equipment Type")]
        public int equipCode { get; set; }

        [Display(Name = "Make")]
        public string make { get; set; }

        [Display(Name = "Model")]
        public string model { get; set; }

        [Display(Name = "RL Reference")]
        public string rlRef { get; set; }

        [Display(Name = "QTY Ordered")]
        public string qtyOrdered { get; set; }

        [Display(Name = "QTY Approved")]
        public string qtyApproved { get; set; }

        [Display(Name = "Price")]
        public string lastPurchasePrice { get; set; }

        [Display(Name = "Remarks")]
        public string remarks { get; set; }

        public string userId { get; set; }

        [Display(Name = "Created Date")]
        public DateTime cDate { get; set; }

        [Display(Name = "Item")]
        public string item { get; set; }

        [Display(Name = "File Reference")] 
        public string fileRef { get; set; }

        [Display(Name = "Proposed Distribution")]
        public string proDistribution { get; set; }
    }
}
