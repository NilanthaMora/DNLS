using IdentityExtension.Models.Bill;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityExtension.Models
{
    public class Base
    {
        [Key] 
        public int id { get; set; }

        [Display(Name = "Base Code")]
        public int code { get; set; }

        [Display(Name = "Base")]
        public string description { get; set; }

        public string remCd { get; set; }

        [Display(Name = "Pay Base")]
        public string payBase { get; set; }

        [ForeignKey("Area")]
        public int areaId { get; set; }

        public int baseType { get; set; }        

        [ForeignKey("ShipType")]
        public int shipTypeId { get; set; }  

        public Area Area { get; set; }
        public ShipType ShipType { get; set; }
        public IList<SubUnit> SubUnits { get; set; }
        //public IList<ElectricityAccountBill> electricityAccountBills { get; set; }
    }
}
