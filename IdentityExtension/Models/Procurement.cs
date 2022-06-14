using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityExtension.Models
{
    public class Procurement
    {
        [Key]
        public int id { get; set; }

        public string equipCode { get; set; }

        public string make { get; set; }

        public string model { get; set; }

        public string rlRef { get; set; }

        public string qtyOrdered { get; set; }

        public string qtyApproved { get; set; }

        public string lastPurchasePrice { get; set; }

        public string remarks { get; set; }

        public DateTime cDate { get; set; }

        public string userId { get; set; }
        public ApplicationUser Application { get; set; }
        public EquipmentProcurement EquipmentProcurement { get; set; }
        public SpareProcurement SpareProcurement { get; set; }

    }
}
