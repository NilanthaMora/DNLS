using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityExtension.Models.Bill
{
    public class ElectricityBillDetail
    {
        [Key]
        public int eleAccId { get; set; }
        
        [Display(Name = "Bill Type")]
        [ForeignKey("ElectricityBillType")] 
        public int billType { get; set; }

        [Display(Name = "Year")]
        public int year { get; set; }

        [Display(Name = "Month")]
        public string month { get; set; }

        [Display(Name = "Last Month")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal lastMonth { get; set; }

        [Display(Name = "Current Month")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal currentMonth { get; set; }

        [Display(Name = "Unit")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal unit { get; set; }

        [Display(Name = "Charge Per Unit")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal chargePerUnit { get; set; }

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

        public ElectricityBillType ElectricityBillType { get; set; }  
    } 
}
