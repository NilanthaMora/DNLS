using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityExtension.Models
{
    public class FuelBillSubDetail
    {
        [Key]
        public int fuelAccId { get; set; }

        [Display(Name = "Bill Type")]
        [ForeignKey("FuelBillAccount")]
        public int billType { get; set; }

        [Display(Name = "Year")]
        public int year { get; set; }

        [Display(Name = "Month")]
        public string month { get; set; }

        [Display(Name = "Last Month")]
        public int lastMonth { get; set; }

        [Display(Name = "Charge Per Unit")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal chargePerUnit { get; set; }

        [Display(Name = "Total Charge")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal totalCharge { get; set; }

        [Display(Name = "SNO")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal sno { get; set; }

        [Display(Name = "From Date")]
        public DateTime fromDate { get; set; } 

        [Display(Name = "To Date")]
        public DateTime toDate { get; set; } 
        
        [Display(Name = "Created Date")]
        public DateTime createdDate { get; set; }

        [Display(Name = "User Id")]
        public string userId { get; set; }

        [Display(Name = "Edit Date")]
        public DateTime editDate { get; set; }

        [Display(Name = "Edit User Id")]
        public string editUserId { get; set; }

        public FuelBillAccount FuelBillAccount { get; set; } 
    }
}
