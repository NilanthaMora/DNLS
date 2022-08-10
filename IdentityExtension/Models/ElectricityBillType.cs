﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityExtension.Models.Bill
{
    public class ElectricityBillType
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Display(Name = "Bill Type")]
        //[ForeignKey("Equipment")]
        public int billType { get; set; }

        [Display(Name = "Description")]
        public string description { get; set; }

        public IList<ElectricityAccountBill> electricityAccountBills { get; set; }

        public IList<ElectricityBillDetail> ElectricityBillDetails { get; set; }  
    }
}
