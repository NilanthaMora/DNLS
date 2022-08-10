using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityExtension.Models
{
    public class FuelBillAccount
    {
        [Key]
        public int billAccId { get; set; }

        [Display(Name = "Bill Type")]
        [ForeignKey("FuelBillType")]
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

        [Display(Name = "Active")]
        public Boolean active { get; set; }

        [Display(Name = "Created Date")]
        public DateTime createdDate { get; set; }

        [Display(Name = "User Id")]
        public string userId { get; set; }

        public FuelBillType FuelBillType { get; set; }

        public Area Area { get; set; }

        public IList<FuelBillDetail> FuelBillDetails { get; set; }

    }
}
