using IdentityExtension.Models.Bill;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityExtension.Models
{
    public class SubUnit
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "Sub Unit Code")]
        public int subUnitCode { get; set; }

        [Display(Name = "Sub Unit")]
        public string description { get; set; }

        [ForeignKey("Base")]
        public int baseId { get; set; }

        public int type { get; set; }

        public Base Base { get; set; }

        //public ElectricityAccountBill electricityAccountBills { get; set; }
    }
}
