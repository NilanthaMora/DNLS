using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityExtension.Models.Bill
{
    public class ElectricityBillDetailDomestic
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

        [Display(Name = "Total Units")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal totalUnits { get; set; }

        [Display(Name = "0-30 Unit")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal unit_0_30 { get; set; }

        [Display(Name = "0-30 Unit Price")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal unitPrice_0_30 { get; set; }

        [Display(Name = "0-30 Fix Charge")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal fixCharge_0_30 { get; set; }

        [Display(Name = "31-60 Unit")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal unit_31_60 { get; set; }

        [Display(Name = "31-60 Unit Price")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal unitPrice_31_60 { get; set; }

        [Display(Name = "31-60 Fix Charge")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal fixCharge_31_60 { get; set; }

        [Display(Name = "0-60 Unit")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal unit_0_60 { get; set; }

        [Display(Name = "0-60 Unit Price")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal unitPrice_0_60 { get; set; }

        [Display(Name = "0-60 Fix Charge")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal fixCharge_0_60 { get; set; }

        [Display(Name = "61-90 Unit")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal unit_61_90 { get; set; }

        [Display(Name = "61-90 Unit Price")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal unitPrice_61_90 { get; set; }

        [Display(Name = "61-90 Fix Charge")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal fixCharge_61_90 { get; set; }

        [Display(Name = "91-120 Unit")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal unit_91_120 { get; set; }

        [Display(Name = "91-120 Unit Price")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal unitPrice_91_120 { get; set; }

        [Display(Name = "91-120 Fix Charge")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal fixCharge_91_120 { get; set; }

        [Display(Name = "121-180 Unit")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal unit_121_180 { get; set; }

        [Display(Name = "121-180 Unit Price")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal unitPrice_121_180 { get; set; }

        [Display(Name = "121-180 Fix Charge")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal fixCharge_121_180 { get; set; }

        [Display(Name = "180 Unit")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal unit_180 { get; set; }

        [Display(Name = "180 Unit Price")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal unitPrice_180 { get; set; }

        [Display(Name = "180 Fix Charge")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal fixCharge_180 { get; set; }
        
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
