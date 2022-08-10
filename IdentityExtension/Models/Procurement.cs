using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityExtension.Models
{
    public class Procurement
    {
        [Key]
        public int id { get; set; }
        
        [Display(Name ="Equipment Code")]
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

        [Display(Name = "Created Date")]
        public DateTime cDate { get; set; }

        [Display(Name = "User Id")]
        public string userId { get; set; }
       // public ApplicationUser Application { get; set; }
        public EquipmentProcurement EquipmentProcurement { get; set; }
        public SpareProcurement SpareProcurement { get; set; }
        public EquipmentTable EquipmentTable { get; set; }

    }
}
 