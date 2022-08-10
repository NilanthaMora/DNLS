using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityExtension.Models.Bill
{
    public class ElectricityBillDetailBulk
    {
        [Key]
        public int eleAccId { get; set; }

        [Display(Name = "Bill Type")]
        //[ForeignKey("Equipment")]
        public int billType { get; set; }

        [Display(Name = "Year")]
        public int year { get; set; }

        [Display(Name = "Month")]
        public string month { get; set; }

        [Display(Name = "Peak Last Month")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal peakLastMonth { get; set; }

        [Display(Name = "Peak Current Month")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal peakCurrentMonth { get; set; }

        [Display(Name = "Peak Unit")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal peakUnit { get; set; }

        [Display(Name = "Peak Charge Per Unit")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal peakChargePerUnit { get; set; }

        [Display(Name = "Day Last Month")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal dayLastMonth { get; set; }

        [Display(Name = "Day Current Month")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal dayCurrentMonth { get; set; }

        [Display(Name = "Day Unit")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal dayUnit { get; set; }

        [Display(Name = "Day Charge Per Unit")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal dayChargePerUnit { get; set; }

        [Display(Name = "Off Last Month")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal offLastMonth { get; set; }

        [Display(Name = "Off Current Month")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal offCurrentMonth { get; set; }

        [Display(Name = "Off Unit")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal offUnit { get; set; }

        [Display(Name = "Off Charge Per Unit")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal offChargePerUnit { get; set; }

        [Display(Name = "KVA Unit")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal kvaUnit { get; set; }

        [Display(Name = "KVA Charge Per Unit")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal kvaChargePerUnit { get; set; }

        [Display(Name = "Department Charge")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal departmentCharge { get; set; }

        [Display(Name = "Fixed Charges")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal fixedCharges { get; set; }

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

        [Display(Name = "ADF Refer")]
        public string adfRefer { get; set; }

        [Display(Name = "ADF Date")]
        public DateTime adfDate { get; set; }

    }
}
