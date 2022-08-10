using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityExtension.Models
{
    public class SpareProcuView
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "Equipment Type")]
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

        [Display(Name = "Part Number")]
        public string partNo { get; set; }

        [Display(Name = "Sub Referance")]
        public string sbRef { get; set; }

        [Display(Name = "Current Stock")]
        public string currentStock { get; set; }

        [Display(Name = "First Rate")]
        public string firstRate { get; set; }

        [Display(Name = "Second Rate")]
        public string secondRate { get; set; }

        [Display(Name = "Third Rate")]
        public string thirdRate { get; set; }

        [Display(Name = "Forth Rate")]
        public string forthRate { get; set; }

        [Display(Name = "Procurement Id")]
        public int procuId { get; set; }
    }
}
