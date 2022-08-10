using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityExtension.Models.Bill
{
    public class ElectricityAccountBill
    {
        [Key]
        public int billAccId { get; set; }

        [Display(Name = "Bill Type")]
        [ForeignKey("ElectricityBillType")]
        public int billType { get; set; }

        [Display(Name = "Area")]
        [ForeignKey("Area")]
        public int areaId { get; set; } 

        [Display(Name = "Base")]
        public int baseId { get; set; }

        [Display(Name = "Sub Unit")]
        public int subUnitId { get; set; }

        [Display(Name = "Account Number")]
        public int accountNumber { get; set; }

        [Display(Name = "Capacity")]
        public string capacity { get; set; }

        [Display(Name = "Active")]
        public Boolean active { get; set; }

        [Display(Name = "Created Date")]
        public DateTime createdDate { get; set; }

        [Display(Name = "User Id")]
        public string userId { get; set; } 

        public Area Area { get; set; }

        public ElectricityBillType ElectricityBillType { get; set; }
    }
}
