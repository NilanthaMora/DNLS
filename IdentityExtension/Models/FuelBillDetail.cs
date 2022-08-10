using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityExtension.Models
{
    public class FuelBillDetail
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

        [Display(Name = "Department Charge")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal departmentCharge { get; set; }

        [Display(Name = "Fixed Charge")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal fixedCharge { get; set; }

        [Display(Name = "Monthly Cost")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal monthlyCost { get; set; }

        [Display(Name = "Bill Confirm")]
        public Boolean billConfirm { get; set; }

        [Display(Name = "Created Date")]
        public DateTime createdDate { get; set; }

        [Display(Name = "User Id")]
        public string userId { get; set; }

        [Display(Name = "Edit Date")]
        public DateTime editDate { get; set; }

        [Display(Name = "Edit User Id")]
        public string editUserId { get; set; }

        [Display(Name = "Bill Confirm User Id")]
        public string billConUserId { get; set; }

        [Display(Name = "Bill Confirm Date")]
        public DateTime billConDate { get; set; }

        public FuelBillAccount FuelBillAccount { get; set; }
    }
}
